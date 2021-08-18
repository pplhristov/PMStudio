using Microsoft.EntityFrameworkCore;
using PMStudio.Data;
using PMStudio.Data.Models;
using PMStudio.Data.Repositories;
using PMStudio.Web.ViewModels.Vendors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PMStudio.Services.Data.Tests
{
    public class VendorsServiceTests
    {
        [Fact]
        public async Task GetCountShouldReturnCorrectNumberUsingDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "VendorsTestDb").Options;
            using var dbContext = new ApplicationDbContext(options);
            dbContext.Vendors.Add(new Vendor());
            dbContext.Vendors.Add(new Vendor());
            dbContext.Vendors.Add(new Vendor());
            await dbContext.SaveChangesAsync();

            using var vendorRepository = new EfDeletableEntityRepository<Vendor>(dbContext);
            var service = new VendorsService(vendorRepository);
            Assert.Equal(3, service.GetCount());
        }

        [Fact]
        public async Task CreateShouldSucceed()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(databaseName: "CreateVendorTestDb").Options;
            using var dbContext = new ApplicationDbContext(options);
            using var vendorRepository = new EfDeletableEntityRepository<Vendor>(dbContext);
            var vendorsService = new VendorsService(vendorRepository);

            var model = new CreateVendorsViewModel()
            {
                Name = "Best Plumbing",
            };

            await vendorsService.CreateAsync(model);

            var createdModel = dbContext.Vendors.FirstOrDefault(p => p.Name == "Best Plumbing");

            Assert.NotNull(createdModel);
        }

        [Fact]
        public async Task DeleteShouldDeleteTheCorrectVendor()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "DeleteVendorsTestDb").Options;
            using var dbContext = new ApplicationDbContext(options);
            using var vendorRepository = new EfDeletableEntityRepository<Vendor>(dbContext);
            var vendorsService = new VendorsService(vendorRepository);

            var vendorId = 3;
            var vendorName = "Best Plumbing";

            dbContext.Vendors.Add(new Vendor()
            {
                Id = vendorId,
                Name = vendorName,
            });
            await dbContext.SaveChangesAsync();

            var countBefore = dbContext.Vendors.Count();

            var vendor = vendorsService.DeleteAsync(vendorId);

            var countAfter = dbContext.Vendors.Count();

            Assert.Equal(countBefore, countAfter + 1);
        }
    }
}
