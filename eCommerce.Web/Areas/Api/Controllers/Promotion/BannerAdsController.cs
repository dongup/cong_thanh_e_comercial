using eCommerce.Web.Areas.Api.Models.Promotion;
using eCommerce.Web.Entities;
using eCommerce.Web.Entities.Promotion;
using eCommerce.Web.Entities.Identity;
using eCommerce.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Areas.Api.Controllers.Promotion
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannerAdsController : BaseApiController
    {
        public BannerAdsController(DatabaseContext context, UserManager<UserEntity> userManager) : base(context, userManager: userManager)
        {

        }

        /// <summary>
        /// Lấy ra danh sách danh mục kèm theo các template của danh mục đó
        /// </summary>
        /// <param name="keyword">Từ khóa tìm theo danh mục sản phẩm</param>
        /// <returns></returns>
        [HttpGet]
        public ResponseModel Get(string keyword = "")
        {
            try
            {
                var result = _context.BannerAds
                    .Select(n => new BannerAdsRequest()
                    {
                        IsShowLeft = n.IsShowLeft,
                        IsShowRight = n.IsShowRight,
                        RighFriendlyUrl = n.RighFriendlyUrl,
                        LeftFriendlyUrl = n.LeftFriendlyUrl,
                        LeftPath = n.LeftPath,
                        RightPath = n.RightPath,
                        TopFriendlyUrl = n.TopFriendlyUrl,
                        TopPath = n.TopPath,
                        IsShowTop = n.IsShowTop,
                        PathBannerBottomSlide1 = n.PathBannerBottomSlide1,
                        PathBannerBottomSlide2 = n.PathBannerBottomSlide2,
                        PathBannerBottomSlide3 = n.PathBannerBottomSlide3,

                        UrlBannerBottomSlide1 = n.UrlBannerBottomSlide1,
                        UrlBannerBottomSlide2 = n.UrlBannerBottomSlide2,
                        UrlBannerBottomSlide3 = n.UrlBannerBottomSlide3,

                        IsShowBannerBottomSlide1 = n.IsShowBannerBottomSlide1,
                        IsShowBannerBottomSlide2 = n.IsShowBannerBottomSlide2,
                        IsShowBannerBottomSlide3 = n.IsShowBannerBottomSlide3,

                        //Banner top promotion
                        BannerTopPromotionPath = n.BannerTopPromotionPath,
                        BannerTopPromotionFriendlyUrl = n.BannerTopPromotionFriendlyUrl,
                        IsShowBannerTopPromotionPath = n.IsShowBannerTopPromotionPath

                    }).FirstOrDefault();

                res.Succeed(result);
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }

            return res;
        }


        [HttpPost]
        public ResponseModel Post([FromBody] BannerAdsRequest model)
        {
            try
            {
                var entity = _context.BannerAds.FirstOrDefault();
                if (entity == null)
                {
                    _context.BannerAds
                          .Add(new BannerAdsEntity()
                          {
                              IsShowLeft = model.IsShowLeft,
                              IsShowRight = model.IsShowRight,
                              RighFriendlyUrl = model.RighFriendlyUrl,
                              LeftFriendlyUrl = model.LeftFriendlyUrl,
                              LeftPath = model.LeftPath,
                              RightPath = model.RightPath,
                              IsShowTop = model.IsShowTop,
                              TopFriendlyUrl = model.TopFriendlyUrl,
                              TopPath = model.TopPath,

                              PathBannerBottomSlide1 = model.PathBannerBottomSlide1,
                              PathBannerBottomSlide2 = model.PathBannerBottomSlide2,
                              PathBannerBottomSlide3 = model.PathBannerBottomSlide3,

                              UrlBannerBottomSlide1 = model.UrlBannerBottomSlide1,
                              UrlBannerBottomSlide2 = model.UrlBannerBottomSlide2,
                              UrlBannerBottomSlide3 = model.UrlBannerBottomSlide3,

                              IsShowBannerBottomSlide1 = model.IsShowBannerBottomSlide1,
                              IsShowBannerBottomSlide2 = model.IsShowBannerBottomSlide2,
                              IsShowBannerBottomSlide3 = model.IsShowBannerBottomSlide3,

                              //Banner top promotion
                              BannerTopPromotionPath = model.BannerTopPromotionPath,
                              BannerTopPromotionFriendlyUrl = model.BannerTopPromotionFriendlyUrl,
                              IsShowBannerTopPromotionPath = model.IsShowBannerTopPromotionPath,
                          });
                }
                else
                {

                    entity.IsShowLeft = model.IsShowLeft;
                    entity.IsShowRight = model.IsShowRight;
                    entity.RighFriendlyUrl = model.RighFriendlyUrl;
                    entity.LeftFriendlyUrl = model.LeftFriendlyUrl;
                    entity.LeftPath = model.LeftPath;
                    entity.RightPath = model.RightPath;
                    entity.IsShowTop = model.IsShowTop;
                    entity.TopFriendlyUrl = model.TopFriendlyUrl;
                    entity.TopPath = model.TopPath;
                    entity.PathBannerBottomSlide1 = model.PathBannerBottomSlide1;
                    entity.PathBannerBottomSlide2 = model.PathBannerBottomSlide2;
                    entity.PathBannerBottomSlide3 = model.PathBannerBottomSlide3;
                    entity.UrlBannerBottomSlide1 = model.UrlBannerBottomSlide1;
                    entity.UrlBannerBottomSlide2 = model.UrlBannerBottomSlide2;
                    entity.UrlBannerBottomSlide3 = model.UrlBannerBottomSlide3;

                    entity.IsShowBannerBottomSlide1 = model.IsShowBannerBottomSlide1;
                    entity.IsShowBannerBottomSlide2 = model.IsShowBannerBottomSlide2;
                    entity.IsShowBannerBottomSlide3 = model.IsShowBannerBottomSlide3;

                    //Banner top promotion
                    entity.BannerTopPromotionPath = model.BannerTopPromotionPath;
                    entity.BannerTopPromotionFriendlyUrl = model.BannerTopPromotionFriendlyUrl;
                    entity.IsShowBannerTopPromotionPath = model.IsShowBannerTopPromotionPath;

                }
                _context.SaveChanges();

                res.Succeed();
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }

            return res;
        }
    }
}
