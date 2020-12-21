namespace PMStudio.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using PMStudio.Data.Common.Repositories;
    using PMStudio.Data.Models;
    using PMStudio.Services.Mapping;
    using PMStudio.Web.ViewModels.MaintenanceServicesViewModels;

    public class MaintenanceServicesService : IMaintenanceServicesService
    {
        private readonly IDeletableEntityRepository<MaintenanceService> maintenanceServicesRepository;
        private readonly IDeletableEntityRepository<Property> propertyRepository;
        private readonly IDeletableEntityRepository<Vendor> vendorsRepository;

        public MaintenanceServicesService(IDeletableEntityRepository<MaintenanceService> maintenanceServicesRepository, IDeletableEntityRepository<Property> propertyRepository, IDeletableEntityRepository<Vendor> vendorsRepository)
        {
            this.maintenanceServicesRepository = maintenanceServicesRepository;
            this.propertyRepository = propertyRepository;
            this.vendorsRepository = vendorsRepository;
        }

        public async Task CreateAsync(CreateMaintenanceServiceViewModel input)
        {

            var property = this.propertyRepository.All().FirstOrDefault(p => p.Name == input.Property);

            var vendor = this.vendorsRepository.All().FirstOrDefault(v => v.Name == input.Vendor);

            var maintenanceService = new MaintenanceService()
            {
                Name = input.Name,
                ServiceDate = input.ServiceDate,
                PropertyId = property.Id,
                VendorId = vendor.Id,
            };

            await this.maintenanceServicesRepository.AddAsync(maintenanceService);
            await this.maintenanceServicesRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var maintenanceService = this.maintenanceServicesRepository.All().FirstOrDefault(x => x.Id == id);
            this.maintenanceServicesRepository.Delete(maintenanceService);
            await this.maintenanceServicesRepository.SaveChangesAsync();
        }


        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 10)
        {
            var maintenanceService = this.maintenanceServicesRepository.AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .To<T>()
                .ToList();
            return maintenanceService;
        }

        public T GetById<T>(int id)
        {
            throw new NotImplementedException();
        }

        public int GetCount()
        {
            return this.maintenanceServicesRepository.All().Count();
        }
    }
}
