using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Areas.Api.Models.Products.ProductGroup
{
    public class ProductGroupSimpleResponse
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public string CreatedDate { get; set; }
        public string Note { get; set; }
        public int CountProduct { get; set; }
        public string FriendlyUrl { get; set; }
    }
    
}
