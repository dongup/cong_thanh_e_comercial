using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Areas.Api.Models.Products.Property
{
    public class ProductPropertyResponse : BaseModel
    {
        public ProductPropertyResponse()
        {

        }

        public ProductPropertyResponse(ProductPropertyEntity entity) : base(entity)
        {
            Property = new PropertyResponse(entity.Property);
            Values = entity.PropertyValues?.Select(x => new ValueModel(x?.Value)).ToList();
            PropertyId = entity.PropertyId;
        }

        public int PropertyId { get; set; }

        public virtual PropertyResponse Property { get; set; }

        public virtual ICollection<ValueModel> Values { get; set; }
    }

    public class ProductPropertyRequest : ProductPropertyResponse
    {
        public ProductPropertyRequest()
        {

        }

        public ProductPropertyEntity CopyTo(ProductPropertyEntity entity)
        {
            base.CopyTo(entity);
            entity.PropertyValues = ValueIds.Select(x => new ProductPropertyValueEntity()
            {
                ValueId = x
            }).ToList();
            entity.PropertyId = PropertyId;

            return entity;
        }

        public virtual List<int> ValueIds { get; set; } = new List<int>();

        protected new virtual PropertyResponse Property { get; set; }

        protected new virtual ICollection<ValueModel> Values { get; set; }
    }
}
