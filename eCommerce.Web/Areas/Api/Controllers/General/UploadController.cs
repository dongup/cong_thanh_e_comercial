using eCommerce.Web.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eCommerce.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using eCommerce.Web.Areas.Api.Models;
using eCommerce.Web.Entities;
using eCommerce.Web.Areas.Api.Models.General;
using Microsoft.Extensions.Configuration;
using eCommerce.Web.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System.Drawing;
using System.Drawing.Imaging;

namespace eCommerce.Web.Areas.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : BaseApiController
    {
        /// <summary>
        /// Loại ảnh tải lên
        /// </summary>
        public enum UploadType
        {
            /// <summary>
            /// Hệ thống
            /// </summary>
            System,
            /// <summary>
            /// Ảnh sản phẩm
            /// </summary>
            Product,
            /// <summary>
            /// Ảnh tin tưc
            /// </summary>
            Post,
            /// <summary>
            /// Ảnh quảng cáo
            /// </summary>
            Popup,
            /// <summary>
            /// Chương trình giảm giá
            /// </summary>
            Promo,
            /// <summary>
            /// Thương hiệu
            /// </summary>
            Brand,
            /// <summary>
            /// Loại khác
            /// </summary>
            Unknown
        }

        private IConfiguration Configuration;

        public UploadController(DatabaseContext context,
            IWebHostEnvironment webHost,
            IConfiguration configuration,
            UserManager<UserEntity> userManager) : base(context, webEnv: webHost, userManager: userManager)
        {
            _fileHelper = new ImageHelper(webHost, configuration, CurrentUser);
            Configuration = configuration;
        }

        /// <summary>
        /// Upload files
        /// </summary>
        /// <param name="fileName">Tên file</param>
        /// <param name="uploadType">Loại ảnh tải lên</param>
        /// <param name="FolderId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseModel> Upload([FromQuery] string fileName, [FromQuery] UploadType uploadType, [FromQuery] int? FolderId)
        {
            var files = Request.Form.Files;
            _fileHelper = new ImageHelper(_webEnvrm, Configuration, CurrentUser, uploadType);

            //LogServices.WriteInfo($"User {CurrentUser.UserName} uploaded {files.Count()} captures");
            List<FileEntity> imgs = new List<FileEntity>();

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    var savePath = _fileHelper.GetImageCaptureSavePath();

                    using (var stream = System.IO.File.Create(savePath.FilePath))
                    {
                        await formFile.CopyToAsync(stream);
                    }

                    string thumbnail = _fileHelper.CreateThumbnail(savePath.FilePath);

                    FileEntity img = new FileEntity();
                    img.FilePath = savePath.RelativeFilePath.ToLinuxPath();
                    img.ThumbNailPath = thumbnail.ToLinuxPath();
                    img.FileType = formFile.ContentType;
                    img.FileSize = formFile.Length / 1000;
                    img.CreatedUserId = UserId;
                    img.FileName = formFile.FileName;
                    img.ForderId = FolderId == 0 ? null : FolderId;
                    imgs.Add(img);
                }
            }
            _context.Files.AddRange(imgs);
            await _context.SaveChangesAsync();
            res.Succeed(imgs.Select(x => new FileResponse(x)).FirstOrDefault());

            return res;
        }

        /// <summary>
        /// Upload from tool 
        /// </summary>
        /// <param name="fileName">Tên file</param>
        /// <param name="uploadType">Loại ảnh tải lên</param>
        /// <param name="FolderId"></param>
        /// <returns></returns>
        [HttpPost("UploadFromTool")]
        public async Task<ResponseModel> UploadFromTool([FromQuery] string fileName, [FromQuery] UploadType uploadType, [FromQuery] int? FolderId, [FromQuery] string categoryName = "", [FromQuery] string NameProduct = "")
        {
            var files = Request.Form.Files;
            _fileHelper = new ImageHelper(_webEnvrm, Configuration, CurrentUser, uploadType);

            //LogServices.WriteInfo($"User {CurrentUser.UserName} uploaded {files.Count()} captures");
            List<FileEntity> imgs = new List<FileEntity>();

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    var path = _webEnvrm.WebRootPath + @"\Upload\Products\";
                    var pathThumb = _webEnvrm.WebRootPath + @"\Upload\.tmb\Products\";

                    string pathCategory = Path.Combine(path, categoryName);
                    string pathProduct = Path.Combine(pathCategory, NameProduct);

                    string pathTmbCategory = Path.Combine(pathThumb, categoryName);
                    string pathTmbProduct = Path.Combine(pathTmbCategory, NameProduct);
                    if (!System.IO.File.Exists(pathCategory))
                    {
                        Directory.CreateDirectory(pathCategory);
                    }
                    if (!System.IO.File.Exists(pathProduct))
                    {
                        Directory.CreateDirectory(pathProduct);
                    }

                    string name = $"IMAGE_{now.Millisecond}_{now.ToString("HHmmss_ddMMyyyy")}.jpg";
                    var savePath = Path.Combine(pathProduct, name);

                    using (var stream = System.IO.File.Create(savePath))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                   
                    if (!System.IO.File.Exists(pathTmbCategory))
                    {
                        Directory.CreateDirectory(pathTmbCategory);
                    }
                    if (!System.IO.File.Exists(pathTmbProduct))
                    {
                        Directory.CreateDirectory(pathTmbProduct);
                    }
                    string thumbnail = CreateThumbnail(savePath, pathTmbProduct);


                    FileEntity img = new FileEntity();
                    img.FilePath = savePath.Replace(_webEnvrm.WebRootPath + "\\", "").ToLinuxPath();
                    img.ThumbNailPath = thumbnail.Replace(_webEnvrm.WebRootPath + "/", "").ToLinuxPath();
                    img.FileType = formFile.ContentType;
                    img.FileSize = formFile.Length / 1000;
                    img.CreatedUserId = UserId;
                    img.FileName = Path.GetFileName(formFile.FileName);
                    img.ForderId = FolderId == 0 ? null : FolderId;
                    imgs.Add(img);
                }
            }
            _context.Files.AddRange(imgs);
            await _context.SaveChangesAsync();
            res.Succeed(imgs.Select(x => new FileResponse(x)).FirstOrDefault());

            return res;
        }
        public string CreateThumbnail(string filePath, string folderName = "")
        {
            string thumbFilePath = "";
            try
            {
                Image image = Image.FromFile(filePath);
                Size thumbSize = GetThumbnailSize(image.Width, image.Height);
                Image thumb = image.GetThumbnailImage(thumbSize.Width, thumbSize.Height, () => false, IntPtr.Zero);
                string thumbFileName = Path.GetFileNameWithoutExtension(filePath) + "_thumb.jpg";
                thumbFilePath = Path.Combine(folderName, thumbFileName);

                ImageCodecInfo myImageCodecInfo;
                Encoder myEncoder;
                EncoderParameter myEncoderParameter;
                EncoderParameters myEncoderParameters;
                // Get an ImageCodecInfo object that represents the JPEG codec.
                myImageCodecInfo = GetEncoderInfo("image/jpeg");
                // for the Quality parameter category.
                myEncoder = Encoder.Quality;

                // EncoderParameter object in the array.
                myEncoderParameters = new EncoderParameters(1);
                // Save the bitmap as a JPEG file with quality level 75.
                myEncoderParameter = new EncoderParameter(myEncoder, 75L);
                myEncoderParameters.Param[0] = myEncoderParameter;

                thumb.Save(thumbFilePath, myImageCodecInfo, myEncoderParameters);
                image.Dispose();
                thumb.Dispose();
            }
            catch (Exception exx)
            {


            }
            return thumbFilePath.RelativePath();
        }


        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }
        private Size GetThumbnailSize(int width, int height)
        {
            int thumbSize = Configuration.GetValue<int>("thumbSize");
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

        /// <summary>
        /// Dùng test upload bằng swagger
        /// </summary>
        /// <param name="files">Files</param>
        /// <param name="fileName">Tên file</param>
        /// <param name="uploadType">Loại hình ảnh 0: System, 1: Product, 2: Post, 3: Popup, 4: Promo, 5: Thương hiệu, 6: loại khác</param>
        /// <param name="forderId"></param>
        /// <returns></returns>
        [HttpPost("FormUpload")]
        public async Task<ResponseModel> UploadForm(List<IFormFile> files, [FromQuery] string fileName, [FromQuery] UploadType uploadType = UploadType.Product, int? forderId = null)
        {
            _fileHelper = new ImageHelper(_webEnvrm, Configuration, CurrentUser, uploadType);

            List<FileEntity> imgs = new List<FileEntity>();

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    var savePath = _fileHelper.GetImageCaptureSavePath();

                    using (var stream = System.IO.File.Create(savePath.FilePath))
                    {
                        await formFile.CopyToAsync(stream);
                    }

                    string thumbnail = _fileHelper.CreateThumbnail(savePath.FilePath);

                    FileEntity img = new FileEntity();
                    img.FilePath = savePath.RelativeFilePath.ToLinuxPath();
                    img.ThumbNailPath = thumbnail.ToLinuxPath();
                    img.FileType = formFile.ContentType;
                    img.FileSize = formFile.Length / 1000;
                    img.CreatedUserId = UserId;
                    img.FileName = formFile.FileName;
                    img.ForderId = forderId == 0 ? null : forderId;

                    imgs.Add(img);
                }
            }
            _context.Files.AddRange(imgs);
            await _context.SaveChangesAsync();
            res.Succeed(imgs.Select(x => new FileResponse(x)).FirstOrDefault());

            return res;
        }





        //[HttpPost("upload-image")]
        //public async Task<IActionResult> UploadImage(int size = 0)
        //{
        //    ResponseModel response = new ResponseModel();
        //    DateTime now = DateTime.Now;
        //    IFormFile file = null;
        //    try
        //    {
        //        file = Request.Form.Files[0];
        //    }
        //    catch
        //    {
        //        response.Message = "Vui lòng đính kèm hình ảnh";
        //        return Ok(response);
        //    }
        //    string fileName = file.FileName;
        //    var stream = file.OpenReadStream();
        //    var fileSize = stream.Length;
        //    var fileExtension = Path.GetExtension(fileName);
        //    var file_extensions = _config.GetValue<string>("image_extensions").Split(' ');
        //    if (!file_extensions.Any(n => n.Equals(fileExtension)))
        //    {
        //        response.Message = "Hình ảnh không hợp lệ";
        //        return Ok(response);
        //    }
        //    string appDataPath = _host.ContentRootPath;
        //    var uploadPath = Path.Combine(appDataPath, "resources", $"{now:yyyy}", $"{now:MM}", $"{now:dd}");
        //    if (!Directory.Exists(uploadPath))
        //    {
        //        Directory.CreateDirectory(uploadPath);
        //    }
        //    string random_name = StringUtility.Random(30);
        //    var image = await Image.LoadAsync(stream);
        //    int width = image.Width;
        //    int height = image.Height;
        //    int image_max_size = size;
        //    if (image_max_size == 0)
        //    {
        //        image_max_size = _config.GetValue<int>("image_max_size");
        //    }
        //    int max_input_size = width > height ? width : height;
        //    image_max_size = image_max_size > max_input_size ? max_input_size : image_max_size;
        //    Size download_size = new Size(0, 0);
        //    if (width > height)
        //    {
        //        download_size.Width = image_max_size;
        //    }
        //    else
        //    {
        //        download_size.Height = image_max_size;
        //    }
        //    string new_download_file = $"{random_name}.jpg";
        //    string local_file_path = Path.Combine(uploadPath, new_download_file);
        //    image.Mutate(n => n.Resize(download_size));
        //    await image.SaveAsJpegAsync(local_file_path);
        //    string download_path = $"resources/{now:yyyy/MM/dd}/{new_download_file}";
        //    response.Result = new FileResponseModel()
        //    {
        //        FileUrl = download_path,
        //        FileSizeInByte = fileSize,
        //        FileName = fileName
        //    };
        //    response.IsSuccess = true;

        //    var newImage = await Image.LoadAsync(local_file_path);

        //    FileInfo fileInfo = new FileInfo(local_file_path);

        //    await db.Files.AddAsync(new FileEntity()
        //    {
        //        FileExtension = Path.GetExtension(new_download_file),
        //        FileName = fileName,
        //        FilePath = local_file_path,
        //    }

    }
}