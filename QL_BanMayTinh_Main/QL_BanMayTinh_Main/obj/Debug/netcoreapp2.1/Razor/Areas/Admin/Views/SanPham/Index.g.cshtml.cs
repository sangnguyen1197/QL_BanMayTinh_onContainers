#pragma checksum "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\SanPham\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a3fbf1bdcdf079b6fc2a8b4e0d33e2cd463251ad"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_SanPham_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/SanPham/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/SanPham/Index.cshtml", typeof(AspNetCore.Areas_Admin_Views_SanPham_Index))]
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
#line 2 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\SanPham\Index.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a3fbf1bdcdf079b6fc2a8b4e0d33e2cd463251ad", @"/Areas/Admin/Views/SanPham/Index.cshtml")]
    public class Areas_Admin_Views_SanPham_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<X.PagedList.IPagedList<QL_BanMayTinh_Main.EF.Sanpham>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(92, 75, true);
            WriteLiteral("<link href=\"/Content/PagedList.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n\r\n");
            EndContext();
#line 5 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\SanPham\Index.cshtml"
  
    ViewData["Title"] = "Sản phẩm";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(270, 45, true);
            WriteLiteral("\r\n<br />\r\n<h2>Quản lí sản phẩm</h2>\r\n<br />\r\n");
            EndContext();
#line 13 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\SanPham\Index.cshtml"
 using (Html.BeginForm("Index", "SanPham", FormMethod.Get))
{

#line default
#line hidden
            BeginContext(379, 36, true);
            WriteLiteral("    <p>\r\n        Nhập tên sản phẩm: ");
            EndContext();
            BeginContext(416, 61, false);
#line 16 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\SanPham\Index.cshtml"
                      Write(Html.TextBox("searchString", ViewBag.CurrentFilter as string));

#line default
#line hidden
            EndContext();
            BeginContext(477, 93, true);
            WriteLiteral("\r\n        <button type=\"submit\"><i class=\"fa fa-search\"></i></button>\r\n    </p>\r\n    <br />\r\n");
            EndContext();
#line 20 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\SanPham\Index.cshtml"
}

#line default
#line hidden
            BeginContext(573, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 22 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\SanPham\Index.cshtml"
 if (TempData["notice"] != null)
{
    if (TempData["notice"].ToString() == "Successfully create")
    {

#line default
#line hidden
            BeginContext(684, 121, true);
            WriteLiteral("        <div class=\"alert alert-success\" role=\"alert\">\r\n            <strong>Thông báo! </strong>Thêm thông tin sản phẩm: ");
            EndContext();
            BeginContext(806, 22, false);
#line 27 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\SanPham\Index.cshtml"
                                                            Write(TempData["tensanpham"]);

#line default
#line hidden
            EndContext();
            BeginContext(828, 29, true);
            WriteLiteral(" thành công\r\n        </div>\r\n");
            EndContext();
#line 29 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\SanPham\Index.cshtml"
    }
    else
    if (TempData["notice"].ToString() == "Successfully edit")
    {

#line default
#line hidden
            BeginContext(944, 120, true);
            WriteLiteral("        <div class=\"alert alert-success\" role=\"alert\">\r\n            <strong>Thông báo! </strong>Sửa thông tin sản phẩm: ");
            EndContext();
            BeginContext(1065, 22, false);
#line 34 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\SanPham\Index.cshtml"
                                                           Write(TempData["tensanpham"]);

#line default
#line hidden
            EndContext();
            BeginContext(1087, 29, true);
            WriteLiteral(" thành công\r\n        </div>\r\n");
            EndContext();
#line 36 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\SanPham\Index.cshtml"
    }
    else
    if (TempData["notice"].ToString() == "Successfully delete")
    {

#line default
#line hidden
            BeginContext(1205, 120, true);
            WriteLiteral("        <div class=\"alert alert-success\" role=\"alert\">\r\n            <strong>Thông báo! </strong>Xóa thông tin sản phẩm: ");
            EndContext();
            BeginContext(1326, 22, false);
#line 41 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\SanPham\Index.cshtml"
                                                           Write(TempData["tensanpham"]);

#line default
#line hidden
            EndContext();
            BeginContext(1348, 29, true);
            WriteLiteral(" thành công\r\n        </div>\r\n");
            EndContext();
#line 43 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\SanPham\Index.cshtml"
    }
    else if (TempData["notice"].ToString() == "Have result")
    {

#line default
#line hidden
            BeginContext(1453, 106, true);
            WriteLiteral("        <div class=\"alert alert-info\" role=\"alert\">\r\n            <strong>Tìm kiếm thành công! </strong>Có ");
            EndContext();
            BeginContext(1560, 15, false);
#line 47 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\SanPham\Index.cshtml"
                                                Write(TempData["dem"]);

#line default
#line hidden
            EndContext();
            BeginContext(1575, 34, true);
            WriteLiteral(" kết quả trả về!\r\n        </div>\r\n");
            EndContext();
#line 49 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\SanPham\Index.cshtml"
    }
    else if (TempData["notice"].ToString() == "No result")
    {

#line default
#line hidden
            BeginContext(1683, 127, true);
            WriteLiteral("        <div class=\"alert alert-danger\" role=\"alert\">\r\n            <strong> Không có kết quả trả về!</strong>\r\n        </div>\r\n");
            EndContext();
#line 55 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\SanPham\Index.cshtml"
    }
}

#line default
#line hidden
            BeginContext(1820, 39, true);
            WriteLiteral("\r\n<p>\r\n    <button class=\"btn btn-info\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 1859, "\"", 1920, 4);
            WriteAttributeValue("", 1869, "location.href=\'", 1869, 15, true);
#line 59 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\SanPham\Index.cshtml"
WriteAttributeValue("", 1884, Url.Action("Create"), 1884, 21, false);

#line default
#line hidden
            WriteAttributeValue("", 1905, "\';return", 1905, 8, true);
            WriteAttributeValue(" ", 1913, "false;", 1914, 7, true);
            EndWriteAttribute();
            BeginContext(1921, 78, true);
            WriteLiteral(">Tạo mới</button>&nbsp;&nbsp;&nbsp;&nbsp;\r\n    <button class=\"btn btn-warning\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 1999, "\"", 2059, 4);
            WriteAttributeValue("", 2009, "location.href=\'", 2009, 15, true);
#line 60 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\SanPham\Index.cshtml"
WriteAttributeValue("", 2024, Url.Action("Index"), 2024, 20, false);

#line default
#line hidden
            WriteAttributeValue("", 2044, "\';return", 2044, 8, true);
            WriteAttributeValue(" ", 2052, "false;", 2053, 7, true);
            EndWriteAttribute();
            BeginContext(2060, 248, true);
            WriteLiteral(">Tải lại</button>\r\n</p>\r\n\r\n<table class=\"table table-striped table-bordered table-hover\" id=\"dataTables-example\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                Mã SP\r\n            </th>\r\n            <th width=\"12%\">\r\n                ");
            EndContext();
            BeginContext(2309, 77, false);
#line 70 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\SanPham\Index.cshtml"
           Write(Html.ActionLink("Tên SP", "Index", new { sortOrder = ViewBag.TenSPSortParm }));

#line default
#line hidden
            EndContext();
            BeginContext(2386, 144, true);
            WriteLiteral("\r\n            </th>\r\n            <th width=\"10%\">\r\n                Thương hiệu\r\n            </th>\r\n            <th width=\"8%\">\r\n                ");
            EndContext();
            BeginContext(2531, 77, false);
#line 76 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\SanPham\Index.cshtml"
           Write(Html.ActionLink("SL tồn", "Index", new { sortOrder = ViewBag.SLTonSortParm }));

#line default
#line hidden
            EndContext();
            BeginContext(2608, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(2664, 79, false);
#line 79 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\SanPham\Index.cshtml"
           Write(Html.ActionLink("Giá bán", "Index", new { sortOrder = ViewBag.GiaBanSortParm }));

#line default
#line hidden
            EndContext();
            BeginContext(2743, 368, true);
            WriteLiteral(@"
            </th>
            <th>
                Xuất xứ
            </th>
            <th width=""22%"">
                Mô tả sản phẩm
            </th>
            <th>
                Hình ảnh
            </th>
            <th>
                <p style=""text-align:center"">Chức năng</p>
            </th>
        </tr>
    </thead>

    <tbody>
");
            EndContext();
#line 97 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\SanPham\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(3160, 60, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(3221, 39, false);
#line 101 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\SanPham\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.MaSp));

#line default
#line hidden
            EndContext();
            BeginContext(3260, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(3328, 40, false);
#line 104 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\SanPham\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.TenSp));

#line default
#line hidden
            EndContext();
            BeginContext(3368, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(3436, 47, false);
#line 107 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\SanPham\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.MaThuongHieu));

#line default
#line hidden
            EndContext();
            BeginContext(3483, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(3551, 45, false);
#line 110 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\SanPham\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.SoLuongTon));

#line default
#line hidden
            EndContext();
            BeginContext(3596, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(3664, 43, false);
#line 113 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\SanPham\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.GiaBanLe));

#line default
#line hidden
            EndContext();
            BeginContext(3707, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(3775, 41, false);
#line 116 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\SanPham\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.XuatSu));

#line default
#line hidden
            EndContext();
            BeginContext(3816, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(3884, 46, false);
#line 119 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\SanPham\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Motakithuat));

#line default
#line hidden
            EndContext();
            BeginContext(3930, 71, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    <img");
            EndContext();
            BeginWriteAttribute("src", " src=", 4001, "", 4054, 1);
#line 122 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\SanPham\Index.cshtml"
WriteAttributeValue("", 4006, Html.DisplayFor(modelItem => item.Hinhanhindex), 4006, 48, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4054, 148, true);
            WriteLiteral(" alt=\"Sample Image\" width=\"50px\" />\r\n                </td>\r\n                <td align=\"center\">\r\n                    <button class=\"btn btn-success\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 4202, "\"", 4289, 4);
            WriteAttributeValue("", 4212, "location.href=\'", 4212, 15, true);
#line 125 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\SanPham\Index.cshtml"
WriteAttributeValue("", 4227, Url.Action("Details",  new { id = item.MaSp }), 4227, 47, false);

#line default
#line hidden
            WriteAttributeValue("", 4274, "\';return", 4274, 8, true);
            WriteAttributeValue(" ", 4282, "false;", 4283, 7, true);
            EndWriteAttribute();
            BeginContext(4290, 86, true);
            WriteLiteral(">Xem</button>&nbsp&nbsp&nbsp&nbsp\r\n                    <button class=\"btn btn-primary\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 4376, "\"", 4460, 4);
            WriteAttributeValue("", 4386, "location.href=\'", 4386, 15, true);
#line 126 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\SanPham\Index.cshtml"
WriteAttributeValue("", 4401, Url.Action("Edit",  new { id = item.MaSp }), 4401, 44, false);

#line default
#line hidden
            WriteAttributeValue("", 4445, "\';return", 4445, 8, true);
            WriteAttributeValue(" ", 4453, "false;", 4454, 7, true);
            EndWriteAttribute();
            BeginContext(4461, 85, true);
            WriteLiteral(">Sửa</button>&nbsp&nbsp&nbsp&nbsp\r\n                    <button class=\"btn btn-danger\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 4546, "\"", 4632, 4);
            WriteAttributeValue("", 4556, "location.href=\'", 4556, 15, true);
#line 127 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\SanPham\Index.cshtml"
WriteAttributeValue("", 4571, Url.Action("Delete",  new { id = item.MaSp }), 4571, 46, false);

#line default
#line hidden
            WriteAttributeValue("", 4617, "\';return", 4617, 8, true);
            WriteAttributeValue(" ", 4625, "false;", 4626, 7, true);
            EndWriteAttribute();
            BeginContext(4633, 77, true);
            WriteLiteral(">Xóa</button>&nbsp&nbsp&nbsp&nbsp\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 130 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\SanPham\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(4721, 30, true);
            WriteLiteral("    </tbody>\r\n</table>\r\nTrang ");
            EndContext();
            BeginContext(4753, 57, false);
#line 133 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\SanPham\Index.cshtml"
  Write(Model.PageCount < Model.PageNumber ? 0 : Model.PageNumber);

#line default
#line hidden
            EndContext();
            BeginContext(4811, 6, true);
            WriteLiteral(" của\r\n");
            EndContext();
            BeginContext(4818, 15, false);
#line 134 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\SanPham\Index.cshtml"
Write(Model.PageCount);

#line default
#line hidden
            EndContext();
            BeginContext(4833, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            BeginContext(4838, 160, false);
#line 136 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\SanPham\Index.cshtml"
Write(Html.PagedListPager(Model, page => Url.Action("Index",
new
{
    page,
    sortOrder = ViewBag.CurrentSort,
    currentFilter =
ViewBag.CurrentFilter
})));

#line default
#line hidden
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<X.PagedList.IPagedList<QL_BanMayTinh_Main.EF.Sanpham>> Html { get; private set; }
    }
}
#pragma warning restore 1591
