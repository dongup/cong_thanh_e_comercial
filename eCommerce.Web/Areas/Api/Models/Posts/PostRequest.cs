using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Entities.Post;
using static eCommerce.Web.Entities.Post.PostEntity;

namespace eCommerce.Web.Areas.Api.Models.Posts
{
    public class PostRequest : PostResponse
    {
        public PostEntity CopyTo(PostEntity entity)
        {
            base.CopyTo(entity);
            entity.PostCategoryId = PostCategoryId;
            entity.BannerId = BannerId;
            entity.Title = Title;
            entity.Content = Content;
            entity.FriendlyUrl = FriendlyUrl;
            entity.Type = Type;
            entity.Tag = Tag;
            entity.ThumbNail = ThumbNail;
            entity.SubTitle = SubTitle;

            return entity;
        }

        protected new int Id { get; set; }

        public string Tag { get; set; }

        protected new PostCategoryResponse PostCategory { get; set; }

        protected new FileResponse Banner { get; set; }
    }
}
