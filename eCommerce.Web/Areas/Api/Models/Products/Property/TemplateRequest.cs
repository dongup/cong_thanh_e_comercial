using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Entities;
using eCommerce.Web.Entities.Product;
using System.Collections.Generic;
using System.Linq;

namespace eCommerce.Web.Areas.Api.Models.Products.Property
{
    public class TemplateRequest : BaseModel
    {
        public TemplateEntity CopyTo(TemplateEntity entity)
        {
            base.CopyTo(entity);
            entity.PropertyTemplateName = PropertyTemplateName;
            entity.CategoryId = CategoryId;
            entity.PropertyTemplates = PropertyIds.Select(x => new PropertyTemplateEntity()
            {
                PropertyId = x
            }).ToList();

            return entity;
        }

        public int CategoryId { get; set; }

        [NotEmpty(ErrorMessage = "Tên mẫu thuộc tính không đc để trống!")]
        public string PropertyTemplateName { get; set; }

        public List<int> PropertyIds { get; set; }

    }
}
