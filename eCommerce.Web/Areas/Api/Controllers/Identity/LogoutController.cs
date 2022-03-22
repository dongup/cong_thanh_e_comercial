using eCommerce.Web.Entities;
using eCommerce.Web.Entities.Identity;
using eCommerce.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace eCommerce.Web.Areas.Api.Controllers.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogoutController : BaseApiController
    {
        public LogoutController(DatabaseContext context, SignInManager<UserEntity> signInManager)
          : base(context, signInManager: signInManager)
        {

        }

        [Authorize]
        [HttpPost]
        public async Task<ResponseModel> Logout()
        {
            try
            {
                await _signInManager.SignOutAsync();
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
