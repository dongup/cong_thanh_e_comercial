using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Areas.Api.Models.Products.Property
{
    public class SetFilterRequest
    {
        //true = add, false = remove
        public bool Type { get; set; }
        public int PropertyId { get; set; }
        public List<int> ValueIds { get; set; }

    }
}
