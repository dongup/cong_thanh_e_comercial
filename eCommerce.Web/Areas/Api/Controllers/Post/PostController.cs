using eCommerce.Utils;
using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Areas.Api.Models.Posts;
using eCommerce.Web.Entities;
using eCommerce.Web.Entities.Post;
using eCommerce.Web.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static eCommerce.Web.Entities.General.FriendlyUrlEntity;
using static eCommerce.Web.Entities.Post.PostEntity;
using eCommerce.Web.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace eCommerce.Web.Areas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : BaseApiController
    {
        private string GetPostImageSavePath(string postName)
        {
            return Path.Combine("Upload", "Posts", postName);
        }

        public PostController(DatabaseContext context, 
            ILogger<PostController> logger = null,
            IConfiguration conf = null, 
            IWebHostEnvironment web = null,
            UserManager<UserEntity> userManager = null) 
            : base(context, config: conf, webEnv: web, logger: logger, userManager: userManager)
        {

        }

        /// <summary>
        /// Lấy ra 10 bài viết cùng chuyên mục với bài viết hiện tại
        /// </summary>
        /// <param name="id">Mã bài viết hiện tại</param>
        /// <returns></returns>
        [HttpGet("RelatedPost/{id}")]
        public ResponseModel RelatedPost(int id)
        {
            try
            {
                int? postCategoryId = _context.Posts.Find(id)?.PostCategoryId;

                var result = _context.Posts
                    .Include(x => x.PostCategory)
                    .Include(x => x.Banner)
                    .Where(x => x.PostCategoryId == postCategoryId 
                            || postCategoryId == null
                            && x.Id != id && x.Status == PostStatus.Approved)
                    .OrderByDescending(x => x.CreatedDate)
                    .Take(10)
                    .Select(x => new PostResponse(x, _context))
                    .ToList();

                res.Succeed(result);
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }
            return res;
        }

        [HttpGet("Tags")]
        public ResponseModel Tags(string keyword = "")
        {
            try
            {
                var result = _context.Posts
                    .Include(x => x.PostCategory)
                    .Include(x => x.Banner)
                    .OrderByDescending(x => x.CreatedDate)
                    .Select(x => x.Tag).Distinct()
                    .Where(delegate(string x) {
                        return x.Like(keyword) && !string.IsNullOrWhiteSpace(x);
                    })
                    .ToList();

                res.Succeed(result);
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }
            return res;
        }

        /// <summary>
        /// Lấy ra một số lượng bài viết nhất định dựa theo loại danh mục
        /// </summary>
        /// <param name="take">Số lượng bài viết cần lấy, mặc định = 9</param>
        /// <returns></returns>
        [HttpGet("LastestPost")]
        public ResponseModel LastestPost(int take = 9)
        {
            try
            {
                var result = _context.Posts
                    .Include(x => x.PostCategory)
                    .Include(x => x.Banner)
                    .OrderByDescending(x => x.CreatedDate)
                    .Where(x => x.Type == PostType.Offical)
                    .Take(take)
                    .Select(x => new PostResponse(x, _context))
                    .ToList();

                res.Succeed(result);
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }
            return res;
        }

        /// <summary>
        /// Lấy danh sách tiêu đề bài viết
        /// </summary>
        /// <param name="keyword">Từ khóa tìm kiếm theo tiêu đề</param>
        /// <returns></returns>
        [HttpGet("Titles")]
        public ResponseModel Titles(string keyword = "")
        {
            try
            {
                var query = _context.Posts
                    .Where(delegate (PostEntity x)
                    {
                        return x.Title.Like(keyword);
                    })
                    .OrderByDescending(x => x.CreatedDate)
                    .Select(x => new { x.Id, x.Title })
                    .ToList();

                res.Succeed(query);
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }
            return res;
        }

        /// <summary>
        /// Lấy ra danh sách dữ liệu phân trang bài viết theo từ khóa, theo tag, và danh mục bài viết
        /// </summary>
        /// <param name="keyword">Từ khóa tìm kiếm theo tiêu đề</param>
        /// <param name="categoryId"></param>
        /// <param name="tag">Thẻ của bài viết</param>
        /// <param name="friendlyurl">url danh mục bài viết</param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="pageItem">Số lượng bài viết, mặc định bằng 12</param>
        /// <param name="pageIndex">Chỉ mục trang</param>
        /// <returns></returns>
        [HttpGet]
        public ResponseModel Get(string keyword = "", 
            int categoryId = 0,
            string tag = "", 
            string friendlyurl = "", 
            string fromDate = "",
            string toDate = "",
            int pageItem = 12, 
            int pageIndex = 0)
        {
            try
            {

                var query = _context.Posts
                    .Include(x => x.PostCategory)
                    .Include(x => x.Banner)
                    .Where(delegate (PostEntity x)
                    {
                        return x.Title.Like(keyword)
                            && x.Tag.Like(tag)
                            && (x.PostCategory.FriendlyUrl == friendlyurl || string.IsNullOrEmpty(friendlyurl))
                            && (categoryId == 0 || x.PostCategoryId == categoryId);
                            //&& x.CreatedDate.Beetween(fromDate, toDate);
                            //Nếu người dùng hiện tại là admin thì chỉ lấy những post chính thức
                            //&& (!IsAdmin || x.Type == PostType.Offical);
                            //TODO: Nếu không là admin thì chỉ lấy những post người dùng này sở hữu
                    })
                    .OrderByDescending(x => x.CreatedDate)
                    .Select(x => new PostResponse(x, _context))
                    .ToList();

                res.Succeed(new PaginationResponse<PostResponse>(query, pageItem, pageIndex));
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
                res.Result = ex.StackTrace;
            }
            return res;
        }

        [HttpGet("ByUrl/{url}")]
        public ResponseModel Get(string url)
        {
            try
            {
                //_logger.LogInformation("get post with url: {url}", url);
                //throw NotFoundException;
                var result = _context.Posts
                    .Include(x => x.PostCategory)
                    .Include(x => x.Banner)
                    .Where(x => x.FriendlyUrl == url)
                    .Select(x => new PostResponse(x, _context))
                    .FirstOrDefault();
                res.Succeed(result);
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
                //_logger.LogError(ex, "exception catched");
            }

            return res;
        }

        [HttpGet("ForUser/{url}")]
        public ResponseModel ForUser(string keyword = "",
            int categoryId = 0,
            string tag = "",
            string categoryUrl = "",
            int pageItem = 12,
            int pageIndex = 0)
        {
            try
            {
                var result = _context.Posts
                    .Include(x => x.PostCategory)
                    .Include(x => x.Banner)
                    .Where(delegate (PostEntity x)
                    {
                        return (x.Title.Like(keyword) || x.Title.Like(tag))
                            && x.Tag.Like(tag)
                            && (x.PostCategory.FriendlyUrl == categoryUrl || categoryUrl == "")
                            && (x.PostCategoryId == categoryId || categoryId == 0)
                            && (x.Type == PostType.Offical);
                    })
                    .OrderByDescending(a=>a.CreatedDate)
                    .Select(x => new PostResponse(x, _context)).ToList();

                res.Succeed(new PaginationResponse<PostResponse>(result, pageItem, pageIndex));
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }

            return res;
        }

        [HttpGet("{id}")]
        public ResponseModel Get(int id)
        {
            try
            {
                var result = _context.Posts
                    .Include(x => x.PostCategory)
                    .Include(x => x.Banner)
                    .Where(x => x.Id == id)
                    .Select(x => new PostResponse(x, _context))
                    .FirstOrDefault();
                res.Succeed(result);
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }

            return res;
        }

        [HttpPost]
        public ResponseModel Post([FromBody] PostRequest value)
        {
            var entity = value.CopyTo(new PostEntity());
            var transaction = _context.Database.BeginTransaction();

            try
            {
                entity.CreatedUserId = UserId;

                _context.Posts.Add(entity);

                AddUrl(UrlType.Post, value.FriendlyUrl);
                _context.SaveChanges();

                _context.Entry(entity).Reference(x => x.Banner).Load();
                entity.Banner.FilePath = _fileHelper.CopyImage(entity.Banner.FilePath, GetPostImageSavePath(entity.FriendlyUrl), UploadController.UploadType.Post);
                entity.Banner.ThumbNailPath = _fileHelper.CopyImage(entity.Banner.ThumbNailPath, GetPostImageSavePath(entity.FriendlyUrl), UploadController.UploadType.Post);

                _context.SaveChanges();
                transaction.Commit();

                res.Succeed();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                if(_context.FriendlyUrls.Any(x => x.FriendlyUrl == value.FriendlyUrl))
                {
                    LogServices.WriteInfo("url existed: " + value.FriendlyUrl);
                    res.Failed("URL đã được sử dụng bạn vui lòng sử dụng url khác");
                }
                else
                {
                    res.Failed(ex.Message);
                    res.Result = ex.StackTrace;
                }
            }
            return res;
        }

        // PUT api/Post/5
        [HttpPut("{id}")]
        public ResponseModel Put(int id, [FromBody] PostRequest value)
        {
            var transaction = _context.Database.BeginTransaction();
            try
            {
                var entity = _context.Posts
                    .Include(x => x.Banner)
                    .Where(x => x.Id == id)
                    .FirstOrDefault();

                

                UpdateUrl(entity.FriendlyUrl, value.FriendlyUrl, UrlType.Post);

                value.CopyTo(entity);

                entity.UpdatedUserId = UserId;
                entity.UpdatedDate = now;
                _context.SaveChanges();

                _context.Entry(entity).Reference(x => x.Banner).Load();
                Log.Information("Post Banner: {Banner}", entity.Banner?.FilePath);

                entity.Banner.FilePath = _fileHelper.CopyImage(entity.Banner.FilePath, GetPostImageSavePath(entity.FriendlyUrl), UploadController.UploadType.Post);
                entity.Banner.ThumbNailPath = _fileHelper.CopyImage(entity.Banner.ThumbNailPath, GetPostImageSavePath(entity.FriendlyUrl), UploadController.UploadType.Post);
                _context.SaveChanges();

                res.Succeed();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                if (!EntityExists(id))
                {
                    res.NotFound();
                }
                else
                {
                    res.Failed(ex.Message);
                    res.Result = ex.StackTrace;
                }
            }

            return res;
        }

        // PUT api/Post/5
        [HttpPut("Type/{id}")]
        public ResponseModel UpdateType(int id, PostType type)
        {
            try
            {
                var entity = _context.Posts
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedUserId = UserId;
                entity.Type = type;

                _context.SaveChanges();
                res.Succeed();
            }
            catch (Exception ex)
            {
                if (!EntityExists(id))
                {
                    res.NotFound();
                }
                else
                {
                    res.Failed(ex.Message);
                    res.Result = ex.StackTrace;
                }
            }

            return res;
        }

        // PUT api/Post/5
        [HttpPut("Status/{id}")]
        public ResponseModel UpdateType(int id, PostStatus value)
        {
            try
            {
                var entity = _context.Posts
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedUserId = UserId;
                entity.Status = value;

                _context.SaveChanges();
                res.Succeed();
            }
            catch (Exception ex)
            {
                if (!EntityExists(id))
                {
                    res.NotFound();
                }
                else
                {
                    res.Failed(ex.Message);
                    res.Result = ex.StackTrace;
                }
            }

            return res;
        }

        // DELETE api/<ProductCategoryController>/5
        [HttpDelete("{id}")]
        public ResponseModel Delete(int id)
        {
            var transaction = _context.Database.BeginTransaction();
            try
            {
                var entity = _context.Posts.Find(id);
                _context.Posts.Remove(entity);

                DeleteUrl(entity.FriendlyUrl);

                _context.SaveChanges();
                res.Succeed();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                res.Failed(ex.Message);
            }

            return res;
        }

        private bool EntityExists(int id)
        {
            return _context.Posts.Any(x => x.Id == id);
        }
    }
}
