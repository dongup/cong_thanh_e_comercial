using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Areas.Api.Models.General
{
    public class FileRequestModel
    {
        public string Mine { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public int Size { get; set; }
        public string Tmb { get; set; }
        public string Url { get; set; }
        //        baseUrl: "http://localhost:27677/Upload/"
        //mime: "image/jpeg"
        //name: "tcl-l40s66a-232120-022147-550x340.jpg"
        //path: "Files/Posts/tcl-l40s66a-232120-022147-550x340.jpg"
        //phash: "v1_XFBvc3Rz0"
        //read: 1
        //size: 38668
        //tmb: "http://localhost:27677/el-finder-file-system/thumb/v1_XFBvc3RzXHRjbC1sNDBzNjZhLTIzMjEyMC0wMjIxNDctNTUweDM0MF9FRUY2OTQ2RTc2N0NEQjZERTYzOTU4NDQ0RjgxOUEzQy5qcGc1"
        //ts: 1619072387
        //url: "http://localhost:27677/Upload/Posts/tcl-l40s66a-232120-022147-550x340.jpg"
        //width: "550"
        //write: 1
    }
}
