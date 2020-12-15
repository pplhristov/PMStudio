namespace PMStudio.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PMStudio.Services.Data;
    using PMStudio.Web.ViewModels;
    using PMStudio.Web.ViewModels.Vendors;

    public class VendorsController : BaseController
    {
        private readonly IVendorsService vendorsService;

        public VendorsController(IVendorsService vendorsService)
        {
            this.vendorsService = vendorsService;
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateAsync(CreateVendorsViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.vendorsService.CreateAsync(input);

            return this.Redirect("/");
        }

        public IActionResult All(int id = 1)
        {
            const int ItemsPerPage = 12;

            var viewModel = new VendorsListViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                Count = this.vendorsService.GetCount(),
                Vendors = this.vendorsService.GetAll<VendorsInListViewModel>(id, 10),
            };
            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await this.vendorsService.DeleteAsync(id);

            return this.RedirectToAction(nameof(this.All));

        }
    }
}