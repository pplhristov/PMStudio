namespace PMStudio.Web.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using PMStudio.Web.ViewModels.TenantsViewModels;

    public class PropertiesListViewModel : PagingViewModel
    {
        public IEnumerable<PropertiesInListViewModel> Properties { get; set; }
    }
}
