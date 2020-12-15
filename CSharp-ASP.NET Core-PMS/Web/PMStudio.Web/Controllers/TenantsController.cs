namespace PMStudio.Web.Controllers
{
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

            await this.tenantsService.CreateAsync(input);

            return this.Redirect("/");
        }

        public IActionResult All(int id = 1)
        {
            const int ItemsPerPage = 12;

            var viewModel = new TenantsListViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                Count = this.tenantsService.GetCount(),
                Tenants = this.tenantsService.GetAll<TenantsInListViewModel>(id, 10),
            };
            return this.View(viewModel);
        }

        public IActionResult ById(int id)
        {
            var property = this.tenantsService.GetById<SingleTenantViewModel>(id);

            return this.View(property);
        }
    }
}
