using eCommerce.Web.Entities.Installment;
using eCommerce.Web.Entities.Orders;
using eCommerce.Web.Entities.Product;
using eCommerce.Web.Entities.Product.ComboProduct;
using eCommerce.Web.Entities.Promotion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Entities
{
    public class ProductEntity : BaseEntity
    {
        public ProductEntity() : base()
        {
            ProductImages = new HashSet<ProductImageEntity>();
            ProductLogs = new HashSet<ProductLogEntity>();
            ProductProperties = new HashSet<ProductPropertyEntity>();
            ProductCombos = new HashSet<ComboProductEntity>();
            PromotionProducts = new HashSet<PromotionProductEntity>();
            ProductPriceLogs = new HashSet<ProductPriceLogEntity>();
        }


        public string ProductName { get; set; }

        public string NomalizedProductName { get; set; }
        public int AccessCount { get; set; }
        public string ProductCode { get; set; }
        public string HighlightProduct { get; set; }
        public string ThumbNail { get; set; }

        public string Description { get; set; }
        public bool IsShowPrice { get; set; }

        public int? ProductBrandId { get; set; }

        public bool IsGift { get; set; }

        public bool IsAllowGifting { get; set; }

        public int StockNumber { get; set; }

        public string Origin { get; set; }

        [System.ComponentModel.DataAnnotations.MaxLength(200)]
        public string StickerImage { get; set; }
        public bool IsShowSticker { get; set; }
        public string PromotionContent { get; set; }

        /// <summary>
        /// Khuyến mãi của hãng
        /// </summary>
        public string PromotionBranch { get; set; }

        /// <summary>
        /// thời gian kết thúc của khuyến mãi. Nếu quá thời gian này ko hiển thị 
        /// </summary>
        public DateTime? PromotionBranchDeadline { get; set; }
        /// <summary>
        /// Giá niêm yết
        /// </summary>
        public int OriginPrice { get; set; }

        /// <summary>
        /// giá bán ra cho khách . = giá bán lẻ - Sum(Khuyến mãi)
        /// </summary>
        public int SaleOffPrice { get; set; }

        // public int PublicPrice { get; set; }

        /// <summary>
        /// giá bản lẻ công thành cung cấp
        /// </summary>
        public int GiaBanLe { get; set; }

        public string GurantyTime { get; set; }

        public string FriendlyUrl { get; set; }
        public string GoldenCommitment { get; set; }

        public bool Status { get; set; }// 0 hết bán , 1 đang bán

        public string Unit { get; set; }
        public bool IsCombo { get; set; } //; 0= Product, 1 = combo
        public int InstallmentPrice { get; set; } // Giá bán trả góp

        public int? ComboId { get; set; }
        [ForeignKey(nameof(ProductBrandId))]
        public virtual ProductBrandEntity ProductBrand { get; set; }

        public virtual ICollection<OrderDetailEntity> OrderDetails { get; set; }

        public virtual ICollection<ProductCategoryEntity> ProductCategories { get; set; }

        public virtual ICollection<ComboProductEntity> ProductCombos { get; set; }

        public virtual GiftProductEntity GiftProduct { get; set; }

        public virtual ICollection<ProductImageEntity> ProductImages { get; set; }

        public virtual ICollection<ProductLogEntity> ProductLogs { get; set; }

        public virtual ICollection<ProductPriceLogEntity> ProductPriceLogs { get; set; }

        public virtual ICollection<ProductPropertyEntity> ProductProperties { get; set; }

        public virtual ICollection<PromotionProductEntity> PromotionProducts { get; set; }
        public virtual ICollection<InstallmentPromotionProductEntity> InstallmentPromotionProducts { get; set; }
    }
}
