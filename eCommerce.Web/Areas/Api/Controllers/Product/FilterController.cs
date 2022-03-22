//using eCommerce.Utils;
//using eCommerce.Web.Areas.Api.Models.Products.Product;
//using eCommerce.Web.Entities;
//using eCommerce.Web.Entities.General;
//using eCommerce.Web.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Linq;
//using static eCommerce.Web.Entities.General.FriendlyUrlEntity;
//using System.Linq.Dynamic.Core;
//using eCommerce.Web.Areas.Api.Models.General;
//using eCommerce.Web.Areas.Api.Models.User;
//using eCommerce.Web.Entities.Product;
//using Microsoft.Extensions.Configuration;
//using System.IO;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Data.SqlClient;

//namespace eCommerce.Web.Areas.Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class FilterController : BaseApiController
//    {
//        public FilterController(DatabaseContext context, IConfiguration config = null, IWebHostEnvironment webHost = null) : base(context, config, webEnv: webHost)
//        {

//        }

//        //Lấy ra danh sách thuộc tính theo url danh mục
//        [HttpGet("ByUrl")]
//        public ResponseModel Get(string categoryUrl)
//        {
//            try
//            {
//                var result = _context.CatergoryFilters
//                    .Include(x => x.ProductCategory)
//                    .Include(x => x.Property).ThenInclude(x => x.Values)
//                    .Where(delegate (CatergoryFilterEntity x)
//                    {
//                        return x.ProductCategory.FriendlyUrl == categoryUrl;
//                    })
//                    .OrderByDescending(x => x.CreatedDate)
//                    .Select(x => new CatergoryFilterResponse(x))
//                    .ToList();
//                res.Succeed(result);
//            }
//            catch (Exception ex)
//            {
//                res.Failed(ex.Message);
//                //res.Result = ex.StackTrace;
//            }

//            return res;
//        }

//        //Lấy ra danh sách filter 
//        [HttpGet("ByUrl")]
//        public ResponseModel Get(string categoryUrl)
//        {
//            try
//            {
//                var result = _context.CatergoryFilters
//                    .Include(x => x.ProductCategory)
//                    .Include(x => x.Property).ThenInclude(x => x.Values)
//                    .Where(delegate (CatergoryFilterEntity x)
//                    {
//                        return x.ProductCategory.FriendlyUrl == categoryUrl;
//                    })
//                    .OrderByDescending(x => x.CreatedDate)
//                    .Select(x => new CatergoryFilterResponse(x))
//                    .ToList();
//                res.Succeed(result);
//            }
//            catch (Exception ex)
//            {
//                res.Failed(ex.Message);
//                //res.Result = ex.StackTrace;
//            }

//            return res;
//        }


//        [HttpGet("ById/{id}")]
//        public ResponseModel Get(int id)
//        {
//            try
//            {
//                var result = _context.Products
//                    .Include(x => x.OrderDetails).ThenInclude(x => x.Order)
//                    .Include(x => x.GiftProduct.Product)
//                    .Include(x => x.ProductImages).ThenInclude(x => x.Image)
//                    .Include(x => x.ProductBrand.Logo)
//                    .Include(x => x.ProductCategories).ThenInclude(x => x.Category)
//                    .Include(x => x.ProductProperties).ThenInclude(x => x.PropertyValues).ThenInclude(x => x.Value)
//                    .Include(x => x.ProductProperties).ThenInclude(x => x.Property)
//                    .Include(x => x.ProductCombos)
//                    .Where(x => x.Id == id)
//                    .Select(x => new ProductResponse(x))
//                    .FirstOrDefault();
//                res.Succeed(result);
//            }
//            catch (Exception ex)
//            {
//                res.Failed(ex.Message);
//            }

//            return res;
//        }

//        [HttpGet("ByUrl/{producturl}")]
//        public ResponseModel Get(string productUrl)
//        {
//            try
//            {
//                var result = _context.Products
//                    .Include(x => x.GiftProduct.Product)
//                    .Include(x => x.ProductImages).ThenInclude(x => x.Image)
//                    .Include(x => x.ProductBrand.Logo)
//                    .Include(x => x.ProductCategories)
//                    .Include(x => x.ProductBrand).ThenInclude(x => x.Logo)
//                    .Include(x => x.ProductProperties).ThenInclude(x => x.PropertyValues).ThenInclude(x => x.Value)
//                    .Where(x => x.FriendlyUrl == productUrl)
//                    .Select(x => new ProductResponse(x))
//                    .FirstOrDefault();
//                if (result == null) throw NotFoundException;

//                res.Succeed(result);
//            }
//            catch (Exception ex)
//            {
//                res.Failed(ex.Message);
//            }

//            return res;
//        }

//        [HttpPost]
//        public ResponseModel Post([FromBody] ProductRequest value)
//        {
//            var transaction = _context.Database.BeginTransaction();

//            try
//            {
//                var entity = value.CopyTo(new ProductEntity());
//                entity.CreatedUserId = UserId;

//                _context.FriendlyUrls.Add(new FriendlyUrlEntity()
//                {
//                    Type = UrlType.Post,
//                    FriendlyUrl = value.FriendlyUrl
//                });

//                _context.Products.Add(entity);
//                _context.SaveChanges();

//                _context.Entry(entity).Collection(x => x.ProductImages).Query().Include(x => x.Image).Load();

//                foreach (var file in entity.ProductImages)
//                {
//                    LogServices.WriteInfo("Copy image: " + file.Image.FilePath);
//                    file.Image.FilePath = _fileHelper.CopyImage(file.Image?.FilePath, GetProductImageSavePath(entity.FriendlyUrl), UploadController.UploadType.Product);
//                    file.Image.ThumbNailPath = _fileHelper.CopyImage(file.Image?.ThumbNailPath, GetProductImageSavePath(entity.FriendlyUrl), UploadController.UploadType.Product);
//                }

//                _context.SaveChanges();
//                res.Succeed();
//                transaction.Commit();
//            }
//            catch (SqlException ex)
//            {
//                res.Failed("Có lỗi xảy ra khi thêm dữ liệu quan hệ, hãy kiểm tra lại các id khóa ngoại của bạn!");
//                res.Result = ex.InnerException?.Message;
//            }
//            catch (Exception ex)
//            {
//                transaction.Rollback();
//                if (_context.FriendlyUrls.Any(x => x.FriendlyUrl == value.FriendlyUrl))
//                {
//                    res.Failed("URL đã được sử dụng bạn vui lòng sử dụng url khác");
//                }
//                else
//                {
//                    res.Failed(ex.Message);
//                    //res.Result = ex.StackTrace;
//                    res.Result = ex.InnerException?.Message;
//                }
//            }

//            return res;
//        }

//        [HttpPut("{id}")]
//        public ResponseModel Put(int id, [FromBody] ProductRequest value)
//        {
//            var transaction = _context.Database.BeginTransaction();
//            try
//            {
//                var entity = _context.Products
//                    .Include(x => x.ProductBrand)
//                    .Include(x => x.GiftProduct)
//                    .Include(x => x.ProductImages).ThenInclude(x => x.Image)
//                    .Include(x => x.ProductLogs)
//                    .Include(x => x.ProductProperties).ThenInclude(x => x.PropertyValues)
//                    .Include(x => x.ProductCategories)
//                    .FirstOrDefault(x => x.Id == id);

//                if (entity == null) throw NotFoundException;

//                var oldUrl = _context.FriendlyUrls.FirstOrDefault(x => x.FriendlyUrl == entity.FriendlyUrl);
//                if (oldUrl != null) oldUrl.FriendlyUrl = value.FriendlyUrl;

//                value.CopyTo(entity);
//                entity.Id = id;
//                entity.UpdatedUserId = UserId;
//                entity.UpdatedDate = now;

//                //Thêm log sản phẩm
//                _context.ProductLogs.Add(new ProductLogEntity()
//                {
//                    Content = $"{CurrentUser.FullName} đã cập nhập thông tin của sản phẩm: {entity.Id}",
//                    CreatedUserId = UserId,
//                    ProductId = entity.Id
//                });

//                _context.SaveChanges();

//                _context.Entry(entity).Collection(x => x.ProductImages).Query().Include(x => x.Image).Load();

//                foreach (var file in entity.ProductImages)
//                {
//                    LogServices.WriteInfo("Copy image: " + file.Image.FilePath);
//                    LogServices.WriteInfo("Copy image: " + file.Image.ThumbNailPath);
//                    file.Image.FilePath = _fileHelper.CopyImage(file.Image.FilePath, GetProductImageSavePath(entity.FriendlyUrl), UploadController.UploadType.Product);
//                    file.Image.ThumbNailPath = _fileHelper.CopyImage(file.Image.ThumbNailPath, GetProductImageSavePath(entity.FriendlyUrl), UploadController.UploadType.Product);
//                }

//                _context.SaveChanges();
//                res.Succeed();
//                transaction.Commit();
//            }
//            catch (Exception ex)
//            {
//                transaction.Rollback();
//                res.Failed(ex.Message);
//                //res.Result = ex.StackTrace;
//            }

//            return res;
//        }

//        /// <summary>
//        /// Cập nhập giá cho sản phẩm
//        /// </summary>
//        /// <param name="id"></param>
//        /// <param name="value"></param>
//        /// <returns></returns>
//        [HttpPut("Price/{id}")]
//        public ResponseModel UpdatePrice(int id, [FromBody] ProductPriceRequest value)
//        {
//            try
//            {
//                var entity = _context.Products
//                    .FirstOrDefault(x => x.Id == id);
//                entity.UpdatedUserId = UserId;
//                entity.UpdatedDate = now;

//                entity.OriginPrice = value.OriginPrice;
//                entity.PublicPrice = value.PublicPrice;
//                entity.SaleOffPrice = value.SaleOffPrice == 0 ? value.OriginPrice : value.SaleOffPrice;
//                entity.GiaBanLe = value.GiaBanLe;

//                _context.SaveChanges();

//                _context.ProductLogs.Add(new ProductLogEntity()
//                {
//                    Level = ProductLogEntity.LogLevel.Information,
//                    Content = $"{CurrentUser.FullName} đã cập nhập giá của sản phẩm: {entity.Id}",
//                    CreatedUserId = UserId,
//                    ProductId = entity.Id
//                });

//                _context.ProductPriceLogs.Add(new ProductPriceLogEntity()
//                {
//                    PublicPrice = entity.PublicPrice,
//                    GiaBanLe = entity.GiaBanLe,
//                    SaleOffPrice = entity.SaleOffPrice,
//                    OriginPrice = entity.OriginPrice,
//                    Note = $"{CurrentUser.FullName} đã cập nhập giá của sản phẩm: {entity.Id}",
//                    CreatedUserId = UserId,
//                    ProductId = entity.Id
//                });

//                _context.SaveChanges();
//                res.Succeed(new SimpleProductResponse(entity));
//            }
//            catch (Exception ex)
//            {
//                if (!EntityExists(id))
//                {
//                    res.NotFound();
//                }
//                else
//                {
//                    res.Failed(ex.Message);
//                    res.Result = ex.StackTrace;
//                }
//            }

//            return res;
//        }

//        /// <summary>
//        /// Cập nhập số lượng tồn cho sản phẩm
//        /// </summary>
//        /// <param name="id">Mã sản phẩm</param>
//        /// <param name="stock">Số lượng tồn mới</param>
//        /// <returns></returns>
//        [HttpPut("StockNumber/{id}")]
//        public ResponseModel UpdateStockNumber(int id, int stock)
//        {
//            try
//            {
//                var entity = _context.Products
//                    .FirstOrDefault(x => x.Id == id);
//                entity.UpdatedUserId = UserId;
//                entity.UpdatedDate = now;
//                entity.StockNumber = stock;

//                _context.SaveChanges();
//                res.Succeed(new ProductResponse(entity));
//            }
//            catch (Exception ex)
//            {
//                if (!EntityExists(id))
//                {
//                    res.NotFound();
//                }
//                else
//                {
//                    res.Failed(ex.Message);
//                }
//            }

//            return res;
//        }

//        [HttpDelete("{id}")]
//        public ResponseModel Delete(int id)
//        {
//            try
//            {
//                var entity = _context.Products.Find(id);
//                _context.Products.Remove(entity);
//                _context.SaveChanges();
//                res.Succeed();
//            }
//            catch (Exception ex)
//            {
//                if (!EntityExists(id))
//                {
//                    res.NotFound();
//                }
//                else
//                {
//                    res.Failed(ex.Message);
//                }
//            }

//            return res;
//        }

//        private bool EntityExists(int id)
//        {
//            return _context.Products.Any(x => x.Id == id);
//        }
//    }
//}
