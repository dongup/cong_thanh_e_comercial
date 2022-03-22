using eCommerce.Utils;
using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Areas.Api.Models.Orders
{
    public class CustomerResponse : BaseModel
    {
        public CustomerResponse(CustomerEntity entity) : base(entity)
        {
            if (entity == null) return;

            FullName = entity.FullName;
            Address = entity.Address;
            Phone = entity.Phone;
            Email = entity.Email;
            ReceiveAddress = entity.ReceiveAddress;
            try
            {

                Orders = entity.Orders?.Select(x => new OrderResponse(x)).ToList();
            }
            catch (Exception e)
            {

            }
        }

        public string FullName { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string ReceiveAddress { get; set; }

        public ICollection<OrderResponse> Orders { get; set; }
    }

    public class SimpleCustomerResponse : BaseModel
    {
        public SimpleCustomerResponse(CustomerEntity entity) : base(entity)
        {
            if (entity == null) return;

            FullName = entity.FullName;
            Address = entity.Address??"";
            Phone = entity.Phone;
            Email = entity.Email??"";
            ReceiveAddress = entity.ReceiveAddress??"";
        }

        public string FullName { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string ReceiveAddress { get; set; }
    }
}
