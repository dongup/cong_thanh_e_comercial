using eCommerce.Web.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Entities.Product
{
    public class ProductCommentEntity : BaseEntity
    {
        public ProductCommentEntity() : base()
        {

        }

        public int ProductId { get; set; }

        public string Conntent { get; set; }

        public int CustomerId { get; set; }

        public bool IsParent { get; set; }

        public bool IsApproved { get; set; }

        public int ApprovedUserId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public ProductEntity Product { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public UserEntity Customer { get; set; }

        [ForeignKey(nameof(ApprovedUserId))]
        public UserEntity AprovedUser { get; set; }
    }
}
