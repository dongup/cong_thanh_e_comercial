using eCommerce.Web.Areas.Api.Controllers;
using eCommerce.Web.Areas.Api.Models;
using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Areas.Api.Models.Products.Product;
using eCommerce.Web.Areas.Api.Models.Promotion;
using eCommerce.Web.Entities;
using eCommerce.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Controllers
{
    public class PromoController : BaseController
    {
        public PromoController(DatabaseContext context) : base(context)
        {

        }

        [AcceptVerbs("GET", "HEAD", Route = "promo/{PromoUrl}")]
        public IActionResult Index(string PromoUrl, [FromQuery] int cate = 0, [FromQuery] int Page = 1, [FromQuery] bool Box = true, [FromQuery] bool Sort = true)
        {
            try
            {

                PopupController popup = new PopupController(_context);
                ResponseModel res = popup.PopupIsShow();
                if (res.IsSuccess)
                {
                    ViewData["Popups"] = res.Result;
                }
                else
                {
                    ViewData["Popups"] = res.Result; new List<PopupResponse>();
                }
                ViewData["PageIndex"] = Page;
                ViewData["Sort"] = Sort;
                ViewData["Box"] = Box;
                ViewData["CategoryId"] = cate;
                //ViewData["AllProduct"] = ProductRandom();
                string QueryString = Request.QueryString.Value.Replace("?", "");
                ViewData["Categories"] = Categories();
                ViewData["Pagination"] = Promotions(PromoUrl, QueryString);
            }
            catch
            {

            }
            return View();
        }

        public PromotionWithProductResponse Promotions(string PromoUrl, string QueryString)
        {
            PromotionController promotions = new PromotionController(_context);
            ResponseModel res = promotions.GetByUrl(PromoUrl, QueryString);
            if (res.IsSuccess)
            {
                return (PromotionWithProductResponse)res.Result;
            }
            else
            {
                throw new Exception(res.Message);
            }
        }
        public List<AllProductResponse> ProductRandom()
        {
            ProductController promo = new ProductController(_context);
            if (res.IsSuccess)
            {
                var rs = (PaginationResponse<AllProductResponse>)res.Result;
                return (List<AllProductResponse>)rs.Data;
            }
            else
            {
                throw new Exception(res.Message);
            }
        }
        public List<CategoryResponse> Categories()
        {
            ProductCategoryController categories = new ProductCategoryController(_context);
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
