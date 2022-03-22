using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Entities.Promotion;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using static eCommerce.Web.Entities.Promotion.PromotionEntity;

namespace eCommerce.Web.Areas.Api.Models.Promotion
{
    public class PromotionResponse : BaseModel
    {
        public PromotionResponse()
        {

        }

        public PromotionResponse(PromotionEntity entity) : base(entity)
        {
            try
            {
                Name = entity.Name;
                BackgroundColor = entity.BackgroundColor;
                Banner = entity.Banner;
                Priority = entity.PriorityPromotion;
                Description = entity.Description;
                DiscountPercent = entity.DiscountPercent;
                DiscountQuantity = entity.DiscountQuantity;
                MaximumDiscount = entity.MaximumDiscount;
                MinimumDiscount = entity.MinimumDiscount;
                StartDate = entity.StartDate.ToString("HH:mm dd/MM/yyyy");
                EndDate = entity.EndDate.ToString("HH:mm dd/MM/yyyy");
                FriendlyUrl = entity.FriendlyUrl;
                Status = (int)entity.Status;
                DiscountType = (int)entity.DiscountType;
                StickerImage = entity.StickerImage ?? "";
                IsShowSticker = entity.IsShowSticker;

                PromotionProducts = entity.PromotionProducts.Select(x => new PromotionProductResponse(x)).ToList();
                RowDisplay = entity.RowDisplay;
                BorderColor = entity.BorderColor;

                int count = PromotionProducts.Count();
                int row = count / 5;
                int row2 = count % 5;


                ActualRowDisplay = entity.RowDisplay > row ? row : entity.RowDisplay;
                if (ActualRowDisplay == 0)
                    ActualRowDisplay = 1;
                if (row2 > 0)
                    ActualRowDisplay += 1;
            }
            catch (System.Exception ex)
            {

            }
        }

        [NotEmpty(ErrorMessage = "Bạn cần nhập tên chương trình!")]
        public string Name { get; set; }

        [NotEmpty(ErrorMessage = "Bạn cần chọn một hình dại diện")]
        public string Banner { get; set; }
        public string StickerImage { get; set; }
        public bool IsShowSticker { get; set; }
        public string Description { get; set; }

        public string IsApplyToAll { get; set; }

        public int ActualRowDisplay { get; set; }

        public int DiscountPercent { get; set; }
        public int Priority { get; set; }

        public int DiscountQuantity { get; set; }

        public int MaximumDiscount { get; set; }

        public string BorderColor { get; set; }

        public int MinimumDiscount { get; set; }

        public string BackgroundColor { get; set; }

        public int RowDisplay { get; set; }

        public int Status { get; set; }

        [NotEmpty(ErrorMessage = "Bạn cần chọn thời gian bắt đầu")]
        public string StartDate { get; set; }

        [NotEmpty(ErrorMessage = "Bạn cần chọn thời gian kết thúc")]
        public string EndDate { get; set; }

        [NotEmpty(ErrorMessage = "Bạn cần nhập URL của chương trình")]
        public string FriendlyUrl { get; set; }

        [Range(1, 2, ErrorMessage = "Bạn cần chọn loại giảm giá!")]
        public int DiscountType { get; set; }

        [Required(ErrorMessage = "Bạn cần chọn sản phẩm")]
        public virtual List<PromotionProductResponse> PromotionProducts { get; set; }
    }

}
