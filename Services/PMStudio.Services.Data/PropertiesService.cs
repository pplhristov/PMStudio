  namespace PMStudio.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using PMStudio.Data.Common.Repositories;
    using PMStudio.Data.Models;
    using PMStudio.Services.Mapping;
    using PMStudio.Web.ViewModels;

    public class PropertiesService : IPropertiesService
    {
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "gif" };
        private readonly IDeletableEntityRepository<Property> propertiesRepository;

        public PropertiesService(IDeletableEntityRepository<Property> propertiesRepository)
        {
            this.propertiesRepository = propertiesRepository;
        }

        public async Task CreateAsync(CreatePropertiesViewModel input, string imagePath)
        {
            var property = new Property()
            {
                Address = input.Address,
                Name = input.Name,
                Owner = input.Owner,
                Size = input.Size,
                ManagerId = input.ManagerId,
            };

            Directory.CreateDirectory(Path.Combine(imagePath, "images"));

            foreach (var image in input.Images)
            {
                var extension = Path.GetExtension(image.FileName).TrimStart('.');

                if (!this.allowedExtensions.Any(x => extension.EndsWith(x)))
                {
                    throw new Exception($"Invalid image extension {extension}");
                }

                var dbImage = new Image
                {
                    AddedByUserId = input.ManagerId,
                    Extension = extension,
                };

                property.Images.Add(dbImage);

                var physicalPath = $"{imagePath}\\images\\{dbImage.Id}.{extension}";

                using (var fileStream = new FileStream(physicalPath, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }
            }

            await this.propertiesRepository.AddAsync(property);
            await this.propertiesRepository.SaveChangesAsync();

            var result = property.Address;
        }

        public async Task DeleteAsync(int id)
        {
            var property = this.propertiesRepository.All().FirstOrDefault(x => x.Id == id);
            this.propertiesRepository.Delete(property);
            await this.propertiesRepository.SaveChangesAsync();
        }

        public async Task EditAsync(int id, EditPropertiesViewModel input)
        {
            var property = this.propertiesRepository.All().FirstOrDefault(x => x.Id == id);
            property.Name = input.Name;
            property.Address = input.Address;
            property.Owner = input.Owner;
            property.Type = input.Type;
            property.Size = input.Size;
            await this.propertiesRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>(int page, string userId, int itemsPerPage = 10)
        {
            var properties = this.propertiesRepository.AllAsNoTracking()
                .Where(p => p.ManagerId == userId)
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .To<T>()
                .ToList();
            return properties;
        }

        public T GetById<T>(int id)
        {
            var property = this.propertiesRepository.AllAsNoTracking().Where(x => x.Id == id).To<T>().FirstOrDefault();

            return property;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.propertiesRepository.AllAsNoTracking()
                .Where(p => p.Tenant == null && p.IsDeleted == false)
                .OrderBy(x => x.Name)
                .Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name))
                .ToList();
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairsForServices()
        {
            return this.propertiesRepository.AllAsNoTracking()
                .OrderBy(x => x.Name)
                .Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name))
                .ToList();
        }

        public int GetCount()
        {
            return this.propertiesRepository.All().Count();
        }

        public bool IsPropertyWithUniqueNameAndAddress(CreatePropertiesViewModel input)
        {
            var existingPropertiesWithSameData = this.propertiesRepository.AllAsNoTracking().Count(p => p.Address == input.Address || p.Name == input.Name);

            return existingPropertiesWithSameData == 0;
        }
    }
}
