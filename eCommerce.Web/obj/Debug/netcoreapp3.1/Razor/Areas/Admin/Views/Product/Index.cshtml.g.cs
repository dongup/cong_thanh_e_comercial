#pragma checksum "D:\eCommerce\eCommerce.Web\Areas\Admin\Views\Product\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4ebba10dea374fc2f9edd07d8e7be886081b5a4d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Product_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Product/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ebba10dea374fc2f9edd07d8e7be886081b5a4d", @"/Areas/Admin/Views/Product/Index.cshtml")]
    public class Areas_Admin_Views_Product_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\eCommerce\eCommerce.Web\Areas\Admin\Views\Product\Index.cshtml"
  
    ViewData["Title"] = "QUẢN LÝ SẢN PHẨM";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container-fluid"">
    <div class=""row"">
        <div class=""col-12"">
            <div class=""page-title-box"">
                <div class=""page-title-right"">
                    <a href=""/admin/product/ExportExcel"" class=""btn btn-primary"">
                        <i class=""mdi mdi mdi-file-export font-16 mr-1""></i>Export Excel
                    </a>
                    <a href=""/admin/product/add"" class=""btn btn-primary""><i class=""mdi mdi-plus-circle font-16 mr-1""></i>Thêm mới sản phẩm</a>
                </div>
                <h4 class=""page-title"">Quản lý sản phẩm</h4>
            </div>
        </div>
    </div>
    <div class=""row"">
        <div class=""col-12"">
            <div class=""card"">
                <div class=""card-body"">
                    <div class=""page-aside-left p-0"">
                        <button onclick=""getDataTable()"" type=""button"" class=""btn btn-block btn-primary""><i class=""mdi mdi-refresh font-16 mr-1""></i>Làm mới dữ liệu</button>
               ");
            WriteLiteral(@"         <div class=""mt-4"">
                            <h5 class=""text-primary"">Tìm kiếm</h5>
                            <div class=""form-group"">
                                <input id=""ipt-text-search"" type=""text"" class=""form-control"" placeholder=""Tìm theo tên, mã sản phẩm..."" autocomplete=""off"" />
                            </div>
                        </div>
                        <hr />

                        <div class=""mt-2"">
                            <h5 class=""text-primary"">Danh mục</h5>
                            <div class=""form-group"">
                                <select name=""CategoryId"" id=""sl-category"" class=""select"" data-toggle=""select"">
                                    <option value=""0"">Tất cả</option>
                                </select>

                            </div>
                        </div>
                        <hr />

                        <div class=""mt-2"">
                            <h5 class=""text-primary"">Trạng thái</h5>
 ");
            WriteLiteral("                           <div class=\"form-group\">\r\n                                <select");
            BeginWriteAttribute("name", " name=\"", 2253, "\"", 2260, 0);
            EndWriteAttribute();
            WriteLiteral(@" id=""sl-status"" class=""select"" data-toggle=""select-no-search"">
                                    <option value=""100"">Tất cả</option>
                                    <option selected value=""1"">Đang bán</option>
                                    <option value=""0"">Đã dừng bán</option>
                                </select>

                            </div>
                        </div>
                        <hr />
                        <div class=""mt-2"">
                            <h5 class=""text-primary"">Thương hiệu</h5>
                            <div class=""form-group"">
                                <select class=""form-control"" id=""sl-brand"" data-toggle=""select"">
                                    <option value=""0""> Tất cả</option>
                                </select>
                            </div>
                        </div>
                        <hr />
                        <div class=""mt-2"">
                            <h5 class=""text-primary"">Sắp s");
            WriteLiteral(@"ếp</h5>
                            <select class=""form-control"" data-toggle=""select-no-search"" id=""sl-sort"">
                                <option value=""1"">Giá niêm yết tăng dần</option>
                                <option value=""2"">Giá niêm yết giảm dần</option>
                                <option value=""3"">Giá bán lẻ tăng dần</option>
                                <option value=""4"">Giá bán lẻ giảm dần</option>
                                <option value=""5"">Lượt truy cập tăng dần</option>
                                <option selected value=""6"">Lượt truy cập giảm dần</option>
                            </select>
                        </div>
                        <hr />
                        <div class=""mt-2"" id=""divFilterPrice"">
                            <h5 class=""text-primary"">Giá bán lẻ</h5>
                            <div class=""custom-control custom-radio mt-1"">
                                <input name=""sts"" type=""radio"" value=""0,999999999"" id=""checkmeout"" c");
            WriteLiteral(@"lass=""custom-control-input"" checked>
                                <label class=""custom-control-label"" for=""checkmeout"">Tất cả</label>
                            </div>
                            <div class=""custom-control custom-radio mt-1"">
                                <input name=""sts"" type=""radio"" value=""0,500000"" id=""checkmeout2"" class=""custom-control-input"">
                                <label class=""custom-control-label"" for=""checkmeout2"">Dưới 500.000đ</label>
                            </div>
                            <div class=""custom-control custom-radio mt-1"">
                                <input name=""sts"" type=""radio"" value=""500000,1000000"" id=""checkmeout3"" class=""custom-control-input"">
                                <label class=""custom-control-label"" for=""checkmeout3"">Từ 500.000đ - 1.000.000đ</label>
                            </div>
                            <div class=""custom-control custom-radio mt-1"">
                                <input name=""sts"" type=""ra");
            WriteLiteral(@"dio"" value=""1000000,2000000"" id=""checkmeout4"" class=""custom-control-input"">
                                <label class=""custom-control-label"" for=""checkmeout4"">Từ 1.000.000đ - 2.000.000đ</label>
                            </div>
                            <div class=""custom-control custom-radio mt-1"">
                                <input name=""sts"" type=""radio"" value=""2000000,3000000"" id=""checkmeout6"" class=""custom-control-input"">
                                <label class=""custom-control-label"" for=""checkmeout6"">Từ 2.000.000đ - 3.000.000đ</label>
                            </div>
                            <div class=""custom-control custom-radio mt-1"">
                                <input name=""sts"" type=""radio"" value=""3000000,5000000"" id=""checkmeout7"" class=""custom-control-input"">
                                <label class=""custom-control-label"" for=""checkmeout7"">Từ 3.000.000đ - 5.000.000đ</label>
                            </div>
                            <div class=""custom-cont");
            WriteLiteral(@"rol custom-radio align-content-end mt-1"">
                                <input name=""sts"" type=""radio"" value=""5000000,999999999"" id=""checkmeout8"" class=""custom-control-input"">
                                <label class=""custom-control-label"" for=""checkmeout8"">Trên 5.000.000đ</label>
                            </div>
                        </div>
                        <hr />
                        <div class=""mt-2"">
                            <h5 class=""text-primary"">Số sản phẩm hiển thị</h5>
                            <div class=""form-group"">
                                <select id=""sel-record-search"" class=""form-control"" data-toggle=""select-no-search"">
                                    <option value=""20"">20 sản phẩm</option>
                                    <option value=""30"">30 sản phẩm</option>
                                    <option value=""50"">50 sản phẩm</option>
                                    <option value=""100"">100 sản phẩm</option>
                            ");
            WriteLiteral(@"        <option value=""200"">200 sản phẩm</option>
                                </select>
                            </div>
                        </div>
                    </div>
                    <div class=""page-aside-right"">
                        <p>Tổng sản phẩm: <span class=""text-primary"" id=""total-product"">0</span> sản phẩm</p>
                        <div class=""table-responsive"">
                            <table id=""btn-product"" class=""table table-hover table-centered"">
                                <thead>
                                    <tr>
                                        <th class=""text-center px-w-50"">#</th>
                                        <th>Mã sản phẩm</th>
                                        <th style=""width:33%;"">Tên sản phẩm</th>
                                        <th");
            BeginWriteAttribute("class", " class=\"", 8235, "\"", 8243, 0);
            EndWriteAttribute();
            WriteLiteral(">Danh mục</th>\r\n                                        <th");
            BeginWriteAttribute("class", " class=\"", 8303, "\"", 8311, 0);
            EndWriteAttribute();
            WriteLiteral(@">Thương hiệu</th>
                                        <th>Xuất xứ</th>
                                        <th>Tình trạng</th>
                                        <th class=""text-right"">Tồn kho</th>
                                        <th class=""money"">Giá niêm yết</th>
                                        <th class=""money"">Giá bán lẻ</th>
                                        <th class=""money"">Giá sau khuyến mãi</th>
                                        <th");
            BeginWriteAttribute("class", " class=\"", 8805, "\"", 8813, 0);
            EndWriteAttribute();
            WriteLiteral(@">Lượt truy cập</th>
                                        <th class=""text-center px-w-50""></th>
                                    </tr>
                                </thead>
                                <tbody id=""tbl-body"">
                                </tbody>
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
<!--  Modal thêm giá trị thuộc tính -->
<div class=""modal fade"" id=""modal-update-price"">
    <div class=""modal-dialog modal-lg"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h4 class=""modal-title"">Cập nhật giá</h4>
          ");
            WriteLiteral(@"      <button type=""button"" class=""close"" data-dismiss=""modal"" aria-hidden=""true"">×</button>
            </div>
            <div class=""modal-body"">
                <div class=""row"">
                    <div class=""col-lg-12"">
                        <div class=""col-md-12"">
                            <div class=""form-group"">
                                <label>Giá niêm yết<span class=""text-danger""> &nbsp;* </span></label>
                                <input type=""text"" id=""ipt-gia-niem-yet"" class=""form-control"" min=""0"" value=""0"" name=""giaBan"" data-toggle=""autonumeric-money""");
            BeginWriteAttribute("placeholder", " placeholder=\"", 10433, "\"", 10447, 0);
            EndWriteAttribute();
            WriteLiteral(@" />
                            </div>
                        </div>
                        <div class=""col-md-12"">
                            <div class=""form-group"">
                                <label>Giá bản lẻ<span class=""text-danger""> &nbsp;* </span></label>
                                <input type=""text"" id=""ipt-gia-ban-le"" class=""form-control"" min=""0"" value=""0"" name=""giaBan"" data-toggle=""autonumeric-money""");
            BeginWriteAttribute("placeholder", " placeholder=\"", 10880, "\"", 10894, 0);
            EndWriteAttribute();
            WriteLiteral(@" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class=""modal-footer"">
                    <button id=""btn-update-price"" type=""button"" class=""btn btn-primary"">Cập nhật</button>
                    <button type=""button"" class=""btn btn-light"" data-dismiss=""modal"">Đóng</button>
                </div>
            </div>
        </div>
    </div>
</div>
<!--  Modal thêm tồn kho -->
<div class=""modal fade"" id=""modal-update-stock"">
    <div class=""modal-dialog modal-lg"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h4 class=""modal-title"">Cập nhật số lượng tồn</h4>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-hidden=""true"">×</button>
            </div>
            <div class=""modal-body"">
                <div class=""row"">
                    <div class=""col-lg-12"">
                        <div class=""form-group mb-3"">
     ");
            WriteLiteral(@"                       <label for=""ipt-value""> Nhập số tồn <span class=""text-danger""> &nbsp;* </span><span id=""modal-label""></span></label>
                            <div class=""input-group"">
                                <input type=""text"" id=""ipt-tock-new"" class=""form-control"" min=""0"" value=""0"" name=""giaBan"" data-toggle=""autonumeric-money""");
            BeginWriteAttribute("placeholder", " placeholder=\"", 12268, "\"", 12282, 0);
            EndWriteAttribute();
            WriteLiteral(@" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""modal-footer"">
                <button id=""btn-update-stock"" type=""button"" class=""btn btn-primary"">Cập nhật</button>
                <button type=""button"" class=""btn btn-light"" data-dismiss=""modal"">Đóng</button>
            </div>
        </div>
    </div>
</div>

");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script>
        var PAGE_INDEX = 1;

        $(document).ready(function () {
            initProductCategory(""#sl-category"", true);
            initProductBrand(""#sl-brand"", true);
            reloadPagination();

        })

        /** Binding event search */
        $('#ipt-text-search').keyup(function () {
            delay(function () {
                reloadPagination();
            }, 250);
        });

        /** Select brand */
        $('#sl-brand,#sl-status, #sel-record-search, #sl-category, #sl-sort, input[name=""sts""]').on('change', function () {
            reloadPagination();
        })



        /** Reload pagination */
        function reloadPagination() {
            $('#div-pagination-selection').twbsPagination('destroy');
            initPagination();
        }
        /** init Pagination */
        function initPagination() {
            let keyword = $('#ipt-text-search').val();
            let pageItem = $('#sel-record-search').find('option:select");
                WriteLiteral(@"ed').val();
            let SortBy = parseInt($('#sl-sort').val());
            let brandId = parseInt(IsNullOrEmpty($('#sl-brand').val()) ? 0 : $('#sl-brand').val());
            let categoryId = $('#sl-category').val();
            let values = $('#divFilterPrice').find('input:checked').val();
            let arr = values.split(',');
            let min = parseInt(arr[0]);
            let max = parseInt(arr[1]);
            let FromPrice = min;
            let ToPrice = max;

            let d = {
                keyword: keyword,
                BrandId: brandId == null ? 0 : brandId,
                PageItem: pageItem,
                CategoryUrl: '',
                CategoryId: categoryId,
                FromPrice: FromPrice,
                ToPrice: ToPrice,
                sortOrder: SortBy,
                status: $(""#sl-status"").val()
            };


            ajaxGet('product/admin', d, function (data) {
                if (data.IsSuccess) {
                    let tota");
                WriteLiteral(@"lPage = data.Result.TotalPage;
                    if (totalPage == 0) {
                        renderTable([]);
                        return;
                    } else if (totalPage > 0) {
                        $('#div-pagination-selection').twbsPagination({
                            totalPages: totalPage,
                            visiblePages: 5,
                            initiateStartPageClick: true,
                            hideOnlyOnePage: true,
                            paginationClass: 'pagination pagination-rounded',
                            first: '←',
                            last: '→',
                            prev: '«',
                            next: '»',
                            onPageClick: function (event, page) {
                                PAGE_INDEX = page;
                                d.PageIndex = PAGE_INDEX;
                                ajaxGet('product/admin', d, function (res) {
                                    if (res.IsS");
                WriteLiteral(@"uccess) {
                                        renderTable(res.Result, pageItem, page, data.Result.TotalRow);
                                    } else {
                                        alertify.alert(res.Message);
                                    }
                                })
                            }
                        });
                    } else {
                        $('#div-pagination-selection').empty();
                    }
                } else {
                    alertify.alert(data.Message);
                }
            });

        }

        function generateCategory(categories) {
            if (categories == undefined) {
                return `<span class=""badge badge-primary"">Không có danh mục</span>`;
            } else
                return categories.map(n => `<span class=""badge badge-primary"">${n.CategoryName}</span>`)
        }

        /**
         * Update OriginPrice and SaleOffPrice
         * id= ProductID
       ");
                WriteLiteral(@"  */
        function UpdateProductPrice(id) {
            console.log(""clicked"");
            let giaNiemYet = parseInt($('#ipt-gia-niem-yet').val().replace(/,/g, ''));
            let giaBanLe = parseInt($('#ipt-gia-ban-le').val().replace(/,/g, ''));
            ajaxPut('product/Price/' + id, { productId: id, OriginPrice: giaNiemYet, GiaBanLe: giaBanLe }, function (res) {
                if (res.IsSuccess) {
                    reloadPagination();
                    alertify.success(""Cập nhật giá thành công"");
                    hideModal('#modal-update-price');
                } else {
                    alertify.alert(res.Message);
                }
            });
        }

        /** Render table */
        function renderTable(data, pageItem, pageIndex, totalRow) {
            let html = """"
            let sttStart = (pageIndex - 1) * pageItem + 1;
            $.each(data.Data, function (index, item) {
                let stt = sttStart + index;
                html += `
   ");
                WriteLiteral(@"                         <tr>
                            <td class=""text-center"">${stt}</td>
                            <td>${item.ProductCode}</td>
                            <td>
                                <div class=""row"">
                                    <div class=""col-md-8"">${item.ProductName}</div>
                                </div>
                            </td>
                            <td class=""text-left"">${generateCategory(item.ProductCategories)}</td>
                            <td class=""text-left"">${item.ProductBrand.BrandName}</td>
                            <td>${getEmptyOrDefault(item.Origin)}</td>
                            <td><span class=""badge badge-${item.Status ? ""primary-lighten"" : ""danger-lighten""}"">${item.Status ? ""Đang bán"" : ""Dừng bán""}</span></td>
                            <td class=""text-right"">${item.StockNumber}</td>
                            <td class=""money"">${formatMoney(item.OriginPrice)}</td>
                            <td class=");
                WriteLiteral(@"""money"">${formatMoney(item.GiaBanLe)}</td>
                            <td class=""money"">${formatMoney(item.SaleOffPrice)}</td>
                            <td class=""text-right"">${item.AccessCount}</td>
                            <td class=""text-center px-w-50"">
                                <div class=""dropdown"">
                                    <a class=""dropdown-toggle text-muted arrow-none cursor-pointer"" data-toggle=""dropdown""><i
                                            class=""mdi mdi-dots-vertical font-18 text-primary""></i></a>
                                    <div class=""dropdown-menu dropdown-menu-right"">
                                        <a href=""/admin/product/detail/${item.Id}"" class=""a-detail dropdown-item cursor-pointer""><i
                                                class=""mdi mdi-window-restore mr-1""></i>Xem chi tiết</a>
                                        <a href=""/admin/product/edit/${item.Id}"" class=""a-detail dropdown-item cursor-pointer""><i
            ");
                WriteLiteral(@"                                    class=""mdi mdi-export mr-1""></i>Cập nhật sản phẩm</a>
                                        <a onclick=""showModalPrice(${item.Id},${item.OriginPrice},${item.GiaBanLe})""
                                            class=""a-delete dropdown-item cursor-pointer""><i class=""mdi mdi-cash-plus mr-1""></i>Cập nhật giá</a>
                                        <a onclick=""showModalStock(${item.Id},${item.StockNumber})""
                                            class=""a-delete dropdown-item cursor-pointer""><i class=""mdi mdi-cart-plus mr-1""></i>Cập nhật tồn</a>
                                        <a onclick=""ToggleStatus(${item.Id},${item.Status ? false : true})"" class=""a-delete dropdown-item cursor-pointer""><i
                                                                                            class=""mdi mdi-toggle-switch mr-1""></i>${item.Status ? ""Dừng bán"" : ""Mở bán""}</a>
                                        <a onclick=""showDelete(${item.Id})"" class=""a-dele");
                WriteLiteral(@"te dropdown-item cursor-pointer""><i
                                                                                            class=""mdi mdi-trash-can-outline mr-1""></i>Xóa sản phẩm</a>
                                    </div>
                                </div>
                            </td>
                        </tr>
`
            })
            if (html == '') {
                $(""#tbl-body"").html(htmlEmptyTableAuto('#btn-product'));
            }
            else {
                $(""#tbl-body"").html(html)
            }

            let $tblBody = $('#tbl-body');
            if (html == '') {
                $tblBody.html(htmlEmptyTableAuto('#btn-product'));
                $('#div-pagination-info').empty();
            } else {
                $tblBody.html(html);

                /** Render pagination des */
                let count = Object.keys(data).length;
                let start = (pageIndex - 1) * pageItem + 1;
                let end = parseInt(start) + pa");
                WriteLiteral(@"rseInt(pageItem) - 1;
                $('#div-pagination-info').html(`Đang xem <b>${(count == 0 ? 0 : start)}</b> - <b>${end}</b> trong <b>${totalRow}</b> sản phẩm`);
                $('#total-product').text(totalRow);
            }
        }

        /** Show Modal Cập nhập giá */
        function showModalPrice(id, originPrice, saleOfPrice) {
            $('#ipt-gia-niem-yet').val(formatMoney(originPrice))
            $('#ipt-gia-ban-le').val(formatMoney(saleOfPrice))
            showModal('#modal-update-price');
            $('#btn-update-price ').attr('onClick', `UpdateProductPrice(${id})`);
        }

        /** Cập nhật số tồn  */
        function showModalStock(id, oldStock) {
            $('#ipt-tock-new').val(oldStock)
            showModal('#modal-update-stock');
            $('#btn-update-stock').unbind().on('click', function () {
                let newStock = parseInt($('#ipt-tock-new').val().replace(',', ''));
                ajaxPut('product/StockNumber/' + id + ""?stock="" +");
                WriteLiteral(@" newStock, {}, function (res) {
                    if (res.IsSuccess) {
                        reloadPagination();
                        alertify.alert(""Cập nhật số tồn thành công"");
                        hideModal('#modal-update-stock');
                    } else {
                        alertify.alert(res.Message);
                    }
                });
            })
        }
        /** Xóa */
        function showDelete(id, oldStock) {
            alertify.confirm(""Xác nhận xóa sản phẩm "", function () {
                ajaxDelete('product/' + id, function (res) {
                    if (res.IsSuccess) {
                        alertify.alert(""Xóa sản phẩm thành công"");
                        reloadPagination();
                    } else {
                        alertify.alert(""Lỗi không xóa được sản phẩm"");
                        console.log(res.Message);
                    }
                })
            });
        }
        /** ToggleStatus */
        functi");
                WriteLiteral(@"on ToggleStatus(id, status) {
            let text = status ? ""Mở bán"" : ""Dừng bán"";
            alertify.confirm(""Xác nhận "" + text + "" sản phẩm "", function () {
                ajaxPost('product/ToggleStatus/' + id + ""/"" + status, {}, function (res) {
                    if (res.IsSuccess) {

                        alertify.alert(text + "" sản phẩm thành công"");
                        reloadPagination();
                    } else {
                        alertify.alert(""Có lỗi xảy ra: "" + res.Message);
                        console.log(res.Message);
                    }
                })
            });
        }

        function GetMinMaxPrice() {
            let Max = 0; let Min = 0;
            var inputs = $('#divFilterPrice').find('input:checked');
            for (var i = 0; i < inputs.length; i++) {
                let values = inputs[i].value;
                let arr = values.split(',');
                let min = parseInt(arr[0]);
                let max = parseInt(arr");
                WriteLiteral(@"[1]);
                if (min < Min) Min = min;
                if (max > Max) Max = max;
            }
            return { max: Max, min: Min }

        }

        function openModalExportExcel() {
            ajaxGet(""Product/AllProduct"", {}, function (data) {
                if (data.IsSuccess) {
                    let html = """";
                    data.Result.Data.map((item, index) => {
                        html += ` <tr>
                            <td class=""text-center"">${index + 1}</td>
                            <td>${item.ProductCode}</td>
                            <td>
                                   ${item.ProductName}
                            </td>
                            <td class=""text-left"">${generateCategory(item.ProductCategories)}</td>
                            <td class=""text-left"">${generateBrandName(item.ProductBrand)}</td>
                            <td>${getEmptyOrDefault(item.Origin)}</td>
                            <td><span class=""badge b");
                WriteLiteral(@"adge-${item.Status ? ""primary-lighten"" : ""danger-lighten""}"">${item.Status ? ""Đang bán"" : ""Dừng bán""}</span></td>
                            <td>${item.Unit}</td>
                            <td>${item.GurantyTime}</td>
                            <td>${generateProperty(item.ProductProperties)}</td>
                            <td>${item.Description}</td>
                            <td>${item.HighlightProduct}</td>
                            <td>${item.PromotionContent}</td>
                            <td class=""money"">${formatMoney(item.OriginPrice)}</td>
                            <td class=""money"">${formatMoney(item.SaleOffPrice)}</td>
                        </tr>`
                    })
                    $('#tbody-export-product').html(html);
                }
            })
            showModal('#modal-export-excel')
        }

        function generateBrandName(BrandName) {
            if (BrandName == undefined) {
                return;
            } else
                r");
                WriteLiteral(@"eturn BrandName.BrandName;
        }
        function generateProperty(Property) {
            let html = '<ul>'
            Property.map((item, index) => {
                let PropertyName = item.Property.PropertyName;
                let PropertyValue = item.Values[0].Value;
                if (PropertyName != null) {
                    html += `<li>${PropertyName + "": "" + PropertyValue}</li>`
                }
            })
            html += ""</ul>""
            return html;
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