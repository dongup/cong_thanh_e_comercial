using eCommerce.Web.Entities;
using eCommerce.Web.Entities.Identity;
using eCommerce.Web.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using eCommerce.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using eCommerce.Web.Areas.Api.Models.User;
using Microsoft.EntityFrameworkCore;
using static eCommerce.Web.Areas.Api.Controllers.BaseApiController;

namespace eCommerce.Web.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class BaseController : Controller
    {
        public BaseController()
        {

        }

        public DateTime now => DateTime.Now;
        public bool IsAdmin => CurrentUser.UserRoles.Any(x => x.Role.Id == (int)AppRole.Admin);

        public ResponseModel res = new ResponseModel();
        public int UserId => int.Parse(string.IsNullOrEmpty(_userManager?.GetUserId(User)) ? "1" : _userManager.GetUserId(User));
        //public int UserId = 13;
        public UserEntity CurrentUser => GetCurentUser(UserId);

        //public UserEntity CurrentUser = new UserEntity() { FullName = "Nguyen Van Dong", UserName = "vandong", Id = 1 };


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

        public BaseController(DatabaseContext context,
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
            return _context.Users
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }
    }
}
