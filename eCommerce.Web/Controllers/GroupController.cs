using eCommerce.Web.Areas.Admin.Controllers;
using eCommerce.Web.Areas.Api.Controllers;
using eCommerce.Web.Areas.Api.Models;
using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Entities;
using eCommerce.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
namespace eCommerce.Web.Controllers
{
    public class GroupController : BaseController
    {
        public GroupController(DatabaseContext context) : base(context)
        {

        }

        [AcceptVerbs("GET", "HEAD", Route = "Group/{Url}")]
        public IActionResult Index(string Url, [FromQuery] bool Box = true, [FromQuery] bool Sort = true)
        {
            try
            {

                Areas.Api.Controllers.PopupController popup = new Areas.Api.Controllers.PopupController(_context);
                ResponseModel res = popup.PopupIsShow();
                if (res.IsSuccess)
                {
                    ViewData["Popups"] = res.Result;
                }
                else
                {
                    ViewData["Popups"] = res.Result; new List<PopupResponse>();
                }
                Areas.Api.Controllers.Product.ProductGroupController productGroupController = new Areas.Api.Controllers.Product.ProductGroupController(_context);
                ViewBag.Products = productGroupController.GetByUrl(Url, Sort).Result;
                ViewData["Categories"] = Categories();
                ViewData["Sort"] = Sort;
                ViewData["Box"] = Box;
            }
            catch
            {

            }
            return View();
        }

        [AcceptVerbs("GET", "HEAD", Route = "IFrameGroup/{Url}/{itemPerRow}/{countRows}/{isShowSlide}")]
        public IActionResult IFrame(string Url, int itemPerRow = 4, int countRows = 3, int isShowSlide = 1)
        {
            try
            {
                ViewBag.IsShowSlide = isShowSlide;
                Areas.Api.Controllers.Product.ProductGroupController productGroupController = new Areas.Api.Controllers.Product.ProductGroupController(_context);
                ViewBag.Products = productGroupController.GetFrame(Url, itemPerRow: itemPerRow, countRow: countRows, isShowSlide).Result;
            }
            catch
            {
            }
            return View();
        }
        public List<CategoryResponse> Categories()
        {
            Areas.Api.Controllers.ProductCategoryController categories = new Areas.Api.Controllers.ProductCategoryController(_context);
            ResponseModel res = categories.Get();
            if (res.IsSuccess)
            {
                return (List<CategoryResponse>)res.Result;
            }
            else
            {
                throw new Exception(res.Message);
            }
        }
    }
}
