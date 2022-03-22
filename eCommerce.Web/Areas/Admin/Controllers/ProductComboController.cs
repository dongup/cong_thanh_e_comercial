using eCommerce.Web.Entities;
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
    public class ProductComboController : BaseController
    {
        Api.Controllers.ProductController apiController;
        public ProductComboController(DatabaseContext context) : base(context)
        {
            apiController = new Api.Controllers.ProductController(_context);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Edit(int id)
        {
            return View();
        }
        public IActionResult Detail(int id)
        {

            return View();

        }
    }
}
