#pragma checksum "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\PhieuNhap\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8e3d54fcd98e9048d2e0b52ea0fc340856a65f74"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_PhieuNhap_Edit), @"mvc.1.0.view", @"/Areas/Admin/Views/PhieuNhap/Edit.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/PhieuNhap/Edit.cshtml", typeof(AspNetCore.Areas_Admin_Views_PhieuNhap_Edit))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8e3d54fcd98e9048d2e0b52ea0fc340856a65f74", @"/Areas/Admin/Views/PhieuNhap/Edit.cshtml")]
    public class Areas_Admin_Views_PhieuNhap_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<QL_BanMayTinh_Main.EF.Phieunhap>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(40, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\PhieuNhap\Edit.cshtml"
  
    ViewData["Title"] = "Edit";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(141, 24, true);
            WriteLiteral("\r\n<h2>Chỉnh sửa</h2>\r\n\r\n");
            EndContext();
#line 10 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\PhieuNhap\Edit.cshtml"
 using (Html.BeginForm())
{
    

#line default
#line hidden
            BeginContext(200, 23, false);
#line 12 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\PhieuNhap\Edit.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(227, 88, true);
            WriteLiteral("    <div class=\"form-horizontal\">\r\n        <h4>Phiếu nhập</h4>\r\n        <hr />\r\n        ");
            EndContext();
            BeginContext(316, 64, false);
#line 17 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\PhieuNhap\Edit.cshtml"
   Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(380, 10, true);
            WriteLiteral("\r\n        ");
            EndContext();
            BeginContext(391, 35, false);
#line 18 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\PhieuNhap\Edit.cshtml"
   Write(Html.HiddenFor(model => model.MaPn));

#line default
#line hidden
            EndContext();
            BeginContext(426, 10, true);
            WriteLiteral("\r\n        ");
            EndContext();
            BeginContext(437, 35, false);
#line 19 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\PhieuNhap\Edit.cshtml"
   Write(Html.HiddenFor(model => model.Flag));

#line default
#line hidden
            EndContext();
            BeginContext(472, 50, true);
            WriteLiteral("\r\n\r\n        <div class=\"form-group\">\r\n            ");
            EndContext();
            BeginContext(523, 93, false);
#line 22 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\PhieuNhap\Edit.cshtml"
       Write(Html.LabelFor(model => model.MaPn, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
            EndContext();
            BeginContext(616, 55, true);
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
            EndContext();
            BeginContext(672, 139, false);
#line 24 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\PhieuNhap\Edit.cshtml"
           Write(Html.EditorFor(model => model.MaPn, new { htmlAttributes = new { @class = "form-control", @style = "width:40%", @readonly = "readonly" } }));

#line default
#line hidden
            EndContext();
            BeginContext(811, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(830, 82, false);
#line 25 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\PhieuNhap\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.MaPn, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(912, 86, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group\">\r\n            ");
            EndContext();
            BeginContext(999, 97, false);
#line 30 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\PhieuNhap\Edit.cshtml"
       Write(Html.LabelFor(model => model.NgayNhap, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
            EndContext();
            BeginContext(1096, 55, true);
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
            EndContext();
            BeginContext(1152, 159, false);
#line 32 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\PhieuNhap\Edit.cshtml"
           Write(Html.EditorFor(model => model.NgayNhap, new { htmlAttributes = new { @class = "form-control", @style = "width:40%", @type = "date", @readonly = "readonly" } }));

#line default
#line hidden
            EndContext();
            BeginContext(1311, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(1330, 86, false);
#line 33 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\PhieuNhap\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.NgayNhap, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(1416, 86, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group\">\r\n            ");
            EndContext();
            BeginContext(1503, 94, false);
#line 38 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\PhieuNhap\Edit.cshtml"
       Write(Html.LabelFor(model => model.MaNcc, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
            EndContext();
            BeginContext(1597, 55, true);
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
            EndContext();
            BeginContext(1653, 103, false);
#line 40 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\PhieuNhap\Edit.cshtml"
           Write(Html.DropDownList("MaNCC", null, htmlAttributes: new { @class = "form-control", @style = "width:40%" }));

#line default
#line hidden
            EndContext();
            BeginContext(1756, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(1775, 83, false);
#line 41 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\PhieuNhap\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.MaNcc, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(1858, 86, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group\">\r\n            ");
            EndContext();
            BeginContext(1945, 97, false);
#line 46 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\PhieuNhap\Edit.cshtml"
       Write(Html.LabelFor(model => model.TongTien, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
            EndContext();
            BeginContext(2042, 55, true);
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
            EndContext();
            BeginContext(2098, 143, false);
#line 48 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\PhieuNhap\Edit.cshtml"
           Write(Html.EditorFor(model => model.TongTien, new { htmlAttributes = new { @class = "form-control", @readonly = "readonly", @style = "width:40%" } }));

#line default
#line hidden
            EndContext();
            BeginContext(2241, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(2260, 86, false);
#line 49 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\PhieuNhap\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.TongTien, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(2346, 252, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group\">\r\n            <div class=\"col-md-offset-2 col-md-10\">\r\n                <input type=\"submit\" value=\"Lưu\" class=\"btn btn-primary\" />\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
            EndContext();
#line 59 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\PhieuNhap\Edit.cshtml"
}

#line default
#line hidden
            BeginContext(2601, 44, true);
            WriteLiteral("\r\n<div>\r\n    <button class=\"btn btn-default\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 2645, "\"", 2705, 4);
            WriteAttributeValue("", 2655, "location.href=\'", 2655, 15, true);
#line 62 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\PhieuNhap\Edit.cshtml"
WriteAttributeValue("", 2670, Url.Action("Index"), 2670, 20, false);

#line default
#line hidden
            WriteAttributeValue("", 2690, "\';return", 2690, 8, true);
            WriteAttributeValue(" ", 2698, "false;", 2699, 7, true);
            EndWriteAttribute();
            BeginContext(2706, 54, true);
            WriteLiteral("><b>Trở lại</b></button>&nbsp&nbsp&nbsp&nbsp\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<QL_BanMayTinh_Main.EF.Phieunhap> Html { get; private set; }
    }
}
#pragma warning restore 1591
