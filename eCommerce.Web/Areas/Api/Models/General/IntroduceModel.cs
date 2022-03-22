using eCommerce.Web.Areas.Api.Models.Posts;
using eCommerce.Web.Entities.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Areas.Api.Models.General
{
    public class IntroduceRequest
    {
        public IntroduceRequest()
        {

        }

        public IntroduceEntity CopyTo(IntroduceEntity entity)
        {
            entity.BannerImages = BannerImages;
            entity.Introduction = Introduction;
            entity.PostId = PostId;

            //entity.ProductCategories = ProductCategories;
            return entity;
        }

        [Required(ErrorMessage = "Vui lòng chọn hình ảnh banner")]
        public string BannerImages { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập nội dung giới thiệu!")]
        public string Introduction { get; set; }

        //[Required(ErrorMessage = "Vui lòng chọn danh mục sản phẩm!")]
        //public string ProductCategories { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn một bài đăng!")]
        public int PostId { get; set; }
    }

    public class IntroduceResponse 
    {
        public IntroduceResponse()
        {

        }

        public string Introduction { get; set; }

        public virtual PostResponse Post { get; set; }

       public virtual ICollection<CategoryResponse> ProductCategories { get; set; }

        public virtual ICollection<FileResponse> BannerImages { get; set; }

        public virtual ICollection<ProductBrandResponse > Brands { get; set; }

    }
}
