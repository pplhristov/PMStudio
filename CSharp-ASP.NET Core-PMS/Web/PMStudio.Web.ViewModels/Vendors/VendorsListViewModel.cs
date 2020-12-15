namespace PMStudio.Web.ViewModels.Vendors
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class VendorsListViewModel : PagingViewModel
    {
        public IEnumerable<VendorsInListViewModel> Vendors { get; set; }
    }
}
