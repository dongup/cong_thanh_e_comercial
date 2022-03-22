using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Entities.General
{
    public class OurBrandEntity : BaseEntity
    {
        public OurBrandEntity() : base()
        {

        }

        public string Name { get; set; }

        public int LogoId { get; set; }

        public bool IsShow { get; set; }

        public virtual FileEntity Logo { get; set; }
    }
}
