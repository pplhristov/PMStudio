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

            input.ManagerId = this.HttpContext.User.Claims.First(c => c.Type.Contains("nameidentifier")).Value;

            try
            {
                await this.vendorsService.CreateAsync(input);

                return this.Redirect("/");
            }
            catch (Exception ex)
            {
                return this.View("Error", new ErrorViewModel { RequestId = ex.Message });
            }
        }

        public IActionResult All(int id = 1)
        {
            const int ItemsPerPage = 12;

            try
            {
                var userId = this.HttpContext.User.Claims.First(c => c.Type.Contains("nameidentifier")).Value;

                var viewModel = new VendorsListViewModel
                {
                    ItemsPerPage = ItemsPerPage,
                    PageNumber = id,
                    Count = this.vendorsService.GetCount(),
                    Vendors = this.vendorsService.GetAll<VendorsInListViewModel>(id, userId, 10),
                };
                return this.View(viewModel);
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
            try
            {
            await this.vendorsService.DeleteAsync(id);

            return this.RedirectToAction(nameof(this.All));
            }
            catch (Exception ex)
            {
                return this.View("Error", new ErrorViewModel { RequestId = ex.Message });
            }
        }
    }
}