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
    public class ProductPropertiesController : BaseController
    {
        public ProductPropertiesController(DatabaseContext context) : base(context) { }

        [Route("Admin/Product/Properties")]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DetailsPropertiesPartial() {
            return View();
        }
    }
}
