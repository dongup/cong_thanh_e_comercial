using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Entities.Product
{
    public class PropertyTemplateEntity : BaseEntity
    {
        public PropertyTemplateEntity() : base()
        {

        }

        public int? TemplateId { get; set; }

        public int PropertyId { get; set; }

        [ForeignKey(nameof(TemplateId))]
        public virtual TemplateEntity Template { get; set; }

        [ForeignKey(nameof(PropertyId))]
        public virtual PropertyEntity Property { get; set; }
    }
}
