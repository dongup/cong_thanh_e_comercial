#pragma checksum "D:\eCommerce\eCommerce.Web\Areas\Admin\Views\Config\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ea0cbeb6cc41b5f6fe742f37ce9d91ed6ae361f9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Config_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Config/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ea0cbeb6cc41b5f6fe742f37ce9d91ed6ae361f9", @"/Areas/Admin/Views/Config/Index.cshtml")]
    public class Areas_Admin_Views_Config_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/iotsoftvn/js_file_manager.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "D:\eCommerce\eCommerce.Web\Areas\Admin\Views\Config\Index.cshtml"
  
    ViewData["Title"] = "CẤU HÌNH HỆ THỐNG";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Styles", async() => {
                WriteLiteral(@"
    <style>
        .table td, .table th {
            padding: 0.2rem 0.5rem;
        }

        .card-body {
            padding: 16px;
        }

        td.fitwidth {
            width: 1px;
            white-space: nowrap;
        }
    </style>
");
            }
            );
            WriteLiteral(@"
<div class=""container"">
    <div class=""row"">
        <div class=""col-8 offset-2"">
            <div class=""page-title-box"">
                <h4 class=""page-title"">Thiết lập hệ thống</h4>
            </div>
            <!-- Thông tin liên hệ -->
            <div class=""card"">
                <div class=""card-body"">
                    <h4 class=""header-title mb-0"">Thông tin liên hệ</h4>
                    <div class=""form-horizontal mt-4"">
                        <!-- Tên công ty -->
                        <div class=""form-group row"">
                            <label class=""col-3 col-form-label font-weight-bold"">Tên công ty <span class=""text-danger"">*</span></label>
                            <div class=""col-9"">
                                <input type=""text"" class=""form-control"" id=""tencongty"" placeholder=""Tên công ty"">
                            </div>
                        </div>
                        <!-- Mã số thuế -->
                        <div class=""form-group row"">");
            WriteLiteral(@"
                            <label class=""col-3 col-form-label font-weight-bold"">Mã số thuế <span class=""text-danger"">*</span></label>
                            <div class=""col-9"">
                                <input type=""text"" class=""form-control"" id=""MST"" placeholder=""Mã số thuế"">
                            </div>
                        </div>
                        <!-- Số điện thoại -->
                        <div class=""form-group row"">
                            <label class=""col-3 col-form-label font-weight-bold"">Hotline <span class=""text-danger"">*</span></label>
                            <div class=""col-9"">
                                <input type=""text"" class=""form-control"" id=""hotline"" placeholder=""Hotline"">
                            </div>
                        </div>
                        <div class=""form-group row"">
                            <label class=""col-3 col-form-label font-weight-bold"">SĐT CSKH <span class=""text-danger"">*</span></label>
             ");
            WriteLiteral(@"               <div class=""col-9"">
                                <input type=""text"" class=""form-control"" id=""CSKH"" placeholder=""Số điện thoại chăm sóc khách hàng"">
                            </div>
                        </div>
                        <!-- Địa chỉ -->
                        <div class=""form-group row"">
                            <label class=""col-3 col-form-label font-weight-bold"">Địa chỉ <span class=""text-danger"">*</span></label>
                            <div class=""col-9"">
                                <input type=""text"" class=""form-control"" id=""dc"" placeholder=""Địa chỉ"">
                            </div>
                        </div>
                        <!-- Email -->
                        <div class=""form-group row"">
                            <label class=""col-3 col-form-label font-weight-bold"">Email <span class=""text-danger"">*</span></label>
                            <div class=""col-9"">
                                <input type=""text"" class=""form-c");
            WriteLiteral(@"ontrol"" id=""email"" placeholder=""Email"">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Cài đặt Website -->
            <div class=""card"">
                <div class=""card-body"">
                    <h4 class=""header-title mb-0"">Cài đặt Website</h4>
                    <div class=""form-horizontal mt-4"">
                        <div class=""form-group row"">
                            <label class=""col-3 col-form-label font-weight-bold"">Logo <span class=""text-danger"">*</span></label>
                            <div class=""col-4"">
                                <img class=""w-100"" id=""img-logo"" onerror=""this.src='/images/default-image.png'"" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Zalo -->
            <div class=""card"">
                <div class=""card-body"">
             ");
            WriteLiteral(@"       <h4 class=""header-title mb-0"">Cấu hình Zalo</h4>
                    <div class=""form-horizontal mt-4"">
                        <div class=""form-group row"">
                            <label class=""col-3 col-form-label font-weight-bold"">Zalo OA Id</label>
                            <div class=""col-9"">
                                <input type=""text"" class=""form-control"" id=""ipt-zalo-oa-id"" placeholder=""Zalo Oa Id"">
                            </div>
                        </div>
                        <div class=""form-group row"">
                            <label class=""col-3 col-form-label font-weight-bold"">Zalo Access Token</label>
                            <div class=""col-9"">
                                <input type=""text"" class=""form-control"" id=""ipt-zalo-access-token"" placeholder=""Zalo Access Token"">
                            </div>
                        </div>
                        <div class=""form-group row"">
                            <label class=""col-12 col");
            WriteLiteral(@"-form-label font-weight-bold"">Người nhận đơn hàng</label>
                            <div class=""col-12"">
                                <div class=""row"">
                                    <div class=""col-md-12"">
                                        <div class=""table-responsive"">
                                            <table class=""table table-striped table-centered table-hover"">
                                                <thead>
                                                    <tr>
                                                        <th class=""text-center px-w-50"">#</th>
                                                        <th class=""px-w-200"">Ảnh đại diện</th>
                                                        <th class=""text-left"">Họ tên</th>
                                                        <th class=""text-left px-w-200"">Mã</th>
                                                    </tr>
                                                </thead>
    ");
            WriteLiteral(@"                                            <tbody id=""tbl-zalo-user"">
                                                </tbody>
                                                <tfoot class=""mt-2"">
                                                    <tr>
                                                        <td id=""td-new-index"" class=""text-center"">1</td>
                                                        <td class=""px-w-200"">
                                                            <img id=""img-add-user"" src=""/images/default-image.png""
                                                                 onerror=""this.src='/images/default-image.png'""
                                                                 class=""mr-2"" style=""width: 50px"">
                                                        </td>
                                                        <td class=""text-left"">
                                                            <select onchange=""onAddUserChange(this)"" id=""ipt-");
            WriteLiteral(@"add-user""
                                                                    class=""px-w-200"" data-toggle=""select"">
                                                            </select>
                                                        </td>
                                                        <td class=""text-left"" id=""td-add-user-id"">
                                                        </td>
                                                        <td class=""text-center px-w-50"">
                                                            <i onclick=""addZaloUser()"" data-toggle=""tooltip"" title=""Thêm người nhận""
                                                               class=""mdi mdi-plus mdi-18px cursor-pointer text-success""></i>
                                                        </td>
                                                    </tr>
                                                </tfoot>
                                            </table>
                     ");
            WriteLiteral(@"                   </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Facebook -->
            <div class=""card"">
                <div class=""card-body"">
                    <h4 class=""header-title mb-0"">Cấu hình Facebook</h4>
                    <div class=""form-horizontal mt-4"">
                        <!-- Facebook -->
                        <div class=""form-group row"">
                            <label class=""col-3 col-form-label font-weight-bold"">Facebook Page Id</label>
                            <div class=""col-9"">
                                <input type=""text"" class=""form-control"" id=""ipt-fb-page-id"" placeholder=""Facebook Page Id"">
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-");
            WriteLiteral(@"- Social -->
            <div class=""card"">
                <div class=""card-body"">
                    <h4 class=""header-title mb-0"">Mạng xã hội</h4>
                    <div class=""form-horizontal mt-4"">
                        <div class=""form-group row"">
                            <label class=""col-3 col-form-label font-weight-bold"">URL Facebook</label>
                            <div class=""col-9"">
                                <input type=""text"" class=""form-control"" id=""fbUrl"" placeholder=""URL Facebook"">
                            </div>
                        </div>
                        <div class=""form-group row"">
                            <label class=""col-3 col-form-label font-weight-bold"">URL Youtube</label>
                            <div class=""col-9"">
                                <input type=""text"" class=""form-control"" id=""youUrl"" placeholder=""URL Youtube"">
                            </div>
                        </div>
                        <div class=""form-g");
            WriteLiteral(@"roup row"">
                            <label class=""col-3 col-form-label font-weight-bold"">URL Instagram</label>
                            <div class=""col-9"">
                                <input type=""text"" class=""form-control"" id=""instagramUrl"" placeholder=""URL Instagram"">
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Mail Server -->
            <div class=""card"">
                <div class=""card-body"">
                    <h4 class=""header-title mb-0"">Mail Server</h4>
                    <div class=""form-horizontal mt-4"">
                        <div class=""form-group row"">
                            <label class=""col-3 col-form-label font-weight-bold"">Mail Server</label>
                            <div class=""col-9"">
                                <input type=""text"" class=""form-control"" id=""mailserver"" placeholder=""Mail Server"">
                            </div>
         ");
            WriteLiteral(@"               </div>
                        <div class=""form-group row"">
                            <label class=""col-3 col-form-label font-weight-bold"">Mail Address</label>
                            <div class=""col-9"">
                                <input type=""text"" class=""form-control"" id=""MailAddress"" placeholder=""Mail Address"">
                            </div>
                        </div>
                        <div class=""form-group row"">
                            <label class=""col-3 col-form-label"">Mail Password</label>
                            <div class=""col-9"">
                                <input type=""text"" class=""form-control"" id=""mailpass"" placeholder=""Mail Password"">
                            </div>
                        </div>
                        <div class=""form-group row"">
                            <label class=""col-3 col-form-label font-weight-bold"">Port</label>
                            <div class=""col-9"">
                                <inpu");
            WriteLiteral(@"t type=""text"" class=""form-control"" id=""Port"" placeholder=""Port"">
                            </div>
                        </div>
                        <div class=""form-group row"">
                            <label class=""col-3 col-form-label font-weight-bold"">SSL</label>
                            <div class=""col-9"">
                                <select class=""form-control"" data-toggle=""select-no-search"">
                                    <option value=""0"">Off</option>
                                    <option value=""1"">On</option>
                                </select>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <button onclick=""update()"" type=""button"" class=""btn btn-primary float-right""><i class=""mdi mdi-check mr-1""></i> Cập nhật</button>
        </div>
    </div>
</div>

");
#nullable restore
#line 249 "D:\eCommerce\eCommerce.Web\Areas\Admin\Views\Config\Index.cshtml"
Write(await Html.PartialAsync("EditPartial"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ea0cbeb6cc41b5f6fe742f37ce9d91ed6ae361f918000", async() => {
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
    <script src=""//cdn.ckeditor.com/4.16.0/standard/ckeditor.js""></script>
    <script>
        $(function () {
            loadPage();
        })

        function loadPage() {
            reloadPagination()
            INIT_FILE_MANAGE(""#img-logo"", function (file) {
                let filAnh = ROOT_URL + file.FilePath;
                sourceLogo = filAnh;
                $(""#img-logo"").attr('src', filAnh);
            })
           
        //initCarousel
            loadSubcribedZaloUser();
            loadAllZaloUser();
        }

        var $companyName = $(""#tencongty"")
        var $address = $(""#dc"")
        var $phone = $(""#sdt"")
        var $email = $(""#email"")
        var $mailServer = $(""#mailserver"")
        var $mailPass = $(""#mailpass"")
        var $tokenFace = $(""#ipt-fb-page-id"")
        var $tokenZalo = $(""#ipt-zalo-access-token"")
        var $fbUrl = $(""#fbUrl"")
        var $youUrl = $(""#youUrl"")
        var $logo = $(""#img-logo"")
        var $CSKH = $(""#CSK");
                WriteLiteral(@"H"")
        var $Hotline = $(""#hotline"")
        var $Port = $(""#Port"")
        var $MailAddress = $(""#MailAddress"")
        var $InstagramUrl = $('#instagramUrl');
        var $MST = $('#MST');
        var id
        var sourceLogo
        var data;

        //load data
        function reloadPagination() {
            ajaxGet(""Information"", {}, function (res) {
                data = res.Result;
                $companyName.val(data.CompanyName);
                $address.val(data.Address);
                $phone.val(data.Phone);
                $email.val(data.Email);
                $mailServer.val(data.MailServer);
                $mailPass.val(data.MailPassword);
                $tokenFace.val(data.FbAppId);
                $tokenZalo.val(data.ZaloAccessToken);
                $fbUrl.val(data.FacebookUrl);
                $youUrl.val(data.YoutubeUrl);
                $logo.attr('src', data.Logo);
                $Hotline.val(data.Hotline);
                $Port.val(data.MailPort");
                WriteLiteral(@");
                $MailAddress.val(data.MailAddress);
                $CSKH.val(data.CSKH);
                $iptZaloOa.val(data.ZaloOAId);
                $InstagramUrl.val(data.InstagramUrl);
                $MST.val(data.MaSoThue)
                id = data.Id;
                sourceLogo = data.Logo
            }, function (err) {
                console.log(err)
            })
        }

        //update
        function update() {
            var zaloUserIds = '';
            zaloUsers.forEach(function (item) { zaloUserIds += item.user_id + ','; });

            let data = {
                Id: id,
                CompanyName: $companyName.val(),
                Address: $address.val(),
                Phone: $phone.val(),
                Email: $email.val(),
                Logo: sourceLogo,
                MailServer: $mailServer.val(),
                MailPassword: $mailPass.val(),
                FbAppId: $tokenFace.val(),
                ZaloAccessToken: $tokenZalo.val(),");
                WriteLiteral(@"
                FacebookUrl: $fbUrl.val(),
                YoutubeUrl: $youUrl.val(),
                Hotline: $Hotline.val(),
                CSKH: $CSKH.val(),
                MailPort: $Port.val(),
                MailAddress: $MailAddress.val(),
                ZaloRecipientIds: zaloUserIds,
                ZaloOAId: $iptZaloOa.val(),
                InstagramUrl: $InstagramUrl.val(),
                MaSoThue:$MST.val(),
            }
            ajaxPut(""Information"", data, function (res) {
                if (res.IsSuccess) {
                    alertify.success('cập nhật thành công');
                    loadPage();
                }
                else {
                    alertify.alert(res.Message)
                }
            })
        }

        //Xử lý zalo
        var $iptZaloOa = $(""#ipt-zalo-oa-id"");
        var $tdNewIndex = $(""#td-new-index"");
        var $sltAddUser = $(""#ipt-add-user"");
        var $imgAddUser = $(""#img-add-user"");
        var $listAddUser");
                WriteLiteral(@" = $(""#list-add-user"");
        var $tdUserId = $(""#td-add-user-id"");
        var $tblZalo = $(""#tbl-zalo-user"")

        var zaloUsers = [];
        var allZaloUser = [];
        var newZaloUser = { user_id: '', display_name: '', avatar: '', id: 0 };
        var selectedUser = {};

        function removeZaloUser(id) {
            zaloUsers.splice(id - 1, 1);
            $tdNewIndex.html(zaloUsers.length + 1);
            var $row = $('#td-' + id);
            $row.remove();
        }

        function addZaloUser() {
            var oldUser;
            if (selectedUser != undefined) {
                oldUser = zaloUsers.find(x => x.user_id == selectedUser.user_id);
            }

            if (oldUser != undefined) {
                alertify.error(""Người dùng này đã có trong danh sách, bạn vui lòng chọn người dùng khác!"");
            } else {
                if (selectedUser != undefined) {
                    zaloUsers.push(selectedUser);
                    rende");
                WriteLiteral(@"rUserTable();
                    $sltAddUser.val('').trigger('change');
                } else {
                    alertify.error(""Vui lòng chọn một tài khoản nhận đơn hàng!"");
                }
            }
        }

        function onAddUserChange(slt) {
            var $this = $(slt);
            var user = allZaloUser.find(x => x.user_id == $this.val());
            if (user != undefined) {
                selectedUser = user;
                $tdUserId.html(user.user_id);
                $imgAddUser.attr('src', user.avatar);
            } else {
                $tdUserId.html('');
                $imgAddUser.attr('src', '');
                selectedUser = undefined;
            }
        }
        function renderUserTable() {
            var html = '';
            $tdNewIndex.html(zaloUsers.length + 1);
            zaloUsers.forEach(function (item, index) {
                html += `<tr id=""td-${index + 1}"">
                                <td class=""text-center px-w-");
                WriteLiteral(@"50"">${index + 1}</td>
                                <td><img id=""img-add-product"" src=""${item.avatar}"" onerror=""this.src='/images/default-image.png'"" class=""mr-2"" style=""width: 50px""></td>
                                <td class=""text-left"">${item.display_name}</td>
                                <td class=""text-left"">${item.user_id}</td>
                        </tr>`;
            });

            $tblZalo.html(html);
        }
        function renderSelectUser() {
            var html = '';
            allZaloUser.forEach(function (item, index) {
                html += `<option value=""${item.user_id}"">${item.display_name}</option>`;
            });

            $sltAddUser.html(html);
            $sltAddUser.val('').trigger('change');
        }
        function loadSubcribedZaloUser() {
            ajaxGet('Zalo/Subcribed', {}, function (res) {
                if (res.IsSuccess) {
                    zaloUsers = res.Result;
                    renderUserTable();
                ");
                WriteLiteral(@"} else {
                    alertify.alert(res.Message);
                }
            });
        }
        function loadAllZaloUser() {
            ajaxGet('Zalo/UnSubcribed', {}, function (res) {
                if (res.IsSuccess) {
                    allZaloUser = res.Result;
                    renderSelectUser();
                } else {
                    alertify.alert(res.Message);
                }
            });
        }

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
