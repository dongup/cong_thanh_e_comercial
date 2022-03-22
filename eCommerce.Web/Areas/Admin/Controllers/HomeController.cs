using eCommerce.Web.Areas.Api.Controllers;
using eCommerce.Web.Entities;
using eCommerce.Web.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

namespace eCommerce.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {


        public HomeController(DatabaseContext context) : base(context)
        {
        }

        public IActionResult Index()
        {
            if (CurrentUser != null)
            {
                if (CurrentUser.RoleName == "Intem")
                {
                    return Redirect("/admin/product/printlabel");
                }else
                return Redirect("/admin/dashboard");
            }
            return View();
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}
