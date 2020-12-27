namespace PMStudio.Web.Controllers
{
    using System;
    using System.IO;
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
            if (this.propertiesService.IsPropertyWithUniqueNameAndAddress(input))
            {
                this.ModelState.AddModelError(string.Empty, "A property with this Name or Address already exists!");
                return this.View(input);
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            input.ManagerId = this.HttpContext.User.Claims.First(c => c.Type.Contains("nameidentifier")).Value;

            try
            {
                await this.propertiesService.CreateAsync(input, $"{Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot")}");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(input);
            }

            return this.Redirect("/");
        }

        public IActionResult All(int id = 1)
        {
            try
            {
                const int ItemsPerPage = 12;

                var userId = this.HttpContext.User.Claims.First(c => c.Type.Contains("nameidentifier")).Value;

                var viewModel = new PropertiesListViewModel
                {
                    ItemsPerPage = ItemsPerPage,
                    PageNumber = id,
                    Count = this.propertiesService.GetCount(),
                    Properties = this.propertiesService.GetAll<PropertiesInListViewModel>(id, userId, 10),
                };
                return this.View(viewModel);
            }
            catch (Exception ex)
            {
                return this.View("Error", new ErrorViewModel { RequestId = ex.Message });
            }
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
            var editModel = this.propertiesService.GetById<EditPropertiesViewModel>(id);
            return this.View(editModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditPropertiesViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.propertiesService.EditAsync(id, input);

            return this.RedirectToAction(nameof(this.ById), new { id });
        }
    }
}
