using PMStudio.Web.ViewModels.Vendors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PMStudio.Services.Data
{
    public interface IVendorsService
    {
        Task CreateAsync(CreateVendorsViewModel input);

        IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 10);

        int GetCount();

        Task DeleteAsync(int id);

        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}
