using Microsoft.EntityFrameworkCore;
using PMStudio.Data;
using PMStudio.Data.Models;
using PMStudio.Data.Repositories;
using PMStudio.Web.ViewModels.MaintenanceServicesViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PMStudio.Services.Data.Tests
{
    public class MaintenanceServicesService_Tests
    {
        [Fact]
        public async Task GetCountShouldReturnCorrectNumberUsingDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "MaintenanceServicesCountTestDb").Options;
            using var dbContext = new ApplicationDbContext(options);
            dbContext.MaintenanceServices.Add(new MaintenanceService());
            await dbContext.SaveChangesAsync();

            using var maintenanceServicesRepository = new EfDeletableEntityRepository<MaintenanceService>(dbContext);
            using var propertyRepository = new EfDeletableEntityRepository<Property>(dbContext);
            using var vendorRepository = new EfDeletableEntityRepository<Vendor>(dbContext);

            var service = new MaintenanceServicesService(maintenanceServicesRepository, propertyRepository, vendorRepository);

            Assert.Equal(1, service.GetCount());
        }

        [Fact]
        public async Task CreateShouldSucceed()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "MaintenanceServicesTestDb").Options;
            using var dbContext = new ApplicationDbContext(options);
            using var maintenanceServiceRepository = new EfDeletableEntityRepository<MaintenanceService>(dbContext);
            using var propertyRepository = new EfDeletableEntityRepository<Property>(dbContext);
            using var vendorRepository = new EfDeletableEntityRepository<Vendor>(dbContext);
            var maintenanceServicesService = new MaintenanceServicesService(maintenanceServiceRepository, propertyRepository, vendorRepository);

            var model = new CreateMaintenanceServiceViewModel()
            {
                Name = "HVAC Service",
            };

            await maintenanceServicesService.CreateAsync(model);

            var createdModel = dbContext.MaintenanceServices.FirstOrDefault(p => p.Name == "HVAC Service");

            Assert.NotNull(createdModel);
        }

        [Fact]
        public async Task DeleteShouldDeleteTheCorrectMaintenanceService()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "DeleteMaintenanceServiceDeleteTestDb").Options;
            using var dbContext = new ApplicationDbContext(options);
            using var maintenanceServiceRepository = new EfDeletableEntityRepository<MaintenanceService>(dbContext);
            using var propertyRepository = new EfDeletableEntityRepository<Property>(dbContext);
            using var vendorRepository = new EfDeletableEntityRepository<Vendor>(dbContext);
            var maintenanceServicesService = new MaintenanceServicesService(maintenanceServiceRepository, propertyRepository, vendorRepository);

            var maintenanceServiceId = 3;
            var maintenanceServiceName = "HVAC Service";

            dbContext.MaintenanceServices.Add(new MaintenanceService()
            {
                Id = maintenanceServiceId,
                Name = maintenanceServiceName,
            });
            await dbContext.SaveChangesAsync();

            var countBefore = dbContext.MaintenanceServices.Count();

            var vendor = maintenanceServicesService.DeleteAsync(maintenanceServiceId);

            var countAfter = dbContext.MaintenanceServices.Count();

            Assert.Equal(countBefore, countAfter + 1);
        }
    }
}
