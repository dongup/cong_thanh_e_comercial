using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Entities.Product;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Web.Areas.Api.Models.Products.Property
{
    public class ValueModel : BaseModel
    {
        public ValueModel()
        {

        }

        public ValueModel(ValueEntity entity) : base(entity)
        {
            if (entity == null) return;
            Value = entity.Value;
            PropertyId = entity.PropertyId;
            IsFilter = entity.IsFilter;
            Id = entity.Id;
        }

        public ValueEntity CopyTo(ValueEntity entity)
        {
            base.CopyTo(entity);
            entity.Value = Value;
            if(PropertyId != 0)
            {
                entity.PropertyId = PropertyId;
            }
            else
            {
                entity.PropertyId = null;
            }

            return entity;
        }

        public int? PropertyId { get; set; } = null;

        public bool IsFilter { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập giá trị thuộc tính")]
        public string Value { get; set; }

    }
}
