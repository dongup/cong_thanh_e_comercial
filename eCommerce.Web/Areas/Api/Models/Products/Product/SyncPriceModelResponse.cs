using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Areas.Api.Models.Products.Product
{
    public class SyncPriceModelResponse
    {
        public string ProductID { get; set; }
        public int? GiaBanLe { get; set; }
        public int? GiaNiemYet { get; set; }
        public int? SoLuongTon { get; set; }
        public int GiaBanLeCu { get; set; }
        public int GiaNiemYetCu { get; set; }
        public int SoLuongTonCu { get; set; }
        public string GhiChu { get; set; }
        public string TenSanPham { get; set; }
        public string HanSuDung { get; set; }
        public string XuatSu { get; set; }
        public string ThongTinKhuyenMai { get; set; }
    }
}
