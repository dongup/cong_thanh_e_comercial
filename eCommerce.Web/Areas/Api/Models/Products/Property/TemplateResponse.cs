using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Entities;
using eCommerce.Web.Entities.Product;
using System.Collections.Generic;
using System.Linq;

namespace eCommerce.Web.Areas.Api.Models.Products.Property
{
    public class TemplateResponse : BaseModel
    {
        public TemplateResponse()
        {

        }
        public TemplateResponse(CategoryEntity e)
        {

        }


        public TemplateResponse(TemplateEntity entity) : base(entity)
        {
            PropertyTemplateName = entity.PropertyTemplateName;
            CategoryId = entity.CategoryId;

            Properties = entity.PropertyTemplates.Select(x => new PropertyResponse(x.Property)).ToList();
            ProductCategory = new CategoryResponse(entity.ProductCategory);
        }

        public string PropertyTemplateName { get; set; }

        public int CategoryId { get; set; }

        public ICollection<PropertyResponse> Properties { get; set; }

        public CategoryResponse ProductCategory { get; set; }
    }

    public class SimpleTemplateResponse : BaseModel
    {
        public SimpleTemplateResponse()
        {

        }

        public SimpleTemplateResponse(TemplateEntity entity) : base(entity)
        {
            PropertyTemplateName = entity.PropertyTemplateName;
            CategoryId = entity.CategoryId;

            //ProductCategory = new ProductCategoryResponse(entity.ProductCategory);
        }

        public string PropertyTemplateName { get; set; }

        public int CategoryId { get; set; }

        //public ProductCategoryResponse ProductCategory { get; set; }
    }
}
