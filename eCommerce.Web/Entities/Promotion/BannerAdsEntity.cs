using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Entities.Promotion
{
    public class BannerAdsEntity : BaseEntity
    {
        public string LeftFriendlyUrl { get; set; }
        public string RighFriendlyUrl { get; set; }
        public string TopFriendlyUrl { get; set; }
        public bool IsShowLeft { get; set; }
        public bool IsShowRight { get; set; }
        public bool IsShowTop { get; set; }
        public string LeftPath { get; set; }
        public string RightPath { get; set; }
        public string TopPath { get; set; }

        /// <summary>
        /// 3 banner dưỡi slide
        /// </summary>
        public string PathBannerBottomSlide1 { get; set; }
        public string PathBannerBottomSlide2 { get; set; }
        public string PathBannerBottomSlide3 { get; set; }

        public string UrlBannerBottomSlide1 { get; set; }
        public string UrlBannerBottomSlide2 { get; set; }
        public string UrlBannerBottomSlide3 { get; set; }

        public bool IsShowBannerBottomSlide1 { get; set; }
        public bool IsShowBannerBottomSlide2 { get; set; }
        public bool IsShowBannerBottomSlide3 { get; set; }

        /// <summary>
        /// Banner top chương trình khuyến mãi
        /// </summary>
        /// 
        public string BannerTopPromotionPath{ get; set; }
        public bool IsShowBannerTopPromotionPath { get; set; }
        public string BannerTopPromotionFriendlyUrl { get; set; }

    }
}
