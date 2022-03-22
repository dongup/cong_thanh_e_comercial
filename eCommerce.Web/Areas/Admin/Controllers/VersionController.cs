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
    public class VersionController : BaseController
    {
        public VersionController(DatabaseContext context):base(context)
        {
        }
        [Microsoft.AspNetCore.Authorization.Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
