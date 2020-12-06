using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace PMStudio.Web.Controllers
{
    public class TenantsController : BaseController
    {
        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }
    }
}
