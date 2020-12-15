namespace PMStudio.Web.ViewModels
{
    using PMStudio.Data.Models;
    using PMStudio.Data.Models.Enum;
    using PMStudio.Services.Mapping;

    public class SinglePropertyViewModel : IMapFrom<Property>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Owner { get; set; }

        public PropertyType PropertyType { get; set; }

    }
}
