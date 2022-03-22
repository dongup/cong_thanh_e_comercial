using eCommerce.Utils;
using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Entities;
using eCommerce.Web.Entities.General;
using eCommerce.Web.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Areas.Api.Controllers.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class FolderController : BaseApiController
    {
        [HttpPost("FileFromPath")]
        public async Task<ResponseModel> FileFromPath(FileRequestModel model)
        {
            var indexStart = model.Url.IndexOf("Upload/");
            // redirect back to the index action to show the form once again
            model.Url = model.Url.Substring(indexStart, model.Url.Length - indexStart).Replace("+",@"%20");
            var indexStartThumb = model.Tmb.IndexOf("el-finder-file-system/");
            model.Tmb = model.Tmb.Substring(indexStartThumb, model.Tmb.Length - indexStartThumb);

            var file = _context.Files.Where(n => n.FilePath == model.Name).FirstOrDefault();
            if (file == null)
            {
                file = new FileEntity()
                {
                    CreatedDate = DateTime.Now,
                    FileName = Path.GetFileName(model.Name),
                    FileType = model.Mine,
                    ThumbNailPath = model.Tmb,
                    FileSize = model.Size,
                    CreatedUserId = UserId,
                    FilePath = model.Url
                };
                _context.Files.Add(file);
                await _context.SaveChangesAsync();

            }
            res.IsSuccess = true;
            res.Result = file;
            return res;
        }


        IWebHostEnvironment _environment;
        public FolderController(DatabaseContext context, IWebHostEnvironment environment) : base(context)
        {
            _environment = environment;
        }

        [HttpGet]
        public ResponseModel Get(string keyword = "")
        {
            try
            {
                var result = _context.Forders
                    .Where(delegate (ForderEntity x)
                    {
                        return x.ForderName.Like(keyword);
                    })
                    .Select(x => new FolderResponse(x, false))
                    .ToList();
                res.Succeed(result);
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }

            return res;
        }

        [HttpPost]
        public ResponseModel Post([FromBody] ForderRequest model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.FolderName))
                    res.Failed("Tên không hợp lệ!");
                else if (_context.Forders.Where(n => n.ForderName == model.FolderName && !n.IsDeleted).FirstOrDefault() != null)
                    res.Failed("Tên đã được sử dụng!");
                else
                {
                    var folder = new Entities.General.ForderEntity()
                    {
                        ParentId = model.ParentId,
                        ForderName = model.FolderName,
                        CreatedDate = DateTime.Now,
                        CreatedUserId = UserId
                    };
                    _context.Forders.Add(folder);
                    _context.SaveChanges();
                    //string fullpath = Path.Combine(_environment.WebRootPath, Global.MakeFolder(model.FolderName));
                    //if (!Directory.Exists(fullpath))
                    //{
                    //    Directory.CreateDirectory(fullpath);
                    //}
                    res.Succeed(folder);
                }

            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }

            return res;
        }

        [HttpPut("{id}")]
        public ResponseModel Put(int id, [FromBody] string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                    res.Failed("Tên không hợp lệ!");
                var entity = _context.Forders.Find(id);
                entity.UpdatedUserId = UserId;
                entity.UpdatedDate = now;
                entity.ForderName = name;
                _context.SaveChanges();
                //string fullpath = Path.Combine(_environment.WebRootPath, Global.MakeFolder(name));
                //if (!Directory.Exists(fullpath))
                //{
                //    Directory.CreateDirectory(fullpath);
                //}
                res.Succeed();

            }
            catch (DbUpdateConcurrencyException ex)
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
        ///     Xóa folder
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ResponseModel Delete(int id)
        {
            try
            {
                var entity = _context.Forders.Find(id);
                if (entity == null)
                    res.Failed("Không tìm thấy forder ");
                entity.IsDeleted = true;
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
        ///     Xóa file
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("file/{id}")]
        public ResponseModel DeleteFile(int id)
        {
            try
            {
                var entity = _context.Files.Find(id);
                if (entity == null)
                    res.Failed("Không tìm thấy tệp tin ");
                entity.IsDeleted = true;
                _context.SaveChanges();
                res.Succeed();
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }

            return res;
        }


        [HttpGet("images")]
        public ResponseModel images(
            int FolderId,
            int pageIndex,
            int pageItem,
            string keyword = "")
        {
            try
            {
                pageItem = 50;
                var query = _context.Files
                     .Where(delegate (FileEntity n)
                     {
                         return (n.ForderId == FolderId) && n.FileName.Like(keyword);
                     })
                     .OrderByDescending(n => n.CreatedDate)
                    .Select(n => new FileResponse(n))

                    .Skip(pageItem * (pageIndex - 1))
                    .Take(pageItem)
                    .ToList();
                res.Succeed(new PaginationResponse<FileResponse>(query, pageItem, pageIndex));

            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }

            return res;
        }

        private bool EntityExists(int id)
        {
            return _context.PostCategories.Any(x => x.Id == id);
        }
    }
}
