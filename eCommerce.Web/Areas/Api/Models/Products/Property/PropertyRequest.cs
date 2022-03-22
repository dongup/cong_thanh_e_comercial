using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Entities;
using eCommerce.Web.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Areas.Api.Models.Products.Property
{
    public class PropertyRequest : BaseModel
    {
        public PropertyEntity CopyTo(PropertyEntity entity)
        {
            base.CopyTo(entity);
            entity.PropertyName = PropertyName;
            entity.CategoryId = CategoryId == 0? null : CategoryId;
            //entity.Values = ValueIds.Select(x => new ValueEntity() { Id = x }).ToList();

            return entity;
        }
        
        [NotEmpty(ErrorMessage = "Tên thuộc tính không được để trống!")]
        public string PropertyName { get; set; }

        public int? CategoryId { get; set; }

        public List<int> ValueIds { get; set; }
    }
}
