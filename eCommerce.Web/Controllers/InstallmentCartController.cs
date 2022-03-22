using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Controllers
{
    [Route("gio-hang-tra-gop")]
    public class InstallmentCartController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
