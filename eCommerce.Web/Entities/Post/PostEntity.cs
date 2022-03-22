using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Entities.Post
{
    public class PostEntity : BaseEntity
    {
        public PostEntity() : base()
        {

        }

        public int PostCategoryId { get; set; }

        public int? BannerId { get; set; }

        /// <summary>
        /// Ảnh đại diện bài viết (Thumbnail)
        /// </summary>
        public string ThumbNail { get; set; }

        public string Title { get; set; } = "";

        public string Content { get; set; }

        public string FriendlyUrl { get; set; }

        public string Tag { get; set; } = "";

        public string SubTitle { get; set;}

        public PostType Type { get; set; } = PostType.Temp;

        public PostStatus Status { get; set; } = PostStatus.Pending;

        public enum PostType { 
            Temp = 1, 
            Offical = 2
        }

        public enum PostStatus
        {
            Pending = 1,
            Approved = 2
        }

        [ForeignKey(nameof(PostCategoryId))]
        public virtual PostCategoryEntity PostCategory { get; set; }

        [ForeignKey(nameof(BannerId))]
        public virtual FileEntity Banner { get; set; }
    }
}
