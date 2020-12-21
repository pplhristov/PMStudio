namespace PMStudio.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using PMStudio.Web.ViewModels.MaintenanceServicesViewModels;

    public interface IMaintenanceServicesService
    {
        Task CreateAsync(CreateMaintenanceServiceViewModel input);

        IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 10);

        int GetCount();

        T GetById<T>(int id);

        Task DeleteAsync(int id);

    }
}