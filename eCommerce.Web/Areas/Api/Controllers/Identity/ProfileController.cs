using eCommerce.Web.Areas.Api.Models.User;
using eCommerce.Web.Entities;
using eCommerce.Web.Entities.Identity;
using eCommerce.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Areas.Api.Controllers.Identity
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : BaseApiController
    {
        public ProfileController(DatabaseContext context, UserManager<UserEntity> userManager)
           : base(context,  userManager: userManager)
        {

        }

        [HttpGet]
        public ResponseModel Get()
        {
            try
            {
                res.Succeed(new UserResponse(CurrentUser));
                //res.Succeed(UserId);
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
