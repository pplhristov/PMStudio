namespace PMStudio.Web.ViewModels.MaintenanceServicesViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class EditMaintenanceServiceViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime ServiceDate { get; set; }

        public string Property { get; set; }

        public string Vendor { get; set; }
    }
}
