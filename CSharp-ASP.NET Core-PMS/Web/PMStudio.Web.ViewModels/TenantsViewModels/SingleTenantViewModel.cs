namespace PMStudio.Web.ViewModels.TenantsViewModels
{
    using PMStudio.Data.Models;
    using PMStudio.Services.Mapping;

    public class SingleTenantViewModel : IMapFrom<Tenant>
    {
        public string Name { get; set; }

        public int Rate { get; set; }

        public int LeasePeriod { get; set; }
    }
}
