namespace PMStudio.Web.ViewModels.MaintenanceServicesViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using PMStudio.Data.Models;
    using PMStudio.Services.Mapping;
    using PMStudio.Web.ViewModels.Vendors;

    public class MaintenanceServicesInListViewModel : IMapFrom<MaintenanceService>
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime ServiceDate { get; set; }

        public SinglePropertyViewModel Property { get; set; }

        public VendorsInListViewModel Vendor { get; set; }
    }
}
