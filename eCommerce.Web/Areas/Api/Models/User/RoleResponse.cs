using eCommerce.Web.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Areas.Api.Models.User
{
    public class RoleResponse 
    {
        public RoleResponse()
        {

        }

        public RoleResponse(RoleEntity entity)
        {
            if (entity == null) return;

            Id = entity.Id;
            Name = entity.Name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
