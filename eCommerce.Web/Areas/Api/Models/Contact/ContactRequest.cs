using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Entities.Generals;
using System.ComponentModel.DataAnnotations;
using static eCommerce.Web.Entities.Generals.ContactEntity;

namespace eCommerce.Web.Areas.Api.Models.Contact
{
    public class ContactRequest : BaseModel
    {
        public ContactEntity CopyTo(ContactEntity entity)
        {
            base.CopyTo(entity);
            entity.CustomerName = CustomerName;
            entity.Phone = Phone;
            entity.Email = Email;
            entity.Address = Address;
            entity.Content = Content;
            //entity.Status = (ContactStatus)Status;
            return entity;
        }
        public string Recaptcha { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập họ tên!")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số điện thoại!")]
        public string Phone { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập nội dung!")]
        public string Content { get; set; }

        /// <summary>
        /// Trạng thái của liên hệ 
        /// 0: Chưa xử lý
        /// 1: Đã xử lý
        /// </summary>
        public int Status { get; set; }
    }
}
