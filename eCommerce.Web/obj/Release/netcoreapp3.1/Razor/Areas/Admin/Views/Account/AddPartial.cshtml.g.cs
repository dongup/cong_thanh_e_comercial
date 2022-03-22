#pragma checksum "D:\eCommerce\eCommerce.Web\Areas\Admin\Views\Account\AddPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a9e768b014ec9594fcf5c5be0a9c6cdc6bf2ebea"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Account_AddPartial), @"mvc.1.0.view", @"/Areas/Admin/Views/Account/AddPartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9e768b014ec9594fcf5c5be0a9c6cdc6bf2ebea", @"/Areas/Admin/Views/Account/AddPartial.cshtml")]
    public class Areas_Admin_Views_Account_AddPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid cursor-pointer rounded-circle col-md-8"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("img-avatar-add"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/default-avatar.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral(@"<div class=""modal "" id=""modal-add"">
    <div class=""modal-dialog modal-lg"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h4 class=""modal-title"" id=""myLargeModalLabel"">Tạo tài khoản</h4>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-hidden=""true"">×</button>
            </div>
            <div class=""modal-body"">
                <div class=""row"">
                    <div class=""col-lg-12"">
                        <form id=""form-add"">
                            <div class=""row"">
                                <div class=""col-md-4"">
                                    <div class=""form-group text-center"">
                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a9e768b014ec9594fcf5c5be0a9c6cdc6bf2ebea4511", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                    </div>
                                </div>
                                <div class=""col-md-8"">
                                    <div class=""form-group mb-3 "">
                                        <label>
                                            Họ tên
                                            <span class=""text-danger"">&nbsp;*</span>
                                        </label>
                                        <input type=""text"" class=""form-control"" name=""FullName"" placeholder=""Nguyễn Văn A"">
                                    </div>
                                    <div class=""form-group mb-3"">
                                        <label>Số điện thoại</label>
                                        <input type=""text"" class=""form-control"" name=""Phone"" placeholder=""xxxx-xxx-xxx "" >
                                    </div>
                                </div>
                            </div>
                           ");
            WriteLiteral(@" <div class=""row"">
                                <div class=""form-group col-md-6"">
                                    <label>Email</label>
                                    <input type=""text"" class=""form-control"" name=""Email"" placeholder=""abc@gmail.com"" >
                                </div>
                                <div class=""form-group col-md-6"">
                                    <label>
                                        Chức vụ
                                        <span class=""text-danger"">&nbsp;*</span>
                                    </label>
                                    <select class=""select2 form-control "" id=""sl-role-add"" name=""RoleId"" data-toggle=""select2-no-search"" data-placeholder=""Chọn chức vụ ..."">
                                    </select>
                                </div>
                            </div>
                            <div class=""row"">
                                <div class=""form-group mb-3 col-md-6"">
             ");
            WriteLiteral(@"                       <label>Tên tài khoản<span class=""text-danger"">&nbsp;*</span></label>
                                    <input type=""text"" class=""form-control"" name=""UserName"" placeholder=""nguyenvana"">
                                </div>
                                <div class=""form-group mb-3 col-md-6"">
                                    <label>
                                        Mật khẩu
                                        <span class=""text-danger"">&nbsp;*</span>
                                    </label>
                                    <input type=""text"" class=""form-control"" name=""Password"" placeholder=""********"">
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-light"" data-dismiss=""modal"">Đóng</button>
                <button onclick=""javascript");
            WriteLiteral(":$(\'#form-add\').submit()\" type=\"submit\"  class=\"btn btn-primary\" type=\"submit\">Thêm mới</button>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
