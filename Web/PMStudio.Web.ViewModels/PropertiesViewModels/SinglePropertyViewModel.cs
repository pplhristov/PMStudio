namespace PMStudio.Web.ViewModels
{
    using AutoMapper;
    using PMStudio.Data.Models;
    using PMStudio.Data.Models.Enum;
    using PMStudio.Services.Mapping;
    using PMStudio.Web.ViewModels.TenantsViewModels;
    using System.Collections.Generic;
    using System.Linq;

    public class SinglePropertyViewModel : IMapFrom<Property>, IHaveCustomMappings
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Owner { get; set; }

        public PropertyType Type { get; set; }

        public SingleTenantViewModel Tenant { get; set; }

        public string ImageUrl { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Property, SinglePropertyViewModel>()
                .ForMember(x => x.ImageUrl, opt =>
                    opt.MapFrom(x =>
                        x.Images.FirstOrDefault().RemoteImageUrl != null ?
                        x.Images.FirstOrDefault().RemoteImageUrl :
                        "/images/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension));
        }
    }
}
