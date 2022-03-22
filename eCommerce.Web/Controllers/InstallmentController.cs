using eCommerce.Web.Areas.Api.Controllers;
using eCommerce.Web.Areas.Api.Models.Installment;
using eCommerce.Web.Areas.Api.Models.Products.Product;
using eCommerce.Web.Entities;
using eCommerce.Web.Entities.Identity;
using eCommerce.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Controllers
{
    [Route("tra-gop")]
    public class InstallmentController : BaseController
    {
        public readonly UserManager<UserEntity> _userManager;
        public InstallmentController(DatabaseContext context, UserManager<UserEntity> _userManager) : base(context)
        {
            this._userManager = _userManager;
        }
        [Route("{url}")]
        public IActionResult Index(string url)
        {
            var product = Product(url);

            ViewData["URL"] = url;
            ViewData["ID"] = product.Id;

            //   Areas.Api.Controllers.Installment.InstallmentController c = new Areas.Api.Controllers.Installment.InstallmentController(_context, _userManager);
            return View(product);
        }
        public IActionResult Index()
        {
            return View();
        }
        public ProductResponse Product(string ProductUrl)
        {
            ProductController product = new ProductController(_context);
            ResponseModel res = product.GetByUrl(ProductUrl, RaiseCountAccess: true);

            if (res.IsSuccess)
            {

                return (ProductResponse)res.Result ?? new ProductResponse();
            }
            else
            {
                throw new Exception(res.Message);
            }
        }
    }

}
