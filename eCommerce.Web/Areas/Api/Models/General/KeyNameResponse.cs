using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Areas.Api.Models.General
{
    public class KeyNameResponse
    {
        public KeyNameResponse(int key, string name)
        {
            Key = key;
            Name = name;
        }

        public int Key { get; set; }// danh cho id
        public string Name { get; set; }
    }
    public class NameValueModel
    {
        public NameValueModel( string name, string value)
        {
            Value = value;
            Name = name;
        }

        public string Value { get; set; }// danh cho id
        public string Name { get; set; }
    }
}
