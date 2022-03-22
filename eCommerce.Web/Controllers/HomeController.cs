using eCommerce.Utils;
using eCommerce.Web.Areas.Api.Controllers;
using eCommerce.Web.Areas.Api.Controllers.General;
using eCommerce.Web.Areas.Api.Models;
using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Areas.Api.Models.Posts;
using eCommerce.Web.Areas.Api.Models.Products.Product;
using eCommerce.Web.Areas.Api.Models.Products.ProductCatergory;
using eCommerce.Web.Areas.Api.Models.Promotion;
using eCommerce.Web.Entities;
using eCommerce.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace eCommerce.Web.Controllers
{

    public class HomeController : BaseController
    {

        public HomeController(DatabaseContext context) : base(context)
        {
        }

        public IActionResult Index()
        {
            Global.Origin = $"{Request.Scheme}://{Request.Host}";

            IntroduceController introduceController = new IntroduceController(_context);
            IntroduceResponse info = introduceController.Get().Result as IntroduceResponse;
            try
            {
                ViewData["ProductCategoryGroups"] = ProductCategoryGroups() ?? new List<ProductCategoryGroupResponse>();

                try
                {
                    ViewData["Popups"] = Popups() ?? new List<PopupResponse>();
                }
                catch (Exception e)
                {

                }
              
                ViewData["Promotions"] = Promotions() ?? new List<PromotionResponse>();
                ViewData["Posts"] = Posts() ?? new List<PostResponse>();
            }
            catch (Exception e)
            {
                return Error();
            }
           
            return View(info);
        }

        public List<ProductCategoryGroupResponse> ProductCategoryGroups()
        {
            ProductCategoryGroupController productCategoryGroup = new ProductCategoryGroupController(_context);
            ResponseModel res = productCategoryGroup.Get();
            if (res.IsSuccess)
            {
                return (List<ProductCategoryGroupResponse>)res.Result;
            }
            else
            {
                throw new Exception(res.Message);
            }
        }

        public List<PromotionResponse> Promotions()
        {
            PromotionController promo = new PromotionController(_context);
            ResponseModel res = promo.ActivePromotionHome();
            if (res.IsSuccess)
            {
                var result = (List<PromotionResponse>)res.Result;
                return result;
            }
            else
            {
                throw new Exception(res.Message);
              //  return new List<PromotionResponse>();
            }
            
        }

        public List<PopupResponse> Popups()
        {
            PopupController popup = new PopupController(_context);
            ResponseModel res = popup.PopupIsShow();
            if (res.IsSuccess)
            {
                return (List<PopupResponse>)res.Result;
            }
            else
            {
                throw new Exception(res.Message);
            }

        }

        public TopProductResponse ProductToday()
        {
            ProductController promo = new ProductController(_context);
            ResponseModel res = promo.TopSale();
            if (res.IsSuccess)
            {
                return (TopProductResponse)res.Result;
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
        public List<PostResponse> Posts()
        {
            Areas.Api.Controllers.PostController promo = new Areas.Api.Controllers.PostController(_context);
            ResponseModel res = promo.LastestPost(6);
            if (res.IsSuccess)
            {
                return (List<PostResponse>)res.Result;
            }
            else
            {
                throw new Exception(res.Message);
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}
