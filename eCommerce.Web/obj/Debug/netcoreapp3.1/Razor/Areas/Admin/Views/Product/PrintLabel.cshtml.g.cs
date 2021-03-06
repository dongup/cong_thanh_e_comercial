#pragma checksum "D:\eCommerce\eCommerce.Web\Areas\Admin\Views\Product\PrintLabel.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5cb1db6dbfc4b980dcb532fbed9b7825281eac5a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Product_PrintLabel), @"mvc.1.0.view", @"/Areas/Admin/Views/Product/PrintLabel.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5cb1db6dbfc4b980dcb532fbed9b7825281eac5a", @"/Areas/Admin/Views/Product/PrintLabel.cshtml")]
    public class Areas_Admin_Views_Product_PrintLabel : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/iotsoftvn/qrcode.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/iotsoftvn/Product/product_print_label.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "D:\eCommerce\eCommerce.Web\Areas\Admin\Views\Product\PrintLabel.cshtml"
  
    ViewData["Title"] = "Intem";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            DefineSection("Styles", async() => {
                WriteLiteral("\r\n    <link href=\"/plugins/table-export/css/tableexport.min.css\" rel=\"stylesheet\" />\r\n");
            }
            );
            WriteLiteral(@"<div class=""container"">
    <div class=""row"">
        <div class=""col-12"">
            <div class=""page-title-box"">
                <div class=""page-title-right "">
                    <button onclick=""showPrintSmallLabel()"" class=""btn btn-primary""><i class=""mdi mdi mdi-printer font-16 mr-1""></i>In tem nh???</button>
                    <button onclick=""showPrintLargeLabel()"" class=""btn btn-primary mr-2""><i class=""mdi mdi mdi-printer font-16 mr-1""></i>In tem l???n </button>
                </div>
                <h4 class=""page-title"">Danh s??ch s???n ph???m in tem</h4>
            </div>
        </div>
    </div>
    <div class=""row mt-3 mb-3"">
        <div class=""col-md-9"">
            <div class=""card mb-0"">
                <div class=""card-header"">
                    <h5 class=""card-title text-uppercase"">Ch???n s???n ph???m c???n in tem</h5>
                </div>
               
                <div class=""card-body"">
                    <div class=""row"">
                        <div class=""col-md-4""");
            WriteLiteral(@">
                            <div class=""form-group"">
                                <label>Ch???n t??? nh??m</label>
                                <p class=""font-10 text-muted""><span class=""text-danger"">*</span> Ch???n s???n ph???m t??? danh s??ch nh??m</p>
                                <select id=""sl-group"" class=""select2 form-control "" data-toggle=""select"">
                                </select>
                            </div>
                        </div>
                        <div class=""col-md-4"">
                            <div class=""form-group"">
                                <label>Ch???n t??? ch????ng tr??nh khuy???n m??i </label>
                                <p class=""font-10 text-muted""><span class=""text-danger"">*</span> Ch???n s???n ph???m t??? danh s??ch ch????ng tr??nh khuy???n m??i</p>
                                <select id=""sl-promo"" class=""select2 form-control "" data-toggle=""select"">
                                </select>

                            </div>
                        </div>");
            WriteLiteral(@"
                        <div class=""col-md-4"">
                            <div class=""form-group"">
                                <label>Ch???n s???n ph???m</label>
                                <p class=""font-10 text-muted""><span class=""text-danger"">*</span> Ch???n c??c s???n ph???m th??m v??o danh s??ch in</p>
                                <select id=""sl-product"" class=""select2 form-control "" data-toggle=""select"">
                                </select>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
        <div class=""col-md-3"">
            <div class=""card mb-0 h-100"">
                <div class=""card-header"">
                    <h5 class=""card-title"">H??nh ???nh m???c ?????nh (% Tr??? g??p)</h5>
                </div>
                <div class=""card-body"">
                    <div class=""row"">
                        <div class=""col-md-7"">
                            <button id=""btn-image-default");
            WriteLiteral(@""" class=""w-100 btn btn-primary"" data-toggle=""tooltip"" data-placement=""top"" title=""Ch???n h??nh tr??? g??p 0% ho???c tr??? tr?????c 0?? ???????c in tr??n tem, k??ch th?????c y??u c???u 80x80""> <i class=""mdi mdi-folder-multiple-image mr-1""></i>Ch???n h??nh  </button>
                            <button id=""btn-image-remove"" class=""mt-1 w-100 btn btn-danger""><i class=""mdi  mdi-18px mdi-delete""></i> X??a h??nh</button>
                        </div>
                        <div class=""col-md-5"">
                            <img id=""img-default"" src=""https://via.placeholder.com/80"" style=""width:80px;height:80px"" onerror=""this.src='https://via.placeholder.com/80'"" />
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>


    <div class=""row"">
        <div class=""col-12"">
            <div class=""card"">
                <div class=""card-header"">
                    <h5 class=""card-title text-uppercase"">Danh s??ch s???n ph???m in tem</h5>
                </div>
");
            WriteLiteral(@"                <div class=""card-body"">
                    <div class=""row"">
                        <div id=""div-export"" class=""col-lg-12"">
                            <table class=""table table-hover table-centered"">
                                <thead>
                                    <tr>
                                        <th class=""text-center px-w-50"">#</th>
                                        <th>M?? s???n ph???m</th>
                                        <th>T??n s???n ph???m</th>
                                        <th>Gi?? ni??m y???t</th>
                                        <th>Gi?? b??n l???</th>
                                        <th");
            BeginWriteAttribute("class", " class=\"", 4980, "\"", 4988, 0);
            EndWriteAttribute();
            WriteLiteral(@">T???n kho</th>
                                    </tr>
                                </thead>
                                <tbody id=""tbl-product"">
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
");
            WriteLiteral(@"<div id=""print-large"" class=""modal"">
    <div class=""modal-dialog modal-lg modal-dialog-scrollable"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h4 id=""modal-edit"" class=""modal-title"">In tem l???n</h4>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-hidden=""true"">??</button>
            </div>
            <div class=""modal-body"">
                <div id=""div-print-large"">
                    <div class=""print-page""></div>
                </div>
            </div>
            <div class=""modal-footer"">
                <button id=""btn-close-edit"" type=""button"" class=""btn btn-light m-w-100"" data-dismiss=""modal""><i class=""mdi mdi-block-helper mr-1""></i>????ng</button>
                <button onclick=""printLargeStart();"" type=""button"" class=""btn btn-primary ml-1""><i class=""mdi mdi-printer mr-1""></i>Print</button>

            </div>

        </div>
    </div>
</div>


");
            WriteLiteral(@"<div id=""print-small"" class=""modal"">
    <div class=""modal-dialog modal-lg modal-dialog-scrollable"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h4 id=""modal-edit"" class=""modal-title"">In tem nh???</h4>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-hidden=""true"">??</button>
            </div>
            <div class=""modal-body m-auto"">
                <div id=""div-print-small"">
                    <div class=""print-page-sm mt-2"">
                    </div>
                </div>

            </div>
            <div class=""modal-footer"">
                <div id=""qrcode""></div>
                <button id=""btn-close-edit"" type=""button"" class=""btn btn-light m-w-100"" data-dismiss=""modal""><i class=""mdi mdi-block-helper mr-1""></i>????ng</button>
                <button onclick=""printSmallStart();"" type=""button"" class=""btn btn-primary ml-1""><i class=""mdi md-18px mdi-printer mr-1""></i>Print</button>
            </div>
        ");
            WriteLiteral("</div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n");
                WriteLiteral("    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5cb1db6dbfc4b980dcb532fbed9b7825281eac5a11754", async() => {
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
                WriteLiteral("\r\n    <script src=\"/iotsoftvn/js_file_manager.js\"></script>\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5cb1db6dbfc4b980dcb532fbed9b7825281eac5a12917", async() => {
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
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral("\r\n\r\n");
            WriteLiteral(@"
<!--<div id=""div-print"" class=""w-100 h-100 border border-secondary overflow-hidden m-auto position-relative"" style=""margin-bottom:30px!important;"">
    <div class=""print-p1""></div>
    <div class=""print-p2"">
        <h4 class=""text-center print-product-name m-0 py-1""><b> T??? L???NH  SHARP SJ-X346E-DS</b></h4>
    </div>
    <div class=""print-p3"">
        <ul>
            <li>Dung t??ch 435 L??t</li>
            <li>C??ng ngh??? INVERTER</li>
            <li>B??? kh??? m??i Nano Ag</li>
            <li>Khay k??ch ch???u l???c</li>
            <li>Xu???t x??? : Th??i lan</li>
            <li>B???o h??nh: 12 th??ng</li>
        </ul>
    </div>
    <div class=""print-p4"">
        <div class=""row"">
            <div class=""bg-white print-price text-center shadow m-auto col-6 offset-3  "">
                <b>
                    <span class=""font-20""> Gi?? ??u ????i:</span> <b class=""text-danger font-24 print-product-name""> 100.000??</b>
                </b> ");
#nullable restore
#line 248 "D:\eCommerce\eCommerce.Web\Areas\Admin\Views\Product\PrintLabel.cshtml"
                Write(Html.Raw("\n"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <span class=""font-12""> Gi?? Ni??m Y???t:</span> <b class=""font-12 ""> <u style=""text-decoration:line-through;"">100.000??</u></b>
            </div>
        </div>
    </div>
    <div class=""print-p5 d-flex "" style=""align-items:center;"">
        <div class=""row"">
            <div class=""col-8"">
                <div>
                    <img class=""print-bank-img col-4 mx-2"" src=""/images/Print/HdBank.png"" alt=""Alternate Text"" />
                    <img class=""print-bank-img col-4"" src=""/images/Print/ASCBank.png"" />
                </div>
            </div>
            <div class=""col-4"">
                <img class=""print-img-tra-gop-0"" src=""/images/Print/print-0.png"" alt=""Alternate Text"" />
            </div>
        </div>
    </div>
    <div class=""print-p6"">
        <ul>
            <li>Combo t??i gi???t cao c???p</li>
            <li>T???ng n?????c gi???t Dnee</li>
            <li>B??? kh??? m??i Nano Ag</li>
            <li>T???ng combo h???p nhuawcj </li>
            <li>T???ng b??? ???ng d???ng </li>
         ");
            WriteLiteral(@"   <li>B???o h??nh: 12 th??ng</li>
        </ul>
    </div>
    <div class=""print-p7"">
        <ul>
            <li>1 ????i </li>
            <li>C??ng ngh??? INVERTER</li>
            <li>B??? kh??? m??i Nano Ag</li>
            <li>Khay k??ch ch???u l???c</li>
            <li>Xu???t x??? : Th??i lan</li>
            <li>B???o h??nh: 12 th??ng</li>
        </ul>
    </div>-->
<!--</div>-->");
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
