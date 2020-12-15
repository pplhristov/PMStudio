namespace PMStudio.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PMStudio.Services.Data;
    using PMStudio.Web.ViewModels;

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

        public IActionResult All(int id=1)
        {
            const int ItemsPerPage = 12;

            var viewModel = new PropertiesListViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                Count = this.propertiesService.GetCount(),
                Properties = this.propertiesService.GetAll<PropertiesInListViewModel>(id, 10),
            };
            return this.View(viewModel);
        }

        public IActionResult ById(int id)
        {
            var property = this.propertiesService.GetById<SinglePropertyViewModel>(id);

            return this.View(property);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await this.propertiesService.DeleteAsync(id);
            return this.RedirectToAction(nameof(this.All));
        }
    }
}
