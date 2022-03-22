using System.Collections.Generic;

namespace eCommerce.Web.Entities.Orders
{
    public class BankEntity : BaseEntity
    {
        public BankEntity() : base()
        {

        }

        public string BankName { get; set; }

        public string Logo { get; set; }

        public string Address { get; set; }

        public string AccountName { get; set; }

        public string AccountNumber { get; set; }

        public ICollection<OrderEntity> Orders { get; set; }
    }
}