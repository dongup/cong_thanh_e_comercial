using eCommerce.Web.Areas.Api.Models.Products.Product;
using eCommerce.Web.Areas.Api.Models.Products.ProductGroup;
using eCommerce.Web.Entities.Installment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Areas.Api.Models.Installment
{
    public class InstallmentResponse
    {
        public int Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
     
        public string Name { get; set; }
        public string InstallmentBankName { get; set; }
        public int InstallmentBankId { get; set; }
        public List<ProductSimpleMostRespone> Products { get; set; }
        public string FromDateString { get; set; }
        public string ToDateString { get; set; }
        public int CountProduct { get; set; }
        public bool IsActive { get; set; }
    }
    public class InstallmentRequest: InstallmentResponse
    {
        public int Id { get; set; }
      
    }

}
