using eCommerce.Utils;
using eCommerce.Web.Areas.Api.Controllers.Product.Base;
using eCommerce.Web.Areas.Api.Models;
using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Areas.Api.Models.Products.Product;
using eCommerce.Web.Areas.Api.Models.Products.Property;
using eCommerce.Web.Areas.Api.Models.Promotion;
using eCommerce.Web.Entities;
using eCommerce.Web.Entities.Identity;
using eCommerce.Web.Entities.Product;
using eCommerce.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using static eCommerce.Web.Entities.General.FriendlyUrlEntity;
using static eCommerce.Web.Entities.Promotion.PromotionEntity;

namespace eCommerce.Web.Areas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles ="Admin, Sale")]
    public class ProductController : BaseProductController
    {
        public ProductController(DatabaseContext context,
            IConfiguration config = null,
            IWebHostEnvironment webHost = null,
            UserManager<UserEntity> userManager = null) : base(context, config, webHost, userManager)
        {

        }

        [HttpGet("AllProduct")]
        public ResponseModel GetAllProduct()
        {
            int pageItem = int.MaxValue;
            int pageIndex = 1;
            var query = _context.Products
                    .Include(x => x.ProductBrand.Logo)
                    .Include(x => x.ProductCategories).ThenInclude(x => x.Category)
                    .Include(x => x.PromotionProducts)
                    .OrderBy($"{nameof(ProductEntity.SaleOffPrice)} {"ASC"}")
                    .Select(x => new AllProductResponse(x)).ToList();

            res.Succeed(new PaginationResponse<AllProductResponse>(query, pageItem, pageIndex));

            return res;

        }

        /// <summary>
        /// Lấy những sản phẩm có giá khuyến mãi lớn nhất, Hien thi ngoai trang chu. Hiện tại ko sử dụng.
        /// </summary>
        /// <returns></returns>
        [HttpGet("TopSale")]
        public ResponseModel TopSale()
        {
            try
            {
                var query = _context.Products
                    .Include(n => n.PromotionProducts).ThenInclude(n => n.Promotion)
                    .Include(x => x.InstallmentPromotionProducts).ThenInclude(x => x.InstallmentPromotion)
                    .Include(x => x.ProductCategories).ThenInclude(x => x.Category)
                    .Include(x => x.ProductBrand.Logo)
                    .Include(x => x.InstallmentPromotionProducts)
                    .Include(x => x.PromotionProducts)
                    .Where(x => x.SaleOffPrice != x.OriginPrice && x.Status && x.StockNumber > 0)
                    .Select(x => new ProductSimpleMostRespone(x))
                    .ToList()
                    .OrderByDescending(x => x.SaleOff)
                    .ToList();

                int Count = query?.Count() ?? 0;
                var Products = query?.Take(10)?.ToList();
                //if (Count == 0)
                //{
                //    Products = (List<SimpleProductResponse>) GetRandomProduct().Result;
                //}
                res.Succeed(new TopProductResponse()
                {
                    Count = Count,
                    Products = Products
                });
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
                res.Result = ex.StackTrace;
            }

            return res;
        }

        /// <summary>
        /// Lấy những tất cả sản phẩm đang khuyến mãi
        /// </summary>
        /// <returns></returns>
        [HttpGet("AllSaleOff")]
        public ResponseModel AllSaleOff(bool priceSortOrder = false,
            string keyword = "",
            int brandId = 0,
            int categoryId = 0,
            int pageItem = 10,
            int pageIndex = 0)
        {
            try
            {
                string order = priceSortOrder ? "ASC" : "DESC";

                var query = _context.Products
                    .OrderBy($"{nameof(ProductEntity.GiaBanLe)} {order}")
                    .Include(n => n.PromotionProducts).ThenInclude(n => n.Promotion)
                    .Include(x => x.ProductCategories).ThenInclude(x => x.Category)
                    .Include(x => x.ProductBrand.Logo)
                    .Where(x =>
                        x.ProductName.Like(keyword)
                        && x.Status
                        && x.SaleOffPrice != x.OriginPrice
                        && (categoryId == 0 || x.ProductCategories.Select(x => x.CategoryId).Contains(categoryId))
                        && (x.ProductBrandId == brandId || brandId == 0)
                    )
                    .Select(x => new SimpleProductResponse(x))
                    .OrderByDescending(x => x.SaleOff).ToList();

                res.Succeed(new PaginationResponse<SimpleProductResponse>(query, pageItem, pageIndex));
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
                res.Result = ex.StackTrace;
            }

            return res;
        }

        /// <summary>
        /// Lấy ra những sản phẩm tương tự với sản phẩm hiện tại
        /// </summary>
        /// <param name="id">Mã sản phẩm hiện tại</param>
        /// <returns></returns>
        [HttpGet("RelatedProduct/{id}")]
        public ResponseModel RelatedProduct(int id)
        {
            try
            {
                //Lấy ra các danh mục của sản phẩm hiện tại
                var ctgryids = new List<int>();
                var product = _context.Products
                     .Include(n => n.PromotionProducts).ThenInclude(n => n.Promotion)
                    .Include(x => x.ProductCategories)
                    .Where(x => x.Id == id)
                    .FirstOrDefault();

                if (product != null)
                {
                    ctgryids = product.ProductCategories.Select(x => x.CategoryId).ToList();
                }

                var query = _context.Products
                     .Include(n => n.PromotionProducts).ThenInclude(n => n.Promotion)
                    .Include(x => x.ProductCategories).ThenInclude(x => x.Category)
                    .Include(x => x.ProductBrand.Logo)
                    .Where(x => //Ds giá lớn hơn sp hiện tại
                                (x.ProductCategories.Any(n => ctgryids.Contains(n.CategoryId)))
                                && x.Status
                                && x.Id != id
                                && x.SaleOffPrice > product.SaleOffPrice
                                && !x.IsCombo
                                )
                    .OrderBy(x => x.SaleOffPrice)
                    .Select(x => new SimpleProductResponse(x))
                    .Take(5)
                    .ToList();

                var query2 = _context.Products
                     .Include(n => n.PromotionProducts).ThenInclude(n => n.Promotion)
                    .Include(x => x.ProductCategories).ThenInclude(x => x.Category)
                    .Include(x => x.ProductBrand.Logo)
                    .Where(x =>  //Ds giá nhỏ hơn sp hiện tại
                                (x.ProductCategories.Any(n => ctgryids.Contains(n.CategoryId)))
                                && x.Status
                                && x.Id != id
                                && x.SaleOffPrice < product.SaleOffPrice
                                && !x.IsCombo
                                )
                    .OrderByDescending(x => x.SaleOffPrice)
                    .Select(x => new SimpleProductResponse(x))
                    .Take(5)
                    .ToList();
                query.AddRange(query2);
                res.Succeed(query);
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
                res.Result = ex.StackTrace;
            }

            return res;
        }

        /// <summary>
        /// Lấy ra danh sách sản phẩm /san-pham
        /// </summary>
        /// <param name="filterStr">Tham số lọc</param>
        /// <returns></returns>
        [HttpGet]
        public ResponseModel Get(string filterStr = "", bool IsSearch = false)
        {
            try
            {
                Dictionary<string, string> dics = GetParams(filterStr);
                //LogServices.WriteInfo("Filter: " + JsonConvert.SerializeObject(dics));

                //Lấy ra các bộ lọc chung
                dics.TryGetValue("brand", out string brand);
                brand = brand ?? "";
                dics.TryGetValue("price", out string price);
                price = price ?? "";
                dics.TryGetValue("cat", out string catStr);
                catStr = catStr ?? "0";
                dics.TryGetValue("keyword", out string keyword);
                keyword = keyword ?? "";
                keyword = WebUtility.UrlDecode(keyword);
                keyword = keyword.RemoveUnicode();
                dics.TryGetValue("categoryUrl", out string categoryUrl);
                categoryUrl = categoryUrl ?? "";
                dics.TryGetValue("page", out string pageIndexStr);
                pageIndexStr = pageIndexStr ?? "0";
                dics.TryGetValue("sort", out string sortStr);
                sortStr = sortStr ?? "true";

                int pageItem = 20;
                int.TryParse(catStr, out int cat);
                int.TryParse(pageIndexStr, out int pageIndex);
                bool.TryParse(sortStr, out bool sort);

                List<int> brands = brand.Split(',')?.Select(delegate (string x)
                {
                    int.TryParse(x, out int i);
                    return i;
                })?.Where(x => x != 0)?.ToList() ?? new List<int>();
                string order = sort ? "ASC" : "DESC";

                //Lấy ra các bộ lọc động
                var filters = GetFilterParams(dics);

                int fromPrice = 0;
                int toPrice = 0;
                if (price != "" && price.Contains("-"))
                {
                    int.TryParse(price.Split('-')[0], out fromPrice);
                    int.TryParse(price.Split('-')[1], out toPrice);
                }
                else
                {
                    fromPrice = 0;
                    toPrice = 0;
                }
                var query = _context.Products
                    .Include(n => n.PromotionProducts).ThenInclude(n => n.Promotion)
                    .Include(x => x.ProductBrand.Logo)
                    .Include(x => x.ProductCategories).ThenInclude(x => x.Category)
                    .Include(x => x.ProductProperties).ThenInclude(x => x.PropertyValues).ThenInclude(x => x.Value)
                    .Include(x => x.InstallmentPromotionProducts).ThenInclude(x => x.InstallmentPromotion)
                    .Include(n => n.ProductBrand)
                    .OrderBy($"{nameof(ProductEntity.GiaBanLe)} {order}").ThenByDescending(x => x.Status)
                    .Where(x => (IsSearch && (
                    (x.NomalizedProductName.Contains(keyword) || x.ProductCode.Contains(keyword))
                        && (string.IsNullOrEmpty(categoryUrl) || x.ProductCategories.Any(x => x.Category.FriendlyUrl == categoryUrl))
                        && (brands.Count() == 0 || brands.Contains((int)x.ProductBrandId))
                        && (x.GiaBanLe >= fromPrice || fromPrice == 0)
                        && (x.GiaBanLe <= toPrice || toPrice == 0)
                        && (cat == 0 || x.ProductCategories.Any(n => n.CategoryId == cat))
                        && !x.IsCombo
                        && (!string.IsNullOrEmpty(keyword) || x.Status)

                    ))// đóng isSearch
                    || (!IsSearch
                         && (((x.NomalizedProductName.Contains(keyword) || x.ProductCode.Contains(keyword))
                         && (!string.IsNullOrEmpty(keyword) || x.Status)
                         && (string.IsNullOrEmpty(categoryUrl) || x.ProductCategories.Any(x => x.Category.FriendlyUrl == categoryUrl))
                         && (brands.Count() == 0 || brands.Contains((int)x.ProductBrandId))
                         && (x.GiaBanLe >= fromPrice || fromPrice == 0)
                         && (x.GiaBanLe <= toPrice || toPrice == 0)
                         && (cat == 0 || x.ProductCategories.Any(n => n.CategoryId == cat))
                         && !x.IsCombo
                         //Sản phẩm phải có thuộc tính trong params filter và giá trị thuộc tính đó thỏa mãn giá trị trong filter
                         //hoặc params filter trống
                         //&& (filters == null || filters.Count() == 0
                         //    || (x.ProductProperties.Any(n => filters.Select(a => a.PropertyId).Contains(n.PropertyId)
                         //        && x.ProductProperties
                         //        //Lấy danh sách giá trị của thuộc tính
                         //        .SelectMany(n => n.PropertyValues.Select(a => a.ValueId))
                         //        //Kiểm tra xem có giá trị nào nằm trong filter hay không
                         //        .Intersect(filters.SelectMany(x => x.ValueIds)).Count() != 0)))
                         )// đóng IsSearch == false;
                    )
                    ))
                    .Select(n => new ProductSimpleMostRespone()
                    {
                        IsShowSticker = n.IsShowSticker,
                        StickerImage = n.StickerImage,
                        BrandName = n.ProductBrand.BrandName,
                        CategoryName = n.ProductCategories.FirstOrDefault().Category.CategoryName,
                        DiscountPrice = n.PromotionProducts.Where(x => x.ProductId == n.Id && x.Promotion.Status == PromoStatus.Activated && x.Promotion.EndDate >= DateTime.Now).Sum(x => x.DiscountQuantity),
                        IsInstallment0Percent = n.InstallmentPromotionProducts.Where(m => m.InstallmentPromotion.ToDate >= DateTime.Now.AddDays(-1) && m.ProductId == n.Id).FirstOrDefault() != null,
                        FriendlyUrl = n.FriendlyUrl,
                        GiaBanLe = n.GiaBanLe,
                        //GoldenCommitment = n.GoldenCommitment,
                        GurantyTime = n.GurantyTime,
                        HighlightProduct = n.HighlightProduct,
                        Id = n.Id,
                        InstallmentPrice = n.InstallmentPrice,
                        Origin = n.Origin,
                        OriginPrice = n.OriginPrice,
                        ProductCode = n.ProductCode,
                        ProductName = n.ProductName,
                        PromotionContent = n.PromotionContent,
                        Status = n.Status,
                        StockNumber = n.StockNumber,
                        ThumbNail = n.ThumbNail,
                        ProductProperties = n.ProductProperties.Select(n => new ProductPropertyResponse(n)).ToList()
                    })

                       .ToList();
                if (order == "ASC")
                    query = query.OrderBy(n => n.SaleOffPrice).ToList();
                else query = query.OrderByDescending(n => n.SaleOffPrice).ToList();
                for (int i = 0; i < query.Count; i++)
                {
                    query[i].SaleOffPrice = query[i].GiaBanLe - query[i].DiscountPrice;
                }

                if (filters != null && filters.Count > 0)
                    query = query.Where(x => x.ProductProperties.Any(n => filters.Any(f => f.PropertyId == n.PropertyId)
                    && n.Values.Any(val => filters.Where(k => k.PropertyId == val.PropertyId).FirstOrDefault().ValueIds.Contains(val.Id))
                    )
                    ).ToList();
                query = query.Where(x => (x.GiaBanLe >= fromPrice || fromPrice == 0) && (x.GiaBanLe <= toPrice || toPrice == 0)).ToList();

                res.Succeed(new PaginationResponse<ProductSimpleMostRespone>(query, pageItem, pageIndex));
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
                res.Result = ex.StackTrace;
            }

            return res;
        }

        /// <summary>
        /// Lấy ra danh sách sản phẩm trên trang admin
        /// </summary>
        /// <param name="sortOrder">Trình tự sắp xếp sản phẩm theo giá
        /// 1: giá gốc tăng dần
        /// 2: giá gốc giảm dần
        /// 3: giá bán lẻ tăng dần
        /// 4: giá bán lẻ giảm dần
        /// </param>
        /// <param name="keyword">Từ khóa tìm kiếm theo tên sản phẩm</param>
        /// <param name="isSortNewPrice"></param>
        /// <param name="fromPrice"></param>
        /// <param name="toPrice"></param>
        /// <param name="brandId">Mã nhãn hàng</param>
        /// <param name="categoryId"></param>
        /// <param name="pageIndex">Chỉ mục trang</param>
        /// <param name="pageItem">Số lượng sản phẩm</param>
        /// <returns></returns>
        [HttpGet("Admin")]
        public ResponseModel GetAdmin(
            int sortOrder = 0,
            string keyword = "",
            bool isSortNewPrice = false,
            int fromPrice = 0,
            int toPrice = 0,
            int brandId = 0,
            int categoryId = 0,
            int status = 100,
            int pageIndex = 0,
            int pageItem = 20)
        {
            try
            {
                string order = "";

                switch ((ProductSortOrder)sortOrder)
                {
                    case ProductSortOrder.GiaBanLeAsc:
                        order = $"GiaBanLe ASC";
                        break;
                    case ProductSortOrder.GiaBanLeDesc:
                        order = $"GiaBanLe DESC";
                        break;
                    case ProductSortOrder.OriginPriceAsc:
                        order = $"OriginPrice ASC";
                        break;
                    case ProductSortOrder.OriginPriceDesc:
                        order = $"OriginPrice DESC";
                        break;
                    case ProductSortOrder.AccessCountAsc:
                        order = $"AccessCount ASC";
                        break;
                    case ProductSortOrder.AccessCountDesc:
                        order = $"AccessCount DESC";
                        break;
                    default:
                        order = $"OriginPrice DESC";
                        break;
                }

                var statusbold = status == 0 ? false : true;
                keyword = keyword.RemoveUnicode();
                var query = _context.Products
                     .Include(n => n.PromotionProducts).ThenInclude(n => n.Promotion)
                    .Include(x => x.ProductBrand.Logo)
                    .Include(x => x.ProductCategories).ThenInclude(x => x.Category)
                    .Include(n => n.ProductBrand)
                    .Include(x => x.ProductPriceLogs)
                    .Include(x => x.InstallmentPromotionProducts)
                    .OrderBy(order)
                    .Where(x =>
                        (x.NomalizedProductName.Contains(keyword) || x.ProductCode.Contains(keyword))
                        && (status == 100 || statusbold == x.Status)
                        && (x.ProductBrandId == brandId || brandId == 0)
                        && (x.GiaBanLe >= fromPrice || fromPrice == 0)
                        && (x.GiaBanLe <= toPrice || toPrice == 0)
                        && (categoryId == 0 || x.ProductCategories.Any(n => n.CategoryId == categoryId))
                        && !x.IsCombo
                    )
                    .Select(n => new ProductSimpleMostRespone()
                    {
                        BrandName = n.ProductBrand.BrandName,
                        CategoryName = n.ProductCategories.FirstOrDefault().Category.CategoryName,
                        DiscountPrice = n.PromotionProducts.Where(x => x.ProductId == n.Id && x.Promotion.Status == PromoStatus.Activated && x.Promotion.EndDate >= DateTime.Now).Sum(x => x.DiscountQuantity),
                        IsInstallment0Percent = n.InstallmentPromotionProducts.Where(m => m.InstallmentPromotion.ToDate >= DateTime.Now.AddDays(-1) && m.ProductId == n.Id).FirstOrDefault() != null,
                        FriendlyUrl = n.FriendlyUrl,
                        GiaBanLe = n.GiaBanLe,
                        ProductCategories = n.ProductCategories.Select(x => new Models.CategoryResponse(x.Category)).ToList(),
                        ProductBrand = new Models.ProductBrandResponse { BrandName = n.ProductBrand.BrandName },
                        //GoldenCommitment = n.GoldenCommitment,
                        GurantyTime = n.GurantyTime,
                        HighlightProduct = n.HighlightProduct,
                        Id = n.Id,
                        InstallmentPrice = n.InstallmentPrice,
                        Origin = n.Origin,
                        OriginPrice = n.OriginPrice,
                        ProductCode = n.ProductCode,
                        ProductName = n.ProductName,
                        PromotionContent = n.PromotionContent,
                        Status = n.Status,
                        StockNumber = n.StockNumber,
                        ThumbNail = n.ThumbNail,
                        AccessCount = n.AccessCount,

                    })
                    .ToList();
                for (int i = 0; i < query.Count; i++)
                {
                    query[i].SaleOffPrice = query[i].GiaBanLe - query[i].DiscountPrice;
                }
                //if (isSortNewPrice)
                //{
                //    query = query.OrderByDescending(x => x.IsNewUpdatePrice);
                //}

                res.Succeed(new PaginationResponse<ProductSimpleMostRespone>(query, pageItem, pageIndex));
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }

            return res;
        }

        [HttpGet("ByName")]
        public ResponseModel GetByName(string keyword)
        {
            try
            {
                var result = _context.Products

                    .Where(delegate (ProductEntity x)
                    {
                        return x.ProductName.Like(keyword)
                        || x.ProductCode.Like(keyword)
                        && x.Status
                        && !x.IsCombo;
                    })
                    .Select(x => new SimpleProductResponse(x))
                    .ToList();
                res.Succeed(result);
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }

            return res;
        }

        [AllowAnonymous]
        [HttpGet("ById/{id}")]
        public ResponseModel ById(int id)
        {
            try
            {
                var result = _context.Products
                    .Include(x => x.OrderDetails).ThenInclude(x => x.Order)
                    .Include(x => x.GiftProduct.Product)
                    .Include(x => x.ProductImages).ThenInclude(x => x.Image)
                    .Include(x => x.ProductBrand.Logo)
                    .Include(x => x.ProductCategories).ThenInclude(x => x.Category)
                    .Include(x => x.ProductProperties).ThenInclude(x => x.PropertyValues).ThenInclude(x => x.Value)
                    .Include(x => x.ProductProperties).ThenInclude(x => x.Property)
                    .Include(x => x.ProductCombos)
                    .Include(x => x.PromotionProducts).ThenInclude(x => x.Promotion)
                    .Where(x => x.Id == id)
                    .Select(x => new ProductResponse()
                    {
                        ThumbNail = x.ThumbNail,
                        AccessCount = x.AccessCount,
                        //ComboId = (int)x.ComboId,
                        //Combos = x.ProductCombos.Select(n=> new Models.Products.ComboProduct.ComboResponse() { })
                        GiaBanLe = x.GiaBanLe,
                        GoldenCommitment = x.GoldenCommitment,
                        HighlightProduct = x.HighlightProduct,
                        HightLineProduct = x.HighlightProduct,
                        GurantyTime = x.GurantyTime,
                        PromotionContent = x.PromotionContent,
                        PromotionBranch = x.PromotionBranch,
                        PromotionBranchDeadline = x.PromotionBranchDeadline,
                        ProductCategories = x.ProductCategories.Select(x => new Models.CategoryResponse() { Id = x.Id, CategoryName = x.Category.CategoryName }).ToList(),
                        IsInstallment0Percent = x.InstallmentPromotionProducts.Where(n => n.InstallmentPromotion.ToDate >= DateTime.Now.AddDays(-1) && n.ProductId == x.Id).FirstOrDefault() != null,
                        ProductImages = x.ProductImages.Select(a => new FileResponse() { FilePath = a.Image.FilePath, ThumbNailPath = a.Image.ThumbNailPath }).ToList(),
                        ProductName = x.ProductName,
                        OriginPrice = x.OriginPrice,
                        ProductBrand = new Models.ProductBrandResponse() { BrandName = x.ProductBrand.BrandName },
                        StockNumber = x.StockNumber,
                        Description = x.Description,
                        Id = x.Id,
                        FriendlyUrl = x.FriendlyUrl,
                        InstallmentPrice = x.InstallmentPrice,
                        ProductProperties = x.ProductProperties.Select(a => new ProductPropertyResponse(a)).ToList(),
                        Status = x.Status,
                        DiscountPrice = x.PromotionProducts.Where(a => a.ProductId == x.Id && a.Promotion.Status == PromoStatus.Activated && a.Promotion.EndDate >= DateTime.Now).Sum(x => x.DiscountQuantity),
                        ProductCode = x.ProductCode,
                        IsShowSticker = x.IsShowSticker,
                        StickerImage = x.StickerImage
                    })
                    .FirstOrDefault();
                if (result == null) {
                    res.NotFound();
                    return res;
                }

                result.SaleOffPrice = result.GiaBanLe - result.DiscountPrice;

                var promo = _context.Promotions.Include(n => n.PromotionProducts)
                    .Where(x => x.EndDate >= DateTime.Now
                    && x.PromotionProducts.Any(i => i.ProductId == result.Id)
                    )
                    .Select(x => new PromotionResponse(x));
                result.Promotions = promo.ToList();

                res.Succeed(result);
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }

            return res;
        }

        [HttpGet("ByIdAllow/{id}")]
        public ResponseModel ByIdEntity(int id)
        {
            try
            {
                var result = _context.Products
                    .Include(x => x.OrderDetails).ThenInclude(x => x.Order)
                    .Include(x => x.GiftProduct.Product)
                    .Include(x => x.ProductImages).ThenInclude(x => x.Image)
                    .Include(x => x.ProductBrand.Logo)
                    .Include(x => x.ProductCategories).ThenInclude(x => x.Category)
                    .Include(x => x.ProductProperties).ThenInclude(x => x.PropertyValues).ThenInclude(x => x.Value)
                    .Include(x => x.ProductProperties).ThenInclude(x => x.Property)
                    .Include(x => x.ProductCombos)
                    .Include(x => x.PromotionProducts).ThenInclude(x => x.Promotion)
                    .Where(x => x.Id == id)
                    .Select(x => new ProductResponse(x))
                    .FirstOrDefault();
                result.SaleOffPrice = result.GiaBanLe - result.DiscountPrice;

                var promo = _context.Promotions.Include(n => n.PromotionProducts)
                    .Where(x => x.EndDate >= DateTime.Now
                    && x.PromotionProducts.Any(i => i.ProductId == result.Id)
                    )
                    .Select(x => new PromotionResponse(x));
                result.Promotions = promo.ToList();

                res.Succeed(result);
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }

            return res;
        }

        /// <summary>
        /// Su dung trong in label, Lấy ít thuộc tính, KO dùng ById ở trên vì by Id Lấy full thuộc tính => Chậm.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("GetById/{id}")]
        public ResponseModel GetById(int id)
        {
            try
            {
                var result = _context.Products
                    .Include(n => n.InstallmentPromotionProducts)
                    .Include(x => x.ProductBrand)
                    .Include(x => x.ProductCategories).ThenInclude(x => x.Category)
                    .Include(x => x.PromotionProducts)
                    .Include(x => x.InstallmentPromotionProducts)
                    .Include(x => x.PromotionProducts)
                    .Where(x => x.Id == id)
                    .Select(n => new ProductSimpleMostRespone()
                    {
                        BrandName = n.ProductBrand.BrandName,
                        CategoryName = n.ProductCategories.FirstOrDefault().Category.CategoryName,
                        DiscountPrice = n.PromotionProducts.Where(x => x.ProductId == n.Id && x.Promotion.Status == PromoStatus.Activated && x.Promotion.EndDate >= DateTime.Now).Sum(x => x.DiscountQuantity),
                        IsInstallment0Percent = n.InstallmentPromotionProducts.Where(m => m.InstallmentPromotion.ToDate >= DateTime.Now.AddDays(-1) && m.ProductId == n.Id).FirstOrDefault() != null,
                        FriendlyUrl = n.FriendlyUrl,
                        GiaBanLe = n.GiaBanLe,
                        GoldenCommitment = n.GoldenCommitment,
                        GurantyTime = n.GurantyTime,
                        HighlightProduct = n.HighlightProduct,
                        Id = n.Id,
                        InstallmentPrice = n.InstallmentPrice,
                        Origin = n.Origin,
                        OriginPrice = n.OriginPrice,
                        ProductCode = n.ProductCode,
                        ProductName = n.ProductName,
                        PromotionContent = n.PromotionContent,
                        Status = n.Status,
                        StockNumber = n.StockNumber,
                        ThumbNail = n.ThumbNail,
                        IsShowSticker = n.IsShowSticker,
                        StickerImage = n.StickerImage
                    })
                    .FirstOrDefault();
                if (result != null)
                {
                    result.SaleOffPrice = result.GiaBanLe - result.DiscountPrice;
                }
                res.Succeed(result);
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }

            return res;
        }

        [HttpGet("ByUrl/{productUrl}")]
        public ResponseModel GetByUrl(string productUrl, bool RaiseCountAccess = false)
        {
            try
            {
                var result = _context.Products
                    .Include(x => x.InstallmentPromotionProducts).ThenInclude(x => x.InstallmentPromotion)
                    .Include(x => x.OrderDetails).ThenInclude(x => x.Order)
                    .Include(x => x.GiftProduct.Product)
                    .Include(x => x.ProductImages).ThenInclude(x => x.Image)
                    .Include(x => x.ProductBrand.Logo)
                    .Include(x => x.ProductCategories).ThenInclude(x => x.Category)
                    .Include(x => x.ProductProperties).ThenInclude(x => x.PropertyValues).ThenInclude(x => x.Value)
                    .Include(x => x.ProductProperties).ThenInclude(x => x.Property)
                    .Include(x => x.ProductCombos)
                    .Include(x => x.PromotionProducts).ThenInclude(x => x.Promotion)
                    .Where(x => x.FriendlyUrl == productUrl)
                    .Select(x => new ProductResponse()
                    {
                        IsShowPrice = x.IsShowPrice,
                        IsShowSticker = x.IsShowSticker,
                        StickerImage = x.StickerImage,
                        ThumbNail = x.ThumbNail,
                        AccessCount = x.AccessCount,
                        PromotionBranch = x.PromotionBranch,
                        PromotionBranchDeadline = x.PromotionBranchDeadline,
                        GiaBanLe = x.GiaBanLe,
                        GoldenCommitment = x.GoldenCommitment,
                        HighlightProduct = x.HighlightProduct,
                        HightLineProduct = x.HighlightProduct,
                        GurantyTime = x.GurantyTime,
                        PromotionContent = x.PromotionContent,
                        ProductCategories = x.ProductCategories.Select(x => new Models.CategoryResponse() { Id = x.CategoryId, CategoryName = x.Category.CategoryName }).ToList(),
                        IsInstallment0Percent = x.InstallmentPromotionProducts.Where(n => n.InstallmentPromotion.ToDate >= DateTime.Now.AddDays(-1) && n.ProductId == x.Id).FirstOrDefault() != null,
                        ProductImages = x.ProductImages.Select(a => new FileResponse() { FilePath = a.Image.FilePath, ThumbNailPath = a.Image.ThumbNailPath }).ToList(),
                        ProductName = x.ProductName,
                        OriginPrice = x.OriginPrice,
                        ProductBrand = new Models.ProductBrandResponse() { BrandName = x.ProductBrand.BrandName, Id = x.ProductBrandId.GetValueOrDefault() },
                        StockNumber = x.StockNumber,
                        Description = x.Description,
                        Id = x.Id,
                        FriendlyUrl = x.FriendlyUrl,
                        InstallmentPrice = x.InstallmentPrice,
                        ProductProperties = x.ProductProperties.Select(a => new ProductPropertyResponse(a)).ToList(),
                        Status = x.Status,
                        Note = x.Note,
                        DiscountPrice = x.PromotionProducts.Where(a => a.ProductId == x.Id && a.Promotion.Status == PromoStatus.Activated && a.Promotion.EndDate >= DateTime.Now).Sum(x => x.DiscountQuantity),
                    }).FirstOrDefault();


                if (result == null) throw NotFoundException;

                result.SaleOffPrice = result.GiaBanLe - result.DiscountPrice;
                result.InstallmentPrice = result.InstallmentPrice - result.DiscountPrice;
                if (result.IsCombo)// nếu là combo thì lấy info combo
                {
                    var combo = _context.Combos
                        .Include(n => n.ComboImages).ThenInclude(n => n.Image)
                          .Include(n => n.ComboProducts).ThenInclude(n => n.Product)
                        //.Include(n => n.ComboImages).ThenInclude(n => n.Image)
                        .Where(n => n.Id == result.ComboId).FirstOrDefault();
                    if (combo != null)
                    {
                        result.SaleOff = 0;
                        result.ProductImages = combo.ComboImages.Select(n => new FileResponse(n.Image)).ToList();
                        result.ProductsCombo = combo.ComboProducts.Select(n => new SimpleProductResponse(n.Product, quantity: n.Quantity)).ToList();
                    }
                }


                // cộng lượt truy cập
                try
                {
                    var pr = _context.Products.Where(n => n.FriendlyUrl == result.FriendlyUrl).FirstOrDefault();
                    if (pr != null)
                    {
                        pr.AccessCount += 1;
                        _context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                }
                res.Succeed(result);
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }

            return res;
        }

        [HttpPost]
        public ResponseModel Post([FromBody] ProductRequest value)
        {
            var transaction = _context.Database.BeginTransaction();
            try
            {
                if (!string.IsNullOrEmpty(value.PromotionBranchDeadlineString))
                {
                    value.PromotionBranchDeadline = value.PromotionBranchDeadlineString.ToDateTime();
                }
                if (_context.Products.Any(x => x.ProductCode == value.ProductCode))
                {
                    throw new Exception("Mã sản phẩm đã được sử dụng, bạn vui lòng sử dụng mã khác!");
                }
                else if (_context.Products.Any(x => x.FriendlyUrl == value.FriendlyUrl))
                {
                    throw new Exception("Đường dẫn sản phẩm đã tồn tại, bạn vui lòng sử dụng đường dẫn khác!");
                }

                var entity = value.CopyTo(new ProductEntity());
                if (value.InstallmentPrice == 0)
                {
                    value.InstallmentPrice = value.SaleOffPrice;
                }
                else
                {
                    entity.InstallmentPrice = value.InstallmentPrice;
                }
                entity.CreatedUserId = UserId;
                entity.Status = true;
                entity.GiaBanLe = value.GiaBanLe;
                AddUrl(UrlType.Product, value.FriendlyUrl);
              
                _context.Products.Add(entity);
                _context.SaveChanges();

                _context.Entry(entity).Collection(x => x.ProductImages).Query().Include(x => x.Image).Load();

                int i = 0;
                foreach (var file in entity.ProductImages)
                {
                    LogServices.WriteInfo("Copy image: " + file.Image.FilePath);
                    file.Image.FilePath = _fileHelper.CopyImage(file.Image?.FilePath, GetProductImageSavePath(entity.FriendlyUrl), UploadController.UploadType.Product);
                    file.Image.ThumbNailPath = _fileHelper.CopyImage(file.Image?.ThumbNailPath, GetProductImageSavePath(entity.FriendlyUrl), UploadController.UploadType.Product);

                }

                _context.SaveChanges();
                res.Succeed();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                res.Failed(ex.Message);
                res.Result = ex.StackTrace;
                //res.Result = ex.InnerException?.Message;
            }

            return res;
        }

        [HttpPut("{id}")]
        public ResponseModel Put(int id, [FromBody] ProductRequest value)
        {

            var transaction = _context.Database.BeginTransaction();
            try
            {
                if (!string.IsNullOrEmpty(value.PromotionBranchDeadlineString))
                {
                    value.PromotionBranchDeadline = value.PromotionBranchDeadlineString.ToDateTime();

                }
                if (_context.Products.Any(x => x.ProductCode == value.ProductCode && x.Id != id))
                {
                    throw new Exception("Mã sản phẩm đã được sử dụng, bạn vui lòng sử dụng mã khác!");
                }
                else if (_context.Products.Any(x => x.FriendlyUrl == value.FriendlyUrl && x.Id != id))
                {
                    throw new Exception("Đường dẫn sản phẩm đã tồn tại, bạn vui lòng sử dụng đường dẫn khác!");
                }
                var entity = _context.Products
                    .Include(x => x.ProductBrand)
                    .Include(x => x.GiftProduct)
                    .Include(x => x.ProductImages).ThenInclude(x => x.Image)
                    .Include(x => x.ProductLogs)
                    .Include(x => x.ProductProperties).ThenInclude(x => x.PropertyValues)
                    .Include(x => x.ProductCategories)
                    .FirstOrDefault(x => x.Id == id);
                var OriginPriceOld = entity.OriginPrice;
                var GiaBanLeOld = entity.GiaBanLe;

                _context.ProductPriceLogs.Add(new ProductPriceLogEntity()
                {
                    GiaBanLe = entity.GiaBanLe,
                    SaleOffPrice = entity.SaleOffPrice,
                    OriginPrice = entity.OriginPrice,
                    SaleOffPriceOld = GiaBanLeOld,
                    OriginPriceOld = OriginPriceOld,
                    Note = $"{CurrentUser.FullName} đã cập nhập giá của sản phẩm: {entity.Id}",
                    CreatedUserId = UserId,
                    ProductId = entity.Id

                });


                if (entity == null) throw NotFoundException;

                UpdateUrl(entity.FriendlyUrl, value.FriendlyUrl, UrlType.Product);

                value.CopyTo(entity);
                entity.Id = id;
                if (value.InstallmentPrice == 0)
                {
                    value.InstallmentPrice = value.SaleOffPrice;
                }
                else
                {
                    entity.InstallmentPrice = value.InstallmentPrice;
                }
                entity.UpdatedUserId = UserId;
                entity.UpdatedDate = now;
                entity.ThumbNail = value.ThumbNail;
               

                //Thêm log sản phẩm
                _context.ProductLogs.Add(new ProductLogEntity()
                {
                    Content = $"{CurrentUser.FullName} đã cập nhập thông tin của sản phẩm: {entity.Id}",
                    CreatedUserId = UserId,
                    ProductId = entity.Id
                });

                _context.SaveChanges();

                _context.Entry(entity).Collection(x => x.ProductImages).Query().Include(x => x.Image).Load();

                //foreach (var file in entity.ProductImages)
                //{
                //    LogServices.WriteInfo("Copy image: " + file.Image.FilePath);
                //    LogServices.WriteInfo("Copy image: " + file.Image.ThumbNailPath);


                //    file.Image.FilePath = _fileHelper.CopyImage(file.Image.FilePath, GetProductImageSavePath(entity.FriendlyUrl), UploadController.UploadType.Product);
                //    file.Image.ThumbNailPath = _fileHelper.CopyImage(file.Image.ThumbNailPath, GetProductImageSavePath(entity.FriendlyUrl), UploadController.UploadType.Product);

                //}
                _context.SaveChanges();
                res.Succeed();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                res.Failed(ex.Message);
                res.Result = ex.StackTrace;
            }

            return res;
        }

        /// <summary>
        /// Cập nhập giá cho sản phẩm
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPut("Price/{id}")]
        public ResponseModel UpdatePrice(int id, [FromBody] ProductPriceRequest value)
        {
            try
            {
                var entity = _context.Products
                    .FirstOrDefault(x => x.Id == id);
                entity.UpdatedUserId = UserId;
                entity.UpdatedDate = now;

                var OriginPriceOld = entity.OriginPrice;
                var SaleOffPriceOld = entity.SaleOffPrice;
                entity.OriginPrice = value.OriginPrice;
                entity.GiaBanLe = value.GiaBanLe;

                _context.SaveChanges();

                _context.ProductLogs.Add(new ProductLogEntity()
                {
                    Level = ProductLogEntity.LogLevel.Information,
                    Content = $"{CurrentUser.FullName} đã cập nhập giá của sản phẩm: {entity.Id}",
                    CreatedUserId = UserId,
                    ProductId = entity.Id
                });

                _context.ProductPriceLogs.Add(new ProductPriceLogEntity()
                {
                    OriginPrice = entity.OriginPrice,
                    OriginPriceOld = OriginPriceOld,
                    SaleOffPrice = entity.GiaBanLe,
                    SaleOffPriceOld = SaleOffPriceOld,
                    Note = $"{CurrentUser.FullName} đã cập nhập giá của sản phẩm: {entity.Id}",
                    CreatedUserId = UserId,
                    ProductId = entity.Id
                });

                _context.SaveChanges();
                res.Succeed(new SimpleProductResponse(entity));
            }
            catch (Exception ex)
            {
                if (!EntityExists(id))
                {
                    res.NotFound();
                }
                else
                {
                    res.Failed(ex.Message);
                    res.Result = ex.StackTrace;
                }
            }

            return res;
        }

        /// <summary>
        /// Cập nhập số lượng tồn cho sản phẩm
        /// </summary>
        /// <param name="id">Mã sản phẩm</param>
        /// <param name="stock">Số lượng tồn mới</param>
        /// <returns></returns>
        [HttpPut("StockNumber/{id}")]
        public ResponseModel UpdateStockNumber(int id, int stock)
        {
            try
            {
                var entity = _context.Products
                    .FirstOrDefault(x => x.Id == id);
                entity.UpdatedUserId = UserId;
                entity.UpdatedDate = now;
                entity.StockNumber = stock;

                _context.SaveChanges();
                res.Succeed(new ProductResponse(entity));
            }
            catch (Exception ex)
            {
                if (!EntityExists(id))
                {
                    res.NotFound();
                }
                else
                {
                    res.Failed(ex.Message);
                }
            }

            return res;
        }

        /// <summary>
        /// Kiem tra san pham co tra gop 0% ko
        /// </summary>
        /// <returns></returns>
        [HttpGet("IsInstallment/{id}")]
        public ResponseModel isPromoInstal(int id)
        {
            try
            {
                var rs = _context.InstallmentPromotionProducts
                    .Where(n => n.ProductId == id
                    && n.InstallmentPromotion.FromDate <= now && n.InstallmentPromotion.ToDate >= now)
                    .FirstOrDefault();

                if (rs == null)
                    res.Failed("Sản phẩm không trả góp 0%");
                else

                    res.Succeed("Sản phẩm có trả góp 0%");
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }

            return res;
        }




        /// <summary>
        /// Bán hoặc dừng bán sp
        /// </summary>
        /// <param name="id">Mã sản phẩm</param>
        /// <param name="status">true = bán, fales = dừng bán</param>
        /// <returns></returns>
        [HttpPost("ToggleStatus/{id}/{status}")]
        public ResponseModel ToggleStatus(int id, bool status)
        {
            try
            {
                var entity = _context.Products
                    .FirstOrDefault(x => x.Id == id);
                entity.UpdatedUserId = UserId;
                entity.UpdatedDate = now;
                entity.Status = status;

                _context.SaveChanges();
                res.Succeed(new ProductResponse(entity));
            }
            catch (Exception ex)
            {
                if (!EntityExists(id))
                {
                    res.NotFound();
                }
                else
                {
                    res.Failed(ex.Message);
                }
            }

            return res;
        }

        [HttpDelete("{id}")]
        public ResponseModel Delete(int id)
        {
            try
            {
                var entity = _context.Products.Find(id);
                _context.Products.Remove(entity);
                DeleteUrl(entity.FriendlyUrl);

                _context.SaveChanges();
                res.Succeed();
            }
            catch (Exception ex)
            {
                if (!EntityExists(id))
                {
                    res.NotFound();
                }
                else
                {
                    res.Failed(ex.Message);
                }
            }

            return res;
        }


        /// <summary>
        /// Lấy tất cả sản phẩm đang bán, 
        /// dùng trong trang thêm sửa chương trình trả góp 0%
        /// </summary>
        /// <returns></returns>
        [HttpGet("AllProductOnSale")]
        public ResponseModel AllProductOnSale()
        {
            var query = _context.Products
                    .Include(x => x.ProductBrand)
                    .Include(n => n.PromotionProducts).ThenInclude(n => n.Promotion)
                    .OrderBy(n => n.ProductCode)
                    .Where(n => n.Status)
                    .Select(n => new ProductSimpleMostRespone()
                    {
                        Id = n.Id,
                        ProductCode = n.ProductCode,
                        BrandName = n.ProductBrand.BrandName,
                        ProductName = n.ProductName,
                        OriginPrice = n.OriginPrice,
                        GiaBanLe = n.GiaBanLe,
                        StockNumber = n.StockNumber,
                        InstallmentPrice = n.InstallmentPrice,
                        DiscountPrice = n.PromotionProducts.Where(n => n.Promotion.EndDate >= DateTime.Now).Sum(n => n.DiscountQuantity)

                    }).ToList();
            for (int i = 0; i < query.Count; i++)
            {
                query[i].SaleOffPrice = query[i].SaleOffPrice - query[i].DiscountPrice;
            }

            res.Succeed(query);

            return res;

        }

        /// <summary>
        /// gửi danh sách sản phẩm cần đồng bộ lên update.
        /// </summary>
        /// <returns></returns>

        [HttpPost("syncPrice")]
        public async Task<ResponseModel> syncPrice(List<SyncPriceModelResponse> datas)
        {
            if (datas != null)
            {
                var listLogPrice = new List<ProductPriceLogEntity>();
                var ids = datas.Select(n => n.ProductID).ToList();
                var products = _context.Products.Where(n => ids.Any(i => i == n.ProductCode)).ToList();
                for (int i = 0; i < products.Count(); i++)
                {

                    var prUpdate = datas.Where(n => n.ProductID?.Trim() == products[i].ProductCode.Trim()).FirstOrDefault();
                    if (prUpdate.GiaBanLe != products[i].GiaBanLe || prUpdate.GiaNiemYet != products[i].OriginPrice)
                        listLogPrice.Add(new ProductPriceLogEntity()
                        {
                            OriginPrice = prUpdate.GiaNiemYet.GetValueOrDefault(),
                            OriginPriceOld = prUpdate.GiaNiemYetCu,
                            SaleOffPrice = prUpdate.GiaBanLe.GetValueOrDefault(),
                            SaleOffPriceOld = prUpdate.GiaBanLeCu,
                            Note = $"{CurrentUser.FullName} đã cập nhập giá của sản phẩm bằng tool sync từ phần mềm tốt nhất: {products[i].Id}",
                            CreatedUserId = UserId,
                            ProductId = products[i].Id,
                            CreatedDate = DateTime.Now
                        });

                    products[i].OriginPrice = prUpdate.GiaNiemYet.GetValueOrDefault();
                    products[i].GiaBanLe = prUpdate.GiaBanLe.GetValueOrDefault();
                    products[i].StockNumber = prUpdate.SoLuongTon.GetValueOrDefault();
                    products[i].HighlightProduct = prUpdate.GhiChu;
                    products[i].Origin = prUpdate.XuatSu;
                    products[i].GurantyTime = prUpdate.HanSuDung;
                    products[i].PromotionContent = prUpdate.ThongTinKhuyenMai;
                    products[i].ProductName = prUpdate.TenSanPham;
                    products[i].UpdatedDate = DateTime.Now;


                }
                var count = await _context.SaveChangesAsync();
                try
                {
                    if (listLogPrice.Count > 0)
                    {
                        _context.ProductPriceLogs.AddRange(listLogPrice);
                        _context.SaveChanges();

                    }
                }
                catch (Exception)
                {
                }
                res.IsSuccess = true;
                res.Result = count;
            }
            return res;
        }


        /// <summary>
        /// Lấy danh sách sản phẩm cần đồng bộ về.
        /// </summary>
        /// <returns></returns>
        [HttpGet("syncPrice")]
        public async Task<ResponseModel> GetSyncPrice()
        {
            List<SyncPriceModelResponse> Results = new List<SyncPriceModelResponse>();
            var products = _context.Products.Select(n => new SyncPriceModelResponse()
            {
                GiaBanLe = n.GiaBanLe,
                GiaNiemYet = n.OriginPrice,
                ProductID = n.ProductCode,
                SoLuongTon = n.StockNumber,
                GhiChu = n.HighlightProduct,
                HanSuDung = n.GurantyTime,
                XuatSu = n.Origin,
                TenSanPham = n.ProductName,
                ThongTinKhuyenMai = n.PromotionContent
            });
            var All = await getAll();


            foreach (var oldPr in products)
            {
                var newPr = All.Where(n => (n.ProductID?.Trim() == oldPr.ProductID?.Trim()) && n.ProductID != null).FirstOrDefault();
                if (newPr == null) continue;
                if (newPr.GiaBanLe == null || newPr.GiaNiemYet == null) continue;
                if (newPr.GiaBanLe == oldPr.GiaBanLe && newPr.GiaNiemYet == oldPr.GiaNiemYet && newPr.SoLuongTon == oldPr.SoLuongTon && newPr.GhiChu == oldPr.GhiChu && newPr.XuatSu == oldPr.XuatSu && newPr.TenSanPham == oldPr.TenSanPham && newPr.HanSuDung == oldPr.HanSuDung && newPr.ThongTinKhuyenMai == oldPr.ThongTinKhuyenMai) continue;
                newPr.GiaBanLeCu = oldPr.GiaBanLe.GetValueOrDefault();
                newPr.GiaNiemYetCu = oldPr.GiaNiemYet.GetValueOrDefault();
                newPr.SoLuongTonCu = oldPr.SoLuongTon.GetValueOrDefault();

                Results.Add(newPr);
            }
            res.Result = Results;
            res.IsSuccess = true;
            return res;
        }
        private async Task<List<SyncPriceModelResponse>> getAll()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new System.Uri("https://apicongthanh.phanmemtotnhat.vn");
                var response = await client.GetAsync("api/search/Get_info_by_productID/all");
                if (response.IsSuccessStatusCode)
                {
                    var item = JsonConvert.DeserializeObject<ResponseModel>(await response.Content.ReadAsStringAsync());
                    var data = (item.Results as Newtonsoft.Json.Linq.JArray).ToObject<List<SyncPriceModelResponse>>();

                    return data;
                }
            }
            catch (System.Exception)
            {
            }
            return null;
        }
    }
}