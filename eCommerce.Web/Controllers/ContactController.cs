using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Controllers
{
    [Route("lien-he")]
    public class ContactController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
