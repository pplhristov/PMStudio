using Microsoft.EntityFrameworkCore;
using PMStudio.Data;
using PMStudio.Data.Models;
using PMStudio.Data.Repositories;
using PMStudio.Web.ViewModels.TenantsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PMStudio.Services.Data.Tests
{
    public class TenantsServiceTests
    {
        [Fact]
        public async Task GetCountShouldReturnCorrectNumberUsingDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TenantsTestDb").Options;
            using var dbContext = new ApplicationDbContext(options);
            dbContext.Tenants.Add(new Tenant());
            dbContext.Tenants.Add(new Tenant());
            dbContext.Tenants.Add(new Tenant());
            await dbContext.SaveChangesAsync();

            using var tenantRepository = new EfDeletableEntityRepository<Tenant>(dbContext);
            using var propertyRepository = new EfDeletableEntityRepository<Property>(dbContext);
            var service = new TenantsService(tenantRepository, propertyRepository);
            Assert.Equal(3, service.GetCount());
        }

        [Fact]
        public async Task CreateShouldSucceed()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(databaseName: "CreateTenantsTestDb").Options;
            using var dbContext = new ApplicationDbContext(options);
            using var tenantRepository = new EfDeletableEntityRepository<Tenant>(dbContext);
            using var propertyRepository = new EfDeletableEntityRepository<Property>(dbContext);
            var tenantsService = new TenantsService(tenantRepository, propertyRepository);

            var model = new CreateTenantsViewModel()
            {
                Name = "Peter",
                Rate = 1800,
                LeasePeriod = 12,
            };

            await tenantsService.CreateAsync(model);

            var createdModel = dbContext.Tenants.FirstOrDefault(p => p.Name == "Peter");

            Assert.NotNull(createdModel);
        }
    }
}
