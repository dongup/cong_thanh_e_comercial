using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Entities.Generals
{
    public class InformationEntity : BaseEntity
    {

        public InformationEntity() : base()
        {

        }

        public string Hotline { get; set; }

        public string CSKH { get; set; }

        public string CompanyName { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }
        public string Logo { get; set; }

        public string MailAddress { get; set; }

        public string MailServer { get; set; }

        public string MailPassword { get; set; }

        public bool MailSSL { get; set; }

        public string MailPort { get; set; }

        public string FbAppId { get; set; }

        public string ZaloOAId { get; set; }

        public string ZaloAccessToken { get; set; }

        public string FbAccessToken { get; set; }

        public string ZaloRecipientIds { get; set; }

        public string GoogleAnalytics { get; set; }

        public string MaSoThue { get; set; }

        public string FacebookUrl { get; set; }

        public string YoutubeUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string BoCongThuong_Url { get; set; }
    }
}
