#pragma checksum "D:\eCommerce\eCommerce.Web\Views\Installment\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6e96dc83e43b1ac690ae9759f70d79b380eb73c2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Installment_Index), @"mvc.1.0.view", @"/Views/Installment/Index.cshtml")]
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
#line 1 "D:\eCommerce\eCommerce.Web\Views\Installment\Index.cshtml"
using eCommerce.Utils;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\eCommerce\eCommerce.Web\Views\Installment\Index.cshtml"
using eCommerce.Web.Areas.Api.Models.Products.Product;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\eCommerce\eCommerce.Web\Views\Installment\Index.cshtml"
using eCommerce.Web.Areas.Api.Models.General;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6e96dc83e43b1ac690ae9759f70d79b380eb73c2", @"/Views/Installment/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b9a16393c34df7e06aa69416c0c5d9467f09a17b", @"/Views/_ViewImports.cshtml")]
    public class Views_Installment_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProductResponse>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("form-customer"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/iotsoftvn/user_installment.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 5 "D:\eCommerce\eCommerce.Web\Views\Installment\Index.cshtml"
  
    ProductResponse Product = Model;
    Layout = "~/Views/Shared/_Layout.cshtml";
    ViewData["Title"] = Product.ProductName;

#line default
#line hidden
#nullable disable
            DefineSection("styles", async() => {
                WriteLiteral(@"
    <style>
        .bg-gradient {
            background: rgb(230,88,35);
            background: linear-gradient(90deg, rgba(230,88,35,1) 0%, rgba(192,10,31,1) 100%);
        }

        .font-15 {
            font-size: 15px;
        }

        .content-hightlightProduct > ul {
            list-style: unset;
        }

        .content-hightlightProduct {
            padding-left: 20px;
        }

        .font-24 {
            font-size: 24px;
        }

        .font-13 {
            font-size: 13px;
        }

        .text-sale {
            text-transform: uppercase;
            font-weight: bold;
            text-align: center;
            font-weight: bold;
            text-transform: uppercase;
        }

        .px-w-100 {
            max-width: 100px;
        }

        .img-product {
            object-fit: contain !important;
            width: 429px;
            height: 429px;
        }

        .p-px-15 {
            padding: 15px;
        }

");
                WriteLiteral(@"        .policy_new li {
            display: flex;
            align-items: center;
            justify-content: flex-start;
            padding-bottom: 10px;
        }

            .policy_new li:last-child {
                padding-bottom: 0px;
            }

            .policy_new li i {
                color: #8bbf8e;
            }

        .list-unset {
            padding-left: 30px;
        }

        #carousel-product-sub > div > div {
            width: 100% !important;
            justify-content: center;
        }

        div.list-unset > ul, ol {
            list-style: unset
        }

            div.list-unset > ul > li::marker {
                color: #004cc6;
            }

        div.list-unset > ol > li::marker {
            color: #004cc6;
        }

        .font-sm-24 {
            font-size: 16px;
            font-weight: 600;
        }

        .font-sm-20 {
            font-size: 16px;
        }

        ");
                WriteLiteral(@"@media (min-width: 576px) {
            .font-sm-24 {
                font-size: 24px;
                font-weight: 500;
            }

            .font-sm-20 {
                font-size: 20px;
            }
        }

        table tr td span {
            margin: 10px;
        }
        .table-responsive::-webkit-scrollbar {
            height: 4px;
            width: 4px;
        }
        
    </style>
");
            }
            );
            WriteLiteral(@"
<section class=""products_page p-0"">
    <div class=""container bg-white pl-0 pr-0 p-t-10"">
        <div class=""row"">
            <div class=""col-md-8 m-auto"">
                <div class=""row"">
                    <div class=""col-md-4"">
                        <img onerror=""this.src='/images/default-image.png'""");
            BeginWriteAttribute("src", " src=\"", 3075, "\"", 3100, 2);
            WriteAttributeValue("", 3081, "/", 3081, 1, true);
#nullable restore
#line 132 "D:\eCommerce\eCommerce.Web\Views\Installment\Index.cshtml"
WriteAttributeValue("", 3082, Product.ThumbNail, 3082, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"img-responsive img-center\">\r\n                    </div>\r\n                    <div class=\"col-md-8\">\r\n                        <p><span class=\"text-orange font-18\">Mua tr??? g??p: <a class=\"font-24\"");
            BeginWriteAttribute("href", " href=\"", 3302, "\"", 3329, 1);
#nullable restore
#line 135 "D:\eCommerce\eCommerce.Web\Views\Installment\Index.cshtml"
WriteAttributeValue("", 3309, Product.FriendlyUrl, 3309, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 135 "D:\eCommerce\eCommerce.Web\Views\Installment\Index.cshtml"
                                                                                                                    Write(Product.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></span></p>\r\n");
#nullable restore
#line 136 "D:\eCommerce\eCommerce.Web\Views\Installment\Index.cshtml"
                         if ((Product.GiaBanLe) < Product.OriginPrice)
                        {
                            decimal precent = Math.Floor((100 - (decimal)((decimal)(Product.GiaBanLe) / (decimal)Product.OriginPrice) * 100));
                            if (precent <= 0)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                <p class=""mt-2"" style=""font-size:16px;"">
                                    <span class=""text-dark font-14"">Gi?? ??u ????i:</span>
                                    <span class=""text-orange font-weight-bold font-sm-20"" margin-right:5px;"">");
#nullable restore
#line 143 "D:\eCommerce\eCommerce.Web\Views\Installment\Index.cshtml"
                                                                                                        Write(Global.FormatMoney((Product.GiaBanLe )));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                    <span class=\"line-center text-muted\" style=\"font-size:14px; margin-right:5px;\">");
#nullable restore
#line 144 "D:\eCommerce\eCommerce.Web\Views\Installment\Index.cshtml"
                                                                                                              Write(Global.FormatMoney(Product.OriginPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                </p>\r\n");
#nullable restore
#line 146 "D:\eCommerce\eCommerce.Web\Views\Installment\Index.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                <p class=""mt-2"" style=""font-size:16px;"">
                                    <span class=""text-dark font-14"">Gi?? ??u ????i:</span>
                                    <span class=""text-orange font-weight-bold font-sm-20"" style=""margin-right:5px;"">");
#nullable restore
#line 151 "D:\eCommerce\eCommerce.Web\Views\Installment\Index.cshtml"
                                                                                                                Write((Product.GiaBanLe) < Product.OriginPrice ? (Product.GiaBanLe).ToString("N0") + "??" : Product.OriginPrice.ToString("N0") + "??");

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                    <span class=\"line-center text-muted\" style=\"font-size:14px; margin-right:5px;\">");
#nullable restore
#line 152 "D:\eCommerce\eCommerce.Web\Views\Installment\Index.cshtml"
                                                                                                              Write(Global.FormatMoney(Product.OriginPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                    <span style=\"font-size:14px;\" class=\"text-orange\">-");
#nullable restore
#line 153 "D:\eCommerce\eCommerce.Web\Views\Installment\Index.cshtml"
                                                                                   Write((Product.GiaBanLe) < Product.OriginPrice ? precent.ToString("N0") + "%" : "");

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                </p>\r\n");
#nullable restore
#line 155 "D:\eCommerce\eCommerce.Web\Views\Installment\Index.cshtml"
                            }
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 157 "D:\eCommerce\eCommerce.Web\Views\Installment\Index.cshtml"
                         if ((Product.GiaBanLe ) >= Product.OriginPrice)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            <p class=""mt-2"" style=""font-size:16px;"">
                                <span class=""text-dark font-14"">Gi?? ??u ????i:</span>
                                <span class=""text-orange font-weight-bold font-sm-20"" style=""margin-right:5px;"">");
#nullable restore
#line 161 "D:\eCommerce\eCommerce.Web\Views\Installment\Index.cshtml"
                                                                                                           Write(Global.FormatMoney(Product.OriginPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                            </p>\r\n");
#nullable restore
#line 163 "D:\eCommerce\eCommerce.Web\Views\Installment\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 165 "D:\eCommerce\eCommerce.Web\Views\Installment\Index.cshtml"
                         if (!string.IsNullOrEmpty(Product.PromotionContent))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            <p>
                                <a data-toggle=""collapse"" href=""#collapseExample"" role=""button"" aria-expanded=""false"" aria-controls=""collapseExample"">
                                    Chi ti???t khuy???n m??i
                                </a>
                            </p>
                            <div class=""collapse"" id=""collapseExample"">
                                <div class=""font-12"">
                                    ");
#nullable restore
#line 174 "D:\eCommerce\eCommerce.Web\Views\Installment\Index.cshtml"
                               Write(Html.Raw(Product.PromotionContent));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n");
#nullable restore
#line 177 "D:\eCommerce\eCommerce.Web\Views\Installment\Index.cshtml"

                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </div>
                </div>
            </div>
        </div>
        <div class=""row mt-4"">
            <div class=""col-md-8 m-auto offset-2 col-sm-12"">
                <div id=""div-month""></div>
                <div class=""mt-2"" id=""tbl-info""></div>
                <p class=""mt-3"" id=""txt-note""></p>
                <div class=""mt-5 d-none"" id=""div-info-customer"">
                    <div class=""col-md-12"">
                        <div class=""widget"">
                            <div class=""section-header"">
                                <h3 class=""heading-design-h5"">Th??ng tin kh??ch h??ng</h3>
                                <p>Ch??ng t??i cam k???t  nh???ng th??ng tin m?? b???n ???? cung c???p cho ch??ng t??i s??? ???????c b???o m???t.</p>
                            </div>
                            <hr>
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6e96dc83e43b1ac690ae9759f70d79b380eb73c216196", async() => {
                WriteLiteral(@"
                                <div class=""row"">
                                    <div class=""col-sm-6"">
                                        <div class=""form-group"">
                                            <label class=""control-label"">H??? v?? t??n <span class=""required"">*</span></label>
                                            <input name=""FullName"" class=""form-control border-form-control""");
                BeginWriteAttribute("value", " value=\"", 7660, "\"", 7668, 0);
                EndWriteAttribute();
                WriteLiteral(@" type=""text"">
                                            <span style=""font-size:75%;"" class=""d-none"" id=""lb-error-fullname""><small class=""text-orange"">*Vui l??ng nh???p h??? v?? t??n</small></span>
                                        </div>
                                    </div>
                                    <div class=""col-sm-6"">
                                        <div class=""form-group"">
                                            <label class=""control-label"">??i???n tho???i <span class=""required"">*</span></label>
                                            <input name=""Phone"" class=""form-control border-form-control""");
                BeginWriteAttribute("value", " value=\"", 8310, "\"", 8318, 0);
                EndWriteAttribute();
                WriteLiteral(@" type=""text"">
                                            <span class=""d-none"" style=""font-size:75%;"" id=""lb-error-phone""><small class=""text-orange"">*S??? ??i???n tho???i kh??ng h???p l???</small></span>
                                        </div>
                                    </div>
                                    <div class=""col-sm-12"">
                                        <div class=""form-group"">
                                            <label class=""control-label"">Email</label>
                                            <input name=""Email"" class=""form-control border-form-control""");
                BeginWriteAttribute("value", " value=\"", 8924, "\"", 8932, 0);
                EndWriteAttribute();
                WriteLiteral(@" type=""email"">
                                        </div>
                                    </div>
                                </div>
                                <div class=""row"">
                                    <div class=""col-sm-12 "">
                                        <div class=""form-group"">
                                            <label class=""control-label"">S??? nh??, T??n ???????ng </label>
                                            <textarea name=""Address"" class=""form-control border-form-control""></textarea>
                                        </div>
                                    </div>
                                </div>
                                <div class=""text-center"">
                                    <a id=""btn-buy"" class=""px-h-42 w-100 text-center"" >
                                        <p class=""btn btn-gradient-orange text-white font-weight-bold justify-content-center rounded-8px d-flex align-items-center h-100 col-md-4 col-sm-12 m-aut");
                WriteLiteral("o\" style=\"padding:16px 5px;\">?????t mua tr??? g??p</p>\r\n                                    </a>\r\n                                </div>\r\n\r\n                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script>\r\n        var URL = \'");
#nullable restore
#line 245 "D:\eCommerce\eCommerce.Web\Views\Installment\Index.cshtml"
              Write(ViewData["URL"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\';\r\n        var ID = \'");
#nullable restore
#line 246 "D:\eCommerce\eCommerce.Web\Views\Installment\Index.cshtml"
             Write(ViewData["ID"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\';\r\n    </script>\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6e96dc83e43b1ac690ae9759f70d79b380eb73c221710", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n");
            }
            );
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProductResponse> Html { get; private set; }
    }
}
#pragma warning restore 1591
