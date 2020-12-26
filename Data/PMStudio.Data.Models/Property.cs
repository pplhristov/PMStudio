namespace PMStudio.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    using PMStudio.Data.Common.Models;
    using PMStudio.Data.Models.Enum;

    public class Property : BaseDeletableModel<int>
    {
        public Property()
        {
            this.PropertyVendors = new HashSet<PropertyVendor>();
            this.Images = new HashSet<Image>();
            this.MaintenanceServices = new HashSet<MaintenanceService>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        public string Owner { get; set; }

        [Required]
        public PropertyType Type { get; set; }

        public int Size { get; set; }

        [ForeignKey("Manager")]
        public virtual string ManagerId { get; set; }

        public virtual ApplicationUser Manager { get; set; }

        [ForeignKey("Tenant")]
        public virtual int? TenantId { get; set; }

        public virtual Tenant Tenant { get; set; }

        public virtual ICollection<MaintenanceService> MaintenanceServices { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public ICollection<PropertyVendor> PropertyVendors { get; set; }
    }
}
