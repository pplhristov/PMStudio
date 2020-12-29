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
    using PMStudio.Web.ViewModels.Vendors;

    public class VendorsService : IVendorsService
    {
      private readonly IDeletableEntityRepository<Vendor> vendorsRepository;

      public VendorsService(IDeletableEntityRepository<Vendor> vendorsRepository)
        {
            this.vendorsRepository = vendorsRepository;
        }

      public async Task CreateAsync(CreateVendorsViewModel input)
        {
            var vendor = new Vendor()
            {
                Name = input.Name,
                Trade = input.Trade,
                Phone = input.Phone,
                Email = input.Email,
                ManagerId = input.ManagerId,
            };

            await this.vendorsRepository.AddAsync(vendor);
            await this.vendorsRepository.SaveChangesAsync();
        }

      public async Task DeleteAsync(int id)
        {
            var vendor = this.vendorsRepository.All().FirstOrDefault(x => x.Id == id);
            this.vendorsRepository.Delete(vendor);
            await this.vendorsRepository.SaveChangesAsync();
        }

      public IEnumerable<T> GetAll<T>(int page, string managerId, int itemsPerPage = 10)
        {
            var vendors = this.vendorsRepository.AllAsNoTracking()
                .Where(v => v.ManagerId == managerId)
               .OrderByDescending(x => x.Id)
               .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
               .To<T>()
               .ToList();
            return vendors;
        }

      public int GetCount()
        {
            return this.vendorsRepository.All().Count();
        }
      public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.vendorsRepository.AllAsNoTracking()
                .OrderBy(x => x.Name)
                .Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name))
                .ToList();
        }
    }
}
