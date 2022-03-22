using eCommerce.Web.Entities.Identity;
using Microsoft.AspNetCore.Hosting;
using eCommerce.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using static eCommerce.Web.Areas.Api.Controllers.UploadController;
using eCommerce.Web.Areas.Api.Models.User;

namespace eCommerce.Utils
{
    public class ImageHelper
    {
        DateTime now => DateTime.Now;
        private readonly IWebHostEnvironment _webEnvrm;
        private UserEntity _currentUser;
        private UploadType UploadType;
        private IConfiguration _config;

        string user => _currentUser?.UserName;

        public ImageHelper(IWebHostEnvironment webHost, IConfiguration config, UserEntity user = null, UploadType uploadType = UploadType.Unknown)
        {
            _webEnvrm = webHost;
            _currentUser = user;
            UploadType = uploadType;
            _config = config;
        }

        public SavePath GetImageCaptureSavePath()
        {
            //Tạo tên file mới
            string fileName = $"IMAGE_{now.Millisecond}_{now.ToString("HHmmss_ddMMyyyy")}.jpg";

            //Lấy đường dẫn tương đối
            string relativeSavePath = GetRelativeSavePath();

            //Lấy đường dãn tuyệt đối
            string savePath = Path.Combine(_webEnvrm.ContentRootPath, "wwwroot", relativeSavePath);
            //Tạo thư mục nếu chưa có
            Directory.CreateDirectory(savePath);

            //Lấy đường dẫn tuyệt đối của file
            string filePath = Path.Combine(savePath, fileName);
            //Lấy đường dẫn tương đối của file
            string relativePath = Path.Combine(relativeSavePath, fileName);

            return new SavePath()
            {
                FilePath = filePath,
                RelativeFilePath = relativePath,
                FileName = fileName,
                SaveDirectory = savePath
            };
        }

        public string GetRelativeSavePath()
        {
            string relativeSavePath = "";

            switch (UploadType)
            {
                case UploadType.System:
                    relativeSavePath = Path.Combine("Upload", "System"); 
                    break;
                case UploadType.Product:
                    relativeSavePath = Path.Combine("Upload", "Products");
                    break;
                case UploadType.Post:
                    relativeSavePath = Path.Combine("Upload", "Posts");
                    break;
                case UploadType.Popup:
                    relativeSavePath = Path.Combine("Upload", "Popups");
                    break;
                case UploadType.Brand:
                    relativeSavePath = Path.Combine("Upload", "Brands");
                    break;
                case UploadType.Promo:
                    relativeSavePath = Path.Combine("Upload", "Promotion");
                    break;
                case UploadType.Unknown:
                    relativeSavePath = Path.Combine("Upload", "UnknownCategory");
                    break;
                default:
                    relativeSavePath = Path.Combine("Upload", "UnknownCategory");
                    break;
            }

            return relativeSavePath;
        }

        /// <summary>
        /// Copy image từ thư mục này tới thư mục khác
        /// </summary>
        /// <param name="from">Đường dẫn hình ảnh ban đầu</param>
        /// <param name="to">Đường dẫn hình ảnh mới</param>
        /// <param name="type">Loại hình ảnh</param>
        public string CopyImage(string from, string to, UploadType type)
        {
            try
            {
                string fromPath = Path.Combine(_webEnvrm.ContentRootPath, "wwwroot", from);
                string toDirectory = Path.Combine(_webEnvrm.ContentRootPath, "wwwroot", to);
                Directory.CreateDirectory(toDirectory);

                string toPath = Path.Combine(toDirectory, Path.GetFileName(fromPath));

                File.Move(fromPath, toPath);
                return toPath.RelativePath().ToLinuxPath();
            }
            catch (Exception)
            {
                return from;
            }
        }

        /// <summary>
        /// Tạo hình ảnh thu nhỏ
        /// </summary>
        /// <param name="filePath">Đường dẫn hình ảnh muốn tạo thumbnail</param>
        /// <returns></returns>
        public string CreateThumbnail(string filePath)
        {
            Image image = Image.FromFile(filePath);
            Size thumbSize = GetThumbnailSize(image.Width, image.Height);

            Image thumb = image.GetThumbnailImage(thumbSize.Width, thumbSize.Height, () => false, IntPtr.Zero);

            string thumbFileName = Path.GetFileNameWithoutExtension(filePath) + "_thumb.jpg";
            string thumbFilePath = Path.Combine(Path.GetDirectoryName(filePath), thumbFileName);

            thumb.Save(thumbFilePath);
            image.Dispose();
            thumb.Dispose();
            return thumbFilePath.RelativePath();
        }
     
        private Size GetThumbnailSize(int width, int height)
        {
            int thumbSize = _config.GetValue<int>("thumbSize");
            //LogServices.WriteInfo("Thumsize value: " + thumbSize);

            int thumbnailWidth = thumbSize;
            int thumbnailHeight = thumbSize;
            if (width > height)
            {
                decimal per = Math.Round((decimal)width / height, 1);
                thumbnailWidth = Convert.ToInt32(thumbSize * per);
            }
            else
            {
                decimal per = Math.Round((decimal)height / width, 1);
                thumbnailHeight = Convert.ToInt32(thumbSize * per);
            }
            Size thumbnailSize = new Size(thumbnailWidth, thumbnailHeight);
            //LogServices.WriteInfo("Thumsize width: " + thumbnailSize.Width);
            //LogServices.WriteInfo("Thumsize height: " + thumbnailSize.Height);

            return thumbnailSize;
        }
    }

    public class SavePath
    {
        public string FilePath { get; set; }
        public string RelativeFilePath { get; set; }
        public string FileName { get; set; }
        public string SaveDirectory { get; set; }
    }
}
