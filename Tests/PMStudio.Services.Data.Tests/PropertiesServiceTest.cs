using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PMStudio.Data;
using PMStudio.Data.Models;
using PMStudio.Data.Repositories;
using PMStudio.Web.ViewModels;
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

        [Fact]
        public async Task CreateShouldSucceed()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(databaseName: "CreatePropertiesTestDb").Options;
            using var dbContext = new ApplicationDbContext(options);
            using var propertyRepository = new EfDeletableEntityRepository<Property>(dbContext);
            var propertiesService = new PropertiesService(propertyRepository);

            var model = new CreatePropertiesViewModel()
            {
                Address = "Test",
                Name = "Test",
                Owner = "Owner",
                Size = 110,
                Type = PMStudio.Data.Models.Enum.PropertyType.Residential,
                Images = new List<IFormFile>(),
            };

            await propertiesService.CreateAsync(model, @"C:\PM.Studio.Images");

            var createdModel = dbContext.Properties.FirstOrDefault(p => p.Name == "Test");

            Assert.NotNull(createdModel);
        }

        [Fact]
        public async Task GetByIdShouldReturnTheCorrectProperty()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "GetByIdPropertiesTestDb").Options;
            using var dbContext = new ApplicationDbContext(options);

            var propertyId = 5;
            var propertyName = $"Property with ID {propertyId}";

            var manager = new ApplicationUser()
            {
                UserName = "Admin",
            };

            var tenant = new Tenant()
            {
                Name = "Test tenant",
            };

            dbContext.Properties.Add(new Property()
            {
                Id = propertyId,
                Name = propertyName,
                Type = PMStudio.Data.Models.Enum.PropertyType.Residential,
                Address = "Kings Lynn",
                Manager = manager,
                Owner = "Test owner",
                Tenant = tenant,
                ModifiedOn = DateTime.Now.AddDays(+1),
                Size = 500,
            });
            await dbContext.SaveChangesAsync();

            using var propertyRepository = new EfDeletableEntityRepository<Property>(dbContext);
            var propertiesService = new PropertiesService(propertyRepository);
            var property = propertiesService.GetById<SinglePropertyViewModel>(propertyId);

            Assert.Equal(propertyName, property.Name);
        }


        [Fact]
        public async Task DeleteShouldDeleteTheCorrectProperty()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "DeletePropertiesTestDb").Options;
            using var dbContext = new ApplicationDbContext(options);

            var propertyId = 5;
            var propertyName = $"Property with ID {propertyId}";

            dbContext.Properties.Add(new Property()
            {
                Id = propertyId,
                Name = propertyName,
            });
            await dbContext.SaveChangesAsync();

            using var propertyRepository = new EfDeletableEntityRepository<Property>(dbContext);
            var propertiesService = new PropertiesService(propertyRepository);

            var countBefore = dbContext.Properties.Count();

            var property = propertiesService.DeleteAsync(propertyId);

            var countAfter = dbContext.Properties.Count();

            Assert.Equal(countBefore, countAfter + 1);
        }
    }
}
