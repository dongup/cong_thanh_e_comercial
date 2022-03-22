using eCommerce.Web.Entities.Generals;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Areas.Api.Models.General
{
    public class PopupResponse : BaseModel
    {
        public PopupResponse()
        {

        }

        public PopupResponse(PopupEntity entity) : base(entity)
        {
            ImageId = entity.ImageId;
            Link = entity.Link;
            Title = entity.Title;
            SubTitle = entity.SubTitle;
            IsShow = entity.IsShow;
            BannerNgang =entity.BannerNgang;
            Image = new FileResponse(entity.Image);
        }

        [Range(1, int.MaxValue, ErrorMessage = "Vui lòng chọn một hình ảnh cho popup!")]
        public int ImageId { get; set; }

        [Required(ErrorMessage = "Vui lòng chỉ định đường dẫn!")]
        public string Link { get; set; }

        public string Title { get; set; }
        public string BannerNgang { get; set; }

        public string SubTitle { get; set; }

        public bool IsShow { get; set; }

        public FileResponse Image { get; set; }
    }
}
