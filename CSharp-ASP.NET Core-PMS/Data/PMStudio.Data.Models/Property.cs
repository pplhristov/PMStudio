namespace PMStudio.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using PMStudio.Data.Common.Models;
    using PMStudio.Data.Models.Enum;

    public class Property : BaseDeletableModel<int>
    {
        public Property()
        {
            this.Suites = new HashSet<Suite>();
            this.PropertyVendors = new HashSet<PropertyVendor>();
        }

        public string Name { get; set; }

        public string Address { get; set; }

        // delete Owner
        public string Owner { get; set; }

        public PropertyType Type { get; set; }

        public ICollection<MaintenanceService> MaintenanceServices { get; set; }

        public ICollection<Suite> Suites { get; set; }

        public ICollection<PropertyVendor> PropertyVendors { get; set; }
    }
}
