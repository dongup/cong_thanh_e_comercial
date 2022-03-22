using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Areas.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerce.Web.Models;
using eCommerce.Web.Entities;
using eCommerce.Web.Areas.Api.Models;
using eCommerce.Web.Areas.Api.Models.Products.Product;
using Microsoft.AspNetCore.Http;

namespace eCommerce.Web.Controllers
{
    [Route("san-pham")]
    public class SearchController : BaseController
    {
        public SearchController(DatabaseContext context) : base(context)
        {

        }
      

        public IActionResult Index([FromQuery] int Page = 1, [FromQuery] bool Box = false, [FromQuery] bool Sort = true)
        {
            try
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
                }
                catch (Exception)
                {

                }
                ViewData["PageIndex"] = Page;
                ViewData["Sort"] = Sort;
                ViewData["Box"] = Box;
                string QueryString = Request.QueryString.Value.Replace("?", "");
                ViewData["Products"] = Products(QueryString);
                ViewData["Categories"] = Categories();
            }
            catch (Exception)
            {
            }
            return View();
        }

        private PaginationResponse<ProductSimpleMostRespone> Products(string QueryString)
        {
            ProductController product = new ProductController(_context);
            ResponseModel res = product.Get(QueryString,true);
            if (res.IsSuccess)
            {
                var paginationResponse = (PaginationResponse<ProductSimpleMostRespone>)res.Result ?? new PaginationResponse<ProductSimpleMostRespone>();
                var products = paginationResponse.Data;
                paginationResponse.Data = products;
                return paginationResponse;
            }
            else
            {
                return new PaginationResponse<ProductSimpleMostRespone>();
                throw new Exception(res.Message);
            }
        }

        private List<CategoryResponse> Categories()
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
