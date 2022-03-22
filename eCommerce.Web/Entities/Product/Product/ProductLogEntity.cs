using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Entities.Product
{
    public class ProductLogEntity : BaseEntity
    {
        public ProductLogEntity() : base()
        {

        }

        public int ProductId { get; set; }

        public string Content { get; set; }

        public LogLevel Level { get; set; } = LogLevel.Information;

        public enum LogLevel
        {
            Error = 0,
            Information = 1,
            Warnning = 2,
        }

        [ForeignKey(nameof(ProductId))]
        public virtual ProductEntity Product { get; set; }
    }
}
