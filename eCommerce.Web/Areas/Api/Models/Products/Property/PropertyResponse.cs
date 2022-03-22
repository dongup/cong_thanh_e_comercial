using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Areas.Api.Models.Products.Property
{
    public class PropertyResponse : BaseModel
    {
        public PropertyResponse()
        {

        }

        public PropertyResponse(PropertyEntity entity) : base(entity)
        {
            if (entity == null) return;

            PropertyName = entity.PropertyName;
            PropertyTemplateId = PropertyTemplateId;
            IsFilter = entity.IsFilter;
            Values = entity.Values?.Select(x => new ValueModel(x)).ToList();
            CategoryId = entity.CategoryId;
            CategoryName = entity.Category?.CategoryName;
        }

        public string PropertyName { get; set; }

        public int PropertyId { get; set; }

        public int PropertyTemplateId { get; set; }

        public int? CategoryId { get; set; }

        public bool IsFilter { get; set; }

        public string CategoryName { get; set; }
        public virtual ICollection<ValueModel> Values { get; set; }
    }

    public class PropertyFilterResponse : PropertyResponse
    {
        public PropertyFilterResponse()
        {

        }

        public PropertyFilterResponse(PropertyEntity entity) : base(entity)
        {
            if (entity == null) return;
            Values = entity.Values.Where(x => x.IsFilter == true).Select(x => new ValueModel(x)).ToList();
        }
    }
}
