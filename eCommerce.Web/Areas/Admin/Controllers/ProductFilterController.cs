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
    public class ProductFilterController : BaseController
    {
        public ProductFilterController(DatabaseContext context) : base(context) { }

        [Route("Admin/Product/Filter")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
