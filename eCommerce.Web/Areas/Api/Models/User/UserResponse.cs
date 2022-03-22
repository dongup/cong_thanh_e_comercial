using eCommerce.Utils;
using eCommerce.Web.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static eCommerce.Web.Entities.Identity.UserEntity;

namespace eCommerce.Web.Areas.Api.Models.User
{
    public class UserResponse
    {
        public UserResponse()
        {

        }

        public UserResponse(UserEntity entity)
        {
            if (entity == null) return;

            Id = entity.Id;
            FullName = entity.FullName.ReplaceNull();
            Phone = entity.Phone.ReplaceNull();
            Email = entity.Email.ReplaceNull();
            Note = entity.Note.ReplaceNull();
            UserName = entity.UserName.ReplaceNull();
            Avatar = entity.Avatar.ReplaceNull();

            Status = entity.Status;
            Roles = entity.UserRoles?.Select(x => new RoleResponse(x.Role))?.ToList();
            RoleName = Roles?.FirstOrDefault()?.Name;
            RoleId = Roles?.FirstOrDefault()?.Id;
        }

        public int Id { get; set; }

        public string Avatar { get; set; }

        [Required(ErrorMessage =  "Họ tên không được để trống!")]
        public string FullName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Note { get; set; }

        public string RoleName { get; set; }

        public ICollection<RoleResponse> Roles { get; set; }

        /// <summary>
        /// 1: Active, 2: Lockdown
        /// </summary>
        public UserStatus Status { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Vui lòng chọn vai trò!")]
        public int? RoleId { get; set; }

        [Required(ErrorMessage = "Tên tài khoản không được để trông!")]
        public string UserName { get; set; }
    }
}
