namespace PMStudio.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using PMStudio.Data.Common.Repositories;
    using PMStudio.Data.Models;
    using PMStudio.Services.Mapping;
    using PMStudio.Web.ViewModels;

    public class PropertiesService : IPropertiesService
    {
        private readonly IDeletableEntityRepository<Property> propertiesRepository;

        public PropertiesService(IDeletableEntityRepository<Property> propertiesRepository)
        {
            this.propertiesRepository = propertiesRepository;
        }

        public async Task CreateAsync(CreatePropertiesViewModel input)
        {
            var property = new Property()
            {
                Address = input.Address,
                Name = input.Name,
                Owner = input.Owner,
                Size = input.Size,
                ManagerId = input.ManagerId,
            };

            await this.propertiesRepository.AddAsync(property);
            await this.propertiesRepository.SaveChangesAsync();
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

        public int GetCount()
        {
            return this.propertiesRepository.All().Count();
        }
    }
}
