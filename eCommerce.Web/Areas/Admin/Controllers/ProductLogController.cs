using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerce.Web.Entities;
using Microsoft.AspNetCore.Authorization;

namespace eCommerce.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductLogController : BaseController
    {
        public ProductLogController(DatabaseContext context) : base(context) { }

        [Route("Admin/Product/Log")]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ViewDetailPartital() {

            return View();
        }
    }
}
