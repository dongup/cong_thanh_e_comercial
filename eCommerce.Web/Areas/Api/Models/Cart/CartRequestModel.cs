using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Areas.Api.Models.Cart
{
    public class CartRequestModel
    {
        public int ProductId { get; set; }// Dùng khi thêm giỏ
        public int CartId { get; set; }// Dùng khi xóa giỏ
    }
}
