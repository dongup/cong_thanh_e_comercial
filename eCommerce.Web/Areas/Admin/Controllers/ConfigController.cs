using eCommerce.Web.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Sale")]
    public class ConfigController : BaseController
    {
        public ConfigController(DatabaseContext _context) : base(_context) { }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult EditPartial()
        {
            return View();
        }
        public IActionResult InstallmentBank()
        {
            return View();
        }

    }
}
