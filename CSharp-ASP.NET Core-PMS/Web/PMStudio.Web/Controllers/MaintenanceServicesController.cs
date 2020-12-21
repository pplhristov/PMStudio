namespace PMStudio.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PMStudio.Services.Data;
    using PMStudio.Web.ViewModels.MaintenanceServicesViewModels;

    public class MaintenanceServicesController : BaseController
    {
        private readonly IMaintenanceServicesService maintenanceServicesService;

        public MaintenanceServicesController(IMaintenanceServicesService maintenanceServicesService)
        {
            this.maintenanceServicesService = maintenanceServicesService;
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateMaintenanceServiceViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.maintenanceServicesService.CreateAsync(input);

            return this.Redirect("/");
        }

        public IActionResult All(int id = 1)
        {
            const int ItemsPerPage = 12;

            var userId = HttpContext.User.Claims.First(c => c.Type.Contains("nameidentifier")).Value;

            var viewModel = new MaintenanceServicesListViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                Count = this.maintenanceServicesService.GetCount(),
                MaintenanceServices = this.maintenanceServicesService.GetAll<MaintenanceServicesInListViewModel>(id, 10),
            };
            return this.View(viewModel);
        }
    }
}
