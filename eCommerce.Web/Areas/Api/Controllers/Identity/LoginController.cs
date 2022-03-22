using eCommerce.Utils;
using eCommerce.Web.Areas.Api.Models;
using eCommerce.Web.Areas.Api.Models.User;
using eCommerce.Web.Entities;
using eCommerce.Web.Entities.Generals;
using eCommerce.Web.Entities.Identity;
using eCommerce.Web.Entities.Post;
using eCommerce.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace eCommerce.Web.Areas.Api.Controllers.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : BaseApiController
    {
        public LoginController(DatabaseContext context, SignInManager<UserEntity> signInManager, UserManager<UserEntity> userManager) 
            : base(context, signInManager: signInManager, userManager: userManager)
        {

        }

        [HttpPost]
        public async Task<ResponseModel> Post([FromBody] LoginRequest value)
        {
            try
            {
                UserEntity user = _context.Users
                        .Include(x => x.UserRoles).ThenInclude(x => x.Role)
                        .Where(x => x.UserName == value.UserName)
                        .FirstOrDefault();
                if (user == null) throw new Exception("Đăng nhập thất bại! Sai tên tài khoản hoặc mật khẩu.");
                if(user.Status == UserEntity.UserStatus.LockDown) throw new Exception("Tài khoản của bạn hiện đã bị khóa, bạn vui lòng liên hệ quản trị viên để được hỗ trợ.");

                SignInResult result = await _signInManager.PasswordSignInAsync(value.UserName, value.Password, false, false);

                if (result.Succeeded)
                {
                   res.Succeed(new UserResponse(user));
                }
                else
                {
                   res.Failed("Đăng nhập thất bại! Sai tên tài khoản hoặc mật khẩu.");
                }
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
