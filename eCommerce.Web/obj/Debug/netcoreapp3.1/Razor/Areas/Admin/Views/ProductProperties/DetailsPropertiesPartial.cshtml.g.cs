#pragma checksum "D:\eCommerce\eCommerce.Web\Areas\Admin\Views\ProductProperties\DetailsPropertiesPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5ecf254610a22ece6a168792c78685d942ff0ea7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_ProductProperties_DetailsPropertiesPartial), @"mvc.1.0.view", @"/Areas/Admin/Views/ProductProperties/DetailsPropertiesPartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ecf254610a22ece6a168792c78685d942ff0ea7", @"/Areas/Admin/Views/ProductProperties/DetailsPropertiesPartial.cshtml")]
    public class Areas_Admin_Views_ProductProperties_DetailsPropertiesPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div id=""modal-edit"" class=""modal"">
    <div class=""modal-dialog"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h4 class=""modal-title"" id=""standard-modalLabel"">Chỉnh sửa thuộc tính</h4>
                <button onclick=""resetInput()"" type=""button"" class=""close"" data-dismiss=""modal"" aria-hidden=""true"">×</button>
            </div>
            <div class=""modal-body"">
                <div class=""row"">
                    <div class=""col-md-12"">
                        <div class=""form-group"">
                            <label>Chọn danh mục <span class=""text-danger"">*</span></label>
                            <select id=""select-categories-properties-edit"" class=""form-control"" data-toggle=""select-no-search"">
                            </select>
                        </div>
                        <div class=""form-group"">
                            <label>Tên thuộc tính <span class=""text-danger"">*</span></label>
                            <input");
            WriteLiteral(@" type=""text"" class=""form-control"" placeholder=""Nhập tên thuộc tính"" id=""proper-edit"" autocomplete=""off"" />
                        </div>
                        <div class=""form-group"">
                            <label>Tên giá trị thuộc tính</label>
                            <input id=""ipt-value-edit"" type=""text"" class=""form-control"" placeholder=""Nhập tên giá trị thuộc tính"" autocomplete=""off"" />
                        </div>
                        <div class=""col-md-12"">
                            <div id=""div-span-value-edit"" class=""form-group""></div>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""modal-footer"">
                <button id=""btn-delete-branch"" type=""button"" class=""btn btn-danger m-w-100 mr-auto ml-1""><i class=""mdi mdi-trash-can mr-1""></i>Xoá</button>
                <button onclick=""resetInput()"" id=""btn-close-edit"" type=""button"" class=""btn btn-light m-w-100"" data-dismiss=""modal""><i class=""mdi m");
            WriteLiteral("di-block-helper mr-1\"></i>Đóng</button>\r\n                <button id=\"btn-edit-branch\" type=\"button\" class=\"btn btn-primary ml-1\"><i class=\"mdi mdi-check mr-1\"></i>Cập nhật</button>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
