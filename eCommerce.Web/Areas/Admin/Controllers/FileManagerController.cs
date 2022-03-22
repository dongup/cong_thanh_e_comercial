using Microsoft.AspNetCore.Mvc;
using System;
using eCommerce.Web.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerce.Web.Areas.Api.Controllers.General;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace eCommerce.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Sale")]
    public class FileManagerController : BaseController
    {

        IWebHostEnvironment _environment;
        public FileManagerController(DatabaseContext context, IWebHostEnvironment environment) : base(context) { _environment = environment; }


        public IActionResult Index()
        {
            var forder = new FolderController(_context, _environment);
            return View(forder.Get().Result);
        }

        public PartialViewResult PartialFile()
        {
            var forder = new FolderController(_context, _environment);
            return PartialView(forder.Get().Result);
        }
    }
}
