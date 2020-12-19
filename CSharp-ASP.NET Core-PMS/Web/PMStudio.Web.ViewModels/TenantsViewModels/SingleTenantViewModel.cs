namespace PMStudio.Web.ViewModels.TenantsViewModels
{
    using PMStudio.Data.Models;
    using PMStudio.Services.Mapping;

    public class SingleTenantViewModel : IMapFrom<Tenant>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Rate { get; set; }

        public int LeasePeriod { get; set; }

        public SinglePropertyViewModel Property { get; set; }
    }
}
