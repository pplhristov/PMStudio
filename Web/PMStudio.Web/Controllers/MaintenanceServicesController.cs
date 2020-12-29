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
    using PMStudio.Web.ViewModels.MaintenanceServicesViewModels;

    public class MaintenanceServicesController : BaseController
    {
        private readonly IMaintenanceServicesService maintenanceServicesService;
        private readonly IPropertiesService propertiesService;
        private readonly IVendorsService vendorService;

        public MaintenanceServicesController(IMaintenanceServicesService maintenanceServicesService, IPropertiesService propertiesService, IVendorsService vendorService)
        {
            this.maintenanceServicesService = maintenanceServicesService;
            this.propertiesService = propertiesService;
            this.vendorService = vendorService;
        }

        [Authorize]
        public IActionResult Create()
        {
            var model = new CreateMaintenanceServiceViewModel();

            model.PropertiesItems = this.propertiesService.GetAllAsKeyValuePairsForServices();
            model.VendorsItems = this.vendorService.GetAllAsKeyValuePairs();
            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateMaintenanceServiceViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            try
            {
            await this.maintenanceServicesService.CreateAsync(input);

            return this.Redirect("/");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(input);
            }
        }

        public IActionResult All(int id = 1)
        {
            const int ItemsPerPage = 12;

            try
            {
                var userId = this.HttpContext.User.Claims.First(c => c.Type.Contains("nameidentifier")).Value;

                var viewModel = new MaintenanceServicesListViewModel
                {
                    ItemsPerPage = ItemsPerPage,
                    PageNumber = id,
                    Count = this.maintenanceServicesService.GetCount(),
                    MaintenanceServices = this.maintenanceServicesService.GetAll<MaintenanceServicesInListViewModel>(id, userId, 10),
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
            await this.maintenanceServicesService.DeleteAsync(id);
            return this.RedirectToAction(nameof(this.All));
        }
    }
}
