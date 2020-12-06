using PMStudio.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMStudio.Data.Models
{
    public class Image:BaseModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public int PropertyId { get; set; }

        public virtual Property Property { get; set; }
    }
}
