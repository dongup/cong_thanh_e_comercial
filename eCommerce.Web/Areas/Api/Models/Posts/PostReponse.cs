using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Areas.Api.Models.User;
using eCommerce.Web.Entities;
using eCommerce.Web.Entities.Post;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static eCommerce.Web.Entities.Post.PostEntity;

namespace eCommerce.Web.Areas.Api.Models.Posts
{
    public class PostResponse : BaseModel
    {
        private DatabaseContext _context;

        public PostResponse()
        {

        }

        public PostResponse(PostEntity entity, DatabaseContext _context = null) : base(entity)
        {
            this._context = _context;
            if (entity == null) return;

            PostCategoryId = entity.PostCategoryId;
            BannerId = entity.BannerId;
            Title = entity.Title;
            Content = entity.Content;
            FriendlyUrl = entity.FriendlyUrl;
            Type = entity.Type;
            ThumbNail = entity.ThumbNail;
            Status = entity.Status;
            SubTitle = entity.SubTitle;
            PostCategory = new PostCategoryResponse(entity.PostCategory);
            Banner = new FileResponse(entity.Banner);
            if(_context != null)
            {
                CreatedUser = new UserResponse(_context.Users.Find(CreatedUserId));
            }
        }

        public string SubTitle { get; set; }

        public PostCategoryResponse PostCategory { get; set; }
        /// <summary>
        /// Ảnh đại diện bài viết (Thumbnail)
        /// </summary>
        public string ThumbNail { get; set; }
        public FileResponse Banner { get; set; }

        public int PostCategoryId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "")]
        public int? BannerId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string FriendlyUrl { get; set; }

        public PostType Type { get; set; }

        public PostStatus Status { get; set; }

        public new string CreatedDate { get => base.CreatedDate; set => base.CreatedDate = value; }

        protected new int CreatedUserId { get => base.CreatedUserId; set => base.CreatedUserId = value; }

        public UserResponse CreatedUser { get; set; }
    }
}
