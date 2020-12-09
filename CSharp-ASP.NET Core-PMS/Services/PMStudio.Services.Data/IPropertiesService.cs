using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PMStudio.Web.ViewModels;

namespace PMStudio.Services.Data
{
    public interface IPropertiesService
    {
        Task CreateAsync(CreatePropertiesViewModel input);

        IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 10);

        int GetCount();
    }
}
