namespace PMStudio.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using PMStudio.Data.Common.Repositories;
    using PMStudio.Data.Models;
    using PMStudio.Services.Mapping;
    using PMStudio.Web.ViewModels.TenantsViewModels;

    public class TenantsService : ITenantsService
    {
        private readonly IDeletableEntityRepository<Tenant> tenantsRepository;
        private readonly IDeletableEntityRepository<Property> propertyRepository;

        public TenantsService(IDeletableEntityRepository<Tenant> tenantsRepository, IDeletableEntityRepository<Property> propertyRepository)
        {
            this.tenantsRepository = tenantsRepository;
            this.propertyRepository = propertyRepository;
        }

        public async Task CreateAsync(CreateTenantsViewModel input)
        {
            var property = this.propertyRepository.All().FirstOrDefault(x => x.Name == input.Property);
            var tenant = new Tenant()
            {
                Name = input.Name,
                Rate = input.Rate,
                LeasePeriod = input.LeasePeriod,
                PropertyId = property.Id,
            };

            await this.tenantsRepository.AddAsync(tenant);
            await this.tenantsRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var tenant = this.tenantsRepository.All().FirstOrDefault(x => x.Id == id);
            this.tenantsRepository.Delete(tenant);
            await this.tenantsRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 10)
        {
                var tenant = this.tenantsRepository.AllAsNoTracking()
                    .OrderByDescending(x => x.Id)
                    .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                    .To<T>()
                    .ToList();
                return tenant;
        }

        public T GetById<T>(int id)
        {

            var tenant = this.tenantsRepository.AllAsNoTracking().Where(x => x.Id == id).To<T>().FirstOrDefault();

            return tenant;
        }

        public int GetCount()
        {
            return this.tenantsRepository.All().Count();
        }
    }
}
