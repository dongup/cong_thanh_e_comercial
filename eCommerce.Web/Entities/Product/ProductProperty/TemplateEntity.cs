using eCommerce.Web.Entities.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Entities
{
    public class TemplateEntity : BaseEntity
    {
        public TemplateEntity() : base()
        {
            PropertyTemplates = new HashSet<PropertyTemplateEntity>();
        }

        public string PropertyTemplateName { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public CategoryEntity ProductCategory { get; set; }

        public virtual ICollection<PropertyTemplateEntity> PropertyTemplates { get; set; }
    }
}
