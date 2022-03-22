using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Areas.Api.Models.Orders
{
    public class CustomerRequest : BaseModel
    {
        public CustomerRequest()
        {

        }

        public CustomerEntity CopyTo(CustomerEntity entity)
        {
            base.CopyTo(entity);
            entity.FullName = FullName;
            entity.Address = Address;
            entity.Phone = Phone;
            entity.Email = Email;
            entity.ReceiveAddress = ReceiveAddress;

            return entity;
        }

        public string FullName { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string ReceiveAddress { get; set; }
    }
}
