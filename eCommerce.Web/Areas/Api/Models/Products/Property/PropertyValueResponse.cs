using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Entities;

namespace eCommerce.Web.Areas.Api.Models.Products.Property
{
    public class PropertyValueResponse : BaseModel
    {
        public PropertyValueResponse()
        {

        }

        public PropertyValueResponse(ProductPropertyValueEntity entity) : base(entity)
        {

        }
    }
}
