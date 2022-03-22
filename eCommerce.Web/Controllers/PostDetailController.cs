using eCommerce.Web.Areas.Api.Controllers;
using eCommerce.Web.Areas.Api.Models.Posts;
using eCommerce.Web.Entities;
using eCommerce.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ApiPostController = eCommerce.Web.Areas.Api.Controllers.PostController;

namespace eCommerce.Web.Controllers
{
    public class PostDetailController : BaseController
    {
        PostCategoryController postCatergoryRepo;
        ApiPostController postRepo;

        public PostDetailController(DatabaseContext context) : base(context)
        {
            postCatergoryRepo = new PostCategoryController(_context);
            postRepo = new ApiPostController(_context);
        }

        public IActionResult Index()
        {
            return View();
        }

        [AcceptVerbs("GET", "HEAD", Route = "postdetail/{friendUrl}")]
        public IActionResult Index(string friendUrl)
        {
            PostResponse post = GetPost(friendUrl);

            ViewData["metaDescript"] = Global.HtmlToPlainText(post.Content);
            ViewData["post"] = post;
            ViewData["tags"] = GetTags();
            ViewData["relatedPosts"] = GetRelatedPost(post.Id);
            ViewData["postCategories"] = GetPostCategories();

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

        private List<PostResponse> GetRelatedPost(int id)
        {
            var result = (List<PostResponse>)postRepo.RelatedPost(id).Result;
            return result;
        }

        private PostResponse GetPost(string url)
        {
            PostResponse post = (PostResponse)postRepo.Get(url).Result;
            return post;
        }
    }

}
