using eCommerce.Web.Areas.Api.Models.Products.Product;
using eCommerce.Web.Entities;
using eCommerce.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace eCommerce.Web.Areas.Admin.Controllers
{

    public class ProductController : BaseController
    {
        Api.Controllers.ProductController apiController;
        public ProductController(DatabaseContext context) : base(context)
        {
            apiController = new Api.Controllers.ProductController(_context);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Add()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult ExportExcel()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SyncPrice()
        {
            //    List<SyncPriceModelResponse> Results = new List<SyncPriceModelResponse>();
            //    var products = _context.Products.Select(n => new SyncPriceModelResponse()
            //    {
            //        GiaBanLe = n.GiaBanLe,
            //        GiaNiemYet = n.OriginPrice,
            //        ProductID = n.ProductCode,
            //        ProductName = n.ProductName,
            //        SoLuongTon = n.StockNumber,
            //    }).ToList();
            //    foreach (var oldPr in products)
            //    {
            //        var newPr = await getSingle(oldPr.ProductID);
            //        if (newPr == null) continue;
            //        if (newPr.GiaBanLe == null || newPr.GiaNiemYet == null)continue;
            //        if (newPr.GiaBanLe == oldPr.GiaBanLe && newPr.GiaNiemYet == oldPr.GiaNiemYet && newPr.SoLuongTon == oldPr.SoLuongTon) continue;
            //        newPr.GiaBanLeCu = oldPr.GiaBanLe.GetValueOrDefault();
            //        newPr.GiaNiemYetCu = oldPr.GiaNiemYet.GetValueOrDefault();
            //        newPr.SoLuongTonCu = oldPr.SoLuongTon.GetValueOrDefault();
            //        newPr.ProductName = oldPr.ProductName;
            //        Results.Add(newPr);
            //  }
            return View();
        }
        private async Task<SyncPriceModelResponse> getSingle(string code)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new System.Uri("https://apicongthanh.phanmemtotnhat.vn");
                var response = await client.GetAsync("api/search/Get_info_by_productID/" + code);
                if (response.IsSuccessStatusCode)
                {
                    var item = JsonConvert.DeserializeObject<ResponseModel>(await response.Content.ReadAsStringAsync());
                    var data = (item.Results as Newtonsoft.Json.Linq.JArray).ToObject<List<SyncPriceModelResponse>>();
                    if (data != null && data.Count > 0)
                        return data[0];
                }
            }
            catch (System.Exception)
            {
            }
            return null;
        }


        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var product = apiController.ByIdEntity(id);
            return View(product.Result as ProductResponse);

        }
        [Authorize(Roles = "Admin")]
        public IActionResult Detail(int id)
        {
            var product = apiController.ById(id);
            return View(product.Result);
        }
        [Authorize(Roles = "Admin,Sale,Intem")]
        public IActionResult PrintLabel()
        {
            return View();
        }
    }

}
