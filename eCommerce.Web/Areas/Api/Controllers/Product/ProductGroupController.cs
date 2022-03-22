using eCommerce.Utils;
using eCommerce.Web.Areas.Api.Models.Products.Product;
using eCommerce.Web.Areas.Api.Models.Products.ProductGroup;
using eCommerce.Web.Entities;
using eCommerce.Web.Entities.Identity;
using eCommerce.Web.Entities.Product.ProductGroup;
using eCommerce.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static eCommerce.Web.Entities.General.FriendlyUrlEntity;
using static eCommerce.Web.Entities.Promotion.PromotionEntity;

namespace eCommerce.Web.Areas.Api.Controllers.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductGroupController : BaseApiController
    {
        public ProductGroupController(DatabaseContext context) : base(context)
        {
        }

        [HttpPost]
        public ResponseModel Post([FromBody] ProductGroupAddRequest group)
        {
            try
            {
                if (_context.Groups.Where(n => n.GroupName == group.GroupName).FirstOrDefault() != null)
                {
                    res.Failed("Tên này đã được sử dụng");
                    return res;
                }
                else if (_context.FriendlyUrls.Where(n => n.FriendlyUrl == group.FriendlyUrl).FirstOrDefault() != null || _context.Groups.Where(n => n.FriendlyUrl == group.FriendlyUrl).FirstOrDefault() != null)
                {
                    res.Failed("Tên đường dẫn đã được sử dụng");
                    res.Result = group;
                    return res;
                }

                var GroupProduct = group.Products.Select(n => new ProductGroupEntity()
                {
                    ProductId = n.Id,
                    CreatedUserId = CurrentUser.Id
                }).Distinct();

                GroupEntity groupEntity = new GroupEntity()
                {
                    GroupName = group.GroupName,
                    CreatedDate = now,
                    CreatedUserId = CurrentUser.Id,
                    Note = group.Note,
                    ProductGroups = GroupProduct.ToList(),
                    FriendlyUrl = group.FriendlyUrl
                };
                _context.FriendlyUrls.Add(new Entities.General.FriendlyUrlEntity()
                {
                    CreatedDate = DateTime.Now,
                    CreatedUserId = CurrentUser.Id,
                    FriendlyUrl = group.FriendlyUrl,
                    Type = UrlType.Group,
                });

                _context.Groups.Add(groupEntity);
                _context.SaveChanges();
                res.Succeed();
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }

            return res;
        }

        [HttpPut]
        public ResponseModel Put([FromBody] ProductGroupAddRequest group)
        {
            try
            {

                GroupEntity groupEntity = _context.Groups.Include(n => n.ProductGroups).Where(n => n.Id == group.Id).FirstOrDefault();
                string oldUrl = groupEntity.FriendlyUrl;
                if (groupEntity == null)
                {
                    res.Failed("Nhóm không tồn tại");
                    return res;
                }
                else if (_context.Groups.Where(n => n.GroupName == group.GroupName && n.Id != group.Id).FirstOrDefault() != null)
                {
                    res.Failed("Tên này đã được sử dụng");
                    return res;
                }
                else if (_context.Groups.Where(n => n.FriendlyUrl == group.FriendlyUrl && n.Id != group.Id).FirstOrDefault() != null)
                {
                    res.Failed("Tên đường dẫn đã được sử dụng");
                    return res;
                }
                else if (group.Products.Count == 0)
                {
                    res.Failed("Vui lòng thêm sản phẩm vào nhóm sản phẩm");
                    return res;
                }
                var GroupProduct = group.Products.Select(n => new ProductGroupEntity()
                {
                    ProductId = n.Id
                });
                groupEntity.GroupName = group.GroupName;
                groupEntity.CreatedDate = now;
                groupEntity.CreatedUserId = CurrentUser.Id;
                groupEntity.Note = group.Note;
                groupEntity.FriendlyUrl = group.FriendlyUrl;
                groupEntity.ProductGroups = GroupProduct.Distinct().ToList();

                if (oldUrl != group.FriendlyUrl)
                {
                    var friendly = _context.FriendlyUrls.Where(n => n.FriendlyUrl == oldUrl && n.Type == UrlType.Group).FirstOrDefault();
                    if (friendly != null)
                        friendly.FriendlyUrl = group.FriendlyUrl;
                    else
                    {
                        _context.FriendlyUrls.Add(new Entities.General.FriendlyUrlEntity()
                        {
                            CreatedDate = DateTime.Now,
                            CreatedUserId = CurrentUser.Id,
                            FriendlyUrl = group.FriendlyUrl,
                            Type = UrlType.Group,
                        });

                    }
                }
                else
                {

                    var friendly = _context.FriendlyUrls.Where(n => n.FriendlyUrl == group.FriendlyUrl && n.Type == UrlType.Group).FirstOrDefault();
                    if (friendly == null)
                    {
                        _context.FriendlyUrls.Add(new Entities.General.FriendlyUrlEntity()
                        {
                            CreatedDate = DateTime.Now,
                            CreatedUserId = CurrentUser.Id,
                            FriendlyUrl = group.FriendlyUrl,
                            Type = UrlType.Group,
                        });
                    }
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

        [HttpDelete("{id}")]
        public ResponseModel Delete(int id)
        {
            try
            {
                var entity = _context.Groups.Find(id);

                _context.Groups.Remove(entity);
                _context.SaveChanges();
                res.Succeed();
            }
            catch (Exception ex)
            {

                res.Failed(ex.Message);
            }

            return res;
        }



        /// <summary>
        ///lấy để thể hiện lên select box, chi lấy tên và Id
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetFilter")]
        public ResponseModel GetFilter(string keysearch = "")
        {
            try
            {
                var result = _context.Groups
                    .OrderBy(n => n.GroupName)
                    .Include(n => n.ProductGroups)
                    .Where(delegate (GroupEntity n)
                    {
                        return n.GroupName.Like(keysearch);
                    })
                    .Select(n => new ProductGroupSimpleResponse
                    {
                        FriendlyUrl = n.FriendlyUrl,
                        Id = n.Id,
                        GroupName = n.GroupName,
                        Note = n.Note,
                        CreatedDate = n.CreatedDate.ToShortDateString(),
                        CountProduct = n.ProductGroups.Count
                    })
                    .ToList();
                res.Succeed(result);
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
                res.Result = ex.StackTrace;
            }
            return res;
        }

        /// <summary>
        /// Lấy danh sách nhóm kèm theo danh sách sản phẩm
        /// </summary>
        /// <returns></returns>
        [HttpGet("Get")]
        public ResponseModel Get(string keysearch = "")
        {
            try
            {
                var result = _context.Groups
                   .OrderByDescending(n => n.CreatedDate)
                   .Include(n => n.ProductGroups).ThenInclude(n => n.Product).ThenInclude(n => n.ProductBrand)
                   .Include(n => n.ProductGroups).ThenInclude(n => n.Product).ThenInclude(n => n.ProductCategories).ThenInclude(n => n.Category)
                   .Include(n => n.ProductGroups).ThenInclude(n => n.Product).ThenInclude(n => n.PromotionProducts)
                   .Where(delegate (GroupEntity n)
                   {
                       return n.GroupName.Like(keysearch);
                   })
                    .Select(n => new ProductGroupDetailResponse()
                    {
                        FriendlyUrl = n.FriendlyUrl,
                        CreatedDate = n.CreatedDate.ToString("d"),
                        Id = n.Id,
                        GroupName = n.GroupName,
                        Note = n.Note,
                        Products = n.ProductGroups
                        .Select(x => new ProductSimpleMostRespone(x.Product)).ToList()
                    })
                    .ToList();
                res.Succeed(result);
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
                res.Result = ex.StackTrace;
            }

            return res;
        }



        /// <summary>
        /// Lấy danh sách nhóm kèm theo danh sách sản phẩm
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetById/{id}")]
        public ResponseModel Get(int id)
        {
            try
            {
                var result = _context.Groups
                    .Where(n => n.Id == id)
                    .Select(n => new ProductGroupDetailResponse()
                    {
                        CreatedDate = n.CreatedDate.ToString("d"),
                        Id = n.Id,
                        FriendlyUrl = n.FriendlyUrl,
                        GroupName = n.GroupName,
                        Note = n.Note,
                        Products = n.ProductGroups
                        .Select(x => new ProductSimpleMostRespone()
                        {
                            ProductCode = x.Product.ProductCode,
                            ThumbNail = x.Product.ThumbNail,
                            GiaBanLe = x.Product.GiaBanLe,
                            GurantyTime = x.Product.GurantyTime,
                            ProductName = x.Product.ProductName,
                            OriginPrice = x.Product.OriginPrice,
                            SaleOffPrice = x.Product.SaleOffPrice,
                            GoldenCommitment = x.Product.GoldenCommitment,
                            PromotionContent = x.Product.PromotionContent,
                            HighlightProduct = x.Product.HighlightProduct,
                            ProductBrand = new Models.ProductBrandResponse() { BrandName = x.Product.ProductBrand.BrandName },
                            StockNumber = x.Product.StockNumber,
                            Id = x.ProductId,
                            FriendlyUrl = x.Product.FriendlyUrl,
                            InstallmentPrice = x.Product.InstallmentPrice,
                            DiscountPrice = x.Product.PromotionProducts.Where(a => a.ProductId == x.Id && a.Promotion.Status == PromoStatus.Activated && a.Promotion.EndDate >= DateTime.Now).Sum(x => x.DiscountQuantity),
                        }).ToList()
                    })
                    .FirstOrDefault();
                for (int i = 0; i < result.Products.Count; i++)
                {
                    result.Products[i].SaleOffPrice = result.Products[i].SaleOffPrice - result.Products[i].DiscountPrice;
                }
                res.Succeed(result);
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
                res.Result = ex.StackTrace;
            }

            return res;
        }

        /// <summary>
        /// Lấy danh sách nhóm kèm theo danh sách sản phẩm
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetFrame/{url}")]
        public ResponseModel GetFrame(string url, int itemPerRow = 4, int countRow = 3, int isShowSlide = 1)
        {
            try
            {
                var result = _context.Groups
                    .Where(n => n.FriendlyUrl == url)
                    .Select(n => new ProductGroupDetailResponse()
                    {
                        FriendlyUrl = n.FriendlyUrl,
                        CreatedDate = n.CreatedDate.ToString("d"),
                        Id = n.Id,
                        GroupName = n.GroupName,
                        Note = n.Note,
                        Products = n.ProductGroups
                        .Select(n => new ProductSimpleMostRespone()
                        {
                            DiscountPrice = n.Product.PromotionProducts.Where(x => x.ProductId == n.Id && x.Promotion.Status == PromoStatus.Activated && x.Promotion.EndDate >= DateTime.Now).Sum(x => x.DiscountQuantity),
                            IsInstallment0Percent = n.Product.InstallmentPromotionProducts.Where(m => m.InstallmentPromotion.ToDate >= DateTime.Now.AddDays(-1) && m.ProductId == n.Id).FirstOrDefault() != null,
                            FriendlyUrl = n.Product.FriendlyUrl,
                            GiaBanLe = n.Product.GiaBanLe,
                            GurantyTime = n.Product.GurantyTime,
                            HighlightProduct = n.Product.HighlightProduct,
                            Id = n.Id,
                            StickerImage = n.Product.StickerImage,
                            IsShowSticker = n.Product.IsShowSticker,
                            Origin = n.Product.Origin,
                            OriginPrice = n.Product.OriginPrice,
                            ProductCode = n.Product.ProductCode,
                            ProductName = n.Product.ProductName,
                            Status = n.Product.Status,
                            StockNumber = n.Product.StockNumber,
                            ThumbNail = n.Product.ThumbNail,
                        })
                        .ToList()
                    })
                    .FirstOrDefault();
                if (isShowSlide == 0)
                {
                    result.Products = result.Products.Take(itemPerRow * countRow).ToList(); ;
                }
                for (int i = 0; i < result.Products.Count; i++)
                {
                    result.Products[i].SaleOffPrice = result.Products[i].GiaBanLe - result.Products[i].DiscountPrice;
                }


                res.Succeed(result);
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
                res.Result = ex.StackTrace;
            }

            return res;
        }


        /// <summary>
        /// Lấy danh sách nhóm kèm theo danh sách sản phẩm
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetByUrl/{url}")]
        public ResponseModel GetByUrl(string url, bool sort)
        {
            try
            {
                var result = _context.Groups
                   
                    .Where(n => n.FriendlyUrl == url)
                    .Select(n => new ProductGroupDetailResponse()
                    {
                        FriendlyUrl = n.FriendlyUrl,
                        CreatedDate = n.CreatedDate.ToString("d"),
                        Id = n.Id,
                        GroupName = n.GroupName,
                        Note = n.Note,
                        Products = n.ProductGroups
                        .Select(n => new ProductSimpleMostRespone()
                        {
                            DiscountPrice = n.Product.PromotionProducts.Where(x => x.ProductId == n.Id && x.Promotion.Status == PromoStatus.Activated && x.Promotion.EndDate >= DateTime.Now).Sum(x => x.DiscountQuantity),
                            IsInstallment0Percent = n.Product.InstallmentPromotionProducts.Where(m => m.InstallmentPromotion.ToDate >= DateTime.Now.AddDays(-1) && m.ProductId == n.Product.Id).FirstOrDefault() != null,
                            FriendlyUrl = n.Product.FriendlyUrl,
                            GiaBanLe = n.Product.GiaBanLe,
                            StickerImage = n.Product.StickerImage,
                            IsShowSticker = n.Product.IsShowSticker,
                            GurantyTime = n.Product.GurantyTime,
                            HighlightProduct = n.Product.HighlightProduct,
                            Id = n.Id,
                            Origin = n.Product.Origin,
                            OriginPrice = n.Product.OriginPrice,
                            ProductCode = n.Product.ProductCode,
                            ProductName = n.Product.ProductName,
                            Status = n.Product.Status,
                            StockNumber = n.Product.StockNumber,
                            ThumbNail = n.Product.ThumbNail,
                        }).ToList()
                    })
                    .FirstOrDefault();

                for (int i = 0; i < result.Products.Count; i++)
                {
                    result.Products[i].SaleOffPrice = result.Products[i].GiaBanLe - result.Products[i].DiscountPrice;
                }

                if (sort)
                    result.Products = result.Products.OrderBy(n => n.GiaBanLe).ToList();
                else result.Products = result.Products.OrderByDescending(n => n.GiaBanLe).ToList();
                res.Succeed(result);
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
                res.Result = ex.StackTrace;
            }

            return res;
        }

    }
}
