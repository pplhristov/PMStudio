﻿namespace PMStudio.Web.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class CreatePropertiesViewModel
    {
        [Required]
        [MinLength(4)]
        public string Name { get; set; }

        [Required]
        [MinLength(10)]
        public string Address { get; set; }
    }
}
