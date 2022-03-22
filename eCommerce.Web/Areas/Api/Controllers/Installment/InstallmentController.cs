using eCommerce.Web.Areas.Api.Models.Installment;
using eCommerce.Web.Areas.Api.Models.Products.Product;
using eCommerce.Web.Entities;
using eCommerce.Web.Entities.Identity;
using eCommerce.Web.Entities.Installment;
using eCommerce.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Linq;
namespace eCommerce.Web.Areas.Api.Controllers.Installment
{
    [Route("api/[controller]")]
    [ApiController]

    public class InstallmentController : BaseApiController
    {

        public InstallmentController(DatabaseContext context, UserManager<UserEntity> userManager) : base(context, userManager: userManager)
        {

        }

        [HttpPost]
        public ResponseModel Post(InstallmentRequest info)
        {
            DateTime.TryParseExact(info.FromDateString, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime from);
            DateTime.TryParseExact(info.ToDateString, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime to);
            if (to < from)
            {
                res.Message = "Thời gian kết thức phải lớn hơn thời gian bắt đầu";
                return res;
            }
            var products = info.Products.Select(n => new InstallmentPromotionProductEntity() { ProductId = n.Id }).ToList();
            var entity = new InstallmentPromotionEntity()
            {
                CreatedDate = DateTime.Now,
                CreatedUserId = CurrentUser.Id,
                FromDate = from,
                ToDate = to,
                InstallmentBankId = info.InstallmentBankId,
                Name = info.Name,
                InstallmenProducts = products
            };
            _context.InstallmentPromotions.Add(entity);
            res.IsSuccess = _context.SaveChanges() > 0;
            return res;
        }

        [HttpDelete("{id}")]
        public ResponseModel Delete(int id)
        {
            try
            {
                var entity = _context.InstallmentPromotions.Find(id);
                _context.InstallmentPromotions.Remove(entity);
                _context.SaveChanges();
                res.Succeed();
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }
            return res;
        }

        [HttpPut]
        public ResponseModel Put(InstallmentRequest info)
        {
            DateTime.TryParseExact(info.FromDateString, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime from);
            DateTime.TryParseExact(info.ToDateString, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime to);

            if (to < from)
            {
                res.Message = "Thời gian kết thức phải lớn hơn thời gian bắt đầu";
                return res;
            }

            var entity = _context.InstallmentPromotions
                .Include(n => n.InstallmentBank)
                .Include(n => n.InstallmenProducts)
                .Where(n => n.Id == info.Id).FirstOrDefault();
            if (entity == null)
            {
                res.Message = "Không tìm thấy chương trình ";
                return res;
            }
            var products = info.Products.Select(n => new InstallmentPromotionProductEntity() { ProductId = n.Id, CreatedUserId = CurrentUser.Id }).ToList();
            entity.Name = info.Name;
            entity.UpdatedDate = DateTime.Now;
            entity.UpdatedUserId = CurrentUser.Id;
            entity.FromDate = from;
            entity.ToDate = to;
            entity.InstallmenProducts = products;
            entity.InstallmentBankId = info.InstallmentBankId;
            res.IsSuccess = _context.SaveChanges() > 0;
            return res;
        }

        [HttpGet("byid/{id}")]
        public ResponseModel Get(int Id)
        {
            var entity = _context.InstallmentPromotions
             .Include(n => n.InstallmenProducts)
             .ThenInclude(n => n.Product)
             .Where(n => n.Id == Id)
             .Select(n => new InstallmentResponse()
             {
                 Id = n.Id,
                 ToDate = n.ToDate,
                 FromDate = n.FromDate,
                 ToDateString = n.ToDate.ToString("dd/MM/yyyy"),
                 FromDateString = n.FromDate.ToString("dd/MM/yyyy"),
                 InstallmentBankName = n.InstallmentBank.BankName,
                 InstallmentBankId = n.InstallmentBankId,
                 Name = n.Name,
                 Products = n.InstallmenProducts.Select(x => new ProductSimpleMostRespone()
                 {
                     Id = x.ProductId,
                     GiaBanLe=x.Product.GiaBanLe,
                     ProductCode=x.Product.ProductCode,
                     ProductName = x.Product.ProductName,
                     InstallmentPrice = x.Product.InstallmentPrice
                 }).ToList()
             }).FirstOrDefault();
        res.IsSuccess = entity != null;
            res.Result = entity;
            return res;
        }

    [HttpGet("GetByIndex")]
    public ResponseModel GetByIndex(int keysearch)
    {
        res.Result = _context.InstallmentPromotions
            .Select(n => new InstallmentResponse()
            {
                Id = n.Id,
                CountProduct = n.InstallmenProducts.Count,
                FromDate = n.FromDate,
                ToDate = n.ToDate,
                FromDateString = n.FromDate.ToString("dd/MM/yyyy"),
                ToDateString = n.ToDate.ToString("dd/MM/yyyy"),
                InstallmentBankId = n.InstallmentBank.Id,
                InstallmentBankName = n.InstallmentBank.BankName,
                Name = n.Name,
                IsActive = n.ToDate >= DateTime.Now.AddDays(-1)

            })
           .ToList();
        res.IsSuccess = true;
        return res;
    }

    [HttpGet("installment-by-url")]
    public ResponseModel getByUser(int prepay, int month, string url)
    {
        var product = _context.Products
            .Include(n => n.PromotionProducts).ThenInclude(n => n.Promotion)
            .Where(n => n.FriendlyUrl == url)
            .Select(n => new ProductResponse(n))
            .FirstOrDefault();

        var banks = _context.InstallmentBanks
            .Include(n => n.InstallmentPromotions).ThenInclude(x => x.InstallmenProducts)
            .Select(n => new InstallmentBankResponse(n))
            .ToList();

        var info = banks.Select(n =>
        {
            var promos = n.InstallmentPromotions?.Where(n => n.ToDate > DateTime.Now.AddDays(-1));
            bool Is0Percent = false;// Kiểm tra trong các chương trình khuyến mãi có sản phẩm này hay ko , nếu có thi sét lãi xuất = 0%
                foreach (var item in promos)
            {
                if (item.InstallmentProducts.Any(x => x.ProductId == product.Id))
                {
                    Is0Percent = true;
                }
            }
            if (Is0Percent)
            {
                n.InterestRate = 0;
            }
            var GiaBanTraGop = product.GiaBanLe;
            var TienTraTruoc = GiaBanTraGop / 100 * prepay;
            var ChenhLech = (float)Math.Round(((GiaBanTraGop - TienTraTruoc) * (n.InterestRate / 100) * month), 0);
            var GopMoiThang = (GiaBanTraGop - TienTraTruoc) / month + (ChenhLech / month);


            var check = n.InstallmentPromotions.Where(n => n.ToDate > DateTime.Now.AddDays(-1));
            return new InstallmentBankUserResponse()
            {
                Id = n.Id,
                GiaSanPham = product.GiaBanLe,
                GiaMuaTraGop = GiaBanTraGop,
                PhanTramTraTruoc = prepay,
                TienTraTruoc = TienTraTruoc,
                LaiXuat = n.InterestRate,
                GopMoiThang = (int)GopMoiThang,
                TongTienPhaiTra = GiaBanTraGop + (int)ChenhLech + n.PhiHoSo,
                ChenhLechVoiMuaTraThang = ChenhLech,
                GiayToCanCo = n.Papers,
                BankName = n.BankName,
                PhiHoSo = n.PhiHoSo,
                LogoPath = n.LogoPath,
                CountMonth = n.CountMonth,
                TienTraGop = GiaBanTraGop - TienTraTruoc,
                MaximumPrepay = n.MaximumPrepay,
                MiximumPrepay = n.MiximumPrepay,
                IsSupport = n.CountMonth.Split("|").Any(i => i == month.ToString()) && prepay >= n.MiximumPrepay && prepay <= n.MaximumPrepay
            };
        });


        res.IsSuccess = true;
        res.Result = info;
        return res;
    }

}

//    Công thức tính trả góp:

//Tiền trả trước  =	Giá bán * Phần trăm trả trước ;
//Tiền chênh lệch sau khi trả góp = (Giá bán sản phẩm - tiền trả trước) * Lãi xuất* Kì hạn(12 thang)
//Số tiền trả hàng tháng = (Giá bán sản phẩm - tiền trả trước)/ Kì hạn
public class InstallmentBankUserResponse : InstallmentBankResponse
{
    public int GiaSanPham { get; set; }
    public int GiaMuaTraGop { get; set; }
    public int PhanTramTraTruoc { get; set; }
    public int TienTraTruoc { get; set; }
    public int TienTraGop { get; set; }
    public float LaiXuat { get; set; }
    public int GopMoiThang { get; set; }
    public int TongTienPhaiTra { get; set; }
    public float ChenhLechVoiMuaTraThang { get; set; }
    public string GiayToCanCo { get; set; }
    public bool IsSupport { get; set; }
}
}
