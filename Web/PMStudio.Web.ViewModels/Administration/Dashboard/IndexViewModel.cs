namespace PMStudio.Web.ViewModels.Administration.Dashboard
{
    using System.Collections.Generic;

    using PMStudio.Data.Models;
    using PMStudio.Services.Mapping;

    public class IndexViewModel
    {
        public IEnumerable<ApplicationUser> Users { get; set; }

        public IEnumerable<ApplicationRole> Roles { get; set; }
    }
}
