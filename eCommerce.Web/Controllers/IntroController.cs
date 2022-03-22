using eCommerce.Web.Areas.Api.Controllers.General;
using eCommerce.Web.Areas.Api.Models;
using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace eCommerce.Web.Controllers
{
    [Route("gioi-thieu")]
    public class IntroController : BaseController
    {
        public IntroController(DatabaseContext context) : base(context)
        {

        }
        public IActionResult Index()
        {
            IntroduceController introduceController = new IntroduceController(_context);
            IntroduceResponse info = introduceController.Get().Result as IntroduceResponse;
            ViewBag.Phone = _context.Information.FirstOrDefault().Hotline;
            return View(info);
        }
    }
}


