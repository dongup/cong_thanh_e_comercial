﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Entities.Identity
{
    public class RoleClaimEntity : IdentityRoleClaim<int>
    {
        public bool IsDeleted { get; set; }
    }
}
