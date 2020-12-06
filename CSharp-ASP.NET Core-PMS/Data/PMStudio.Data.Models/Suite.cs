using PMStudio.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMStudio.Data.Models
{
    public class Suite : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public int Size { get; set; }

        public DateTime LeasedOn { get; set; }

        public int PropertyId { get; set; }

        public virtual Property Property { get; set; }

    }
}
