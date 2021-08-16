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
   public class PropertiesServiceTest
    {
        [Fact]
        public async Task GetCountShouldReturnCorrectNumberUsingDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "PropertiesTestDb").Options;
            using var dbContext = new ApplicationDbContext(options);
            dbContext.Properties.Add(new Property());
            dbContext.Properties.Add(new Property());
            dbContext.Properties.Add(new Property());
            await dbContext.SaveChangesAsync();

            using var propertyRepository = new EfDeletableEntityRepository<Property>(dbContext);
            var propertiesService = new PropertiesService(propertyRepository);
            Assert.Equal(3, propertiesService.GetCount());
        }
    }
}
