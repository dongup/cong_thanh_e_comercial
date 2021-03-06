#pragma checksum "D:\eCommerce\eCommerce.Web\Views\Post\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f6a9e00ecad3ad3307ca9f31e64366595a1294bd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Post_Index), @"mvc.1.0.view", @"/Views/Post/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\eCommerce\eCommerce.Web\Views\_ViewImports.cshtml"
using eCommerce.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\eCommerce\eCommerce.Web\Views\_ViewImports.cshtml"
using eCommerce.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\eCommerce\eCommerce.Web\Views\Post\Index.cshtml"
using eCommerce.Web.Areas.Api.Models.Posts;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\eCommerce\eCommerce.Web\Views\Post\Index.cshtml"
using eCommerce.Web.Areas.Api.Models.General;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\eCommerce\eCommerce.Web\Views\Post\Index.cshtml"
using System.Collections.Generic;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f6a9e00ecad3ad3307ca9f31e64366595a1294bd", @"/Views/Post/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b9a16393c34df7e06aa69416c0c5d9467f09a17b", @"/Views/_ViewImports.cshtml")]
    public class Views_Post_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "D:\eCommerce\eCommerce.Web\Views\Post\Index.cshtml"
  
    ViewData["Title"] = "Tin t???c";
    Layout = "~/Views/Shared/_Layout.cshtml";

    PaginationResponse<PostResponse> posts = (PaginationResponse<PostResponse>)ViewData["posts"];
    List<string> tags = (List<string>)ViewData["tags"];
    List<PostCategoryResponse> postCategories = (List<PostCategoryResponse>)ViewData["postCategories"];
    PostCategoryResponse category = (PostCategoryResponse)ViewData["Category"];

    int pageIndex = int.Parse(ViewData["CurrentPage"].ToString());
    int nextIndex = int.Parse(ViewData["NextPage"].ToString());
    int prevIndex = int.Parse(ViewData["PrevPage"].ToString());

    string url = ViewData["url"].ToString();

#line default
#line hidden
#nullable disable
            DefineSection("Styles", async() => {
                WriteLiteral("\r\n    <style>\r\n     \r\n    </style>\r\n");
            }
            );
            WriteLiteral(@"<section class=""blog_page pt-0"">
    <div class=""container bg-white p-t-10"">
        <div class=""row"">
            <div class=""col-md-3 p-md-0"">
                <div class=""widget blog-sidebar mb18"">
                    <div class=""sidebar-widget"">
                        <h5>Danh m???c</h5>
                        <ul class=""widget-tag"">
");
#nullable restore
#line 32 "D:\eCommerce\eCommerce.Web\Views\Post\Index.cshtml"
                             foreach (var item in postCategories)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li><a");
            BeginWriteAttribute("href", " href=\"", 1350, "\"", 1374, 1);
#nullable restore
#line 34 "D:\eCommerce\eCommerce.Web\Views\Post\Index.cshtml"
WriteAttributeValue("", 1357, item.FriendlyUrl, 1357, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"icofont icofont-square-right\"></i> ");
#nullable restore
#line 34 "D:\eCommerce\eCommerce.Web\Views\Post\Index.cshtml"
                                                                                                        Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 35 "D:\eCommerce\eCommerce.Web\Views\Post\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </ul>\r\n                    </div>\r\n");
            WriteLiteral(@"                </div>
            </div>
            <div class=""col-md-9"">
                <div class=""row"">
                    <div class=""col-md-12"">
                        <div class=""section-header"">
                            <h5 class=""heading-design-h5"">");
#nullable restore
#line 53 "D:\eCommerce\eCommerce.Web\Views\Post\Index.cshtml"
                                                     Write(category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"col-md-12\">\r\n");
#nullable restore
#line 57 "D:\eCommerce\eCommerce.Web\Views\Post\Index.cshtml"
                         if (posts.Data.Count == 0)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <p class=\"justify-content-center\">Hi????n ch??a co?? tin t????c na??o trong danh mu??c na??y</p>\r\n");
#nullable restore
#line 60 "D:\eCommerce\eCommerce.Web\Views\Post\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"row\">\r\n");
#nullable restore
#line 62 "D:\eCommerce\eCommerce.Web\Views\Post\Index.cshtml"
                             foreach (var item in posts.Data)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\"col-md-4 p-2\">\r\n                                    <div class=\"panel blog-box product-item\">\r\n                                        <div class=\"panel-image\">\r\n                                            <a");
            BeginWriteAttribute("href", " href=\"", 3032, "\"", 3056, 1);
#nullable restore
#line 67 "D:\eCommerce\eCommerce.Web\Views\Post\Index.cshtml"
WriteAttributeValue("", 3039, item.FriendlyUrl, 3039, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                                <img onerror=\"this.src=\'/images/default-image.png\'\" class=\"img-responsive\"\r\n                                                     style=\" height: 140px; width: 100%; object-fit: fill;\"");
            BeginWriteAttribute("src", " src=\"", 3291, "\"", 3312, 1);
#nullable restore
#line 69 "D:\eCommerce\eCommerce.Web\Views\Post\Index.cshtml"
WriteAttributeValue("", 3297, item.ThumbNail, 3297, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 3313, "\"", 3319, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                            </a>\r\n                                            <div class=\"title\">\r\n                                                <small>");
#nullable restore
#line 72 "D:\eCommerce\eCommerce.Web\Views\Post\Index.cshtml"
                                                  Write(item.PostCategory.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</small>
                                            </div>
                                        </div>
                                        <div class=""panel-body"">
                                            <div class=""widget-post-info"">
                                                <h6><a class=""max-line-2"" style=""height: 30px !important""");
            BeginWriteAttribute("href", " href=\"", 3873, "\"", 3897, 1);
#nullable restore
#line 77 "D:\eCommerce\eCommerce.Web\Views\Post\Index.cshtml"
WriteAttributeValue("", 3880, item.FriendlyUrl, 3880, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 77 "D:\eCommerce\eCommerce.Web\Views\Post\Index.cshtml"
                                                                                                                              Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></h6>\r\n                                            </div>\r\n");
            WriteLiteral("                                        </div>\r\n                                    </div>\r\n                                </div>\r\n");
#nullable restore
#line 85 "D:\eCommerce\eCommerce.Web\Views\Post\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 88 "D:\eCommerce\eCommerce.Web\Views\Post\Index.cshtml"
                     if (posts.TotalPage > 1)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <nav aria-label=\"Page navigation example\" style=\"width: 100%;\">\r\n                            <ul class=\"pagination justify-content-center\">\r\n                                <li");
            BeginWriteAttribute("class", " class=\"", 4660, "\"", 4713, 2);
            WriteAttributeValue("", 4668, "page-item", 4668, 9, true);
#nullable restore
#line 92 "D:\eCommerce\eCommerce.Web\Views\Post\Index.cshtml"
WriteAttributeValue(" ", 4677, pageIndex == 0 ? "disabled" : "", 4678, 35, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 4773, "\"", 4814, 1);
#nullable restore
#line 93 "D:\eCommerce\eCommerce.Web\Views\Post\Index.cshtml"
WriteAttributeValue("", 4780, url + "?pageIndex=" + prevIndex, 4780, 34, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                        <i class=\"fa fa-angle-left\" aria-hidden=\"true\"></i>\r\n                                    </a>\r\n                                </li>\r\n");
#nullable restore
#line 97 "D:\eCommerce\eCommerce.Web\Views\Post\Index.cshtml"
                                 for (int i = 0; i < posts.TotalPage; i++)
                                {
                                    if (pageIndex - 1 == i)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <li class=\"page-item active\"><a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 5292, "\"", 5340, 1);
#nullable restore
#line 101 "D:\eCommerce\eCommerce.Web\Views\Post\Index.cshtml"
WriteAttributeValue("", 5299, url + "?pageIndex=" + (i+1).ToString(), 5299, 41, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 101 "D:\eCommerce\eCommerce.Web\Views\Post\Index.cshtml"
                                                                                                                                       Write(i + 1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 102 "D:\eCommerce\eCommerce.Web\Views\Post\Index.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <li class=\"page-item\"><a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 5563, "\"", 5611, 1);
#nullable restore
#line 105 "D:\eCommerce\eCommerce.Web\Views\Post\Index.cshtml"
WriteAttributeValue("", 5570, url + "?pageIndex=" + (i+1).ToString(), 5570, 41, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 105 "D:\eCommerce\eCommerce.Web\Views\Post\Index.cshtml"
                                                                                                                                Write(i + 1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 106 "D:\eCommerce\eCommerce.Web\Views\Post\Index.cshtml"
                                    }
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li");
            BeginWriteAttribute("class", " class=\"", 5741, "\"", 5812, 2);
            WriteAttributeValue("", 5749, "page-item", 5749, 9, true);
#nullable restore
#line 108 "D:\eCommerce\eCommerce.Web\Views\Post\Index.cshtml"
WriteAttributeValue(" ", 5758, pageIndex == posts.TotalPage - 1 ? "disabled" : "", 5759, 53, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 5872, "\"", 5913, 1);
#nullable restore
#line 109 "D:\eCommerce\eCommerce.Web\Views\Post\Index.cshtml"
WriteAttributeValue("", 5879, url + "?pageIndex=" + nextIndex, 5879, 34, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                        <i class=\"fa fa-angle-right\" aria-hidden=\"true\"></i>\r\n                                    </a>\r\n                                </li>\r\n                            </ul>\r\n                        </nav>\r\n");
#nullable restore
#line 115 "D:\eCommerce\eCommerce.Web\Views\Post\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
