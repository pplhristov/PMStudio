namespace PMStudio.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using PMStudio.Services.Data;
    using PMStudio.Web.ViewModels;

    public class HomeController : BaseController
    {
        private readonly IGetTotalCountsService countsService;

        public HomeController(IGetTotalCountsService countsService)
        {
            this.countsService = countsService;
        }

        public IActionResult Index()
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type.Contains("nameidentifier"))?.Value;

            var viewModel = this.countsService.GetTotalCount(userId);

            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
