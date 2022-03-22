using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerce.Web.Entities;
using Microsoft.AspNetCore.Authorization;

namespace eCommerce.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Sale")]
    public class PopupController : BaseController
    {
        public PopupController(DatabaseContext context) : base(context) { }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddPartial()
        {
            return View();
        }
        public IActionResult EditPartial()
        {

            return View();
        }

       
    }
}
