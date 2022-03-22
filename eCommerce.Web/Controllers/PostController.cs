using eCommerce.Web.Areas.Api.Controllers;
using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Areas.Api.Models.Posts;
using eCommerce.Web.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using static eCommerce.Web.Entities.General.FriendlyUrlEntity;
using ApiPostController = eCommerce.Web.Areas.Api.Controllers.PostController;


namespace eCommerce.Web.Controllers
{
    [Route("bai-viet")]
    public class PostController : BaseController
    {
        PostCategoryController postCatergoryRepo;
        ApiPostController postRepo;


        public PostController(DatabaseContext context) : base(context)
        {
            postCatergoryRepo = new PostCategoryController(_context);
            postRepo = new ApiPostController(_context);
        }

        public IActionResult Index(string keyword = "",
            int categoryId = 0,
            string tag = "",
            int pageItem = 12,
            int pageIndex = 1)
        {
            ViewData["url"] = "";
            ViewData["Category"] = new PostCategoryResponse() { Name = "Tất cả tin" };

            PaginationResponse<PostResponse> page = GetPosts(keyword, categoryId, tag, "", pageItem, pageIndex);
            ViewData["posts"] = page;
            ViewData["tags"] = GetTags();
            ViewData["postCategories"] = GetPostCategories();


            ViewData["CurrentPage"] = pageIndex;

            ViewData["NextPage"] = pageIndex == page.TotalPage - 1 ? page.TotalPage - 1 : pageIndex + 1;
            ViewData["PrevPage"] = pageIndex == 0 ? 0 : pageIndex - 1;

            return View();
        }

        [AcceptVerbs("GET", "HEAD", Route = "{categoryUrl}")]
        public IActionResult Index(
            string categoryUrl = "", 
            string keyword = "",
            int categoryId = 0,
            string tag = "",
            int pageItem = 12,
            int pageIndex = 0)
        {
            var postCategory = _context.PostCategories.Where(x => x.FriendlyUrl == categoryUrl).FirstOrDefault();

            if (postCategory != null)
            {
                ViewData["Category"] = new PostCategoryResponse(postCategory);
            }
            else
            {
                ViewData["Category"] = new PostCategoryResponse() { Name = "Tất cả tin" };
            }

            ViewData["url"] = categoryUrl;
            ViewData["CurrentPage"] = pageIndex;

            PaginationResponse<PostResponse> page = GetPosts(keyword, categoryId, tag, categoryUrl, pageItem, pageIndex);
            ViewData["posts"] = page;
            ViewData["tags"] = GetTags();
            ViewData["postCategories"] = GetPostCategories();


            ViewData["NextPage"] = pageIndex == page.TotalPage? page.TotalPage : pageIndex + 1;
            ViewData["PrevPage"] = pageIndex == 1? 1 : pageIndex - 1;

            return View();
        }
   
        private List<PostCategoryResponse> GetPostCategories()
        {
            var result = (List<PostCategoryResponse>)postCatergoryRepo.Get().Result;
            return result;
        }

        private List<string> GetTags()
        {
            var result = (List<string>)postRepo.Tags().Result;
            return result;
        }

        private PaginationResponse<PostResponse> GetPosts(string keyword, 
            int categoryId = 0,
            string tag = "",
            string categoryUrl = "",
            int pageItem = 12,
            int pageIndex = 0)
        {
            PaginationResponse<PostResponse> res = (PaginationResponse<PostResponse>)postRepo.ForUser(keyword, categoryId, tag, categoryUrl, pageItem, pageIndex).Result;
            return res;
        }
    }
}
