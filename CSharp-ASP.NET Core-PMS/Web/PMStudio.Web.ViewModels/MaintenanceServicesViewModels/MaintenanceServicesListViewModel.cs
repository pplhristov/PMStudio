namespace PMStudio.Web.ViewModels.MaintenanceServicesViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using PMStudio.Data.Models;
    using PMStudio.Services.Mapping;

    public class MaintenanceServicesListViewModel : PagingViewModel
    {
        public IEnumerable<MaintenanceServicesInListViewModel> MaintenanceServices { get; set; }
    }
}
