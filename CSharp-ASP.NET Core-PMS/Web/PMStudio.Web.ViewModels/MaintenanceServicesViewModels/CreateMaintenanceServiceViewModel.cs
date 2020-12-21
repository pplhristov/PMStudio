namespace PMStudio.Web.ViewModels.MaintenanceServicesViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class CreateMaintenanceServiceViewModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public DateTime ServiceDate { get; set; }

        [Required]
        public string Property { get; set; }

        [Required]
        public string Vendor { get; set; }

    }
}
