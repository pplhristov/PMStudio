namespace PMStudio.Web.ViewModels.Vendors
{
    using PMStudio.Data.Models;
    using PMStudio.Services.Mapping;

    public class VendorsInListViewModel : IMapFrom<Vendor>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Trade { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
