namespace PMStudio.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PMStudio.Services.Data;
    using PMStudio.Web.ViewModels.TenantsViewModels;

    public class TenantsController : BaseController
    {
        private readonly ITenantsService tenantsService;

        public TenantsController(ITenantsService tenantsService)
        {
            this.tenantsService = tenantsService;
        }


        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateTenantsViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            input.ManagerId = this.HttpContext.User.Claims.First(c => c.Type.Contains("nameidentifier")).Value;

            await this.tenantsService.CreateAsync(input);

            return this.Redirect("/");
        }

        public IActionResult All(int id = 1)
        {
            const int ItemsPerPage = 12;

            var userId = HttpContext.User.Claims.First(c => c.Type.Contains("nameidentifier")).Value;

            var viewModel = new TenantsListViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                Count = this.tenantsService.GetCount(),
                Tenants = this.tenantsService.GetAll<TenantsInListViewModel>(id,userId, 10),
            };
            return this.View(viewModel);
        }

        public IActionResult ById(int id)
        {
            var tenant = this.tenantsService.GetById<SingleTenantViewModel>(id);

            return this.View(tenant);
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
