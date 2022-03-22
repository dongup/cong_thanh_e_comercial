using eCommerce.Web.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace eCommerce.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductBrandController : BaseController
    {
        public ProductBrandController(DatabaseContext context) : base(context) { }

        [Route("Admin/Product/Brand")]
        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult AddPartial()
        {
            return PartialView();
        }

        public PartialViewResult EditPartial()
        {
            return PartialView();
        }
    }
}
