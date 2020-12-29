namespace PMStudio.Web.Areas.Administration.Controllers
{
    using PMStudio.Services.Data;
    using PMStudio.Web.ViewModels.Administration.Dashboard;

    using Microsoft.AspNetCore.Mvc;
    using PMStudio.Data.Common.Repositories;
    using PMStudio.Data.Models;

    public class DashboardController : AdministrationController
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;
        private readonly IDeletableEntityRepository<ApplicationRole> rolesRepository;
        public DashboardController(
            IDeletableEntityRepository<ApplicationUser> usersRepository,
            IDeletableEntityRepository<ApplicationRole> rolesRepository
            )
        {
            this.usersRepository = usersRepository;
            this.rolesRepository = rolesRepository;
        }

        public IActionResult Index()
        {
            var users = this.usersRepository.AllAsNoTracking();
            var roles = this.rolesRepository.AllAsNoTracking();


            var viewModel = new IndexViewModel
            {
                Users = users,
                Roles = roles,

            };
            return this.View(viewModel);
        }
    }
}
