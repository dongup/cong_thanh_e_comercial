using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Areas.Api.Models.Products.ComboProduct;
using eCommerce.Web.Areas.Api.Models.Products.Property;
using eCommerce.Web.Areas.Api.Models.Promotion;
using eCommerce.Web.Areas.Api.Models.User;
using eCommerce.Web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using static eCommerce.Web.Entities.Promotion.PromotionEntity;
/// <summary>
/// Note: Origin price là giá gố
/// DiscountPrice là số tiền đk  khuyến mãi trong các chương trình
/// saleOffPrice là Giá bán lẻ sau khi đã trừ tiền khuyến mãi,
/// Giá bán lẻ là giá Công thành gửi;
/// Ví Dụ:  Sản phẩm có giá gốc      = 1.000.000    OriginPrice
///                   Giá bán lẻ     =  900.000     GiaBanLe
///                   Giá đk giảm    =  100.000     DiscountPrice
///                   Giá bán cuối   =  800.000     SaleOffPrice
/// </summary>
namespace eCommerce.Web.Areas.Api.Models.Products.Product
{
    public class ProductResponse : BaseModel
    {
        public ProductResponse()
        {

        }

        public ProductResponse(ProductEntity entity) : base(entity)
        {
            if (entity == null) return;

            // Tính tiền giảm trong các chương trình khuyến mãi
            var promos = entity.PromotionProducts?.Where(n => n.Promotion.EndDate >= DateTime.Now && n.ProductId == entity.Id && n.Promotion.Status == PromoStatus.Activated);
            if (promos != null)
                foreach (var item in promos)
                {
                    SaleOff += item.DiscountQuantity;
                }
            ProductName = entity.ProductName;
            ProductCode = entity.ProductCode;
            ThumbNail = entity.ThumbNail;
            Description = entity.Description;
            ProductBrandId = entity.ProductBrandId;
            IsGift = entity.IsGift;
            IsAllowGifting = entity.IsAllowGifting;
            StockNumber = entity.StockNumber;
            Origin = entity.Origin;
            PromotionContent = entity.PromotionContent;
            OriginPrice = entity.OriginPrice;
            GiaBanLe = entity.GiaBanLe;
            GurantyTime = entity.GurantyTime;
            Note = entity.Note;
            FriendlyUrl = entity.FriendlyUrl;
            HasGift = entity.GiftProduct != null;
            SaleOffPrice = entity.GiaBanLe - SaleOff;
            Unit = entity.Unit;
            AccessCount = entity.AccessCount;
            IsCombo = entity.IsCombo;
            ComboId = entity.ComboId.GetValueOrDefault();
            CountOrder = entity.OrderDetails?.Count() ?? 0;
            IsShowPrice = entity.IsShowPrice;
            StickerImage = entity.StickerImage;
            IsShowSticker = entity.IsShowSticker;
            TotalSale = entity.OrderDetails?.Sum(x => x.BuyPrice * x.Quanity) ?? 0;
            PromotionBranch = entity.PromotionBranch;
            PromotionBranchDeadline = entity.PromotionBranchDeadline;
            HighlightProduct = entity.HighlightProduct;
            ProductBrand = new ProductBrandResponse(entity.ProductBrand);
            ProductCategories = entity.ProductCategories?.Select(x => new CategoryResponse(x.Category)).ToList();
            GiftProduct = new GiftProductResponse(entity.GiftProduct);
            Promotions = entity.PromotionProducts?.Where(n => n.Promotion?.EndDate >= DateTime.Now).Select(x => new PromotionResponse(x.Promotion)).ToList();
            Combos = entity.ProductCombos?.Select(x => new ComboResponse(x.Combo)).ToList();
            ProductImages = entity.ProductImages?.Select(x => new FileResponse(x.Image)).ToList();
            ProductLogs = entity.ProductLogs?.Select(x => new ProductLogResponse(x)).ToList();
            ProductProperties = entity.ProductProperties?.Select(x => new ProductPropertyResponse(x)).ToList();
            GoldenCommitment = entity.GoldenCommitment;
            Status = entity.Status;
            if (Status && StockNumber == 0)
            {
                Status = false;
            }
            if (entity.InstallmentPromotionProducts != null)
                IsInstallment0Percent = entity.InstallmentPromotionProducts.Where(n =>
                n.InstallmentPromotion.ToDate >= DateTime.Now.AddDays(-1)
                && n.ProductId == entity.Id
                ).FirstOrDefault() != null;
            InstallmentPrice = entity.InstallmentPrice;
        }
        public DateTime? PromotionBranchDeadline { get; set; }

        public int InstallmentPrice { get; set; }// Giá bán trả góp
        public bool Status { get; set; }
        public string ProductName { get; set; }

        public string ProductCode { get; set; }
        public string StickerImage { get; set; }
        public bool IsShowSticker { get; set; }
        public string ThumbNail { get; set; }
        public int DiscountPrice { get; set; }
        public string Description { get; set; }
        public int ProductCategoryId { get; set; }

        /// <summary>
        ///    Sản phẩm có cho trả góp 0% không
        /// </summary>
        public bool IsInstallment0Percent { get; set; }

        /// <summary>
        /// Lượt truy cập của sản phẩm
        /// </summary>
        public int AccessCount { get; set; }
        public int? ProductBrandId { get; set; }
        public string PromotionBranch { get; set; }
        public bool IsGift { get; set; }

        public bool IsAllowGifting { get; set; }

        public int StockNumber { get; set; }

        public string Origin { get; set; }

        public string PromotionContent { get; set; }

        public int OriginPrice { get; set; }

        public int SaleOffPrice { get; set; }

        public int SaleOff { get; set; }

        public int PublicPrice { get; set; }

        public int GiaBanLe { get; set; }

        public string GurantyTime { get; set; }
        public string GoldenCommitment { get; set; }

        public string FriendlyUrl { get; set; }

        public bool HasGift { get; set; }
        public string HighlightProduct { get; set; }

        public string Unit { get; set; }

        public int CountOrder { get; set; }

        public bool IsCombo { get; set; }

        public int ComboId { get; set; }
        public bool IsShowPrice { get; set; }

        public int TotalSale { get; set; }
        public string HightLineProduct { get; set; }

        public new string CreatedDate { get => base.CreatedDate; set => base.CreatedDate = value; }

        public new string UpdatedDate { get => base.UpdatedDate; set => base.UpdatedDate = value; }

        public UserResponse CreatedUser { get; set; }

        public ProductBrandResponse ProductBrand { get; set; }

        public virtual ICollection<PromotionResponse> Promotions { get; set; }

        public ICollection<CategoryResponse> ProductCategories { get; set; }

        public GiftProductResponse GiftProduct { get; set; }

        public ICollection<FileResponse> ProductImages { get; set; }

        public virtual ICollection<ProductLogResponse> ProductLogs { get; set; }

        public virtual ICollection<ProductPropertyResponse> ProductProperties { get; set; }

        public virtual ICollection<ComboResponse> Combos { get; set; }
        public virtual ICollection<SimpleProductResponse> ProductsCombo { get; set; }


    }

    public class SimpleProductResponse : BaseModel
    {
        public SimpleProductResponse()
        {

        }
        /*
         quantity : số lượng sản phẩm trong combo
         */
        public SimpleProductResponse(ProductEntity entity, int quantity) : base(entity)
        {
            if (entity == null) return;

            // Tính tiền giảm trong các chương trình khuyến mãi
            var promos = entity.PromotionProducts?.Where(n => n.Promotion.EndDate >= DateTime.Now && n.ProductId == entity.Id && n.Promotion.Status == PromoStatus.Activated);
            if (promos != null)
                foreach (var item in promos)
                {
                    SaleOff += item.DiscountQuantity;
                }


            StickerImage = entity.StickerImage;
            IsShowSticker = entity.IsShowSticker;
            ProductName = entity.ProductName;
            ThumbNail = entity.ThumbNail;
            OriginPrice = entity.OriginPrice;
            GiaBanLe = entity.GiaBanLe;
            FriendlyUrl = entity.FriendlyUrl;
            GurantyTime = entity.GurantyTime;
            SaleOffPrice = GiaBanLe - SaleOff;
            Origin = entity.Origin;
            StockNumber = entity.StockNumber;
            ProductBrandId = entity.ProductBrandId;
            ProductCode = entity.ProductCode;
            CountOrder = entity.OrderDetails?.Count() ?? 0;
            TotalSale = entity.OrderDetails?.Sum(x => x.BuyPrice * x.Quanity) ?? 0;
            ProductBrand = new ProductBrandResponse(entity.ProductBrand);
            ProductCategories = entity.ProductCategories?.Select(x => new CategoryResponse(x.Category)).ToList();
            ProductImages = entity.ProductImages?.Select(x => new FileResponse(x.Image)).ToList();
            Quantity = quantity;
            Status = entity.Status;
            if (Status && StockNumber == 0)
            {
                Status = false;
            }
            //Nếu có một log cập nhập giá trong vòng 2 ngày gần đây thì đánh dấu là mới update giá
            DateTime now = DateTime.Now;
            IsNewUpdatePrice = entity.ProductPriceLogs.Any(x => (now - x.CreatedDate).TotalDays < 3);
            GoldrenCommitment = entity.GoldenCommitment;

        }


        public SimpleProductResponse(ProductEntity entity) : base(entity)
        {
            if (entity == null) return;
            // Tính tiền giảm trong các chương trình khuyến mãi
            var promos = entity.PromotionProducts?.Where(n => n.Promotion.EndDate >= DateTime.Now && n.ProductId == entity.Id && n.Promotion.Status == PromoStatus.Activated);
            if (promos != null)
                foreach (var item in promos)
                {
                    SaleOff += item.DiscountQuantity;
                }
            ProductName = entity.ProductName;
            ThumbNail = entity.ThumbNail;
            OriginPrice = entity.OriginPrice;
            SaleOffPrice = entity.GiaBanLe - SaleOff;
            GiaBanLe = entity.GiaBanLe;
            FriendlyUrl = entity.FriendlyUrl;
            GurantyTime = entity.GurantyTime;
            Origin = entity.Origin;
            StockNumber = entity.StockNumber;
            ProductBrandId = entity.ProductBrandId;
            ProductCode = entity.ProductCode;
            IsShowPrice = entity.IsShowPrice;
            HighlightProduct = entity.HighlightProduct;
            PromotionBranch = entity.PromotionBranch;
            PromotionBranchDeadline = entity.PromotionBranchDeadline;
            CountOrder = entity.OrderDetails?.Count() ?? 0;
            TotalSale = entity.OrderDetails?.Sum(x => x.BuyPrice * x.Quanity) ?? 0;
            ProductBrand = new ProductBrandResponse(entity.ProductBrand);
            ProductCategories = entity.ProductCategories?.Select(x => new CategoryResponse(x.Category)).ToList();
            ProductImages = entity.ProductImages?.Select(x => new FileResponse(x.Image)).ToList();
            //Nếu có một log cập nhập giá trong vòng 2 ngày gần đây thì đánh dấu là mới update giá
            Status = entity.Status;
            if (Status && StockNumber == 0)
            {
                Status = false;
            }
            DateTime now = DateTime.Now;
            AccessCount = entity.AccessCount;
            IsNewUpdatePrice = entity.ProductPriceLogs.Any(x => (now - x.CreatedDate).TotalDays < 3);
            if (entity.InstallmentPromotionProducts != null)
                IsInstallment0Percent = entity.InstallmentPromotionProducts.Where(n =>
                n.InstallmentPromotion.ToDate >= DateTime.Now.AddDays(-1)
                && n.ProductId == entity.Id
                ).FirstOrDefault() != null;

            StickerImage = entity.StickerImage;
            IsShowSticker = entity.IsShowSticker;
        }
        public DateTime? PromotionBranchDeadline { get; set; }

        public string PromotionBranch { get; set; }
        public string StickerImage { get; set; }
        public bool IsShowSticker { get; set; }
        public int DiscountPrice { get; set; }
        public bool IsInstallment0Percent { get; set; }
        public int AccessCount { get; set; }
        public bool IsNewUpdatePrice { get; set; }

        public int OriginPrice { get; set; }

        public string ProductName { get; set; }
        public string GoldrenCommitment { get; set; }
        public string ThumbNail { get; set; }
        public bool IsShowPrice { get; set; }
        public int PublicPrice { get; set; }

        public int SaleOffPrice { get; set; }

        public string Origin { get; set; }

        public int StockNumber { get; set; }

        public int GiaBanLe { get; set; }

        public int SaleOff { get; set; }

        public string GurantyTime { get; set; }

        public string FriendlyUrl { get; set; }

        public int? ProductBrandId { get; set; }

        public string ProductCode { get; set; }
        public string HighlightProduct { get; set; }
        public int ProductCategoryId { get; set; }

        public int CountOrder { get; set; }

        public int TotalSale { get; set; }
        public int Quantity { get; set; } // số lượng sp trong combo
        public bool Status { get; set; }
        public CategoryResponse? Temp { get; set; }

        public ProductBrandResponse ProductBrand { get; set; }

        public ICollection<CategoryResponse> ProductCategories { get; set; }

        public ICollection<FileResponse> ProductImages { get; set; }
    }
    public class AllProductResponse : BaseModel
    {
        public AllProductResponse()
        {

        }
        /*
         quantity : số lượng sản phẩm trong combo
         */
        public AllProductResponse(ProductEntity entity, int quantity) : base(entity)
        {
            if (entity == null) return;

            ProductName = entity.ProductName;
            ThumbNail = entity.ThumbNail;
            OriginPrice = entity.OriginPrice;
            SaleOffPrice = entity.SaleOffPrice;
            GiaBanLe = entity.GiaBanLe;
            Unit = entity.Unit;
            SaleOff = PublicPrice - SaleOffPrice;
            FriendlyUrl = entity.FriendlyUrl;
            Description = entity.Description;
            PromotionContent = entity.PromotionContent;
            GurantyTime = entity.GurantyTime;
            ProductProperties = entity.ProductProperties?.Select(x => new ProductPropertyResponse(x)).ToList();
            HighlightProduct = entity.HighlightProduct;
            Origin = entity.Origin;
            StockNumber = entity.StockNumber;
            ProductBrandId = entity.ProductBrandId;
            ProductCode = entity.ProductCode;
            CountOrder = entity.OrderDetails?.Count() ?? 0;
            TotalSale = entity.OrderDetails?.Sum(x => x.BuyPrice * x.Quanity) ?? 0;
            ProductBrand = new ProductBrandResponse(entity.ProductBrand);
            ProductCategories = entity.ProductCategories?.Select(x => new CategoryResponse(x.Category)).ToList();
            ProductImages = entity.ProductImages?.Select(x => new FileResponse(x.Image)).ToList();
            Quantity = quantity;
            Status = entity.Status;
            if (Status && StockNumber == 0)
            {
                Status = false;
            }
            //Nếu có một log cập nhập giá trong vòng 2 ngày gần đây thì đánh dấu là mới update giá
            DateTime now = DateTime.Now;
            IsNewUpdatePrice = entity.ProductPriceLogs.Any(x => (now - x.CreatedDate).TotalDays < 3);
            GoldrenCommitment = entity.GoldenCommitment;

        }


        public AllProductResponse(ProductEntity entity) : base(entity)
        {
            if (entity == null) return;

            IsShowSticker = entity.IsShowSticker;
            StickerImage = entity.StickerImage;
            ProductName = entity.ProductName;
            ThumbNail = entity.ThumbNail;
            OriginPrice = entity.OriginPrice;
            SaleOffPrice = entity.SaleOffPrice;
            GiaBanLe = entity.GiaBanLe;
            Unit = entity.Unit;
            PromotionContent = entity.PromotionContent;
            SaleOff = PublicPrice - SaleOffPrice;
            FriendlyUrl = entity.FriendlyUrl;
            GurantyTime = entity.GurantyTime;
            Origin = entity.Origin;
            StockNumber = entity.StockNumber;
            ProductBrandId = entity.ProductBrandId;
            ProductCode = entity.ProductCode;
            HighlightProduct = entity.HighlightProduct;
            CountOrder = entity.OrderDetails?.Count() ?? 0;
            TotalSale = entity.OrderDetails?.Sum(x => x.BuyPrice * x.Quanity) ?? 0;
            ProductBrand = new ProductBrandResponse(entity.ProductBrand);
            ProductCategories = entity.ProductCategories?.Select(x => new CategoryResponse(x.Category)).ToList();
            //Nếu có một log cập nhập giá trong vòng 2 ngày gần đây thì đánh dấu là mới update giá
            Status = entity.Status;
            if (Status && StockNumber == 0)
            {
                Status = false;
            }
            DateTime now = DateTime.Now;
            AccessCount = entity.AccessCount;
            IsNewUpdatePrice = entity.ProductPriceLogs.Any(x => (now - x.CreatedDate).TotalDays < 3);
        }
        public int AccessCount { get; set; }
        public bool IsNewUpdatePrice { get; set; }

        public string StickerImage { get; set; }
        public bool IsShowSticker { get; set; }
        public int OriginPrice { get; set; }

        public string ProductName { get; set; }
        public string GoldrenCommitment { get; set; }
        public string ThumbNail { get; set; }

        public int PublicPrice { get; set; }

        public int SaleOffPrice { get; set; }

        public string Origin { get; set; }

        public int StockNumber { get; set; }

        public int GiaBanLe { get; set; }

        public int SaleOff { get; set; }

        public string GurantyTime { get; set; }
        public virtual ICollection<ProductPropertyResponse> ProductProperties { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public string PromotionContent { get; set; }
        public string FriendlyUrl { get; set; }

        public int? ProductBrandId { get; set; }

        public string ProductCode { get; set; }
        public string HighlightProduct { get; set; }
        public int ProductCategoryId { get; set; }

        public int CountOrder { get; set; }

        public int TotalSale { get; set; }
        public int Quantity { get; set; } // số lượng sp trong combo
        public bool Status { get; set; }

        public ProductBrandResponse ProductBrand { get; set; }

        public ICollection<CategoryResponse> ProductCategories { get; set; }

        public ICollection<FileResponse> ProductImages { get; set; }
    }

    public class ProductSimpleMostRespone
    {
        public ProductSimpleMostRespone(ProductEntity n)
        {
            //var promos = n.PromotionProducts?.Where(n => n.Promotion.EndDate >= DateTime.Now && n.ProductId == n.Id && n.Promotion.Status == PromoStatus.Activated);
            //if (promos != null)
            //    foreach (var item in promos)
            //    {
            //        SaleOff += item.DiscountQuantity;
            //    }

            Id = n.Id;
            StickerImage = n.StickerImage;
            IsShowSticker = n.IsShowSticker;
            ProductName = n.ProductName;
            OriginPrice = n.OriginPrice;
            BrandName = n.ProductBrand?.BrandName;
            CategoryName = n.ProductCategories?.FirstOrDefault()?.Category?.CategoryName;
            ProductCode = n.ProductCode;
            PromotionContent = n.PromotionContent;
            GoldenCommitment = n.GoldenCommitment;
            HighlightProduct = n.HighlightProduct;
            FriendlyUrl = n.FriendlyUrl;
            GurantyTime = n.GurantyTime;
            Origin = n.Origin;
            GiaBanLe = n.GiaBanLe;
            InstallmentPrice = n.InstallmentPrice;
            IsInstallment0Percent = n.InstallmentPromotionProducts.Where(m =>
               m.InstallmentPromotion.ToDate >= DateTime.Now.AddDays(-1)
               && m.ProductId == n.Id
                ).FirstOrDefault() != null;
            var Discount = n.PromotionProducts.Where(n => n.ProductId == Id && n.Promotion.Status == PromoStatus.Activated && n.Promotion.EndDate >= DateTime.Now).Sum(n => n.DiscountQuantity);
            SaleOffPrice = n.GiaBanLe - Discount;
            StockNumber = n.StockNumber;
            Status = n.Status;
            if (Status && StockNumber == 0)
            {
                Status = false;
            }
            ThumbNail = n.ThumbNail;

        }
        public ProductSimpleMostRespone()
        {

        }
        public virtual ICollection<ProductPropertyResponse> ProductProperties { get; set; }
        public string ThumbNail { get; set; }
        public int AccessCount { get; set; }
        public int StockNumber { get; set; }
        public int SaleOff { get; set; }
        public ProductBrandResponse ProductBrand { get; set; }
        public bool IsInstallment0Percent { get; set; }
        public string Origin { get; set; }
        public ICollection<CategoryResponse> ProductCategories { get; set; }
        public string GurantyTime { get; set; }
        public string FriendlyUrl { get; set; }
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int OriginPrice { get; set; }
        public int GiaBanLe { get; set; }
        public int SaleOffPrice { get; set; }
        public string StickerImage { get; set; }
        public bool IsShowSticker { get; set; }
        /// <summary>
        /// Giá tiền giẩm trong các chương trình khuyến mãi.
        /// </summary>
        public int DiscountPrice { get; set; }
        public string BrandName { get; set; }
        public string CategoryName { get; set; }
        public string ProductCode { get; set; }
        public string PromotionContent { get; set; }
        public string HighlightProduct { get; set; }
        public string GoldenCommitment { get; set; }
        public int InstallmentPrice { get; set; }
        public bool Status { get; set; }

    }


}
