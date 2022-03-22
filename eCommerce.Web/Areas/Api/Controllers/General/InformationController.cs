using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Entities;
using eCommerce.Web.Entities.Generals;
using eCommerce.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using eCommerce.Web.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Areas.Api.Controllers.General
{
    /// <summary>
    /// Thông tin hệ thống
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class InformationController : BaseApiController
    {
        public InformationController(DatabaseContext context, UserManager<UserEntity> userManager) : base(context, userManager: userManager)
        {

        }

        [HttpGet]
        public ResponseModel Get()
        {
            try
            {
                var result = _context.Information.FirstOrDefault(); 
                res.Succeed(new InformationModel(result));
                //res.Succeed(UserId);
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
                res.Result = ex.StackTrace;
            }

            return res;
        }

        [HttpPut]
        public async Task<ResponseModel> Put([FromBody] InformationModel value)
        {
            try
            {
                InformationEntity entity = _context.Information.FirstOrDefault();
                value.CopyTo(entity);
                entity.UpdatedUserId = UserId;
                entity.UpdatedDate = now;

                await _context.SaveChangesAsync();
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
