#pragma checksum "D:\eCommerce\eCommerce.Web\Views\Group\IFrame.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "aaf5a0baf2e3294c67e5e0b64f882702c4eff008"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Group_IFrame), @"mvc.1.0.view", @"/Views/Group/IFrame.cshtml")]
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
#line 1 "D:\eCommerce\eCommerce.Web\Views\Group\IFrame.cshtml"
using eCommerce.Utils;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\eCommerce\eCommerce.Web\Views\Group\IFrame.cshtml"
using eCommerce.Web.Areas.Api.Models.Products.ProductGroup;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aaf5a0baf2e3294c67e5e0b64f882702c4eff008", @"/Views/Group/IFrame.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b9a16393c34df7e06aa69416c0c5d9467f09a17b", @"/Views/_ViewImports.cshtml")]
    public class Views_Group_IFrame : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\eCommerce\eCommerce.Web\Views\Group\IFrame.cshtml"
  
    Layout = "~/Views/Shared/_LayoutIFrame.cshtml";
    ProductGroupDetailResponse group = ViewBag.Products as ProductGroupDetailResponse;
    int isShowSlide = (int)ViewBag.IsShowSlide;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Styles", async() => {
                WriteLiteral(@"
    <style>
        .promo-sticker {
            height: 40px !important;
            margin-top: -52px !important;
            object-fit: fill !important;
        }


        .products_page_list {
            padding: 10px;
        }

        .product-item-body p {
            padding: 0;
        }

        .font-13 {
            font-size: 13px;
        }

        .promo-title {
            color: #fff;
            padding: 10px 0 0 10px;
        }
    </style>


    <style>
        .product-item-image img {
            height: 184px;
        }

        #collapse-brand > div > ul > li > label > input:focus {
            border: none;
        }

        #right-bar {
            position: relative;
            padding-right: 15px;
            z-index: 0;
            width: 280px;
            display: block;
            overflow-y: hidden;
            overflow-x: hidden;
            height: auto;
        }

        .font-10 {
            font-size: 10px;
    ");
                WriteLiteral("    }\r\n\r\n        .style-list {\r\n            position: static;\r\n        }\r\n\r\n        .product-item .card-title {\r\n            min-height: 44px !important;\r\n        }\r\n\r\n        ");
                WriteLiteral(@"@media (min-width: 768px) {
            .font-10 {
                font-size: 13px !important;
            }

            .mobile-filter {
                max-height: 100vh;
                overflow-y: hidden;
            }

            .collapsing {
                -webkit-transition: none;
                transition: none;
                display: none;
            }
        }

        div.list-unset > ul, ol {
            list-style: unset;
        }

        #carousel-banner-slider .item {
            text-align: center !important;
            background-color: #Ffff !important;
        }

        ");
                WriteLiteral(@"@media (max-width: 768px) {

            #right-bar {
                position: fixed !important;
                top: 0;
                display: none;
                padding-right: 0px !important;
                right: 0;
                max-width: 280px;
                z-index: 101 !important;
                overflow-y: scroll;
                height: auto;
                max-height: 100vh;
            }
        }
    </style>
");
            }
            );
            WriteLiteral("\r\n<section class=\"products_page\">\r\n    <div class=\"container\">\r\n        <div class=\"row flex-column-reverse flex-md-row\">\r\n            <div class=\"col-lg-12 col-md-12\">\r\n                <div class=\"row\" id=\"carousel-product-promo\">\r\n");
#nullable restore
#line 118 "D:\eCommerce\eCommerce.Web\Views\Group\IFrame.cshtml"
                      
                        string cl = "col-lg-3 col-md-3 col-sm-6 col-6 p-0";
                        if (isShowSlide == 1)
                            cl = "";
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 123 "D:\eCommerce\eCommerce.Web\Views\Group\IFrame.cshtml"
                     foreach (var item in group.Products)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div");
            BeginWriteAttribute("class", " class=\"", 3150, "\"", 3161, 1);
#nullable restore
#line 125 "D:\eCommerce\eCommerce.Web\Views\Group\IFrame.cshtml"
WriteAttributeValue("", 3158, cl, 3158, 3, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                            <div class=\"product-item\">\r\n");
#nullable restore
#line 127 "D:\eCommerce\eCommerce.Web\Views\Group\IFrame.cshtml"
                                 if (item.IsInstallment0Percent)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\'productdetail-tragop-0-small d-none d-md-block\'><p>Trả góp 0%</p></div>");
#nullable restore
#line 128 "D:\eCommerce\eCommerce.Web\Views\Group\IFrame.cshtml"
                                                                                                                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 129 "D:\eCommerce\eCommerce.Web\Views\Group\IFrame.cshtml"
                                 if ((Global.CaculatorSaleOff(item.OriginPrice, item.SaleOffPrice) * (-1)) > 0)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <div class=\"product-detail-discount-small\"><p class=\"px-w-57\">Giảm giá ");
#nullable restore
#line 131 "D:\eCommerce\eCommerce.Web\Views\Group\IFrame.cshtml"
                                                                                                       Write(Global.CaculatorSaleOff(item.OriginPrice, item.SaleOffPrice)*(-1));

#line default
#line hidden
#nullable disable
            WriteLiteral("%</p></div>\r\n");
#nullable restore
#line 132 "D:\eCommerce\eCommerce.Web\Views\Group\IFrame.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\"product-item-image\">\r\n                                    <a");
            BeginWriteAttribute("href", " href=\"", 3881, "\"", 3908, 2);
            WriteAttributeValue("", 3888, "/", 3888, 1, true);
#nullable restore
#line 134 "D:\eCommerce\eCommerce.Web\Views\Group\IFrame.cshtml"
WriteAttributeValue("", 3889, item.FriendlyUrl, 3889, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\">\r\n                                        <img onerror=\"this.src=\'/images/default-image.png\'\" class=\"card-img-top img-fluid\"");
            BeginWriteAttribute("src", " src=\"", 4050, "\"", 4074, 2);
            WriteAttributeValue("", 4056, "/", 4056, 1, true);
#nullable restore
#line 135 "D:\eCommerce\eCommerce.Web\Views\Group\IFrame.cshtml"
WriteAttributeValue("", 4057, item.ThumbNail, 4057, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    </a>\r\n");
#nullable restore
#line 138 "D:\eCommerce\eCommerce.Web\Views\Group\IFrame.cshtml"
                                     if (!string.IsNullOrEmpty(item.StickerImage) && item.IsShowSticker)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <div>\r\n                                            <img onerror=\"this.src=\'/images/default-image.png\'\" loading=\"lazy\"");
            BeginWriteAttribute("src", " src=\"", 4480, "\"", 4504, 1);
#nullable restore
#line 141 "D:\eCommerce\eCommerce.Web\Views\Group\IFrame.cshtml"
WriteAttributeValue("", 4486, item.StickerImage, 4486, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"img-fluid promo-sticker\" />\r\n                                        </div>\r\n");
#nullable restore
#line 143 "D:\eCommerce\eCommerce.Web\Views\Group\IFrame.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </div>\r\n                                <div class=\"product-item-body px-4 text-left\">\r\n                                    <a");
            BeginWriteAttribute("href", " href=\"", 4787, "\"", 4814, 2);
            WriteAttributeValue("", 4794, "/", 4794, 1, true);
#nullable restore
#line 146 "D:\eCommerce\eCommerce.Web\Views\Group\IFrame.cshtml"
WriteAttributeValue("", 4795, item.FriendlyUrl, 4795, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\">\r\n");
#nullable restore
#line 147 "D:\eCommerce\eCommerce.Web\Views\Group\IFrame.cshtml"
                                         if (item.IsInstallment0Percent)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\'productdetail-tragop-0-small d-block d-md-none\'><p>Trả góp 0%</p></div>");
#nullable restore
#line 148 "D:\eCommerce\eCommerce.Web\Views\Group\IFrame.cshtml"
                                                                                                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <p class=\"card-title text-black\">");
#nullable restore
#line 149 "D:\eCommerce\eCommerce.Web\Views\Group\IFrame.cshtml"
                                                                     Write(item.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 150 "D:\eCommerce\eCommerce.Web\Views\Group\IFrame.cshtml"
                                          
                                            var rootPrice = item.OriginPrice > item.SaleOffPrice ? @Global.FormatMoney(item.OriginPrice) : "";
                                        

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 154 "D:\eCommerce\eCommerce.Web\Views\Group\IFrame.cshtml"
                                         if (item.OriginPrice > item.SaleOffPrice)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <p> <b class=\"text-black\">Giá chính hãng </b></p>\r\n                                            <p>\r\n                                                <span class=\"badge badge-orange badge-percent\">");
#nullable restore
#line 158 "D:\eCommerce\eCommerce.Web\Views\Group\IFrame.cshtml"
                                                                                          Write(Global.CaculatorSaleOff(item.OriginPrice, item.SaleOffPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral(" %</span>\r\n                                                <span class=\"product-desc-price text-left\">\r\n                                                    ");
#nullable restore
#line 160 "D:\eCommerce\eCommerce.Web\Views\Group\IFrame.cshtml"
                                               Write(Global.FormatMoney(item.OriginPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                                </span>

                                            </p>
                                            <p> <b class=""text-black"">Giá ưu đãi </b></p>
                                            <span class=""product-price text-left text-orange"">");
#nullable restore
#line 165 "D:\eCommerce\eCommerce.Web\Views\Group\IFrame.cshtml"
                                                                                         Write(Global.FormatMoney(item.SaleOffPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 166 "D:\eCommerce\eCommerce.Web\Views\Group\IFrame.cshtml"

                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <p> <b class=\"text-black\">Giá ưu đãi </b></p>\r\n                                            <span class=\"product-price text-left text-orange\">");
#nullable restore
#line 171 "D:\eCommerce\eCommerce.Web\Views\Group\IFrame.cshtml"
                                                                                         Write(Global.FormatMoney(item.SaleOffPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 172 "D:\eCommerce\eCommerce.Web\Views\Group\IFrame.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </a>\r\n\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n");
#nullable restore
#line 178 "D:\eCommerce\eCommerce.Web\Views\Group\IFrame.cshtml"

                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n\r\n        </div>\r\n    </div>\r\n</section>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n\r\n    <script>\r\n        var isShowSlide = ");
#nullable restore
#line 189 "D:\eCommerce\eCommerce.Web\Views\Group\IFrame.cshtml"
                     Write(isShowSlide);

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        $(document).ready(function () {\r\n            if (isShowSlide == 1)\r\n            {\r\n                initCarouselProduct(\'#carousel-product-today, #carousel-product-promo\', 5, 500000);\r\n            }\r\n        });\r\n\r\n    </script>\r\n");
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
