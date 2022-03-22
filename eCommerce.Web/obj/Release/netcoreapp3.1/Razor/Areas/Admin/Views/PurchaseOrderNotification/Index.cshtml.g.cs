#pragma checksum "D:\eCommerce\eCommerce.Web\Areas\Admin\Views\PurchaseOrderNotification\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9c0ebcfbb29bf612b126301bfd5c5bfe02193478"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_PurchaseOrderNotification_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/PurchaseOrderNotification/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9c0ebcfbb29bf612b126301bfd5c5bfe02193478", @"/Areas/Admin/Views/PurchaseOrderNotification/Index.cshtml")]
    public class Areas_Admin_Views_PurchaseOrderNotification_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\eCommerce\eCommerce.Web\Areas\Admin\Views\PurchaseOrderNotification\Index.cshtml"
  
    ViewData["Title"] = "THÔNG BÁO ĐƠN ĐẶT HÀNG";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container-fluid"">
    <div class=""row"">
        <div class=""col-12"">
            <div class=""page-title-box"">
                <h4 class=""page-title"">Thông báo đơn đặt hàng</h4>
            </div>
        </div>
    </div>
    <div class=""row"">
        <div class=""col-12"">
            <div class=""card"">
                <div class=""card-body"">
                    <div class=""page-aside-left p-0"">
                        <button onclick=""getDataTable()"" type=""button"" class=""btn btn-block btn-primary""><i class=""mdi mdi-refresh font-16 mr-1""></i>Làm mới dữ liệu</button>
                        <!-- Search -->
                        <div class=""mt-4"">
                            <h5 class=""text-primary"">Tìm theo mã đặt hàng, tên khách hàng</h5>
                            <div class=""form-group"">
                                <input id=""ipt-text-search"" type=""text"" class=""form-control"" placeholder=""Tìm mã đơn hàng, tên khách hàng"" autocomplete=""off"" />
                           ");
            WriteLiteral(@" </div>
                        </div>
                        <hr />
                        <div class=""mt-4"">
                            <h5 class=""text-primary"">Thời gian</h5>
                            <div class=""form-group"">
                                <input id=""
                                       "" type=""text"" class=""form-control"" data-toggle=""date-range-picker"">
                            </div>
                        </div>
                        <hr />
                        <div class=""mt-2"">
                            <h5 class=""text-primary"">Số đơn hàng</h5>
                            <div class=""form-group"">
                                <select id=""sel-record-search"" class=""form-control"" data-toggle=""select-no-search"">
                                    <option value=""20"">20 đơn hàng</option>
                                    <option value=""30"">30 đơn hàng</option>
                                    <option value=""50"">50 đơn hàng</option>
              ");
            WriteLiteral(@"                      <option value=""100"">100 đơn hàng</option>
                                    <option value=""200"">200 đơn hàng</option>
                                </select>
                            </div>
                        </div>
                        <hr />
                        <div class=""mt-4"">
                            <h5 class=""text-primary"">Trạng thái</h5>
                            <div class=""form-group"">
                                <div class=""custom-control custom-radio"">
                                    <input type=""radio"" name=""status"" value=""all"" class=""custom-control-input order-status"" id=""status-all"" checked data-value=""0"">
                                    <label class=""custom-control-label"" for=""status-all"">Tất cả</label>
                                </div>
                                <div class=""custom-control custom-radio"">
                                    <input type=""radio"" name=""status"" value=""pen"" class=""custom-control-input");
            WriteLiteral(@" order-status"" id=""status-pending"" data-value=""1"">
                                    <label class=""custom-control-label"" for=""status-pending"">Chờ xử lý</label>
                                </div>
                                <div class=""custom-control custom-radio"">
                                    <input type=""radio"" name=""status"" value=""app"" class=""custom-control-input order-status"" id=""status-approved"" data-value=""2"">
                                    <label class=""custom-control-label"" for=""status-approved"">Đã duyệt</label>
                                </div>

                                <div class=""custom-control custom-radio"">
                                    <input type=""radio"" name=""status"" value=""sell"" class=""custom-control-input order-status"" id=""status-sell"" data-value=""3"">
                                    <label class=""custom-control-label"" for=""status-sell"">Đã bán</label>
                                </div>
                                <div class=""custo");
            WriteLiteral(@"m-control custom-radio"">
                                    <input type=""radio"" name=""status"" value=""cancel"" class=""custom-control-input order-status"" id=""status-cancel"" data-value=""4"">
                                    <label class=""custom-control-label"" for=""status-cancel"">Đã hủy</label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class=""page-aside-right"">
                        <!-- Table -->
                        <div class=""table-responsive"">
                            <table class=""table table-hover"">
                                <thead class=""thead-light"">
                                    <tr>
                                        <th>#</th>
                                        <th>Mã đơn hàng</th>
                                        <th>Tên khách hàng</th>
                                        <th>Tổng tiền</th>
                                      ");
            WriteLiteral(@"  <th>Trạng thái đơn hàng</th>
                                        <th>Thời gian đặt hàng</th>
                                    </tr>
                                </thead>
                                <tbody id=""tb-body"" class=""cursor-pointer"">
                                  
                                </tbody>
                            </table>
                        </div>
                        <div class=""row"">
                            <div id=""div-pagination-info"" class=""col-6 mt-2"">Đang xem <b>1</b> - <b>20</b> trong <b>20</b> đơn hàng</div>
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
#line 107 "D:\eCommerce\eCommerce.Web\Areas\Admin\Views\PurchaseOrderNotification\Index.cshtml"
Write(await Html.PartialAsync("DetailPartial"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $(function () {
            reloadPagination()
            loadStausOrder();
            //initSelectWard('#ipt-branch-add-ward, #ipt-branch-edit-ward');


            //search
            $(""#ipt-text-search"").keyup(function () {
                delay(function () {
                    reloadPagination();
                }, 250);
            });


            //status change
            $('.order-status').change(function () {
                let me = $(this);
                StatusId_ = me.data('value');
                delay(function () {
                    reloadPagination();
                }, 250);
            });

            //recordchagne
            $('#sel-record-search').change(function () {
                Record = $('#sel-record-search').val()
                delay(function () {
                    reloadPagination();
                }, 250);
            });

            $('#ipt-date-search').change(function () {
                let Day = $(");
                WriteLiteral(@"""#ipt-date-search"").val()
                StartDay = Day.slice(0, 10)
                EndDay = Day.slice(13)
                delay(function () {
                    reloadPagination();
                }, 250);
            });

            let Day = $(""#ipt-date-search"").val()
            StartDay = Day.slice(0, 10)
            EndDay = Day.slice(13)
            
        })

        //let PURCHASE_ORDER_NOTIFICATION = [];
        //let ROOT_ID = 0;
        //let TOTAL_ROW = 0;

        var PAGE_INDEX = 0;
        let StatusId_ = 0
        let StartDay;
        let EndDay;
        let Record = $('#sel-record-search').val();


        //renderStatus
        function renderStatus(status) {
            switch (status) {
                case 1:
                    return '<span class=""badge badge-warning-lighten"">Chờ xử lý</span>';
                    break;
                case 2:
                    return '<span class=""badge badge-info-lighten"">Đã duyệt</span>';
                 ");
                WriteLiteral(@"   break;
                case 3:
                    return '<span class=""badge badge-success-lighten"">Đã bán</span>';
                    break;
                case 4:
                    return '<span class=""badge badge-danger-lighten"">Đã hủy</span>';
                    break;
            }
        }



        //reloadPagination
        //function reloadPagination() {
        //    let key = $(""#ipt-text-search"").val();

        //    ajaxGet(`OrderNotification?keyword=${key}&pageItem=10&pageIndex=0&statusId=0`, {}, function (res) {
        //        console

        //        if (res.IsSuccess) {
        //            let html = """"
        //            let data = res.Result.Data;
        //            $.each(data, function (index, item) {
        //                html += `
        //                        <tr  onclick=""openModalDetail(${item.Id})"">
        //                                <td>${index + 1}</td>
        //                                <td><a href=""apps-eco");
                WriteLiteral(@"mmerce-orders-details.html"" class=""text-body font-weight-bold"">${item.Id}</a> </td>
        //                                <td>${item.Order.Customer.FullName}</td>
        //                                <td>${(item.Order.Total).toLocaleString('vi-vn')}VNĐ</td>
        //                                <td>${renderStatus(item.Order.Status)}</td>
        //                                <td>${item.Order.CreatedDate}</td>
        //                        </tr>
        //                `
        //            })
        //            if (html == '') {
        //                $(""#tb-body"").html(htmlEmptyTable(6));
        //            }
        //            else {
        //                $(""#tb-body"").html(html);

        //            }
        //        }
        //        else {
        //            alertify.alert(res.Message)
        //        }
             
        //    })
        //}



    

        /** Load root */
        function loadStausOrder() {
         ");
                WriteLiteral(@"   $.post('/Root/SelectDropdown', {}, function (data) {
                if (data.IsSuccess) {
                    let html = `
                                        <div class=""custom-control custom-radio mt-2 div-role"">
                                            <input data-id=""0"" id=""rdb-role-0"" type=""radio"" name=""search-root"" class=""custom-control-input"" checked>
                                            <label class=""custom-control-label cursor-pointer"" for=""rdb-role-0"">Tất cả</label>
                                        </div>
                                    `;
                    let htmlOption = '';
                    $.each(data.Result, function (index, item) {
                        html += `
                                            <div class=""custom-control custom-radio mt-2 div-role"">
                                                <input data-id=""${item.RootId}"" id=""rdb-role-${item.RootId}"" type=""radio"" name=""search-root"" class=""custom-control-input"">
               ");
                WriteLiteral(@"                                 <label class=""custom-control-label cursor-pointer"" for=""rdb-role-${item.RootId}"">${item.RootName} <span class=""text-muted""> (${item.CountBranch})</span></label>
                                            </div>
                                        `;
                        htmlOption += `<option value=""${item.RootId}"">${item.RootName}</option>`;
                    })
                    let $div = $('#div-filter-root');
                    $div.html(html);
                    $('#sel-branch-add-root, #sel-branch-edit-root').html(htmlOption);

                    /** Binding on change search root */
                    $div.find('input[type=radio]').change(function () {
                        ROOT_ID = $(this).attr('data-id');
                        loadTable();
                    });
                } else {
                    alertify.alert(data.Message);
                }
            }, ""json"");
        }

        /** Load table */
        func");
                WriteLiteral(@"tion reloadPagination() {
            $('#div-pagination-selection').twbsPagination('destroy');
            initPagination();
        }

        /** init Pagination */
        function initPagination() {
        
            let d = {
                keyword: $('#ipt-text-search').val(),
                fromDate:StartDay ,
                toDate: EndDay,
                pageItem: Record,
                pageIndex: PAGE_INDEX,
                statusId: StatusId_
            };


            ajaxGet('OrderNotification', d, function (data) {
                if (data.IsSuccess) {
                    let totalPage = data.Result.TotalPage;
                    let totalRow = data.Result.TotalRow;

                    if (totalPage == 0) {
                        renderTable([]);
                        return;
                    } else if (totalPage > 0) {
                        $('#div-pagination-selection').twbsPagination({
                            totalPages: totalPage,
         ");
                WriteLiteral(@"                   visiblePages: 5,
                            initiateStartPageClick: true,
                            hideOnlyOnePage: totalRow < d.pageItem ? true : false,
                            paginationClass: 'pagination pagination-rounded',
                            first: '←',
                            last: '→',
                            prev: '«',
                            next: '»',
                            onPageClick: function (event, page) {
                                d.pageIndex = page;
                                ajaxGet('OrderNotification', d, function (res) {
                                    if (res.IsSuccess) {
                                        renderTable(res.Result, d.pageItem, page, data.Result.TotalRow);
                                    } else {
                                        alertify.error(res.Message);
                                    }
                                })
                            }
                ");
                WriteLiteral(@"        });
                    } else {
                        $('#div-pagination-selection').empty();
                    }
                } else {
                    alertify.alert(data.Message);
                }
            });


        }

        /** Render table */
        function renderTable(data, pageItem, pageIndex, totalRow) {
            let html = """";
            $.each(data.Data, function (index, item) {

                html += `
                        <tr onclick=""openModalDetail(${item.Id})"">
                            <td>${index + 1}</td>
                            <td><a href=""apps-ecommerce-orders-details.html"" class=""text-body font-weight-bold"">${item.Id}</a> </td>
                            <td>${item.Order.Customer.FullName}</td>
                            <td>${item.Order.Total}</td>
                            <td>${renderStatus(item.Order.Status)}</td>
                            <td class=""font-weight-bold"">${item.Order.CreatedDate}</td>
         ");
                WriteLiteral(@"               </tr>`;
            })
            let $tbl = $(""#tb-body"");
            if (html == '') {
                $tbl.html(htmlEmptyTable(7));
                $('#div-pagination-info').empty();
            } else {
                $tbl.html(html);
                /** Render pagination des */
                let count = data.Data.length;
                let start = (pageIndex - 1) * pageItem + 1;
                let end = start + count - 1;
                $('#div-pagination-info').html(`Đang xem <b>${(count == 0 ? 0 : start)}</b> - <b>${end}</b> trong <b>${totalRow}</b> đơn hàng`);
            }
        }



        /**
         * Open modal detail
         * Param: id = BranchId
         */
        function openModalDetail(id) {
            $('#modal-detail-purchase-order-notification').modal({ backdrop: 'static' });


            $.post('/Branch/SelectEdit', { BranchId: id }, function (data) {
                if (data.IsSuccess) {
                    $.each(data.Result, ");
                WriteLiteral(@"function (index, item) {
                        $('#ipt-branch-edit-code').val(item.BranchCode);
                        $('#ipt-branch-edit-name').val(item.BranchName);
                        $('#ipt-branch-edit-address').val(item.BranchAddress);
                        $('#ipt-branch-edit-ward').html(`<option value=${item.WardId}>${item.WardName}</option>`).trigger('change');
                        $('#sel-branch-edit-root').val(item.RootId).trigger('change');
                        return;
                    })
                    $('#btn-edit-branch').attr('onclick', `updateBranch(${id})`);
                    $('#btn-delete-branch').attr('onclick', `deleteBranch(${id})`);
                    $('#modal-edit-branch').modal({ backdrop: 'static' });
                } else {
                    alertify.alert(data.Message);
                }
            }, 'json')
        }

        /**
         * Update Branch
         * Param: id = BranchId
         */
        function updateBranch");
                WriteLiteral(@"(id) {
            let code = $('#ipt-branch-edit-code').val();
            let address = $('#ipt-branch-edit-address').val();
            let name = $('#ipt-branch-edit-name').val();
            let ward = $('#ipt-branch-edit-ward').val();
            let root = $('#sel-branch-edit-root').find('option:selected').val();
            if (name == '') {
                alertify.alert('Tên chi nhánh không được để trống')
            } else if (code == '') {
                alertify.alert('Mã chi nhánh không được để trống')
            } else if (address == '') {
                alertify.alert('Địa chỉ chi nhánh không được để trống')
            } else if (ward == null) {
                alertify.alert('Phường/Xã/Thị Trấn chi nhánh không được để trống')
            } else {
                let d = {
                    BranchId: id,
                    BranchCode: code,
                    RootId: root,
                    BranchName: name,
                    BranchAddress: address,
          ");
                WriteLiteral(@"          WardId: ward
                }
                $.post('/Branch/Update', d, function (data) {
                    if (data.IsSuccess) {
                        loadTable();
                        $('#modal-edit-branch').modal('hide');
                        alertify.success('Cập nhật chi nhánh thành công');
                    } else {
                        alertify.alert(data.Message);
                    }
                }, 'json');
            }
        }

        /**
         * Delete Branch
         * Param: id = BranchId
         */
        function deleteBranch(id) {
            alertify.confirm('Bạn có chắc chắn muốn xoá chi nhánh này', function () {
                $.post('/Branch/Delete', { BranchId: id }, function (data) {
                    if (data.IsSuccess) {
                        loadTable();
                        $('#modal-edit-branch').modal('hide');
                        alertify.success('Xoá chi nhánh thành công');
                    } else {");
                WriteLiteral(@"
                        alertify.alert(data.Message);
                    }
                }, 'json');
            });
        }


        /** Open modal Import Branch */
        function openModalImport() {
            let $modal = $('#modal-import');
            $modal.find('#tbdExcel').html(htmlEmptyTable(7));;
            $modal.modal({ backdrop: 'static' });
        }

        /** Import Branch */
        function importExcel() {
            let $table = $('#tbdExcel');
            if ($table.find('.bg-warning').length > 0) {
                alertify.error('File tải lên đã bị lỗi, những ô có thể bị lỗi sẽ tô màu vàng. Vui lòng kiểm tra lại.')
                $('#btnSaveImport').removeAttr('onclick').attr('disabled', true);
            } else {
                alertify.confirm('Bạn có chắc chán muốn thêm những nhóm sản phẩm này không?', function () {
                    let arr = [];

                    $table.find('tr').each(function () {
                        let $td = $(th");
                WriteLiteral(@"is).find('td');
                        arr.push({
                            BranchCode: $td.eq(1).text().trim(),
                            BranchName: $td.eq(2).text().trim(),
                            RootId: $td.eq(3).text().trim(),
                            BranchAddress: $td.eq(4).text().trim(),
                            WardName: $td.eq(5).text().trim()
                        });
                    });

                    $.post('/Branch/Import', { TableImport: JSON.stringify(arr) }, function (data) {
                        if (data.IsSuccess) {
                            alertify.success('Import nhóm sản phẩm thành công');
                            $('#modal-import').modal('hide');
                            loadTable();
                            console.table(data.Result);
                        } else {
                            alertify.error(data.Message);
                        }
                    })
                });
            }
        }


");
                WriteLiteral("\n    </script>\r\n");
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
