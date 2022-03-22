using eCommerce.Utils;
using eCommerce.Web.Areas.Api.Models;
using eCommerce.Web.Areas.Api.Models.User;
using eCommerce.Web.Entities;
using eCommerce.Web.Entities.Generals;
using eCommerce.Web.Entities.Identity;
using eCommerce.Web.Entities.Post;
using eCommerce.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Areas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseApiController
    {
        public UserController(DatabaseContext context, 
            UserManager<UserEntity> userManager, 
            SignInManager<UserEntity> signInManager,
            RoleManager<RoleEntity> roleManager) 
            : base(context, userManager: userManager, signInManager: signInManager, roleManager: roleManager)
        {

        }

        [HttpGet]
        public ResponseModel Get(string keyword, int positionId = 0, int statusId = 0)
        {
            try
            {
                var result = _context.Users
                    .Include(x => x.UserRoles).ThenInclude(x => x.Role)
                    .Where(delegate (UserEntity x) {
                        return (x.FullName.Like(keyword)
                            || x.UserName.Like(keyword)
                            || x.Email.Like(keyword)
                            || x.Phone.Like(keyword))
                            && (x.UserRoles.Any(x => x.RoleId == positionId) || positionId == 0)
                            && ((int)x.Status == statusId || statusId == 0) ; 
                    })
                    .OrderByDescending(x => x.CreatedDate)
                    .Select(x => new UserResponse(x))
                    .ToList();

                res.Succeed(result);
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
                res.Result = ex.StackTrace;
            }

            return res;
        }


        [HttpGet("GetAllPosition")]
        public ResponseModel GetAllPosition()
        {
            try
            {
                var result = _context.Roles
                    .Select(x => new RoleResponse(x)).ToList();
                res.Succeed(result);
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
                var result = _context.Users
                    .Include(x => x.UserRoles).ThenInclude(x => x.Role)
                    .Where(x => x.Id == id)
                    .Select(x => new UserResponse(x))
                    .FirstOrDefault();
                res.Succeed(result);
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }

            return res;
        }

        /// <summary>
        /// Đặt lại mật khẩu cho người dùng
        /// </summary>
        /// <param name="id">Mã người dùng</param>
        /// <param name="value">Chứa thông tin mật khẩu mới</param>
        /// <returns></returns>
        [HttpPost("ResetPassword/{id}")]
        public async Task<ResponseModel> ResetPassword(int id, ResetPaswordRequest value)
        {
            try
            {
                UserEntity user = _context.Users.Find(id);
                string token = await _userManager.GeneratePasswordResetTokenAsync(user);
                IdentityResult rslt = await _userManager.ResetPasswordAsync(user, token, value.NewPassword);
                if (rslt.Succeeded)
                {
                    res.Succeed();
                    await _signInManager.SignOutAsync();
                }
                else
                {
                    res.Failed("Thay đổi mật khẩu thất bại bạn vui lòng thử lại sau!");
                }

                res.Succeed();
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }

            return res;
        }

        /// <summary>
        /// Khóa tài khoản người dùng
        /// </summary>
        /// <param name="id">Mã người dùng</param>
        /// <returns></returns>
        [HttpPost("LockDownUser/{id}")]
        public async Task<ResponseModel> LockDownUser(int id)
        {
            try
            {
                UserEntity user = _context.Users.Find(id);
                user.Status = UserEntity.UserStatus.LockDown;
                await _context.SaveChangesAsync();

                res.Succeed();
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }

            return res;
        }

        /// <summary>
        /// Mở khóa tài khoản cho người dùng
        /// </summary>
        /// <param name="id">Mã người dùng</param>
        /// <returns></returns>
        [HttpPost("UnLockUser/{id}")]
        public async Task<ResponseModel> UnLockUser(int id)
        {
            try
            {
                UserEntity user = _context.Users.Find(id);
                user.Status = UserEntity.UserStatus.Active;
                await _context.SaveChangesAsync();

                res.Succeed();
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }

            return res;
        }

        [HttpPost]
        public async Task<ResponseModel> Post([FromBody] UserRequest value)
        {
            var transaction = _context.Database.BeginTransaction();
            try
            {
                RoleEntity role = await _roleManager.FindByIdAsync(value.RoleId.ToString());
                if (role == null) throw new Exception("Vai trò không tồn tại!");
                LogServices.WriteInfo(role.Name);

                UserEntity user = value.CopyTo(new UserEntity());
                user.CreatedUserId = UserId;
                user.IsAdmin = true;

                IdentityResult createResult = await _userManager.CreateAsync(user, value.Password);

                if (createResult.Succeeded)
                {
                    IdentityResult addResult = await _userManager.AddToRoleAsync(user, role.Name);
                    if (addResult.Succeeded)
                    {
                        res.Succeed();
                    }
                    else
                    {
                        res.Failed(GetIdentityError(addResult.Errors.FirstOrDefault()));
                        res.Result = addResult.Errors;
                    }
                }
                else
                {
                    res.Failed(GetIdentityError(createResult.Errors.FirstOrDefault()));
                    res.Result = createResult.Errors;
                }
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                res.Failed(ex.Message);
                res.Result = ex.StackTrace;
            }

            return res;
        }

        [HttpPut("{id}")]
        public async Task<ResponseModel> Put(int id, [FromBody] UserRequest value)
        {
            try
            {
                UserEntity entity = _context.Users
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .FirstOrDefault(x => x.Id == id);

                value.CopyTo(entity);
                entity.UpdatedUserId = UserId;
                entity.UpdatedDate = now;
           
                RoleEntity newRole = await _roleManager.FindByIdAsync(value.RoleId.ToString());
                if (newRole == null) throw new Exception("Vai trò không tồn tại!");

                //Nếu user đã có vai trò thì xóa vai trò cũ
                string oldRole = entity.UserRoles.FirstOrDefault()?.Role?.Name;
                if (!string.IsNullOrEmpty(oldRole))
                {
                    await _userManager.RemoveFromRoleAsync(entity, oldRole);
                }

                await _userManager.AddToRoleAsync(entity, newRole.Name);

                await _userManager.UpdateAsync(entity);

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
                }
            }

            return res;
        }

        [HttpDelete("{id}")]
        public ResponseModel Delete(int id)
        {
            try
            {
                var entity = _context.Users.Find(id);
                _context.Users.Remove(entity);
                _context.SaveChanges();
                res.Succeed();
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }

            return res;
        }

        private bool EntityExists(int id)
        {
            return _context.Users.Any(x => x.Id == id);
        }

        private string GetIdentityError(IdentityError error)
        {
            string err = "";
            switch (error.Code)
            {
                case "InvalidUserName":
                    err = "Tài khoản không hợp lệ, bạn vui lòng nhập lại tài khoản";
                    break;
                case "DuplicateUserName":
                    err = "Tên tài khoản đã tồn tại, bạn vui lòng chọn tên tài khoản khác";
                    break;
                default:
                    break;
            }

            return err;
        }

        
    }
}
