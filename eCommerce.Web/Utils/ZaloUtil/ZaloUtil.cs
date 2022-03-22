using eCommerce.Web.Entities;
using eCommerce.Web.Entities.Generals;
using eCommerce.Web.Entities.Orders;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ZaloDotNetSDK;
using ZaloDotNetSDK.entities.oa;

namespace eCommerce.Utils.ZaloUtil
{
    public class ZaloUtil
    {
        private DatabaseContext _context;
        private InformationEntity info;

        private ZaloClient client;

        public ZaloUtil(DatabaseContext context)
        {
            _context = context;
            info = _context.Information.FirstOrDefault();
            client = new ZaloClient(info.ZaloAccessToken);
        }

        public List<ZaloFollowerResponse> GetAllFollowers()
        {
            List<ZaloFollowerResponse> followers = new List<ZaloFollowerResponse>();

            for (int i = 0; i <= 1; i++)
            {
                ZaloResponse<ZaloAllFollowerRepsonse> rspns = client.getListFollower(i * 50, 50).ToObject<ZaloResponse<ZaloAllFollowerRepsonse>>();

                if (rspns.data != null)
                {
                    foreach (var item in rspns.data.followers)
                    {
                        ZaloResponse<ZaloFollowerResponse> result = client.getProfileOfFollower(item.user_id).ToObject<ZaloResponse<ZaloFollowerResponse>>();
                        followers.Add(result.data);
                    }
                }
            }

            return followers.Where(x => x != null).ToList();
        }

        public ZaloFollowerResponse GetFollower(string user_id)
        {
            ZaloResponse<ZaloFollowerResponse> result = client.getProfileOfFollower(user_id).ToObject<ZaloResponse<ZaloFollowerResponse>>();
            if (result.error != 0)
            {
                throw new Exception(result.message);
            }
            else
            {
                return result.data;
            }
        }

        public void SendTextMessage(string user_id, string msg)
        {
            ZaloResponse<object> result = client.sendTextMessageToUserId(user_id, msg).ToObject<ZaloResponse<object>>();
            if (result.error != 0)
            {
                throw new Exception(result.message);
            }
        }

        public void SendOrderMessage(OrderEntity order)
        {
            List<Element> elements = new List<Element>();
            LogServices.WriteInfo("Origin: " + Global.Origin);

            OpenUrlElement headElement = new OpenUrlElement("Thông báo đơn đặt hàng mới",
                $"Mã: {order.Id}\nKH: {order.Customer.FullName}\nSĐT: { order.Customer.Phone}\nĐC: { order.Customer.Address}",
                $"{Global.Origin}/Upload/Logo_thuong_hieu_vs_danh_muc/logodonhangzalo.jpg",
                $"{Global.Origin}/admin/purchaseorder");
            elements.Add(headElement);

            foreach (var item in order.OrderDetails)
            {
                string price = string.Format(new CultureInfo("vi-VN"), "{0:#,##0}", item.BuyPrice);

                string name = item.Product.ProductName;
                int lenghtSub = item.Product.ProductName.Length;
                lenghtSub = lenghtSub > 40 ? 40 : lenghtSub;

                if (lenghtSub < item.Product.ProductName.Length)
                {
                    name = name.Substring(0, lenghtSub) + "...";
                }

                string prodUrl = $"{Global.Origin}/{item.Product.FriendlyUrl}";
                OpenUrlElement producElement = new OpenUrlElement(
                    $"{name}\n{price}đ - SL: {item.Quanity} {item.Product.Unit}", "",
                    $"{Global.Origin}/{item.Product.ThumbNail}",
                    prodUrl);
                LogServices.WriteInfo("Zalo Product url: " + prodUrl);

                elements.Add(producElement);
            }

            //Button Call Khách hàng
            OpenPhoneElement phoneElement = new OpenPhoneElement($"Liên hệ khách hàng qua số đt: {order.Customer?.Phone}",
                "subtitle", $"{Global.Origin}/images/call-icon.png", order.Customer?.Phone);

            elements.Add(phoneElement);

            var userIds = info.ZaloRecipientIds?.Split(',')?.Where(x => !string.IsNullOrEmpty(x)).ToList();
            if (userIds != null)
            {
                foreach (var id in userIds)
                {

                    ZaloResponse<object> result = client.sendListElementMessagetoUserId(id, "Thông báo đơn đặt hàng mới", elements)
                                               .ToObject<ZaloResponse<object>>();

                    LogServices.WriteInfo($"Send order via to zalo id ${id}: ${result.message}");
                }
            }
        }
    }

    public class ZaloTokenResponse
    {
        public string access_token { get; set; }
        public string expire_in { get; set; }
    }

    public class ZaloResponse<T>
    {
        public string message { get; set; }
        public int error { get; set; }
        public T data { get; set; }
    }

    public class ZaloAllFollowerRepsonse
    {
        public int total { get; set; }
        public List<ZaloFollowerResponse> followers { get; set; }
    }

    public class ZaloFollowerResponse
    {
        public string user_id_by_app { get; set; }
        public string user_id { get; set; }
        public string display_name { get; set; }
        public string user_gender { get; set; }
        public string avatar { get; set; }

        public FollowerTagAndNote tags_and_notes_info { get; set; }
    }

    public class FollowerTagAndNote
    {
        public List<object> notes { get; set; }
        public List<object> tag_names { get; set; }
    }
}
