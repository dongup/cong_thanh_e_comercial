using eCommerce.Utils;
using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Areas.Api.Models.Products;
using eCommerce.Web.Areas.Api.Models.Products.Property;
using eCommerce.Web.Entities;
using eCommerce.Web.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Areas.Api.Models.Products.Product
{
    public class ProductRequest : ProductResponse
    {
        public ProductRequest()
        {

        }

        public ProductEntity CopyTo(ProductEntity entity)
        {
            base.CopyTo(entity);
            entity.PromotionBranchDeadline = PromotionBranchDeadline;
            entity.ProductName = ProductName;
            entity.NomalizedProductName = ProductName.RemoveUnicode();
            entity.ProductCode = ProductCode;
            entity.Description = Description;
            entity.ProductBrandId = ProductBrandId;
            entity.IsGift = IsGift;
            entity.IsAllowGifting = IsAllowGifting;
            entity.StockNumber = StockNumber;
            entity.Origin = Origin;
            entity.PromotionContent = PromotionContent;
            entity.OriginPrice = OriginPrice;
            entity.GiaBanLe = GiaBanLe;
            entity.HighlightProduct = HighlightProduct;
            entity.GurantyTime = GurantyTime;
            entity.FriendlyUrl = FriendlyUrl;
            entity.IsAllowGifting = IsAllowGifting;
            entity.Unit = Unit;
            entity.IsShowPrice = IsShowPrice;
            entity.GoldenCommitment = GoldenCommitment;
            entity.ThumbNail = ThumbNail;
            entity.IsShowPrice = IsShowPrice;
            entity.NomalizedProductName = ProductName.RemoveUnicode();
            entity.IsShowSticker = IsShowSticker;
            entity.StickerImage = StickerImage;
            entity.PromotionBranch = PromotionBranch;
            entity.ProductCategories = CategoryIds.Select(x => new ProductCategoryEntity()
            {
                CategoryId = x
            }).ToList();

            entity.ProductImages = ImageIds.Select(x => new ProductImageEntity()
            {
                ImageId = x
            }).ToList();

            entity.ProductProperties = Properties.Select(x => x.CopyTo(new ProductPropertyEntity())).ToList();


            return entity;
        }
        public string PromotionBranchDeadlineString { get; set; }
        public List<int> ImageIds { get; set; } = new List<int>();

        public List<int> CategoryIds { get; set; } = new List<int>();

        public List<ProductPropertyRequest> Properties { get; set; } = new List<ProductPropertyRequest>();

        protected new ProductBrandResponse ProductBrand { get; set; }

        protected new CategoryResponse ProductCategories { get; set; }

        protected new GiftProductResponse GiftProduct { get; set; }

        protected new ICollection<FileResponse> ProductImages { get; set; }
        protected new virtual ICollection<ProductLogResponse> ProductLogs { get; set; }

        protected new virtual ICollection<ProductPropertyResponse> ProductProperties { get; set; }
    }
}
