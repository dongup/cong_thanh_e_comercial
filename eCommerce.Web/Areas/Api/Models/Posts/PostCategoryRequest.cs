using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Entities.Post;

namespace eCommerce.Web.Areas.Api.Models.Posts
{
    public class PostCategoryRequest : BaseModel
    {
        public PostCategoryEntity CopyTo(PostCategoryEntity entity)
        {
            base.CopyTo(entity);
            entity.Name = Name;
            entity.FriendlyUrl = FriendlyUrl;
            return entity;
        }

        public string Name { get; set; }

        public string FriendlyUrl { get; set; }

        protected new int Id { get; set; }
    }
}
