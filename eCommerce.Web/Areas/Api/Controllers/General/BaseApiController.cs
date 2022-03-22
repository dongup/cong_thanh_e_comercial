using eCommerce.Utils;
using eCommerce.Web.Areas.Api.Models.User;
using eCommerce.Web.Entities;
using eCommerce.Web.Entities.Identity;
using eCommerce.Web.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using static eCommerce.Web.Entities.General.FriendlyUrlEntity;
using System.Security.Claims;

namespace eCommerce.Web.Areas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        public enum AppRole { 
            Admin = 1,
            User = 0
        }

        public DateTime now => DateTime.Now;
        public bool IsAdmin => CurrentUser.UserRoles.Any(x => x.Role.Id == (int)AppRole.Admin);

        public ResponseModel res = new ResponseModel();

        public int UserId => GetUserId();
        public UserEntity CurrentUser => GetCurentUser(UserId);

        public readonly DatabaseContext _context;
        public readonly UserManager<UserEntity> _userManager;
        public readonly RoleManager<RoleEntity> _roleManager;
        public readonly SignInManager<UserEntity> _signInManager;
        public readonly IWebHostEnvironment _webEnvrm;
        public readonly IConfiguration _config;
        public readonly ILogger _logger;
        public ImageHelper _fileHelper;

        public CultureInfo vnCulture = new CultureInfo("vi-VN");

        public Exception NotFoundException = new Exception("Không tìm thấy dữ liệu");

        public BaseApiController()
        {

        }

        public BaseApiController(DatabaseContext context,
            IConfiguration config = null,
            UserManager<UserEntity> userManager = null,
            RoleManager<RoleEntity> roleManager = null,
            IWebHostEnvironment webEnv = null,
            SignInManager<UserEntity> signInManager = null,
            ILogger logger = null)
        {
            _logger = logger;
            _userManager = userManager;
            _context = context;
            _roleManager = roleManager;
            _webEnvrm = webEnv;
            _signInManager = signInManager;
            _config = config;
            _fileHelper = new ImageHelper(_webEnvrm, config);
        }

        protected UserResponse GetUser(int id)
        {
            return new UserResponse(_context.Users
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .Where(x => x.Id == id)
                .FirstOrDefault());
        }

        protected UserEntity GetCurentUser(int id)
        {
           // LogServices.WriteInfo("Get current user id: " + id.ToString());

            return _context.Users
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .Where(x => x.Id == id)
                .FirstOrDefault()??new UserEntity() { FullName = "Đông", Id = 1 };
        }

        protected int GetUserId()
        {
            int id = 0;
            try
            {
                var claim= User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                id = int.Parse(string.IsNullOrEmpty(claim) ? "1" : claim);
            }
            catch (Exception err)
            {
                id = 1;
            }
            return id;
        }

        protected void DeleteUrl(string url)
        {
            var urlEntity = _context.FriendlyUrls.Where(x => x.FriendlyUrl == url).FirstOrDefault();
            if(urlEntity != null)
            {
                _context.FriendlyUrls.Remove(urlEntity);
                _context.SaveChanges();
            }
        }

        protected void UpdateUrl(string oldUrl, string newUrl, UrlType type)
        {
            try
            {
                var url = _context.FriendlyUrls.Where(x => x.FriendlyUrl == oldUrl).FirstOrDefault();
                if(url != null)
                {
                    if (UrlExisted(newUrl) && newUrl != oldUrl)
                    {
                        throw new Exception("Url đã được sử dụng bạn vui lòng chọn url khác!");
                    }
                    url.FriendlyUrl = newUrl;

                    _context.SaveChanges();
                }
                else
                {
                    AddUrl(type, newUrl);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void AddUrl(UrlType type, string url)
        {
            try
            {
                if (UrlExisted(url))
                {
                    throw new Exception("Url đã tồn tại bạn vui lòng chọn tên url khác!");
                }
                _context.FriendlyUrls.Add(new Entities.General.FriendlyUrlEntity(type, url));
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        protected bool UrlExisted(string url)
        {
            return _context.FriendlyUrls.Any(x => x.FriendlyUrl == url);
        }
    }
}
