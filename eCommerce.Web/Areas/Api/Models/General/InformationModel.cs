using eCommerce.Web.Entities.Generals;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Areas.Api.Models.General
{
    public class InformationModel : BaseModel
    {
        public InformationModel()
        {

        }

        public InformationModel(InformationEntity entity) : base(entity)
        {
            if (entity == null) return;

            CompanyName = entity.CompanyName;
            Address = entity.Address;
            Email = entity.Email;
            Logo = entity.Logo;
            MailServer = entity.MailServer;

            FbAppId = entity.FbAppId;
            ZaloOAId = entity.ZaloOAId;
            FbAccessToken = entity.FbAccessToken;
            ZaloAccessToken = entity.ZaloAccessToken;
            ZaloRecipientIds = entity.ZaloRecipientIds;

            FacebookUrl = entity.FacebookUrl;
            YoutubeUrl = entity.YoutubeUrl;
            Hotline = entity.Hotline;
            CSKH = entity.CSKH;
            MailAddress = entity.MailAddress;
            MaSoThue = entity.MaSoThue;
            BoCongThuong_Url = entity.BoCongThuong_Url;
            InstagramUrl = entity.InstagramUrl;

        }

        public InformationEntity CopyTo(InformationEntity entity)
        {
            base.CopyTo(entity);
            entity.CompanyName = CompanyName;
            entity.Address = Address;
            entity.Email = Email;
            entity.Logo = Logo;
            entity.MailServer = MailServer;

            entity.FbAppId = FbAppId;
            entity.ZaloOAId = ZaloOAId;
            entity.FbAccessToken = FbAccessToken;
            entity.ZaloAccessToken = ZaloAccessToken;
            entity.ZaloRecipientIds = ZaloRecipientIds;

            //entity.TokenGoogle = TokenGoogle;
            entity.FacebookUrl = FacebookUrl;
            entity.YoutubeUrl = YoutubeUrl;
            entity.Hotline = Hotline;
            entity.CSKH = CSKH;
            entity.MailSSL = MailSSL;
            entity.MailPort = MailPort;
            entity.MailAddress = MailAddress;
            entity.GoogleAnalytics = GoogleAnalytics;
            entity.MaSoThue = MaSoThue;
            entity.Note = "";
            entity.InstagramUrl = InstagramUrl;
            return entity;
        }

        public string InstagramUrl { get; set; }
        public string BoCongThuong_Url { get; set; }
        public bool MailSSL { get; set; }

        public string MailPort { get; set; }

        public string Hotline { get; set; }

        public string CSKH { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên công ty")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập địa chỉ công ty")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập địa chỉ email công ty")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn logo")]
        public string Logo { get; set; }

        public string MailServer { get; set; }

        public string MailPassword { get; set; }

        public string MailAddress { get; set; }

        public string FbAppId { get; set; }

        public string ZaloOAId { get; set; }

        public string ZaloAccessToken { get; set; }

        public string FbAccessToken { get; set; }

        public string ZaloRecipientIds { get; set; }

        public string GoogleAnalytics { get; set; }

        public string MaSoThue { get; set; }

        public string FacebookUrl { get; set; }

        public string YoutubeUrl { get; set; }
    }
}
