﻿namespace PMStudio.Web.ViewModels.TenantsViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class CreateTenantsViewModel
    {
        [Required]
        [MinLength(4)]
        public string Name { get; set; }

        [Required]
        public int Rate { get; set; }

        [Required]
        public int LeasePeriod { get; set; }

        public int PropertyId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> PropertiesItems { get; set; }


        public string ManagerId { get; set; }
    }
}
