#pragma checksum "D:\eCommerce\eCommerce.Web\Views\Error\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fd0c922c01ea3003132fce349b095b31b09a7180"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Error_Index), @"mvc.1.0.view", @"/Views/Error/Index.cshtml")]
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
#line 1 "D:\eCommerce\eCommerce.Web\Views\Error\Index.cshtml"
using eCommerce.Utils;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fd0c922c01ea3003132fce349b095b31b09a7180", @"/Views/Error/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b9a16393c34df7e06aa69416c0c5d9467f09a17b", @"/Views/_ViewImports.cshtml")]
    public class Views_Error_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/iotsoftvn/utils.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\eCommerce\eCommerce.Web\Views\Error\Index.cshtml"
  
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
            BeginWriteAttribute("alt", " alt=\"", 541, "\"", 547, 0);
            EndWriteAttribute();
            WriteLiteral(@" height=""18""></span>
                        </a>
                    </div>

                    <div class=""card-body p-4"">
                        <div class=""text-center"">
                            <h1 class=""text-error"">4<i class=""mdi mdi-emoticon-sad""></i>4</h1>
                            <h4 class=""text-uppercase text-danger mt-3"">Bạn không có quyền truy cập vào hệ thống</h4>
                            <p class=""text-muted mt-3"">Bạn không có quyền truy cập vào hệ thống vui lòng liên hệ Admin để được cấp quyền truy cập</p>

                            <a class=""btn btn-info mt-3"" href=""javascript:logOut()""><i class=""mdi mdi-reply""></i>Quay lại đăng nhập</a>
                        </div>
                    </div> <!-- end card-body-->
                </div>
                <!-- end card -->
            </div> <!-- end col -->
        </div>
        <!-- end row -->
    </div>
    <!-- end container -->
</div>
<!-- end page -->
<!-- bundle -->
<script src=""assets/js/vendor.min");
            WriteLiteral(".js\"></script>\r\n<script src=\"assets/js/app.min.js\"></script>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fd0c922c01ea3003132fce349b095b31b09a71805569", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <script>\r\n     var ROOT_URL = \'");
#nullable restore
#line 43 "D:\eCommerce\eCommerce.Web\Views\Error\Index.cshtml"
                Write(Html.Raw(Global.ROOT_URL));

#line default
#line hidden
#nullable disable
                WriteLiteral("\';\r\n        var ROOT_API = \'");
#nullable restore
#line 44 "D:\eCommerce\eCommerce.Web\Views\Error\Index.cshtml"
                   Write(Html.Raw(Global.ROOT_API));

#line default
#line hidden
#nullable disable
                WriteLiteral("\';\r\n        function logOut() {\r\n                ajaxPost(\'Logout\', null, function (res) {\r\n                    localStorage.setItem(\'userAd\', \"\");\r\n                    window.location.href = \"/admin\";\r\n                })\r\n        }\r\n    </script>\r\n");
            }
            );
            WriteLiteral("\r\n\r\n\r\n\r\n");
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
