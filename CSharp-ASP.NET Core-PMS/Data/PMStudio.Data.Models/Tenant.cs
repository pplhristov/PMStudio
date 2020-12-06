using PMStudio.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMStudio.Data.Models
{
    public class Tenant : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public int Rate { get; set; }

        public int LeasePeriod { get; set; }

        public int PropertyId { get; set; }

        public virtual Property Property { get; set; }
    }
}
