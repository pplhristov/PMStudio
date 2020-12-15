namespace PMStudio.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using PMStudio.Data.Common.Models;

    public class Vendor : BaseDeletableModel<int>
    {
        public Vendor()
        {
            this.PropertyVendors = new HashSet<PropertyVendor>();
        }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Trade { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public ICollection<PropertyVendor> PropertyVendors { get; set; }
    }
}
