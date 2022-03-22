using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        public string Note { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedUserId { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? UpdatedUserId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
