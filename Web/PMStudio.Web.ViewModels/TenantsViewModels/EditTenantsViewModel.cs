using PMStudio.Data.Models;
using PMStudio.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMStudio.Web.ViewModels.TenantsViewModels
{
    public class EditTenantsViewModel : IMapFrom<Tenant>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Rate { get; set; }

        public int LeasePeriod { get; set; }

       // public int PropertyId { get; set; }

        //public IEnumerable<KeyValuePair<string, string>> PropertiesItems { get; set; }
    }
}
