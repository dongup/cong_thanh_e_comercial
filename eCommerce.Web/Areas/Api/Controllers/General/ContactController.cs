using eCommerce.Utils;
using eCommerce.Web.Areas.Api.Models.Contact;
using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Entities;
using eCommerce.Web.Entities.Generals;
using eCommerce.Web.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using eCommerce.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static eCommerce.Web.Entities.Generals.ContactEntity;

namespace eCommerce.Web.Areas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : BaseApiController
    {
        public ContactController(DatabaseContext context, UserManager<UserEntity> userManager) : base(context, userManager: userManager)
        {

        }

        /// <summary>
        /// Lấy danh sách các tin nhẵn liên hệ khách hàng gửi lên
        /// </summary>
        /// <param name="keyword">Từ khóa tìm kiếm theo tên khách hàng, sđt, email</param>
        /// <param name="fromDate">Ngày bắt đầu</param>
        /// <param name="toDate">Ngày kết thúc</param>
        /// <param name="pageIndex">Trang hiện tại</param>
        /// <param name="pageItem">Số dòng cần lấy</param>
        /// <returns></returns>
        [HttpGet]
        public ResponseModel Get([FromQuery] string keyword = "", [FromQuery] string fromDate = "", [FromQuery] string toDate = "", [FromQuery] int pageIndex = 0, [FromQuery] int pageItem = 10)
        {
            try
            {
                var result = _context.Contracts
                    .Where(delegate (ContactEntity x)
                    {
                        return (x.CustomerName.Like(keyword)
                            || x.Email.Like(keyword)
                            || x.Phone.Like(keyword))
                            && x.CreatedDate.Beetween(fromDate, toDate);
                    })
                    .OrderByDescending(x => x.CreatedDate)
                    .Select(x => new ContactResponse(x)).ToList();

                res.Succeed(new PaginationResponse<ContactResponse>(result, pageItem, pageIndex));
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }

            return res;
        }

        /// <summary>
        /// Lấy danh sách các tin nhẵn liên hệ chưa xử lý
        /// </summary>
        /// <returns></returns>
        [HttpGet("CountUnHandled")]
        public ResponseModel Get()
        {
            try
            {
                var result = _context.Contracts
                   .Where(x => x.Status == ContactStatus.Pending)
                    .Select(x => new ContactResponse(x));
                res.Succeed(result.Count());
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
                var result = _context.Contracts
                    .Where(x => x.Id == id)
                    .Select(x => new ContactResponse(x))
                    .FirstOrDefault();
                res.Succeed(result);
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }

            return res;
        }

        [HttpPost]
        public ResponseModel Post([FromBody] ContactRequest value)
        {
            try
            {
                if (IsValidRecaptcha(value.Recaptcha)) { 
                    var entity = value.CopyTo(new ContactEntity());
                    entity.CreatedUserId = UserId;
                    _context.Contracts.Add(entity);
                    _context.SaveChanges();
                    res.Succeed();
                }
                else
                {
                    res.Failed("Xác thực Recaptcha không thành công");
                }
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }
            return res;
        }

        private bool IsValidRecaptcha(string recaptcha)
        {
            string recaptcha_token = recaptcha;

            string responseInString = "";

            string url = "https://www.google.com/recaptcha/api/siteverify";

            using (var wb = new System.Net.WebClient())

            {

                var data = new System.Collections.Specialized.NameValueCollection();

                data["response"] = recaptcha_token;

                data["secret"] = "6Le86ZsaAAAAABU6KXieBB9XPvaPqkt2EjeGXKQl";

                var response = wb.UploadValues(url, "POST", data);

                responseInString = System.Text.Encoding.UTF8.GetString(response);

            }

            dynamic result = Newtonsoft.Json.Linq.JObject.Parse(responseInString);

            if (result.success == false)

            {
                return false;
            }
            else
            {
                return true;

            }

        }

        /// <summary>
        /// Cập nhập trạng thái liên hệ 
        /// </summary>
        /// <param name="id">Mã liên hệ</param>
        /// <param name="statusId">Mã trạng thái, gửi lên qua query ?statusId=1</param>
        /// <returns></returns>
        [HttpPut("Status/{id}")]
        public ResponseModel PutStatus(int id, [FromQuery] int statusId)
        {
            try
            {
                var entity = _context.Contracts.Find(id);
                entity.Status = (ContactStatus)statusId;
                entity.UpdatedUserId = UserId;
                entity.UpdatedDate = now;

                _context.SaveChanges();

                res.Succeed(new ContactResponse(entity));
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

        /// <summary>
        /// Cập nhập trạng thái liên hệ 
        /// </summary>
        /// <param name="id">Mã liên hệ</param>
        /// <param name="value">Thông tin liên hệ</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ResponseModel Put(int id, [FromBody] ContactRequest value)
        {
            try
            {
                var entity = _context.Contracts.Find(id);
                value.CopyTo(entity);
                entity.UpdatedUserId = UserId;
                entity.UpdatedDate = now;

                _context.SaveChanges();

                res.Succeed(new ContactResponse(entity));
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
                var entity = _context.Contracts.Find(id);
                _context.Contracts.Remove(entity);
                _context.SaveChanges();
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

        private bool EntityExists(int id)
        {
            return _context.Contracts.Any(x => x.Id == id);
        }
    }
}
