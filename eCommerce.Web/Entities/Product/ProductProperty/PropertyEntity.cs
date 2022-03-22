using eCommerce.Web.Entities.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Entities
{
    public class PropertyEntity : BaseEntity
    {
        public PropertyEntity() : base()
        {
            PropertyTemplates = new HashSet<PropertyTemplateEntity>();
            Values = new HashSet<ValueEntity>();
        }

        public int? CategoryId { get; set; }

        public string PropertyName { get; set; }

        //Xác định thuộc tính này có filter hay không
        public bool IsFilter { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public virtual CategoryEntity Category { get; set; }

        public virtual ICollection<ValueEntity> Values { get; set; }

        public virtual ICollection<PropertyTemplateEntity> PropertyTemplates { get; set; }
    }
}
