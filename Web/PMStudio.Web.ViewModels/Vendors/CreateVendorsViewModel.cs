namespace PMStudio.Web.ViewModels.Vendors
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class CreateVendorsViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Trade { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
