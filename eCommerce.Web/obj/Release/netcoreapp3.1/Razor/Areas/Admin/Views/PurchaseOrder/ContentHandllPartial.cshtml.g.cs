#pragma checksum "D:\eCommerce\eCommerce.Web\Areas\Admin\Views\PurchaseOrder\ContentHandllPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c7326e10f7fa7a8d2d61bc5e8d7dd7871a590b49"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_PurchaseOrder_ContentHandllPartial), @"mvc.1.0.view", @"/Areas/Admin/Views/PurchaseOrder/ContentHandllPartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c7326e10f7fa7a8d2d61bc5e8d7dd7871a590b49", @"/Areas/Admin/Views/PurchaseOrder/ContentHandllPartial.cshtml")]
    public class Areas_Admin_Views_PurchaseOrder_ContentHandllPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div id=""modal-content-handle"" class=""modal"" >
    <div class=""modal-dialog modal-md"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h4 id=""modal-edit"" class=""modal-title"">Nội dung thực hiện</h4>
                <button onclick=""resetContenthandle()"" type=""button"" class=""close"" data-dismiss=""modal"" aria-hidden=""true"">×</button>
            </div>
            <div class=""modal-body"">
                <div class=""row"">
                    <div class=""col-md-12"">
                        <div class=""form-group"">
                            <textarea id=""contentHandle"" data-toggle=""maxlength"" class=""form-control"" maxlength=""225"" rows=""3""
                                      placeholder=""Nhập nội dung thực hiện""></textarea>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""modal-footer"">
                <button onclick=""resetContenthandle()"" id=""btn-close-edit"" type=""button"" clas");
            WriteLiteral(@"s=""btn btn-light m-w-100"" data-dismiss=""modal""><i class=""mdi mdi-block-helper mr-1""></i>Đóng</button>
                <button id=""btn-edit-branch-handle"" type=""button"" class=""btn btn-primary ml-1""><i class=""mdi mdi-check mr-1""></i>Cập nhật</button>
            </div>
        </div>
    </div>
</div>

<div id=""modal-content-handle__"" class=""modal"">
    <div class=""modal-dialog modal-md"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h4 id=""modal-edit"" class=""modal-title"">Xem nội dung xử lý</h4>
                <button onclick=""resetContenthandle()"" type=""button"" class=""close"" data-dismiss=""modal"" aria-hidden=""true"">×</button>
            </div>
            <div class=""modal-body"">
                <div class=""row"">
                    <div class=""col-md-12"">
                        <div class=""form-group"">
                            <textarea id=""contentHandle__"" data-toggle=""maxlength"" class=""form-control"" maxlength=""225"" rows=""3""
              ");
            WriteLiteral(@"                        placeholder=""Chưa có nội dung xử lý""></textarea>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""modal-footer"">
                <button onclick=""resetContenthandle()"" id=""btn-close-edit"" type=""button"" class=""btn btn-light m-w-100"" data-dismiss=""modal""><i class=""mdi mdi-block-helper mr-1""></i>Đóng</button>
                <button id=""btn-edit-branch-handle__"" type=""button"" class=""btn btn-primary ml-1""><i class=""mdi mdi-check mr-1""></i>Cập nhật</button>
            </div>
        </div>
    </div>
</div>");
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
