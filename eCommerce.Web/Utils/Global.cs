using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace eCommerce.Utils
{
    public class Global
    {
        public static string ROOT_URL = "/";
        public static string ROOT_API = "/api/";

        public static string Origin = "https://dienmaycongthanh.vn";

        // public static string ROOT_URL = "http://192.168.0.195:8012/";
        // public static string ROOT_API = "http://192.168.0.195:8012/api/";
        public static decimal CaculatorSaleOff(int originPrice, int saleoffPrice)
        {
            //return Math.Floor((100 - (decimal)((decimal)saleoffPrice / (decimal)originPrice) * 100));
            if (originPrice == 0 || saleoffPrice == 0)
                return 0;
            return Math.Floor((((decimal)((decimal)originPrice - (decimal)saleoffPrice) / originPrice) * 100) * -1);
        }
        public static string FormatMoney(int money)
        {
            string a = money.ToString("N0").Replace("-", "");
            return a.Replace(".", ",") + "₫";
        }
        public static bool CompareString(string a = "", string b = "")
        {
            a = a ?? "";
            b = b ?? "";
            return (RemoveUnicode(a).ToLower().Replace(" ", "").Contains(RemoveUnicode(b).ToLower().Replace(" ", "")));
        }

        public static string RemoveUnicode(string text)
        {
            string[] arr1 = new string[] { "á", "à", "ả", "ã", "ạ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ",
                    "đ",
                    "é","è","ẻ","ẽ","ẹ","ê","ế","ề","ể","ễ","ệ",
                    "í","ì","ỉ","ĩ","ị",
                    "ó","ò","ỏ","õ","ọ","ô","ố","ồ","ổ","ỗ","ộ","ơ","ớ","ờ","ở","ỡ","ợ",
                    "ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ","ự",
                    "ý","ỳ","ỷ","ỹ","ỵ",};
            string[] arr2 = new string[] { "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",
                    "d",
                    "e","e","e","e","e","e","e","e","e","e","e",
                    "i","i","i","i","i",
                    "o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o",
                    "u","u","u","u","u","u","u","u","u","u","u",
                    "y","y","y","y","y",};
            for (int i = 0; i < arr1.Length; i++)
            {
                text = text.Replace(arr1[i], arr2[i]);
                text = text.Replace(arr1[i].ToUpper(), arr2[i].ToUpper());
            }
            Regex reg = new Regex("[*'\",.<>?/\':;}{}|(!`~!@#$%^&*()+=]");
            text = reg.Replace(text, string.Empty);
            Regex reg1 = new Regex("[ ]");
            text = reg.Replace(text, "");

            return text;
        }

        public static string MakeFolder(string name)
        {
            return RemoveUnicode(name).Replace(' ', '_');
        }
        public static string ShortString(string content)
        {
            return String.Join(" ", content.Split().Take(70).ToArray());
        }

        public static string HtmlToPlainText(string html)
        {
            const string tagWhiteSpace = @"(>|$)(\W|\n|\r)+<";//matches one or more (white space or line breaks) between '>' and '<'
            const string stripFormatting = @"<[^>]*(>|$)";//match any character between '<' and '>', even when end tag is missing
            const string lineBreak = @"<(br|BR)\s{0,1}\/{0,1}>";//matches: <br>,<br/>,<br />,<BR>,<BR/>,<BR />
            var lineBreakRegex = new Regex(lineBreak, RegexOptions.Multiline);
            var stripFormattingRegex = new Regex(stripFormatting, RegexOptions.Multiline);
            var tagWhiteSpaceRegex = new Regex(tagWhiteSpace, RegexOptions.Multiline);

            var text = html;
            //Decode html specific characters
            text = System.Net.WebUtility.HtmlDecode(text);
            //Remove tag whitespace/line breaks
            text = tagWhiteSpaceRegex.Replace(text, "><");
            //Replace <br /> with line breaks
            text = lineBreakRegex.Replace(text, Environment.NewLine);
            //Strip formatting
            text = stripFormattingRegex.Replace(text, string.Empty);

            return ShortString(text);
        }

        public static string FormatPhoneNumber(string phone)
        {
            return String.Format("{0:#### ### ###}", phone);
        }
        public static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static int ActualRowDisplayPromotion( int count, int RowDisplay)
        {
            int ActualRowDisplay;
            int row = count / 5;
            int row2 = count % 5;

            ActualRowDisplay = RowDisplay > row ? row : RowDisplay;
            if (ActualRowDisplay == 0)
                ActualRowDisplay = 1;
            if (row2 > 0)
                ActualRowDisplay += 1;
            return ActualRowDisplay;
        }


    }
}
