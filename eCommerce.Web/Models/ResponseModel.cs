using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Models
{
    public class ResponseModel
    {
        public bool IsSuccess { get; set; }
        public object Result { get; set; } = new object();
        public string Message { get; set; }
        //public int StatusCode { get; set; }

        public void Succeed(object Result = null)
        {
            IsSuccess = true;
            this.Result = Result;
        }

        public void Failed(string msg = "")
        {
            IsSuccess = false;
            Message = msg;
        }

        public void NotFound()
        {
            Message = "Cannot found this item!";
            IsSuccess = false;
        }

        public void Forbiden()
        {
            Message = "Access denied! You do not have permission to access.";
            IsSuccess = false;
        }

        public void UnAuthorize()
        {
            Message = "Please login first!";
            IsSuccess = false;
        }

        // Dung trong đồng bộ giá, sl tồn
        public object Results { get; set; }
    }
}
