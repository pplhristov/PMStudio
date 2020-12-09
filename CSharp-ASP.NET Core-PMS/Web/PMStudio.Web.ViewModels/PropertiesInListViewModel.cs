namespace PMStudio.Web.ViewModels
{
    using PMStudio.Data.Models;
    using PMStudio.Services.Mapping;

    public class PropertiesInListViewModel : IMapFrom<Property>
    {
        public int Id { get; set; }
         
        public string Name { get; set; }

        public string Address { get; set; }
    }
}

