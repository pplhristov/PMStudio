namespace PMStudio.Services.Data
{
    using PMStudio.Data.Common.Repositories;
    using PMStudio.Data.Models;
    using PMStudio.Web.ViewModels;
    using System.Threading.Tasks;

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
    }
}
