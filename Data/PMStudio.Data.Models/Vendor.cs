namespace PMStudio.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using PMStudio.Data.Common.Models;

    public class Vendor : BaseDeletableModel<int>
    {
        public Vendor()
        {
            this.PropertyVendors = new HashSet<PropertyVendor>();
            this.MaintenanceServices = new HashSet<MaintenanceService>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Trade { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        public ICollection<PropertyVendor> PropertyVendors { get; set; }

        public IEnumerable<MaintenanceService> MaintenanceServices { get; set; }
    }
}
