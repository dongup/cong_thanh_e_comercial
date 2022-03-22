using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerce.Web.Entities;
namespace eCommerce.Web.Areas.Admin.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin,Sale")]
    public class PromotionController : BaseController
    {
        public PromotionController(DatabaseContext context) : base(context) { }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Installment()
        {
            return View();
        }
        public IActionResult InstallmentAdd()
        {
            return View();
        }
        public IActionResult InstallmentEdit(int Id)
        {
            ViewData["ID"] = Id;
            return View();
        }
    }
}
