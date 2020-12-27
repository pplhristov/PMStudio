namespace PMStudio.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using PMStudio.Data.Common.Repositories;
    using PMStudio.Data.Models;
    using PMStudio.Web.ViewModels.NewFolder;

    public class GetTotalCounts : IGetTotalCountsService
    {
        private IDeletableEntityRepository<Property> propertiesRepository;
        private IDeletableEntityRepository<Tenant> tenantsRepository;

        public GetTotalCounts(IDeletableEntityRepository<Property> propertiesRepository,
        IDeletableEntityRepository<Tenant> tenatsReposity)
        {
            this.propertiesRepository = propertiesRepository;

            this.tenantsRepository = tenatsReposity;
        }

        public IndexViewModel GetTotalCount(string managerId)
        {
            var data = new IndexViewModel
            {
                TotalProperties = this.propertiesRepository.AllAsNoTracking()
                .Where(p => p.ManagerId == managerId)?.Count() ?? 0,

                TotalTenants = this.tenantsRepository.AllAsNoTracking()
                .Where(p => p.ManagerId == managerId)?.Count() ?? 0,
            };

            return data;
        }
    }
}
