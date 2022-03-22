using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Entities.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Areas.Api.Models.Posts
{
    public class PostCategoryResponse : BaseModel
    {
        public PostCategoryResponse()
        {

        }

        public PostCategoryResponse(PostCategoryEntity entity)
        {
            if (entity == null) return;

            Id = entity.Id;
            Name = entity.Name;
            FriendlyUrl = entity.FriendlyUrl;

            CountPost = entity.Posts.Count();
        }

        public string FriendlyUrl { get; set; }

        public string Name { get; set; }

        public int CountPost { get; set; }
    }
}
