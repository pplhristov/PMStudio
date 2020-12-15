namespace PMStudio.Web.ViewModels.TenantsViewModels
{
    using PMStudio.Data.Models;
    using PMStudio.Services.Mapping;

    public class TenantsInListViewModel : IMapFrom<Tenant>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int LeasePeriod { get; set; }
    }
}
