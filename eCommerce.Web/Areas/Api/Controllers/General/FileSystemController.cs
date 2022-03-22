using elFinder.NetCore;
using elFinder.NetCore.Drivers.FileSystem;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace eCommerce.Web.Areas.Api.Controllers.General
{

    public class ParamasterQuerystringElFinder
    {
        public string mimes { get; set; }
        public string cmd { get; set; }
        public string target { get; set; }
        public string _ { get; set; }
        //public List<string>intersect { get; set; }
        public string intersect { get; set; }
    }
    [Route("el-finder-file-system")]
    public class FileSystemController : Controller
    {
        IWebHostEnvironment _env;
        private IConfiguration Configuration;
        public FileSystemController(IWebHostEnvironment env, IConfiguration configuration)
        {
            _env = env;
            Configuration = configuration;
        }

        // Url để client-side kết nối đến backend
        // /el-finder-file-system/connector
        [Route("connector")]
        public async Task<IActionResult> Connector()
        {
            var connector = GetConnector();
            var dict = HttpUtility.ParseQueryString(Request.QueryString.Value);
            string json = JsonConvert.SerializeObject(dict.Cast<string>().ToDictionary(k => k, v => dict[v]));
            ParamasterQuerystringElFinder paramasterQuerystringElFinder = JsonConvert.DeserializeObject<ParamasterQuerystringElFinder>(json);

            //var fileImg = dict["intersect[]"];
            //if (fileImg != null && paramasterQuerystringElFinder.cmd == "ls")
            //{
            //    var newf = fileImg.Split(',').Select(n => Guid.NewGuid().ToString()).ToArray();
            //    var newFile = string.Join(",", newf);
            //    dict.Set("intersect[]", newFile);
            //    var a = new QueryString(dict.ToString());
            //}

            if (paramasterQuerystringElFinder.cmd == "rename")
            {
                return Ok(new { error = "Bạn không thể đổi tên thư mục hoặc tên file !" });
            }
            return await connector.ProcessAsync(Request);
        }

        // Địa chỉ để truy vấn thumbnail
        // /el-finder-file-system/thumb
        [Route("thumb/{hash}")]
        public async Task<IActionResult> Thumbs(string hash)
        {
            var connector = GetConnector();
            return await connector.GetThumbnailAsync(HttpContext.Request, HttpContext.Response, hash);
        }

        private Connector GetConnector()
        {
            // Thư mục gốc lưu trữ là wwwwroot/files (đảm bảo có tạo thư mục này)
            string pathroot = "Upload";

            var driver = new FileSystemDriver();

            string absoluteUrl = UriHelper.BuildAbsolute(Request.Scheme, Request.Host);
            var uri = new Uri(absoluteUrl);

            // .. ... wwww/files
            string rootDirectory = Path.Combine(_env.WebRootPath, pathroot);
            string url = $"{uri.Scheme}://{uri.Authority}/{pathroot}/";
            string urlthumb = $"{uri.Scheme}://{uri.Authority}/el-finder-file-system/thumb/";


            var root = new RootVolume(rootDirectory, url, urlthumb)
            {

                //IsReadOnly = !User.IsInRole("Administrators")
                IsReadOnly = false, // Can be readonly according to user's membership permission
                IsLocked = false, // If locked, files and directories cannot be deleted, renamed or moved
                Alias = "Files", // Beautiful name given to the root/home folder
                MaxUploadSizeInKb = Configuration.GetValue<int>("MaxSizeUpload"), // Limit imposed to user uploaded file <= 2048 KB
                //LockedFolders = new List<string>(new string[] { "Folder1" }
                ThumbnailSize = 100,
            };


            driver.AddRoot(root);

            return new Connector(driver)
            {
                // This allows support for the "onlyMimes" option on the client.
                MimeDetect = MimeDetectOption.Internal,
            };
        }

    }

}
