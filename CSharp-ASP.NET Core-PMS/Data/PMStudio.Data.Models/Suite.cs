namespace PMStudio.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using PMStudio.Data.Common.Models;

    public class Suite : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public int Size { get; set; }

        public DateTime LeasedOn { get; set; }

        public int PropertyId { get; set; }

        public virtual Property Property { get; set; }

    }
}
