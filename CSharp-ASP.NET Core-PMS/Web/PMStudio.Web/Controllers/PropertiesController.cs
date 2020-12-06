namespace PMStudio.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PMStudio.Services.Data;
    using PMStudio.Web.ViewModels;
    using System.Threading.Tasks;

    public class PropertiesController : BaseController
    {
        private readonly IPropertiesService propertiesService;

        public PropertiesController(IPropertiesService propertiesService)
        {
            this.propertiesService = propertiesService;
        }


        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreatePropertiesViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.propertiesService.CreateAsync(input);

            return this.Redirect("/");
        }

        public IActionResult All()
        {
            return this.View();
        }

    }
}
