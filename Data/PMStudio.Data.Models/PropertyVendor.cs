namespace PMStudio.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PropertyVendor
    {
        public int Id { get; set; }

        public int PropertyId { get; set; }

        public virtual Property Property { get; set; }

        public int VendorId { get; set; }

        public virtual Vendor Vendor { get; set; }
    }
}
