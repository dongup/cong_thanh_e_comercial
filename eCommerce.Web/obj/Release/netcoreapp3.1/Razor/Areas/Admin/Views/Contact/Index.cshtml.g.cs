#pragma checksum "D:\eCommerce\eCommerce.Web\Areas\Admin\Views\Contact\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "90bc2f6f89581fee494ec0fbf61806fa748d2d3e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Contact_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Contact/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"90bc2f6f89581fee494ec0fbf61806fa748d2d3e", @"/Areas/Admin/Views/Contact/Index.cshtml")]
    public class Areas_Admin_Views_Contact_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\eCommerce\eCommerce.Web\Areas\Admin\Views\Contact\Index.cshtml"
  
    ViewData["Title"] = "LIÊN HỆ";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            DefineSection("styles", async() => {
                WriteLiteral("\r\n   <style>\r\n       .text-TailTruncation {\r\n           white-space: nowrap;\r\n           width: 350px;\r\n           overflow: hidden;\r\n           text-overflow: ellipsis;\r\n       }\r\n   </style>\r\n");
            }
            );
            WriteLiteral(@"<div class=""container-fluid"">
    <div class=""row"">
        <div class=""col-12"">
            <div class=""page-title-box"">
                <h4 class=""page-title"">Liên hệ</h4>
            </div>
        </div>
    </div>
    <div class=""row"">
        <div class=""col-12"">
            <div class=""card"">
                <div class=""card-body"">
                    <div class=""page-aside-left p-0"">
                        <button onclick=""reloadPagination()"" type=""button"" class=""btn btn-block btn-primary""><i class=""mdi mdi-refresh font-16 mr-1""></i>Làm mới dữ liệu</button>
                        <div class=""mt-4"">
                            <h5 class=""text-primary"">Tìm kiếm</h5>
                            <div class=""form-group"">
                                <input id=""ipt-text-search"" type=""text"" class=""form-control"" placeholder=""Tìm tên, email, điện thoại..."" autocomplete=""off"" />
                            </div>
                        </div>
                        <hr />
           ");
            WriteLiteral(@"             <div class=""mt-1"">
                            <h5 class=""text-primary"">Ngày gửi</h5>
                            <div class=""form-group"">
                                <input id=""ipt-date-search"" type=""text"" class=""form-control"" data-toggle=""date-range-picker"" placeholder=""Chọn ngày..."" autocomplete=""off"" />
                            </div>
                        </div>
                        <hr />
                        <div class=""mt-1"">
                            <h5 class=""text-primary"">Số lượng thông tin </h5>
                            <div class=""form-group"">
                                <select id=""sel-record-search"" class=""form-control"" data-toggle=""select-no-search"">
                                    <option value=""20"">20 thông tin</option>
                                    <option value=""30"">30 thông tin</option>
                                    <option value=""50"">50 thông tin</option>

                                </select>
                     ");
            WriteLiteral(@"       </div>
                        </div>
                    </div>
                    <div class=""page-aside-right"">
                        <div class=""table-responsive"">
                            <table class=""table table-hover table-centered text-center"">
                                <thead>
                                    <tr>
                                        <th class=""text-center px-w-50"">#</th>
                                        <th class=""text-left"">Tên Khách Hàng</th>
                                        <th class=""text-left"">Địa Chỉ</th>
                                        <th class=""text-left"">Email</th>
                                        <th>Số Điện Thoại</th>
                                        <th>Nội Dung</th>
                                        <th>Tình Trạng</th>
                                    </tr>
                                </thead>
                                <tbody id=""tbl-contact"" class=""cursor-pointer"">
     ");
            WriteLiteral(@"                           </tbody>
                            </table>
                        </div>
                        <div class=""row"">
                            <div id=""div-pagination-info"" class=""col-6 mt-2""></div>
                            <div class=""col-6""><div id=""div-pagination-selection"" class=""float-right mb-3 mt-1""></div></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

");
#nullable restore
#line 84 "D:\eCommerce\eCommerce.Web\Areas\Admin\Views\Contact\Index.cshtml"
Write(await Html.PartialAsync("ViewPartial"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $(function () {
            reloadPagination()
            let Day = $(""#ipt-date-search"").val()
            StartDay = Day.slice(0, 10)
            EndDay = Day.slice(13)
        })
        var PAGE_INDEX = 0;
        let StartDay;
        let EndDay;
        let Record = $('#sel-record-search').val();

        $('#ipt-date-search').change(function () {
            let Day = $(""#ipt-date-search"").val()
            StartDay = Day.slice(0, 10)
            EndDay = Day.slice(13)

            delay(function () {
                reloadPagination();
            }, 250);
        });

        $('#sel-record-search').change(function () {
            Record = $('#sel-record-search').val()
            delay(function () {
                reloadPagination();
            }, 250);
        });

        //search
        $(""#ipt-text-search"").keyup(function () {
            delay(function () {
                reloadPagination();
            }, 250);
        });

     ");
                WriteLiteral(@"   /** Binding event search */
        $('#ipt-text-search').keyup(function () {
            delay(function () {
                reloadPagination();
            }, 250);
        });
        /** Binding event change date */
        $('#ipt-date-search').on('change', function () {
            let value = $(this).val();
            let dateArray = value.split(' - ');
            FROM_DATE = dateArray[0];
            TO_DATE = dateArray[1];
            reloadPagination();
        })
        /** Reload pagination */
        function reloadPagination() {
            $('#div-pagination-selection').twbsPagination('destroy');
            initPagination();
        }
        /** Get pagination */
        function initPagination() {
            let d = {
                keyword: $('#ipt-text-search').val(),
                fromDate: StartDay,
                toDate: EndDay,
                pageItem: Record,
                pageIndex: PAGE_INDEX
            };
            ajaxGet('Contact', d, ");
                WriteLiteral(@"function (data) {
                if (data.IsSuccess) {
                    let totalPage = data.Result.TotalPage;
                    let totalRow = data.Result.TotalRow;
                    if (totalPage == 0) {
                        renderTable([]);
                    } else if (totalPage > 0) {

                        $('#div-pagination-selection').twbsPagination({
                            totalPages: totalPage,
                            visiblePages: 5,
                            initiateStartPageClick: true,
                            hideOnlyOnePage: totalRow < d.pageItem ? true : false,
                            paginationClass: 'pagination pagination-rounded',
                            first: '←',
                            last: '→',
                            prev: '«',
                            next: '»',
                            onPageClick: function (event, page) {
                                d.pageIndex = page;
                                ajaxGe");
                WriteLiteral(@"t('Contact', d, function (res) {
                                    if (res.IsSuccess) {
                                        renderTable(res.Result, d.pageItem, page, data.Result.TotalRow);
                                    }
                                    else {
                                        alertify.error(res.Message);
                                    }
                                });
                            }
                        });
                    } else {
                        $('#div-pagination-selection').empty();
                    }
                }
                else {
                    alertify.alert(data.Message);
                }

            });
        }
        /** Render table */
        function renderTable(data, pageItem, pageIndex, totalRow) {
            let html = """";
            $.each(data.Data, function (index, item) {
                html += `
                                <tr onclick=""viewContact(${item.Id}");
                WriteLiteral(@")"">
                                    <td>${index + 1}</td>
                                    <td class=""text-left"">${getEmptyOrDefault(item.CustomerName)}</td>
                                    <td class=""text-left"">${getEmptyOrDefault(item.Address)}</td>
                                    <td class=""text-left"">${getEmptyOrDefault(item.Email)}</td>
                                    <td>${item.Phone}</td>
                                    <td><div class=""text-TailTruncation""><span>${item.Content}</span></div></td>
                                    <td>${item.Status === 0 ? '<span class=""badge badge-danger"">Chưa liên hệ</span>' : '<span class=""badge badge-success"">Đã liên hệ</span>'}</td>
                                </tr>
                            `
            })
            let $table = $(""#tbl-contact"");
            if (html == '') {
                $table.html(htmlEmptyTable(7));
                $('#div-pagination-info').empty();
            } else {
                $tabl");
                WriteLiteral(@"e.html(html)
                let count = data.Data.length;
                let start = (pageIndex - 1) * pageItem + 1;
                let end = start + count - 1;
                $('#div-pagination-info').html(`Đang xem <b>${(count == 0 ? 0 : start)}</b> - <b>${end}</b> trong <b>${totalRow}</b> thông tin`);
            }
        }
        /** View contact */
        function viewContact(id) {
            //load cập nhật hay chưa cập nhật
            ajaxGet(`Contact/${id}`, {}, function (res) {
                $('#status_edit').val(res.Result.Status).trigger('change');
            }, function (err) {
            })
            //nút update
            $(""#btn-edit-branch"").attr('onclick', `update(${id})`);
            //nút detle
            $(""#btn-delete-branch"").attr('onclick', `detele(${id})`);
            //load data-edit
            ajaxGet(`contact/${id}`, {}, function (res) {
                if (res.IsSuccess) {

                    let item = res.Result;
                    $(");
                WriteLiteral(@"'#ipt-name').val(item.CustomerName);
                    $('#ipt-date').val(item.CreatedDate);
                    $('#ipt-phone').val(item.Phone);
                    $('#ipt-email').val(item.Email);
                    $('#ipt-address').val(item.Address);
                    $('#ipt-content').val(item.Content);
                    $('#ipt-note').val(item.Note)
                    showModal('#modal-view-contact');
                } else {
                    alertify.alert(res.Message);
                }
            }, 'json');
        }
        //update data
        function update(id) {
            let status = Number($(""#status_edit"").val())
            let data = {
                Note: $('#ipt-note').val(),
                CustomerName: $('#ipt-name').val(),
                Phone: $('#ipt-phone').val(),
                Email: $('#ipt-email').val(),
                Address: $('#ipt-address').val(),
                Content: $('#ipt-content').val(),
            }
            ajaxPut");
                WriteLiteral(@"(`Contact/${id}`, data, function (res) {
             
                if (res.IsSuccess) {

                    ajaxPut(`Contact/Status/${id}?statusId=${status}`, {}, function (res) {
                        if (res.IsSuccess) {
                            $(""#btn-close-edit"").click()
                            reloadPagination()
                            alertify.success('Cập Nhật Thành Công');
                        }
                        else {
                            alertify.alert(res.Message);
                        }
                    })
                }
                else {
                    alertify.alert(res.Message)
                }
            })
        }
        /** detele data */
        function detele(id) {
            alertify.confirm(""Bạn có chắc xóa liên hệ này"",
                function () {
                    ajaxDelete(`Contact/${id}`, function (res) {

                        if (res.IsSuccess) {
                            alertify.succ");
                WriteLiteral(@"ess('Xóa thành công');
                            hideModal(""#modal-view-contact"")
                            reloadPagination()
                        }
                        else {
                            alertify.alert(res.Message)
                        }

                    })
                },
                function () {

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