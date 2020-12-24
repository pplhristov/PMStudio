namespace PMStudio.Web.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Microsoft.AspNetCore.Http;
    using PMStudio.Data.Models.Enum;

    public class CreatePropertiesViewModel
    {
        [Required]
        [MinLength(4)]
        public string Name { get; set; }

        [Required]
        [MinLength(10)]
        public string Address { get; set; }

        [Required]
        public string Owner { get; set; }

        [Required]

        public int Size { get; set; }

        [Required]

        public PropertyType Type { get; set; }

        public IEnumerable<IFormFile> Images { get; set; }

        public string ManagerId { get; set; }


    }
}
