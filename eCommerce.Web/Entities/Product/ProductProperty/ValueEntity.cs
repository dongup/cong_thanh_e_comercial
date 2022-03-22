using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Entities.Product
{
    public class ValueEntity : BaseEntity
    {
        public ValueEntity()
        {
            //PropertyValues = new HashSet<PropertyValueEntity>();
        }
        public string Value { get; set; }

        public int? CategoryId { get; set; }

        public int? PropertyId { get; set; } = null;

        //Xác định giá trị này có hiển thị lên filter hay không
        public bool IsFilter { get; set; }

        [ForeignKey(nameof(PropertyId))]
        public virtual PropertyEntity Property { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public virtual CategoryEntity Category { get; set; }
    }
}
