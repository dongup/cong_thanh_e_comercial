using eCommerce.Web.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Areas.Api.Models.User
{
    public class UserRequest : UserResponse
    {
        public UserRequest()
        {

        
        }

        public UserEntity CopyTo(UserEntity entity)
        {
            entity.FullName = FullName;
            entity.Email = Email;
            entity.Phone = Phone;
            entity.Note = Note;
            entity.UserName = UserName;
            entity.Avatar = Avatar;

            return entity;
        }

        public string Password { get; set; } = "";

        protected new int Id { get; set; }

        protected new string RoleName { get; set; }
    }

}
