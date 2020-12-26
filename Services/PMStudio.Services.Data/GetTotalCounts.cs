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

        public IndexViewModel GetTotalCount()
        {
            var data = new IndexViewModel
            {
                TotalProperties = this.propertiesRepository.All().Count(),

                TotalTenants = this.tenantsRepository.All().Count(),
            };

            return data;
        }
    }
}
