using eCommerce.Web.Entities.Generals;

namespace eCommerce.Web.Areas.Api.Models.General
{
    public class PopupRequest : PopupResponse
    {
        public PopupRequest()
        {

        }

        public PopupEntity CopyTo(PopupEntity entity)
        {
            base.CopyTo(entity);
            entity.ImageId = ImageId;
            entity.Link = Link;
            entity.Title = Title;
            entity.SubTitle = SubTitle;
            entity.IsShow = IsShow;
            entity.BannerNgang = BannerNgang;

            return entity;
        }

        protected new int Id { get; set; }

        protected new FileResponse Image { get; set; }
    }
}
