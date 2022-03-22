using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Areas.Api.Models.Products.Property;
using eCommerce.Web.Entities;
using eCommerce.Web.Entities.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Areas.Api.Models
{
    public class CategoryResponse : BaseModel
    {
        public CategoryResponse()
        {
        }

        public CategoryResponse(CategoryEntity entity)
        {
            if (entity == null) return;

            Id = entity.Id;
            CategoryName = entity.CategoryName;
            CountProduct = entity.ProductCategories.Count();
            FriendlyUrl = entity.FriendlyUrl;
            CategoryGroupId = entity.CategoryGroupId;
            Banner = entity.Banner;
            Note = entity.Note;
            OrderLevel = entity.OrderLevel;
            StickerImage = entity.StickerImage;
            IsShowSticker = entity.IsShowSticker;
            Properties = entity.Properties?.Select(n => new PropertyResponse(n)).ToList();
        }
        /// <summary>
        /// Thứ tự sắp xếp danh mục để thể hiện trang chủ
        /// Ví dụ Tivi (Order=1), Quạt làm mát (Order= 2), Amply (Order=3)
        /// </summary>
        public int OrderLevel { get; set; }
        public int? CategoryGroupId { get; set; }

        public string FriendlyUrl { get; set; }
        /// <summary>
        /// Conver note to in để order số thứ tự sắp sếp TAB ngoài trang chủ
        /// </summary>
        public int NoteInt
        {
            get
            {
                if (string.IsNullOrEmpty(Note)) return 0;
                else
                {
                    int.TryParse(Note ?? "", out int num);
                    return num;
                }
            }
        }
        public string CategoryName { get; set; }

        public int CountProduct { get; set; }

        public string Banner { get; set; }
        public string StickerImage { get; set; }
        public bool IsShowSticker { get; set; }
        public List<PropertyResponse> Properties { get; set; }
    }

    public class DetailCategoryResponse : CategoryResponse
    {
      

        public List<TemplateResponse> Templates { get; set; }

        public DetailCategoryResponse(CategoryEntity entity) : base(entity)
        {
            if (entity == null) return;
            Templates = entity.Templates.Select(x => new TemplateResponse(x)).ToList();
        }
    }

    public class CategoryFilterResponse : BaseModel
    {
        public CategoryFilterResponse()
        {

        }

        public CategoryFilterResponse(CategoryEntity entity)
        {
            if (entity == null) return;
            CategoryName = entity.CategoryName;
            CountProduct = entity.ProductCategories.Count();
            FriendlyUrl = entity.FriendlyUrl;
            CategoryGroupId = entity.CategoryGroupId;
            Banner = entity.Banner;
            Id = entity.Id;
            PropertyFilters = entity.Properties?
                .Where(n => n.IsFilter)
                .Select(n => new PropertyFilterResponse(n)).ToList();
        }

        public int? CategoryGroupId { get; set; }

        public string FriendlyUrl { get; set; }

        public string CategoryName { get; set; }

        public int CountProduct { get; set; }

        public string Banner { get; set; }

        public List<PropertyFilterResponse> PropertyFilters { get; set; }
    }
}
