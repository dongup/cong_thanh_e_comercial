using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Entities;
using eCommerce.Web.Entities.Product;
using System.Collections.Generic;
using System.Linq;

namespace eCommerce.Web.Areas.Api.Models
{
    public class CategoryRequest : BaseModel
    {
        public CategoryEntity CopyTo(CategoryEntity entity) 
        {
            base.CopyTo(entity);
            entity.CategoryName = CategoryName;
            entity.CategoryGroupId = (GroupId == 0 || GroupId == null) ? entity.CategoryGroupId : GroupId;
            entity.Banner = Banner;
            entity.FriendlyUrl = FriendlyUrl;
            entity.IsShowSticker = IsShowSticker;
            entity.StickerImage = StickerImage;
            return entity;
        }

        protected new int Id { get; set; }

        public string FriendlyUrl { get; set; }

        public int? GroupId { get; set; }

        public string CategoryName { get; set; }

        public string Banner { get; set; }
        public string StickerImage { get; set; }
        public bool IsShowSticker { get; set; }
        //public List<int> ProductIds { get; set; }
    }
}
