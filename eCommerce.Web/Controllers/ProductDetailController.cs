using eCommerce.Web.Areas.Api.Models.Products.Product;
using eCommerce.Web.Areas.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerce.Web.Models;
using eCommerce.Web.Entities;

namespace eCommerce.Web.Controllers
{
    public class ProductDetailController : BaseController
    {
        public ProductDetailController(DatabaseContext context) : base(context)
        {

        }

        [AcceptVerbs("GET", "HEAD", Route = "productdetail/{ProductUrl}")]
        //[HttpGet("{ProductUrl}")]
        public IActionResult Index(string ProductUrl)
        {
            try
            {
                ViewData["ProductUrl"] = ProductUrl;
                ProductResponse ProductResult = Product(ProductUrl);
                ViewData["Product"] = ProductResult;
                ViewData["ProductRelated"] = ProductRelated(ProductResult.Id);
                ViewData["DetailColumnProduct"] = string.IsNullOrEmpty(ProductResult.PromotionContent) ? 7 : 4;
                ViewData["PromoCloumnProduct"] = string.IsNullOrEmpty(ProductResult.PromotionContent) ? 4 : 3;
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
            return View();
        }

        public ProductResponse Product(string ProductUrl)
        {
            ProductController product = new ProductController(_context);
            ResponseModel res = product.GetByUrl(ProductUrl,RaiseCountAccess:true);

            if (res.IsSuccess)
            {
               
                return (ProductResponse)res.Result ?? new ProductResponse();
            }
            else
            {
                throw new Exception(res.Message);
            }
        }

        public List<SimpleProductResponse> ProductRelated(int ProductId)
        {
            ProductController product = new ProductController(_context);
            ResponseModel res = product.RelatedProduct(ProductId);
            if (res.IsSuccess)
            {
                return (List<SimpleProductResponse>)res.Result;
            }
            else
            {
                throw new Exception(res.Message);
            }
        }
    }
}
