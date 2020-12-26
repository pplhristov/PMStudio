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
        public int PropertyId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> PropertiesItems { get; set; }

        [Required]
        public int VendorId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> VendorsItems { get; set; }

    }
}
