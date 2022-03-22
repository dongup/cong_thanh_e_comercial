using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Entities.Generals;
using static eCommerce.Web.Entities.Generals.ContactEntity;

namespace eCommerce.Web.Areas.Api.Models.Contact
{
    public class ContactResponse : BaseModel
    {
        public ContactResponse(ContactEntity entity) : base(entity)
        {
            CustomerName = entity.CustomerName;
            Phone = entity.Phone;
            Email = entity.Email;
            Address = entity.Address;
            Content = entity.Content;
            Status = entity.Status;
        }

        public string CustomerName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Content { get; set; }

        /// <summary>
        /// Trạng thái của liên hệ 
        /// 0: Chưa xử lý
        /// 1: Đã xử lý
        /// </summary>
        public ContactStatus Status { get; set; }

        public new string CreatedDate { get => base.CreatedDate; set => base.CreatedDate = value; }
    }
}
