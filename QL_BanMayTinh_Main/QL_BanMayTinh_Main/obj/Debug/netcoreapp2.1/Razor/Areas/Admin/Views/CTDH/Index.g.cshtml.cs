#pragma checksum "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\CTDH\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bc295e1e31c8cef1522ce621ab0cfb8502d1a565"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_CTDH_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/CTDH/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/CTDH/Index.cshtml", typeof(AspNetCore.Areas_Admin_Views_CTDH_Index))]
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
#line 2 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\CTDH\Index.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bc295e1e31c8cef1522ce621ab0cfb8502d1a565", @"/Areas/Admin/Views/CTDH/Index.cshtml")]
    public class Areas_Admin_Views_CTDH_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<X.PagedList.IPagedList<QL_BanMayTinh_Main.EF.Chitietdonhang>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Content/PagedList.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
            BeginContext(99, 72, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d0e40b92f0394d08a797e60eca2354be", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(171, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 5 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\CTDH\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(275, 64, true);
            WriteLiteral("\r\n<br />\r\n<h2>Thông tin chi tiết đơn hàng: <b style=\"color:red\">");
            EndContext();
            BeginContext(340, 12, false);
#line 11 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\CTDH\Index.cshtml"
                                                 Write(ViewBag.MaDH);

#line default
#line hidden
            EndContext();
            BeginContext(352, 63, true);
            WriteLiteral("</b></h2>\r\n<h3><b>Tổng tiền đơn hàng:</b> <b style=\"color:red\">");
            EndContext();
            BeginContext(416, 31, false);
#line 12 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\CTDH\Index.cshtml"
                                               Write(ViewBag.TongTien.ToString("N0"));

#line default
#line hidden
            EndContext();
            BeginContext(447, 23, true);
            WriteLiteral(" VNĐ</b></h3>\r\n<br />\r\n");
            EndContext();
#line 14 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\CTDH\Index.cshtml"
 using (Html.BeginForm("Index", "CTDH", FormMethod.Get))
{

#line default
#line hidden
            BeginContext(531, 40, true);
            WriteLiteral("    <p>\r\n        Nhập sản phẩm cần tìm: ");
            EndContext();
            BeginContext(572, 61, false);
#line 17 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\CTDH\Index.cshtml"
                          Write(Html.TextBox("searchString", ViewBag.CurrentFilter as string));

#line default
#line hidden
            EndContext();
            BeginContext(633, 93, true);
            WriteLiteral("\r\n        <button type=\"submit\"><i class=\"fa fa-search\"></i></button>\r\n    </p>\r\n    <br />\r\n");
            EndContext();
#line 21 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\CTDH\Index.cshtml"
}

#line default
#line hidden
            BeginContext(729, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 23 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\CTDH\Index.cshtml"
 if (TempData["notice"] != null)
{
    if (TempData["notice"].ToString() == "Successfully edit")
    {

#line default
#line hidden
            BeginContext(838, 129, true);
            WriteLiteral("        <div class=\"alert alert-success\" role=\"alert\">\r\n            <strong>Thông báo! </strong>Sửa thông tin chi tiết đơn hàng: ");
            EndContext();
            BeginContext(968, 16, false);
#line 28 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\CTDH\Index.cshtml"
                                                                    Write(TempData["ctdh"]);

#line default
#line hidden
            EndContext();
            BeginContext(984, 39, true);
            WriteLiteral(" với mã sản phẩm <b style=\"color:red\"> ");
            EndContext();
            BeginContext(1024, 16, false);
#line 28 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\CTDH\Index.cshtml"
                                                                                                                            Write(TempData["masp"]);

#line default
#line hidden
            EndContext();
            BeginContext(1040, 34, true);
            WriteLiteral(" </b> thành công\r\n        </div>\r\n");
            EndContext();
#line 30 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\CTDH\Index.cshtml"
    }
    else
    if (TempData["notice"].ToString() == "Successfully delete")
    {

#line default
#line hidden
            BeginContext(1163, 129, true);
            WriteLiteral("        <div class=\"alert alert-success\" role=\"alert\">\r\n            <strong>Thông báo! </strong>Xóa thông tin chi tiết đơn hàng: ");
            EndContext();
            BeginContext(1293, 16, false);
#line 35 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\CTDH\Index.cshtml"
                                                                    Write(TempData["ctdh"]);

#line default
#line hidden
            EndContext();
            BeginContext(1309, 29, true);
            WriteLiteral(" thành công\r\n        </div>\r\n");
            EndContext();
#line 37 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\CTDH\Index.cshtml"
    }

    else if (TempData["notice"].ToString() == "Have result")
    {

#line default
#line hidden
            BeginContext(1416, 106, true);
            WriteLiteral("        <div class=\"alert alert-info\" role=\"alert\">\r\n            <strong>Tìm kiếm thành công! </strong>Có ");
            EndContext();
            BeginContext(1523, 15, false);
#line 42 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\CTDH\Index.cshtml"
                                                Write(TempData["dem"]);

#line default
#line hidden
            EndContext();
            BeginContext(1538, 34, true);
            WriteLiteral(" kết quả trả về!\r\n        </div>\r\n");
            EndContext();
#line 44 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\CTDH\Index.cshtml"
    }
    else if (TempData["notice"].ToString() == "No result")
    {

#line default
#line hidden
            BeginContext(1646, 127, true);
            WriteLiteral("        <div class=\"alert alert-danger\" role=\"alert\">\r\n            <strong> Không có kết quả trả về!</strong>\r\n        </div>\r\n");
            EndContext();
#line 50 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\CTDH\Index.cshtml"
    }
}

#line default
#line hidden
            BeginContext(1783, 42, true);
            WriteLiteral("\r\n<p>\r\n    <button class=\"btn btn-warning\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 1825, "\"", 1885, 4);
            WriteAttributeValue("", 1835, "location.href=\'", 1835, 15, true);
#line 54 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\CTDH\Index.cshtml"
WriteAttributeValue("", 1850, Url.Action("Index"), 1850, 20, false);

#line default
#line hidden
            WriteAttributeValue("", 1870, "\';return", 1870, 8, true);
            WriteAttributeValue(" ", 1878, "false;", 1879, 7, true);
            EndWriteAttribute();
            BeginContext(1886, 372, true);
            WriteLiteral(@">Tải lại</button>
</p>

<table class=""table table-striped table-bordered table-hover"" id=""dataTables-example"">
    <thead>
        <tr>
            <th>
                Mã sản phẩm
            </th>
            <th>
                Tên sản phẩm
            </th>
            <th>
                Hình ảnh
            </th>
            <th>
                ");
            EndContext();
            BeginContext(2259, 85, false);
#line 70 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\CTDH\Index.cshtml"
           Write(Html.ActionLink("Số lượng mua", "Index", new { sortOrder = ViewBag.SoLuongSortParm }));

#line default
#line hidden
            EndContext();
            BeginContext(2344, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(2400, 85, false);
#line 73 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\CTDH\Index.cshtml"
           Write(Html.ActionLink("Thành tiền", "Index", new { sortOrder = ViewBag.ThanhTienSortParm }));

#line default
#line hidden
            EndContext();
            BeginContext(2485, 162, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                <p style=\"text-align:center\">Chức năng</p>\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n\r\n    <tbody>\r\n");
            EndContext();
#line 82 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\CTDH\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(2696, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(2745, 39, false);
#line 86 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\CTDH\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.MaSp));

#line default
#line hidden
            EndContext();
            BeginContext(2784, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(2840, 55, false);
#line 89 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\CTDH\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.MaSpNavigation.TenSp));

#line default
#line hidden
            EndContext();
            BeginContext(2895, 59, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                <img");
            EndContext();
            BeginWriteAttribute("src", " src=", 2954, "", 3022, 1);
#line 92 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\CTDH\Index.cshtml"
WriteAttributeValue("", 2959, Html.DisplayFor(modelItem => item.MaSpNavigation.Hinhanhindex), 2959, 63, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3022, 90, true);
            WriteLiteral(" alt=\"Sample Image\" width=\"50px\" />\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(3113, 42, false);
#line 95 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\CTDH\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.SoLuong));

#line default
#line hidden
            EndContext();
            BeginContext(3155, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(3211, 44, false);
#line 98 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\CTDH\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.ThanhTien));

#line default
#line hidden
            EndContext();
            BeginContext(3255, 101, true);
            WriteLiteral("\r\n            </td>\r\n            <td align=\"center\">\r\n                <button class=\"btn btn-success\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 3356, "\"", 3462, 4);
            WriteAttributeValue("", 3366, "location.href=\'", 3366, 15, true);
#line 101 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\CTDH\Index.cshtml"
WriteAttributeValue("", 3381, Url.Action("Details",  new { madh = item.MaDh, masp= item.MaSp }), 3381, 66, false);

#line default
#line hidden
            WriteAttributeValue("", 3447, "\';return", 3447, 8, true);
            WriteAttributeValue(" ", 3455, "false;", 3456, 7, true);
            EndWriteAttribute();
            BeginContext(3463, 69, true);
            WriteLiteral(">Xem</button>&nbsp&nbsp&nbsp&nbsp\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 104 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\CTDH\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(3543, 34, true);
            WriteLiteral("    </tbody>\r\n\r\n</table>\r\n\r\nTrang ");
            EndContext();
            BeginContext(3579, 57, false);
#line 109 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\CTDH\Index.cshtml"
  Write(Model.PageCount < Model.PageNumber ? 0 : Model.PageNumber);

#line default
#line hidden
            EndContext();
            BeginContext(3637, 6, true);
            WriteLiteral(" của\r\n");
            EndContext();
            BeginContext(3644, 15, false);
#line 110 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\CTDH\Index.cshtml"
Write(Model.PageCount);

#line default
#line hidden
            EndContext();
            BeginContext(3659, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(3662, 160, false);
#line 111 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\CTDH\Index.cshtml"
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
            BeginContext(3822, 46, true);
            WriteLiteral("\r\n\r\n<div>\r\n    <button class=\"btn btn-default\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 3868, "\"", 3938, 4);
            WriteAttributeValue("", 3878, "location.href=\'", 3878, 15, true);
#line 121 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\CTDH\Index.cshtml"
WriteAttributeValue("", 3893, Url.Action("Index","DonHang"), 3893, 30, false);

#line default
#line hidden
            WriteAttributeValue("", 3923, "\';return", 3923, 8, true);
            WriteAttributeValue(" ", 3931, "false;", 3932, 7, true);
            EndWriteAttribute();
            BeginContext(3939, 60, true);
            WriteLiteral("><b>Trở lại</b></button>&nbsp&nbsp&nbsp&nbsp\r\n</div>\r\n<br />");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<X.PagedList.IPagedList<QL_BanMayTinh_Main.EF.Chitietdonhang>> Html { get; private set; }
    }
}
#pragma warning restore 1591
