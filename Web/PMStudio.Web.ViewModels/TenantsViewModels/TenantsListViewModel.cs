namespace PMStudio.Web.ViewModels.TenantsViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class TenantsListViewModel : PagingViewModel
    {
        public IEnumerable<TenantsInListViewModel> Tenants { get; set; }
    }
}
