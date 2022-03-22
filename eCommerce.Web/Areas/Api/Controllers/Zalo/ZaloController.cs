using eCommerce.Utils;
using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Areas.Api.Models.Orders;
using eCommerce.Web.Entities;
using eCommerce.Web.Entities.Orders;
using eCommerce.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using static eCommerce.Web.Entities.Orders.OrderEntity;
using eCommerce.Web.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using eCommerce.Utils.ZaloUtil;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace eCommerce.Web.Areas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZaloController : BaseApiController
    {
        private ZaloUtil zalo;
        private readonly IConfiguration cf;
        public ZaloController(DatabaseContext context, UserManager<UserEntity> userManager, IConfiguration config) : base(context, userManager: userManager)
        {
            zalo = new ZaloUtil(context);
            cf = config;
        }
        
        [HttpGet("Subcribed")]
        public ResponseModel GetSubcribedUser()
        {
            try
            {
                List<ZaloFollowerResponse> users = new List<ZaloFollowerResponse>();
                var userIds = _context.Information.FirstOrDefault().ZaloRecipientIds?.Split(',').Where(x => !string.IsNullOrEmpty(x)).ToList();
                var result1 = zalo.GetAllFollowers();
                if (userIds != null && userIds.Count()!= 0)
                {
                    var result = zalo.GetAllFollowers();
                    users = result.Where(x => userIds.Contains(x.user_id)).ToList();
                    res.Succeed(users);
                }
                else
                    res.Failed("Hiện không có người dùng nào đang đăng kí nhận tin nhắn");
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
                res.Result = ex.StackTrace;
            }
            return res;
        }

        /**Dự phòng cho Access Token V4*/
        [HttpGet("getauthcodezalo")]
        public ResponseModel getauthcodezalo()
        {
            return res;
        }

        /**Dự phòng cho Access Token V4*/
        [HttpGet ("GetAuthCode")]
        public ResponseModel getmoda()
        {
            var Zalo_Dev= new
            {
                zalo_code_verifier= cf.GetSection("zalo:zalo_code_verifier").Value,
                zalo_app_id= cf.GetSection("zalo:zalo_app_id").Value,
                zalo_app_secrect= cf.GetSection("zalo:zalo_app_secrect").Value,
                code_challenge=Global.ComputeSha256Hash(cf.GetSection("zalo:zalo_code_verifier").Value),
            };
            string url = @"https://oauth.zaloapp.com/v4/oa/permission?app_id=" + Zalo_Dev.zalo_app_id + "&redirect_uri=" + System.Web.HttpUtility.UrlEncode("https://d4fa-2402-800-63ad-f0c9-4875-d48-97fb-35b2.ngrok.io/api/zalo/getauthcodezalo"); //+ "&code_challenge="+Zalo_Dev.code_challenge+"&state=zaloauthen";
            res.Message = url;
            return res;
           

        }
        [HttpGet("Followers")]
        public ResponseModel GetFollower()
        {
            try
            {
                var result = zalo.GetAllFollowers();
                res.Succeed(result);
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }
            return res;
        }

        [HttpGet("UnSubcribed")]
        public ResponseModel GetUnSubcribed()
        {
            try
            {
                var result = zalo.GetAllFollowers();
                //var userIds = _context.Information.FirstOrDefault().ZaloRecipientIds?.Split(',').Where(x => !string.IsNullOrEmpty(x));
                //if (userIds != null && userIds.Count() != 0)
                //{
                //    result = result.Where(x => !userIds.Contains(x.user_id)).ToList();
                //}
                //else
                //{

                //}
                res.Succeed(result);
                res.Message = result.Count().ToString();
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }
            return res;
        }

        [HttpGet("ById")]
        public ResponseModel GetById([FromQuery]string userId)
        {
            try
            {
                var result = zalo.GetFollower(userId);
                res.Succeed(result);
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
                res.Result = ex.StackTrace;
            }

            return res;
        }

        /// <summary>
        /// Thêm người nhận tin nhắn
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public ResponseModel Put([FromBody] string userIds)
        {
            try {
                var info = _context.Information.FirstOrDefault();
                if(info != null) info.ZaloRecipientIds = userIds;
                _context.SaveChanges();
                res.Succeed();
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }

            return res;
        }

        /// <summary>
        /// Xóa người nhận tin nhắn
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        [HttpDelete("{user_id}")]
        public ResponseModel Delete(string user_id)
        {
            try
            {
                var info = _context.Information.FirstOrDefault();
                List<string> userIds = info.ZaloRecipientIds.Split(',').Where(x => !string.IsNullOrEmpty(x)).ToList();
                var user = userIds.Where(x => x == user_id).FirstOrDefault();
                if (user != null) userIds.Remove(user);

                var newString = string.Join(",", userIds);
                info.ZaloRecipientIds = newString;

                _context.SaveChanges();
                res.Succeed();
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
                res.Result = ex.InnerException.Message;
            }

            return res;
        }
    }
}
