#pragma checksum "D:\eCommerce\eCommerce.Web\Areas\Admin\Views\Error\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bf99b01c89e169ed42283ca2853d1724c5a54836"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Error_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Error/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bf99b01c89e169ed42283ca2853d1724c5a54836", @"/Areas/Admin/Views/Error/Index.cshtml")]
    public class Areas_Admin_Views_Error_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\eCommerce\eCommerce.Web\Areas\Admin\Views\Error\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_LayoutLanding.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""account-pages mt-5 mb-5"">
    <div class=""container"">
        <div class=""row justify-content-center"">
            <div class=""col-lg-5"">
                <div class=""card"">
                    <!-- Logo -->
                    <div class=""card-header pt-4 pb-4 text-center bg-primary"">
                        <a href=""index.html"">
                            <span><img src=""assets/images/logo.png""");
            BeginWriteAttribute("alt", " alt=\"", 518, "\"", 524, 0);
            EndWriteAttribute();
            WriteLiteral(@" height=""18""></span>
                        </a>
                    </div>

                    <div class=""card-body p-4"">
                        <div class=""text-center"">
                            <h1 class=""text-error"">4<i class=""mdi mdi-emoticon-sad""></i>4</h1>
                            <h4 class=""text-uppercase text-danger mt-3"">Page Not Found</h4>
                            <p class=""text-muted mt-3"">
                                It's looking like you may have taken a wrong turn. Don't worry... it
                                happens to the best of us. Here's a
                                little tip that might help you get back on track.
                            </p>

                            <a class=""btn btn-info mt-3"" href=""index.html""><i class=""mdi mdi-reply""></i> Return Home</a>
                        </div>
                    </div> <!-- end card-body-->
                </div>
                <!-- end card -->
            </div> <!-- end col -->
      ");
            WriteLiteral("  </div>\r\n        <!-- end row -->\r\n    </div>\r\n    <!-- end container -->\r\n</div>\r\n");
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
