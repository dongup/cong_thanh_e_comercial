#pragma checksum "D:\eCommerce\eCommerce.Web\Areas\Admin\Views\Account\ProfilePartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1a45d441e0e2db814539e946aceed2a7d88a5460"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Account_ProfilePartial), @"mvc.1.0.view", @"/Areas/Admin/Views/Account/ProfilePartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1a45d441e0e2db814539e946aceed2a7d88a5460", @"/Areas/Admin/Views/Account/ProfilePartial.cshtml")]
    public class Areas_Admin_Views_Account_ProfilePartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<eCommerce.Web.Areas.Api.Models.User.UserResponse>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""modal"" id=""modal-profile"">
    <div class=""modal-dialog modal-lg"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h4 class=""modal-title"" id=""myLargeModalLabel"">Thông tin tài khoản</h4>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-hidden=""true"">×</button>
            </div>
            <div class=""modal-body"">
                <div class=""row"">
                    <div class=""col-lg-12"">
                        <form id=""form-profile"">
                            <div class=""row"">
                                <div class=""col-md-4"">
                                    <div class=""form-group text-center"">
                                        <img class=""img-fluid cursor-pointer rounded-circle col-md-8"" id=""img-avatar-edit""");
            BeginWriteAttribute("src", " src=\"", 930, "\"", 950, 2);
            WriteAttributeValue("", 936, "/", 936, 1, true);
#nullable restore
#line 17 "D:\eCommerce\eCommerce.Web\Areas\Admin\Views\Account\ProfilePartial.cshtml"
WriteAttributeValue("", 937, Model.Avatar, 937, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@"   onerror=""this.src='/images/default-avatar.jpg'""     />
                                    </div>
                                </div>
                                <div class=""col-md-8"">
                                    <div class=""form-group mb-3 "">
                                        <label>Họ tên</label>
                                        <input type=""text""");
            BeginWriteAttribute("value", " value=\"", 1339, "\"", 1362, 1);
#nullable restore
#line 23 "D:\eCommerce\eCommerce.Web\Areas\Admin\Views\Account\ProfilePartial.cshtml"
WriteAttributeValue("", 1347, Model.FullName, 1347, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" readonly class=""form-control  bg-white"" >
                                    </div>
                                    <div class=""form-group mb-3"">
                                        <label>Số điện thoại</label>
                                        <input type=""text"" class=""form-control bg-white"" readonly");
            BeginWriteAttribute("value", " value=\"", 1685, "\"", 1705, 1);
#nullable restore
#line 27 "D:\eCommerce\eCommerce.Web\Areas\Admin\Views\Account\ProfilePartial.cshtml"
WriteAttributeValue("", 1693, Model.Phone, 1693, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" >
                                    </div>
                                </div>
                            </div>
                            <div class=""row"">
                                <div class=""form-group  col-md-6"">
                                    <label>Email</label>
                                    <input type=""text"" class=""form-control bg-white"" readonly");
            BeginWriteAttribute("value", " value=\"", 2096, "\"", 2116, 1);
#nullable restore
#line 34 "D:\eCommerce\eCommerce.Web\Areas\Admin\Views\Account\ProfilePartial.cshtml"
WriteAttributeValue("", 2104, Model.Email, 2104, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" >
                                </div>
                                <div class=""form-group col-md-6"">
                                    <label>Chức vụ</label>
                                    <input type=""text""  class=""form-control bg-white"" readonly");
            BeginWriteAttribute("value", " value=\"", 2382, "\"", 2405, 1);
#nullable restore
#line 38 "D:\eCommerce\eCommerce.Web\Areas\Admin\Views\Account\ProfilePartial.cshtml"
WriteAttributeValue("", 2390, Model.RoleName, 2390, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                                </div>
                            </div>

                        </form>
                    </div>
                </div>
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-light m-w-100"" data-dismiss=""modal""><i class=""mdi mdi-block-helper mr-1""></i>Đóng</button>
            </div>
        </div>
    </div>
</div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<eCommerce.Web.Areas.Api.Models.User.UserResponse> Html { get; private set; }
    }
}
#pragma warning restore 1591
