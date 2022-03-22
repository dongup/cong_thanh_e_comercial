using eCommerce.Web.Areas.Api.Controllers.General;
using eCommerce.Web.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace eCommerce.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class IntroManagerController : BaseController
    {
        
        public IntroManagerController(DatabaseContext _context) : base(_context)
        {
          
        }
        public IActionResult Index()
        {
            IntroduceController introduceController = new IntroduceController(_context);
            var info = introduceController.Get();
            return View(info.Result);
        }
    }
}
