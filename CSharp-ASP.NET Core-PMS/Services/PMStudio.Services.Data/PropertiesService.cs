namespace PMStudio.Services.Data
{
    using PMStudio.Data.Common.Repositories;
    using PMStudio.Data.Models;
    using PMStudio.Web.ViewModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Linq;
    using PMStudio.Services.Mapping;

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
            };

            await this.propertiesRepository.AddAsync(property);
            await this.propertiesRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 10)
        {
            var properties = this.propertiesRepository.AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .To<T>()
                .ToList();
            return properties;
        }

        public int GetCount()
        {
            return this.propertiesRepository.All().Count();
        }
    }
}
