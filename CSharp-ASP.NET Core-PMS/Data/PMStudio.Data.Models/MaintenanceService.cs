namespace PMStudio.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using PMStudio.Data.Common.Models;

    public class MaintenanceService : BaseDeletableModel<int>
    {
        [Required]
        [MinLength(4)]
        public string Name { get; set; }

        [Required]
        public DateTime ServiceDate { get; set; }

        public int PropertyId { get; set; }

        public virtual Property Property { get; set; }

        public int VendorId { get; set; }

        public virtual Vendor Vendor { get; set; }
    }
}
