#pragma checksum "D:\eCommerce\eCommerce.Web\Views\Contact\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "491aa500e3eef29e9ab124e8ebc841f66caff58b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Contact_Index), @"mvc.1.0.view", @"/Views/Contact/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"491aa500e3eef29e9ab124e8ebc841f66caff58b", @"/Views/Contact/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b9a16393c34df7e06aa69416c0c5d9467f09a17b", @"/Views/_ViewImports.cshtml")]
    public class Views_Contact_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/iotsoftvn/contact.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "D:\eCommerce\eCommerce.Web\Views\Contact\Index.cshtml"
  
    ViewData["Title"] = "Li??n h???, G??p ??, Khi???u n???i";
    Layout = "~/Views/Shared/_Layout.cshtml";
    

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""osahan-breadcrumb"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-12"">
                <ol class=""breadcrumb"">
                    <li class=""breadcrumb-item""><a href=""/"">Trang ch???</a></li>
                    <li class=""breadcrumb-item active"">Li??n h???</li>
                </ol>
            </div>
        </div>
    </div>
</div>

<section class=""our-team-main mt-4"">
    <div class=""container"">
        <div class=""section-header section-header-center text-center"">
            <h3 class=""heading-design-center-h3"">Li??n h???, G??p ??, Khi???u n???i</h3>
        </div>
        <div class=""row"">
            <div class=""col-md-8 mx-auto"">
                <div class=""widget mb-4"">
                    <div class=""row"">
                        <div class=""col-md-12"">
                            <div class=""form-group"">
                                <p class=""text-center"">Ch??ng t??i cam k???t nh???ng th??ng tin m?? b???n ???? cung c???p cho ch??ng t??i s??? ???????c b???o");
            WriteLiteral(@" m???t</p>
                                <label class=""control-label"">
                                    T??n ?????y ????? <span class=""required"">*</span>
                                    <span id=""name-error"" class=""text-danger d-none "">
                                         Vui l??ng nh???p t??n
                                    </span>
                                </label>
                                <input id=""ipt-name"" class=""form-control border-form-control"" placeholder=""Nh???p t??n ?????y ?????"" type=""text"" autocomplete=""off"" autofocus>
                            </div>
                        </div>
                        <div class=""col-md-6"">
                            <div class=""form-group"">
                                <label class=""control-label"">
                                    S??? ??i???n tho???i <span class=""required"">*</span>
                                    <span id=""phone-error"" class=""text-danger d-none"">
                                        S??? ??i???n tho???i kh??ng h???p l");
            WriteLiteral(@"???
                                    </span>
                                </label>
                                <input id=""ipt-phone"" class=""form-control border-form-control"" placeholder=""Nh???p s??? ??i???n tho???i"" type=""text"" autocomplete=""off"">
                            </div>
                        </div>
                        <div class=""col-md-6"">
                            <div class=""form-group"">
                                <label class=""control-label"">?????a ch??? email</label>
                                <input id=""ipt-email"" class=""form-control border-form-control"" placeholder=""Nh???p ?????a ch??? email"" type=""text"" autocomplete=""off"">
                            </div>
                        </div>
                        <div class=""col-md-12"">
                            <div class=""form-group"">
                                <label class=""control-label"">?????a ch???</label>
                                <textarea id=""ipt-address"" class=""form-control border-form-control"" rows=""1"" ");
            WriteLiteral(@"autocomplete=""off"" placeholder=""Nh???p ?????a ch???""></textarea>
                            </div>
                        </div>
                        <div class=""col-md-12"">
                            <div class=""form-group"">
                                <label class=""control-label"">
                                    N???i dung li??n h???, g??p ??, khi???u n???i <span class=""required"">*</span>
                                    <span id=""content-error"" class=""text-danger d-none"">
                                         Nh???p n???i dung
                                    </span>
                                </label>
                                <textarea id=""ipt-content"" class=""form-control border-form-control"" rows=""5"" autocomplete=""off"" placeholder=""Nh???p n???i dung""></textarea>
                            </div>
                        </div>
                        <div class=""col-md-12"">
                            <div id=""g-recaptcha"" class=""d-flex justify-content-center""></div>
            ");
            WriteLiteral(@"            </div>
                        <div class=""col-md-12 text-right"">
                            <button onclick=""sendContact()"" type=""button"" class=""btn btn-warning ml-1""><i class=""icofont icofont-send-mail mr-1""></i>G???i li??n h???</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>

");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "491aa500e3eef29e9ab124e8ebc841f66caff58b8531", async() => {
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
                WriteLiteral(@"
    <script type=""text/javascript"" defer>
        $.getScript('https://www.google.com/recaptcha/api.js', function () {
            delay(() => {
                grecaptcha.render(document.getElementById('g-recaptcha'), {
                    'sitekey': '6Le86ZsaAAAAAPOm092WdYu_3UbSVJxgFt4Abqkk',
                });
            }, 2000);
            
        });
    </script>
");
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
