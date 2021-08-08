using Microsoft.EntityFrameworkCore;
using PMStudio.Data;
using PMStudio.Data.Models;
using PMStudio.Data.Repositories;
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
    }
}
