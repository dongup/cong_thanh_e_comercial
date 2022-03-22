using eCommerce.Web.Entities.Installment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Areas.Api.Models.Installment
{
    public class InstallmentBankResponse
    {

        public InstallmentBankResponse()
        {

        }
        public InstallmentBankResponse(InstallmentBankEntity n)
        {
            Id = n.Id;
            BankName = n.BankName;
            LogoPath = n.LogoPath;
            Papers = n.Papers;
            InterestRate = n.InterestRate;
            CountMonth = n.CountMonth;
            MiximumPrepay = n.MiximumPrepay;
            MaximumPrepay = n.MaximumPrepay;
            PhiHoSo = n.PhiHoSo;
            InstallmentPromotions = n.InstallmentPromotions?.Select(x => new InstallmentPromotionResponse(x)
           ).ToList();
        }

        public ICollection<InstallmentPromotionResponse> InstallmentPromotions { get; set; }
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên không được để trống")]
        public string BankName { get; set; }

        [Required(ErrorMessage = "Logo không được để trống")]
        public string LogoPath { get; set; }

        /// <summary>
        /// // Giấy tờ cần thiết nhưn chứng minh, hóa đơn điện nước
        /// </summary>ư
        [Required(ErrorMessage = "Giấy tờ không được để trống")]
        public string Papers { get; set; }

        /// <summary>
        /// Lãi xuất
        /// </summary>

        [Required(ErrorMessage = "Logo không được để trống")]
        public float InterestRate { get; set; }

        /// <summary>
        /// Thời gian trả trong vòng mấy tháng .
        /// Ví dụ: 6,9,12 => Lưu theo chuỗi cách bởi đấu ','
        /// </summary>
        public string CountMonth { get; set; }
        /// <summary>
        /// Số tiền trả trước tối thiểu
        /// </summary>
        [ValidPrepayMiximun]
        public int MiximumPrepay { get; set; }

        /// <summary>
        /// Số tiền trả trước tối đa
        /// </summary>
        [ValidPrepayMaximun]
        public int MaximumPrepay { get; set; }

        /// <summary>
        /// Phí làm hồ sơ
        /// </summary>
        public int PhiHoSo { get; set; }
    }
    public class InstallmentBankRequest : InstallmentBankResponse
    {

    }

    public class ValidPrepayMiximunAttribute : ValidationAttribute
    {
        public string ErrMsg { get; set; } = "Mức trả trước tối thiểu phải lớn hơn 0, nhỏ hơn hoặc bằng 70 và là bội của 10";
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                float.TryParse(value.ToString(), out float mix);
                if (mix < 0 || (mix % 10 != 0) || mix > 70)
                {
                    return new ValidationResult(ErrMsg);
                }
            }
            return ValidationResult.Success;
        }
    }
    public class ValidPrepayMaximunAttribute : ValidationAttribute
    {
        public string ErrMsg { get; set; } = "Mức trả trước tối đa phải nhỏ hơn 100 và là bội của 10";
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                float.TryParse(value.ToString(), out float mix);
                if (mix > 100 || (mix % 10 != 0))
                {
                    return new ValidationResult(ErrMsg);
                }
            }
            return ValidationResult.Success;
        }
    }
    public class InstallmentPromotionResponse
    {
        public InstallmentPromotionResponse(InstallmentPromotionEntity n)
        {
            FromDate = n.FromDate;
            ToDate = n.ToDate;
            Name = n.Name;
            InstallmentBank = n.InstallmentBank;
            InstallmentProducts = n.InstallmenProducts;
        }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Name { get; set; }
        public int InstallmentBankId { get; set; }
        public InstallmentBankEntity InstallmentBank { get; set; }
        public ICollection<InstallmentPromotionProductEntity> InstallmentProducts { get; set; }
    }
}
