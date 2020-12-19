namespace PMStudio.Web.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using PMStudio.Data.Models;
    using PMStudio.Data.Models.Enum;
    using PMStudio.Services.Mapping;

    public class EditPropertyViewModel : IMapFrom<Property>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
  
        public string Owner { get; set; }

        public PropertyType Type { get; set; }

        public int Size { get; set; }
    }
}
