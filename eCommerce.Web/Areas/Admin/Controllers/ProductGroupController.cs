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
    public class ProductGroupController : BaseController
    {
        public ProductGroupController(DatabaseContext context) : base(context) { }

        [Route("/admin/product-group")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("/admin/product-group/add")]
        public IActionResult Add()
        {
            return View();
        }

        [Route("/admin/product-group/detail/{id}")]
        public IActionResult Detail(int id)
        {
            ViewData["Id"] = id;
            return View();
        }
    }
}
