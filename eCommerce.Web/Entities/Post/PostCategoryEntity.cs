using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Entities.Post
{
    public class PostCategoryEntity : BaseEntity
    {
        public PostCategoryEntity() : base()
        {
            Posts = new HashSet<PostEntity>();
        }

        public string Name { get; set; }

        public string FriendlyUrl { get; set; }

        public virtual ICollection<PostEntity> Posts { get; set; }
    }
}
