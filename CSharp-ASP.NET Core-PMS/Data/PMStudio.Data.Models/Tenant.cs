namespace PMStudio.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    using PMStudio.Data.Common.Models;

    public class Tenant : BaseDeletableModel<int>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Rate { get; set; }

        [Required]
        public int LeasePeriod { get; set; }

        public int PropertyId { get; set; }

        public virtual Property Property { get; set; }

        [ForeignKey("Manager")]
        public virtual string ManagerId { get; set; }

        public virtual ApplicationUser Manager { get; set; }

    }
}
