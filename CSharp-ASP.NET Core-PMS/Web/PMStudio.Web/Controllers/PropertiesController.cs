namespace PMStudio.Web.Controllers
{
    using System.Linq;
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
                return View(new ErrorViewModel());
            }

            input.ManagerId = this.HttpContext.User.Claims.First(c => c.Type.Contains("nameidentifier")).Value;

            await this.propertiesService.CreateAsync(input);

            return this.Redirect("/");
        }

        public IActionResult All(int id=1)
        {
            const int ItemsPerPage = 12;

            var userId = HttpContext.User.Claims.First(c => c.Type.Contains("nameidentifier")).Value;

            var viewModel = new PropertiesListViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                Count = this.propertiesService.GetCount(),
                Properties = this.propertiesService.GetAll<PropertiesInListViewModel>(id, userId, 10),
            };
            return this.View(viewModel);
        }
        [Authorize]
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

        [Authorize]
        public IActionResult Edit(int id)
        {
            var editModel = this.propertiesService.GetById<EditPropertyViewModel>(id);
            return this.View(editModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditPropertyViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.propertiesService.EditAsync(id, input);

            return RedirectToAction(nameof(this.ById), new { id });
        }
    }
}
