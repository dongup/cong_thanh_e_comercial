using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Enum
{
    public enum OrderStatus
    {
        CANCEL = 1,// HỦY
        PENDING = 2,// mới đặt cong đang chờ xác nhận
        VERIFIED = 3,// đã xác nhận nhưng chưa bán
        SUCCESS = 4//bán thành công
    }
}
