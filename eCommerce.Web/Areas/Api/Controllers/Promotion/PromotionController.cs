using eCommerce.Utils;
using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Areas.Api.Models.Products.Product;
using eCommerce.Web.Areas.Api.Models.Promotion;
using eCommerce.Web.Entities;
using eCommerce.Web.Entities.Promotion;
using eCommerce.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using static eCommerce.Web.Entities.General.FriendlyUrlEntity;
using System.Linq.Dynamic.Core;
using static eCommerce.Web.Entities.Promotion.PromotionEntity;
using eCommerce.Web.Areas.Api.Controllers.Product.Base;
using System.Collections.Generic;
using eCommerce.Web.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using eCommerce.Web.Areas.Api.Models.Products.ProductGroup;
using eCommerce.Web.Areas.Api.Models;

namespace eCommerce.Web.Areas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionController : BaseProductController
    {
        //private static string giaTotUrl = "gia-tot-hom-nay";

        public PromotionController(DatabaseContext context, UserManager<UserEntity> userManager = null) : base(context, userManager: userManager)
        {

        }

        /// <summary>
        /// Lấy ra những chương trình giảm giá hiện đang hoạt động
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet("ActivePromotion")]
        // public ResponseModel ActivePromotionTesst()
        public ResponseModel ActivePromotion()
        {

            try
            {
                var result = _context.Promotions

                    .OrderBy(x => x.PriorityPromotion).ThenBy(x => x.CreatedDate)
                    .Where(delegate (PromotionEntity x)
                    {
                        return now.Beetween(x.StartDate, x.EndDate) && x.Status == PromoStatus.Activated;
                    })
                    .Select(entity =>
                    new PromotionResponse
                    {
                        Name = entity.Name,
                        BackgroundColor = entity.BackgroundColor,
                        Banner = entity.Banner,
                        Priority = entity.PriorityPromotion,
                        Description = entity.Description,
                        DiscountPercent = entity.DiscountPercent,
                        DiscountQuantity = entity.DiscountQuantity,
                        MaximumDiscount = entity.MaximumDiscount,
                        MinimumDiscount = entity.MinimumDiscount,
                        StartDate = entity.StartDate.ToString("HH:mm dd/MM/yyyy"),
                        EndDate = entity.EndDate.ToString("HH:mm dd/MM/yyyy"),
                        FriendlyUrl = entity.FriendlyUrl,
                        Status = (int)entity.Status,
                        DiscountType = (int)entity.DiscountType,
                        StickerImage = entity.StickerImage ?? "",
                        IsShowSticker = entity.IsShowSticker,
                        PromotionProducts = _context.PromotionProducts.Where(x => x.PromotionId == entity.Id).Select(x => new PromotionProductResponse
                        {
                            PromotionId = x.PromotionId,
                            ProductId = x.ProductId,
                            DiscountQuantity = x.DiscountQuantity,
                            MaximumDiscount = x.MaximumDiscount,
                            DiscountType = x.DiscountType,
                            SaleOffPrice = x.SaleOffPrice,
                            // Product = new SimpleProductResponse(x.Product),
                            Product = _context.Products.Where(product => product.Id == x.ProductId).Select(product =>
                                 new SimpleProductResponse
                                 {
                                     StickerImage = product.StickerImage,
                                     IsShowSticker = product.IsShowSticker,
                                     ProductName = product.ProductName,
                                     ThumbNail = product.ThumbNail,
                                     OriginPrice = product.OriginPrice,
                                     GiaBanLe = product.GiaBanLe,
                                     FriendlyUrl = product.FriendlyUrl,
                                     GurantyTime = product.GurantyTime,
                                     SaleOffPrice = 0,
                                     Origin = product.Origin,
                                     Temp = product.ProductCategories.Select(x => new CategoryResponse(x.Category)).FirstOrDefault(),
                                     StockNumber = product.StockNumber,
                                     Status = product.Status,
                                     ProductBrandId = product.ProductBrandId,
                                     ProductCode = product.ProductCode,
                                     CountOrder = product.OrderDetails.Count(),
                                     TotalSale = product.OrderDetails.Sum(x => x.BuyPrice * x.Quanity),
                                 }).OrderByDescending(x => x.CountOrder).FirstOrDefault(),
                            ProductName = x.Product.ProductName,
                            Thumbnail = x.Product.ThumbNail,
                            OriginPrice = x.Product.OriginPrice,
                        }).ToList(),
                        RowDisplay = entity.RowDisplay,
                        BorderColor = entity.BorderColor,
                        ActualRowDisplay = Global.ActualRowDisplayPromotion(entity.PromotionProducts.Count(), entity.RowDisplay),
                    })
                    .ToList();

                foreach (var promo in result)
                {
                    foreach (var productpromo in promo.PromotionProducts)
                    {
                        productpromo.Product.SaleOffPrice = productpromo.Product.GiaBanLe - SaleOfPriveCalc(productpromo.Product.Id);
                    }
                }
                res.Succeed(result);
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
                res.Result = ex.StackTrace;
            }
            return res;
        }

        /// <summary>
        /// Sự dug trên trang chủ. TOÀN_EDIT Từ câu  ActivePromotion
        /// </summary>
        /// <returns></returns>
        [HttpGet("ActivePromotionHome")]
        public ResponseModel ActivePromotionHome()
        {
            try
            {
                var result = _context.Promotions
                    .OrderBy(x => x.PriorityPromotion).ThenBy(x => x.CreatedDate)
                    .Where(x => x.StartDate <= now && x.EndDate >= now && x.Status == PromoStatus.Activated)
                    .Select(entity =>
                    new PromotionResponse
                    {
                        Name = entity.Name,
                        BackgroundColor = entity.BackgroundColor,
                        Banner = entity.Banner,
                        Priority = entity.PriorityPromotion,
                        Description = entity.Description,
                        DiscountPercent = entity.DiscountPercent,
                        DiscountQuantity = entity.DiscountQuantity,
                        MaximumDiscount = entity.MaximumDiscount,
                        MinimumDiscount = entity.MinimumDiscount,
                        StartDate = entity.StartDate.ToString("HH:mm dd/MM/yyyy"),
                        EndDate = entity.EndDate.ToString("HH:mm dd/MM/yyyy"),
                        FriendlyUrl = entity.FriendlyUrl,
                        Status = (int)entity.Status,
                        DiscountType = (int)entity.DiscountType,
                        StickerImage = entity.StickerImage ?? "",
                        IsShowSticker = entity.IsShowSticker,
                        PromotionProducts = entity.PromotionProducts.Select(x => new PromotionProductResponse
                        {
                            PromotionId = x.PromotionId,
                            ProductId = x.ProductId,
                            DiscountQuantity = x.DiscountQuantity,
                            MaximumDiscount = x.MaximumDiscount,
                            DiscountType = x.DiscountType,
                            SaleOffPrice = x.SaleOffPrice,
                            ProductName = x.Product.ProductName,
                            Thumbnail = x.Product.ThumbNail,
                            OriginPrice = x.Product.OriginPrice,
                            Product = new SimpleProductResponse()
                            {
                                Id = x.Product.Id,
                                StickerImage = x.Product.StickerImage,
                                IsShowSticker = x.Product.IsShowSticker,
                                ProductName = x.Product.ProductName,
                                ThumbNail = x.Product.ThumbNail,
                                OriginPrice = x.Product.OriginPrice,
                                GiaBanLe = x.Product.GiaBanLe,
                                FriendlyUrl = x.Product.FriendlyUrl,
                                GurantyTime = x.Product.GurantyTime,
                                SaleOffPrice = x.Product.GiaBanLe - entity.DiscountQuantity,
                                Origin = x.Product.Origin,
                                Temp = x.Product.ProductCategories.Select(x => new CategoryResponse(x.Category)).FirstOrDefault(),
                                StockNumber = x.Product.StockNumber,
                                Status = x.Product.Status,
                                ProductBrandId = x.Product.ProductBrandId,
                                ProductCode = x.Product.ProductCode,
                                CountOrder = x.Product.OrderDetails.Count(),
                                TotalSale = x.Product.OrderDetails.Sum(x => x.BuyPrice * x.Quanity),
                                IsInstallment0Percent = _context.InstallmentPromotionProducts.Where(m => m.InstallmentPromotion.ToDate >= DateTime.Now.AddDays(-1) && m.ProductId == x.ProductId).FirstOrDefault() != null,

                            },
                        }).OrderBy(n => n.Product.CountOrder).ToList(),
                        RowDisplay = entity.RowDisplay,
                        BorderColor = entity.BorderColor,
                        ActualRowDisplay = Global.ActualRowDisplayPromotion(entity.PromotionProducts.Count(), entity.RowDisplay),
                    });

                //foreach (var promo in result)
                //{
                //    for (int i = 0; i < promo.PromotionProducts.Count; i++)
                //    {
                //        var productpromo = promo.PromotionProducts[i];
                //        productpromo.Product.IsInstallment0Percent = isPromoInstal(productpromo.Product.Id);
                //        if(productpromo.Product.IsInstallment0Percent)
                //        return new ResponseModel() { Message = "TOANG CMNR" };

                //    }
                //}
                res.Succeed(result.ToList());
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
                res.Result = ex.StackTrace;
            }
            return res;
        }

        [HttpGet("Check/{id}")]
        public bool isPromoInstal(int id)
        {
            var rs = _context.InstallmentPromotionProducts
                .Where(n => n.ProductId == id
                && n.InstallmentPromotion.FromDate <= now && n.InstallmentPromotion.ToDate >= now.AddDays(-1))
                .FirstOrDefault();
            if (rs == null) return false;
            else return true;
        }

        private int SaleOfPriveCalc(int ProductId)
        {
            int SaleOff = 0;
            var promos = _context.PromotionProducts.Where(n => n.Promotion.EndDate >= DateTime.Now && n.ProductId == ProductId && n.Promotion.Status == PromoStatus.Activated);
            if (promos != null)
                foreach (var item in promos)
                {
                    SaleOff += item.DiscountQuantity;
                }
            return SaleOff;
        }

        /// <summary>
        /// Lấy ra các chương trình khuyến mãi theo keyword
        /// </summary>
        /// <param name="keyword">Từ khóa tìm kiếm theo tên chương trình</param>
        /// <param name="status">Trạng thái 1: hoạt động, 2: Không hoạt động</param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="pageItem"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        [HttpGet]
        public ResponseModel Get(string keyword,
            int status = 0,
            string fromDate = "",
            string toDate = "",
            int pageItem = 10,
            int pageIndex = 0)
        {
            try
            {
                var result = _context.Promotions
                    .Include(x => x.PromotionProducts).ThenInclude(x => x.Product.GiftProduct.Product)
                    .Include(x => x.PromotionProducts).ThenInclude(x => x.Product.ProductImages).ThenInclude(x => x.Image)
                    .Include(x => x.PromotionProducts).ThenInclude(x => x.Product.ProductBrand)
                    .Include(x => x.PromotionProducts).ThenInclude(x => x.Product.ProductCategories)
                    .Where(delegate (PromotionEntity x)
                    {
                        return x.Name.Like(keyword)
                        && ((int)x.Status == status || status == 0);
                        //&& (x.StartDate.Beetween(fromDate, toDate));
                    })
                    .OrderBy(x => x.Status).ThenBy(x => x.PriorityPromotion)
                    //.OrderByDescending(x => x.CreatedDate)
                    .Select(x => new PromotionResponse(x))
                    .ToList();

                res.Succeed(new PaginationResponse<PromotionResponse>(result, pageItem, pageIndex));
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }
            return res;
        }

        /// <summary>
        /// Kiểm trả sản phẩm đã có trong chương trình khác khi thêm 
        /// sản phẩm,nếu có thì warning
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("isInOrtherPromo/{id}")]
        public ResponseModel IsInOrtherPromo(int id)
        {
            var d = _context.PromotionProducts
                  .Where(n => n.ProductId == id
                  && n.Promotion.EndDate >= DateTime.Now
                  ).Select(n => n.Promotion.Name).ToList();
            res.IsSuccess = d.Count > 0;
            res.Result = d;
            return res;
        }
        /// <summary>
        /// Lấy ra các chương trình khuyến mãi theo url
        /// </summary>
        /// <param name="promotionUrl">Promo url</param>
        /// <param name="filterStr"></param>
        /// <returns></returns>
        [HttpGet("ByUrl/{promotionUrl}")]
        public ResponseModel GetByUrl(string promotionUrl = "", string filterStr = "")
        {
            try
            {
                PromotionResponse promotion = new PromotionResponse();
                PaginationResponse<ProductSimpleMostRespone> products = new PaginationResponse<ProductSimpleMostRespone>();
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

                //Nếu url là giá tốt thì lấy tất cả sản phẩm đang giảm giá
                //if (promotionUrl == giaTotUrl)
                //{
                //    promotion = new PromotionResponse() { Name = "Giá tốt hôm nay" };
                //    var query = _context.Products
                //        .OrderBy($"{nameof(ProductEntity.GiaBanLe)} {order}")
                //        .Include(x => x.ProductBrand.Logo)
                //        .Include(x => x.InstallmentPromotionProducts).ThenInclude(x => x.InstallmentPromotion)
                //        .Include(x => x.ProductCategories).ThenInclude(x => x.Category)
                //        .Include(x => x.ProductProperties).ThenInclude(x => x.PropertyValues).ThenInclude(x => x.Value)
                //        .Include(x => x.PromotionProducts).ThenInclude(x => x.Promotion)
                //        .Where(delegate (ProductEntity x)
                //        {
                //            return (x.ProductName.Like(keyword) || x.ProductCode.Like(keyword))
                //            && x.Status
                //            && (string.IsNullOrEmpty(categoryUrl) || x.ProductCategories.Any(x => x.Category.FriendlyUrl == categoryUrl))
                //            && (brands.Count() == 0 || brands.Contains((int)x.ProductBrandId))
                //            && (x.OriginPrice >= fromPrice || fromPrice == 0)
                //            && (x.OriginPrice <= toPrice || toPrice == 0)
                //            && (cat == 0 || x.ProductCategories.Any(n => n.CategoryId == cat))
                //            //Sản phẩm phải có thuộc tính trong params filter và giá trị thuộc tính đó thỏa mãn giá trị trong filter
                //            //hoặc params filter trống
                //            && (filters == null || filters.Count() == 0
                //                || (x.ProductProperties.Any(n => filters.Select(a => a.PropertyId).Contains(n.PropertyId)
                //                    && x.ProductProperties
                //                    //Lấy danh sách giá trị của thuộc tính
                //                    .SelectMany(n => n.PropertyValues.Select(a => a.ValueId))
                //                    //Kiểm tra xem có giá trị nào nằm trong filter hay không
                //                    .Intersect(filters.SelectMany(x => x.ValueIds)).Count() != 0)))
                //            && x.SaleOffPrice != x.OriginPrice;
                //        }).Select(x => new ProductSimpleMostRespone(x)).ToList();
                //    if (order == "ASC")
                //        query = query.OrderBy(n => n.SaleOffPrice).ToList();
                //    else query = query.OrderByDescending(n => n.SaleOffPrice).ToList();
                //    products = new PaginationResponse<ProductSimpleMostRespone>(query, pageItem, pageIndex);
                //}
                //Nếu không thì lấy những sản phẩm có trong chương trình giảm giá
                //else
                //{
                promotion = _context.Promotions
                    .Where(x => x.FriendlyUrl == promotionUrl)
                    .Select(x => new PromotionResponse()
                    {
                        ActualRowDisplay = x.RowDisplay,
                        BackgroundColor = x.BackgroundColor,
                        RowDisplay = x.RowDisplay,
                        Banner = x.Banner,
                        StickerImage = x.StickerImage,
                        IsShowSticker = x.IsShowSticker
                    }).FirstOrDefault();


                var query = _context.Products
                    .OrderBy($"{nameof(ProductEntity.SaleOffPrice)} {order}")
                    .Include(x => x.ProductBrand.Logo)
                    .Include(x => x.InstallmentPromotionProducts).ThenInclude(x => x.InstallmentPromotion)
                    .Include(x => x.ProductCategories).ThenInclude(x => x.Category)
                    .Include(x => x.ProductProperties).ThenInclude(x => x.PropertyValues).ThenInclude(x => x.Value)
                    .Include(x => x.PromotionProducts).ThenInclude(x => x.Promotion)
                    .Where(x =>
                        (x.NomalizedProductName.Contains(keyword) || x.ProductCode.Contains(keyword))
                        && x.Status
                        && (string.IsNullOrEmpty(categoryUrl) || x.ProductCategories.Any(x => x.Category.FriendlyUrl == categoryUrl))
                        && (brands.Count() == 0 || brands.Contains((int)x.ProductBrandId))
                        && (x.OriginPrice >= fromPrice || fromPrice == 0)
                        && (x.OriginPrice <= toPrice || toPrice == 0)
                        && (cat == 0 || x.ProductCategories.Any(n => n.CategoryId == cat))
                        //Sản phẩm phải có thuộc tính trong params filter và giá trị thuộc tính đó thỏa mãn giá trị trong filter
                        //hoặc params filter trống
                        && (filters == null || filters.Count() == 0
                            || (x.ProductProperties.Any(n => filters.Select(a => a.PropertyId).Contains(n.PropertyId)
                                && x.ProductProperties
                                //Lấy danh sách giá trị của thuộc tính
                                .SelectMany(n => n.PropertyValues.Select(a => a.ValueId))
                                //Kiểm tra xem có giá trị nào nằm trong filter hay không
                                .Intersect(filters.SelectMany(x => x.ValueIds)).Count() != 0)))
                        && (x.PromotionProducts.Any(x => x.Promotion.FriendlyUrl == promotionUrl) || string.IsNullOrEmpty(promotionUrl))
                    ).Select(n => new ProductSimpleMostRespone()
                    {
                        DiscountPrice = n.PromotionProducts.Where(x => x.ProductId == n.Id && x.Promotion.Status == PromoStatus.Activated && x.Promotion.EndDate >= DateTime.Now).Sum(x => x.DiscountQuantity),
                        IsInstallment0Percent = n.InstallmentPromotionProducts.Where(m => m.InstallmentPromotion.ToDate >= DateTime.Now.AddDays(-1) && m.ProductId == n.Id).FirstOrDefault() != null,
                        FriendlyUrl = n.FriendlyUrl,
                        GiaBanLe = n.GiaBanLe,
                        ProductCategories = n.ProductCategories.Select(x => new Models.CategoryResponse(x.Category)).ToList(),
                        GurantyTime = n.GurantyTime,
                        HighlightProduct = n.HighlightProduct,
                        Id = n.Id,
                        Origin = n.Origin,
                        OriginPrice = n.OriginPrice,
                        ProductCode = n.ProductCode,
                        ProductName = n.ProductName,
                        Status = n.Status,
                        StockNumber = n.StockNumber,
                        ThumbNail = n.ThumbNail,
                    }).ToList();

                if (order == "ASC")
                    query = query.OrderBy(n => n.SaleOffPrice).ToList();
                else query = query.OrderByDescending(n => n.SaleOffPrice).ToList();

                for (int i = 0; i < query.Count; i++)
                {
                    query[i].SaleOffPrice = query[i].GiaBanLe - query[i].DiscountPrice;
                }
                products = new PaginationResponse<ProductSimpleMostRespone>(query, pageItem, pageIndex);
                //}

                var result = new PromotionWithProductResponse()
                {
                    Products = products,
                    Promotion = promotion
                };
                res.Succeed(result);
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
                res.Result = ex.StackTrace;
            }
            return res;
        }

        /// <summary>
        ///lấy để thể hiện lên select box, chi lấy tên và Id 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetFilter")]
        public ResponseModel GetFilter(string keysearch = "")
        {
            try
            {
                var result = _context.Promotions
                    .OrderBy(n => n.CreatedDate)
                    .Where(delegate (PromotionEntity n)
                    {
                        return n.Name.Like(keysearch) && n.EndDate >= now;
                    })
                    .Select(n => new KeyNameResponse(n.Id, n.Name))
                    .ToList();
                res.Succeed(result);
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
                res.Result = ex.StackTrace;
            }
            return res;
        }

        [HttpGet("ById/{id}")]
        public ResponseModel GetById(int id)
        {
            try
            {
                var result = _context.Promotions
                    .Include(x => x.PromotionProducts).ThenInclude(x => x.Product)
                    .Where(x => x.Id == id)
                    .Select(x => new PromotionResponse(x))
                    .FirstOrDefault();

                if (result == null) throw NotFoundException;

                res.Succeed(result);
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }

            return res;
        }

        /// <summary>
        /// Lấy danh sash sản phẩm theo id promotion,
        /// dùng trong page in label
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("products/{id}")]
        public ResponseModel products(int id)
        {
            try
            {
                var result = _context.Promotions
                    .Include(x => x.PromotionProducts).ThenInclude(x => x.Product).ThenInclude(x => x.ProductCategories)
                    .Include(x => x.PromotionProducts).ThenInclude(x => x.Product).ThenInclude(x => x.ProductBrand)
                    .Where(x => x.Id == id)
                    .Select(x => new
                    {
                        Products = x.PromotionProducts.Select(i => new ProductSimpleMostRespone(i.Product))
                    })
                    .FirstOrDefault();
                if (result == null) throw NotFoundException;
                res.Succeed(result);
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }

            return res;
        }

        [HttpPost]
        public ResponseModel Post([FromBody] PromotionRequest value)
        {
            var transaction = _context.Database.BeginTransaction();
            try
            {
                if (value.PromotionProductRequests == null
                    || value.PromotionProductRequests.Count == 0) throw new Exception("Vui lòng chọn sản phẩm");

                var entity = value.CopyTo(new PromotionEntity());
                if (entity.EndDate <= entity.StartDate)
                {
                    res.Message = "Thời gian kết thúc phải lớn hơn thời gian bắt đầu";
                    return res;
                }
                entity.CreatedUserId = UserId;
                _context.Promotions.Add(entity);
                _context.SaveChanges();
                AddUrl(UrlType.Promotion, value.FriendlyUrl);
                // Cập nhật sticker cho sản phẩm trong chương trình
                var productIds = entity.PromotionProducts.Select(n => n.ProductId);
                var products = _context.Products.Where(n => productIds.Any(x => x == n.Id));
                foreach (var item in products)
                {
                    if (!string.IsNullOrEmpty(entity.StickerImage))
                        item.StickerImage = entity.StickerImage;
                    item.IsShowSticker = entity.IsShowSticker;
                }
                //Cập nhập giá khuyến mãi của sản phẩm
                _context.SaveChanges();
                res.Succeed();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                res.Failed(ex.Message);
            }

            return res;
        }

        [HttpPut("{id}")]
        public ResponseModel Put(int id, [FromBody] PromotionRequest value)
        {
            var transaction = _context.Database.BeginTransaction();
            try
            {
                var entity = _context.Promotions
                    .Include(x => x.PromotionProducts)
                    .FirstOrDefault(x => x.Id == id);

                UpdateUrl(entity.FriendlyUrl, value.FriendlyUrl, UrlType.Post);
                value.CopyTo(entity);
                if (entity.EndDate <= entity.StartDate)
                {
                    res.Message = "Thời gian kết thúc phải lớn hơn thời gian bắt đầu";
                    return res;
                }
                entity.UpdatedUserId = UserId;
                entity.UpdatedDate = now;

                var productIds = entity.PromotionProducts.Select(n => n.ProductId);
                var products = _context.Products.Where(n => productIds.Any(x => x == n.Id));

                foreach (var item in products)
                {
                    if (!string.IsNullOrEmpty(entity.StickerImage))
                        item.StickerImage = entity.StickerImage;
                    item.IsShowSticker = entity.IsShowSticker;
                }
                _context.SaveChanges();
                res.Succeed();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
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

        [HttpPut("Status/{id}")]
        public ResponseModel PutStatus(int id, [FromBody] int status)
        {
            try
            {
                var entity = _context.Promotions
                    .Include(x => x.PromotionProducts)
                    .FirstOrDefault(x => x.Id == id);
                entity.UpdatedUserId = UserId;
                entity.UpdatedDate = now;
                entity.Status = (PromoStatus)status;

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

        [HttpDelete("{id}")]
        public ResponseModel Delete(int id)
        {
            try
            {
                var entity = _context.Promotions.Find(id);
                if (entity == null)
                {
                    throw NotFoundException;
                }

                _context.Promotions.Remove(entity);
                DeleteUrl(entity.FriendlyUrl);

                _context.SaveChanges();
                res.Succeed();
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }

            return res;
        }

        private new bool EntityExists(int id)
        {
            return _context.Promotions.Any(x => x.Id == id);
        }
    }
}
