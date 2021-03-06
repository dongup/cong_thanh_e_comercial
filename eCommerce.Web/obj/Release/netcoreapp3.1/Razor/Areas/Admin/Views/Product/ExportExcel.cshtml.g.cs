#pragma checksum "D:\eCommerce\eCommerce.Web\Areas\Admin\Views\Product\ExportExcel.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3e5c3ba45910813803ba3ec255401f5241bfbb84"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Product_ExportExcel), @"mvc.1.0.view", @"/Areas/Admin/Views/Product/ExportExcel.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3e5c3ba45910813803ba3ec255401f5241bfbb84", @"/Areas/Admin/Views/Product/ExportExcel.cshtml")]
    public class Areas_Admin_Views_Product_ExportExcel : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/iotsoftvn/Product/product_export_product.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\eCommerce\eCommerce.Web\Areas\Admin\Views\Product\ExportExcel.cshtml"
  
    ViewData["Title"] = "QU???N L?? S???N PH???M";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            DefineSection("Styles", async() => {
                WriteLiteral("\r\n    <link href=\"/plugins/table-export/css/tableexport.min.css\" rel=\"stylesheet\" />\r\n");
            }
            );
            WriteLiteral(@"<div class=""container-fluid"">
    <div class=""row"">
        <div class=""col-12"">
            <div class=""page-title-box"">
                <div class=""page-title-right"">
                    <button onclick=""openTableExport('#div-export', 'xlsx', 'DANH_SACH_SAN_PHAM');"" class=""btn btn-primary""><i class=""mdi mdi mdi-file-export font-16 mr-1""></i>Export Excel</button>
                </div>
                <h4 class=""page-title"">Export Excel</h4>
            </div>
        </div>
    </div>
    <div class=""row"">
        <div class=""col-12"">
            <div class=""card"">
                <div class=""card-body"">
                    <div class=""row"">
                        <div id=""div-export"" class=""col-lg-12"">
                            <table class=""table table-hover table-centered"">
                                <thead>
                                    <tr>
                                        <th class=""text-center px-w-50"">#</th>
                                        <th>M?? s???n");
            WriteLiteral(" ph???m</th>\r\n                                        <th>T??n s???n ph???m</th>\r\n                                        <th");
            BeginWriteAttribute("class", " class=\"", 1361, "\"", 1369, 0);
            EndWriteAttribute();
            WriteLiteral(">Danh m???c</th>\r\n                                        <th");
            BeginWriteAttribute("class", " class=\"", 1429, "\"", 1437, 0);
            EndWriteAttribute();
            WriteLiteral(@">Th????ng hi???u</th>
                                        <th>Xu???t x???</th>
                                        <th>T??nh tr???ng</th>
                                        <th>??VT</th>
                                        <th>B???o h??nh</th>
                                        <th>N???i dung khuy???n m??i</th>
                                        <th class=""money"">Gi?? ni??m y???t</th>
                                        <th class=""money"">Gi?? b??n l???</th>
                                    </tr>
                                </thead>
                                <tbody id=""tbody-export-product"">
                                    <tr>
                                        <td class=""text-center"" colspan=""15""><i class=""mdi mdi-48px mdi-spin mdi-loading""></i></td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div");
            WriteLiteral(">\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n    <script src=\"/plugins/table-export/xlsx.core.min.js\"></script>\r\n    <script src=\"/plugins/table-export/libs/FileSaver/FileSaver.min.js\"></script>\r\n    <script src=\"/plugins/table-export/tableExport.js\"></script>\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3e5c3ba45910813803ba3ec255401f5241bfbb846525", async() => {
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
                WriteLiteral("\r\n");
            }
            );
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
