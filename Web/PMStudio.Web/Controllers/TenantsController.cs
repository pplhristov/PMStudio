namespace PMStudio.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PMStudio.Services.Data;
    using PMStudio.Web.ViewModels;
    using PMStudio.Web.ViewModels.TenantsViewModels;

    public class TenantsController : BaseController
    {
        private readonly ITenantsService tenantsService;
        private readonly IPropertiesService propertiesService;

        public TenantsController(ITenantsService tenantsService, IPropertiesService propertiesService)
        {
            this.tenantsService = tenantsService;
            this.propertiesService = propertiesService;
        }


        [Authorize]
        public IActionResult Create()
        {
            var model = new CreateTenantsViewModel();
            try
            {
            model.PropertiesItems = this.propertiesService.GetAllAsKeyValuePairs();

            return this.View(model);

            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View();
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateTenantsViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            try
            {
            input.ManagerId = this.HttpContext.User.Claims.First(c => c.Type.Contains("nameidentifier")).Value;

            await this.tenantsService.CreateAsync(input);

            return this.Redirect("/");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View();
            }
        }

        public IActionResult All(int id = 1)
        {
            try
            {
                const int ItemsPerPage = 12;

                var userId = HttpContext.User.Claims.First(c => c.Type.Contains("nameidentifier")).Value;

                var viewModel = new TenantsListViewModel
                {
                    ItemsPerPage = ItemsPerPage,
                    PageNumber = id,
                    Count = this.tenantsService.GetCount(),
                    Tenants = this.tenantsService.GetAll<TenantsInListViewModel>(id, userId, 10),
                };
                return this.View(viewModel);
            }
            catch (Exception ex)
            {
                return this.View("Error", new ErrorViewModel { RequestId = ex.Message });
            }
        }

        public IActionResult ById(int id)
        {
            try
            {
            var tenant = this.tenantsService.GetById<SingleTenantViewModel>(id);

            return this.View(tenant);
            }
            catch (Exception ex)
            {
                return this.View("Error", new ErrorViewModel { RequestId = ex.Message });
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await this.tenantsService.DeleteAsync(id);
            return this.RedirectToAction(nameof(this.All));
        }
    }
}
