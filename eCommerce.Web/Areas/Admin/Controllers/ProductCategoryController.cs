using eCommerce.Web.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace eCommerce.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductCategoryController : BaseController
    {
        public ProductCategoryController(DatabaseContext context) : base(context){}

        [Route("Admin/Product/Category")]
        public IActionResult Index()
        {
            //ProductCategoryController db = new ProductCategoryController(_context);
            //var data = db.Get("");
            //if (data.IsSuccess)
            //    return View(data.Result);
            //else return View(new List<ProductCategoryResponse>());
            return View();
        }

        public PartialViewResult AddPartial()
        {
            return PartialView();
        }

        public PartialViewResult EditPartial()
        {
            return PartialView();
        }
    }
}
