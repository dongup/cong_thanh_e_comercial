using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Areas.Api.Models.Products.Property
{
    public class AddMultiValueModel
    {
        public AddMultiValueModel()
        {

        }

        public List<ValueModel> Values { get; set; }
    }
}
