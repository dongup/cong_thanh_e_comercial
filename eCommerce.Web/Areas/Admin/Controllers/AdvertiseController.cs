﻿using eCommerce.Web.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Sale")]
    public class AdvertiseController : BaseController
    {
        public AdvertiseController(DatabaseContext context) : base(context) { }
        public IActionResult Index()
        {
            return View();
        }
    }
}
