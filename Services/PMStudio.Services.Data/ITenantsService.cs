namespace PMStudio.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using PMStudio.Web.ViewModels.TenantsViewModels;

    public interface ITenantsService
    {
        Task CreateAsync(CreateTenantsViewModel input);

        IEnumerable<T> GetAll<T>(int page,string userId, int itemsPerPage = 10);

        int GetCount();

        T GetById<T>(int id);

        Task EditAsync(int id, EditTenantsViewModel input);

        Task DeleteAsync(int id);
    }
}
