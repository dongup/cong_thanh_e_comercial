using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Entities.Product
{
    public class CategoryEntity : BaseEntity
    {
        public CategoryEntity()
        {
            Templates = new HashSet<TemplateEntity>();
            ProductCategories = new HashSet<ProductCategoryEntity>();
            Properties = new HashSet<PropertyEntity>();
        }

        public string CategoryName { get; set; }

        public string FriendlyUrl { get; set; }

        public string Banner { get; set; }
        public string StickerImage { get; set; }
        public bool IsShowSticker { get; set; }

        public int? CategoryGroupId { get; set; }

        [ForeignKey(nameof(CategoryGroupId))]
        public virtual ProductCategoryGroupEntity CategoryGroup { get; set; }

        /// <summary>
        /// Thứ tự sắp xếp danh mục để thể hiện trang chủ
        /// Ví dụ Tivi (Order=1), Quạt làm mát (Order= 2), Amply (Order=3)
        /// </summary>
        public int OrderLevel { get; set; }
        public ICollection<ProductCategoryEntity> ProductCategories { get; set; }

        public virtual ICollection<TemplateEntity> Templates { get; set; }

        public virtual ICollection<PropertyEntity> Properties { get; set; }

    }
}
