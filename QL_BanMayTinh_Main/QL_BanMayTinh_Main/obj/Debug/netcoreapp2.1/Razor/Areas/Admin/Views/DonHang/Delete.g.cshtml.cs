#pragma checksum "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\DonHang\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d97a19c6fe3c41e3fe3ac045420a0d7e3ec3f44f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_DonHang_Delete), @"mvc.1.0.view", @"/Areas/Admin/Views/DonHang/Delete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/DonHang/Delete.cshtml", typeof(AspNetCore.Areas_Admin_Views_DonHang_Delete))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d97a19c6fe3c41e3fe3ac045420a0d7e3ec3f44f", @"/Areas/Admin/Views/DonHang/Delete.cshtml")]
    public class Areas_Admin_Views_DonHang_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<QL_BanMayTinh_Main.EF.Donhang>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(38, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\DonHang\Delete.cshtml"
  
    ViewData["Title"] = "Delete";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(141, 158, true);
            WriteLiteral("\r\n<h2>Xóa thông tin</h2>\r\n\r\n<h3>Bạn chắc rằng muốn xóa thông tin đơn hàng?</h3>\r\n<div>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(300, 40, false);
#line 15 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\DonHang\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.MaDh));

#line default
#line hidden
            EndContext();
            BeginContext(340, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(384, 36, false);
#line 18 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\DonHang\Delete.cshtml"
       Write(Html.DisplayFor(model => model.MaDh));

#line default
#line hidden
            EndContext();
            BeginContext(420, 45, true);
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(466, 44, false);
#line 22 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\DonHang\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.TaiKhoan));

#line default
#line hidden
            EndContext();
            BeginContext(510, 45, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(556, 40, false);
#line 26 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\DonHang\Delete.cshtml"
       Write(Html.DisplayFor(model => model.TaiKhoan));

#line default
#line hidden
            EndContext();
            BeginContext(596, 45, true);
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(642, 43, false);
#line 30 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\DonHang\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.NgayTao));

#line default
#line hidden
            EndContext();
            BeginContext(685, 45, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(731, 39, false);
#line 34 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\DonHang\Delete.cshtml"
       Write(Html.DisplayFor(model => model.NgayTao));

#line default
#line hidden
            EndContext();
            BeginContext(770, 45, true);
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(816, 44, false);
#line 38 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\DonHang\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Shipname));

#line default
#line hidden
            EndContext();
            BeginContext(860, 45, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(906, 40, false);
#line 42 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\DonHang\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Shipname));

#line default
#line hidden
            EndContext();
            BeginContext(946, 45, true);
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(992, 46, false);
#line 46 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\DonHang\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.ShipMobile));

#line default
#line hidden
            EndContext();
            BeginContext(1038, 45, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1084, 42, false);
#line 50 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\DonHang\Delete.cshtml"
       Write(Html.DisplayFor(model => model.ShipMobile));

#line default
#line hidden
            EndContext();
            BeginContext(1126, 45, true);
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1172, 47, false);
#line 54 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\DonHang\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.ShipAddress));

#line default
#line hidden
            EndContext();
            BeginContext(1219, 45, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1265, 43, false);
#line 58 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\DonHang\Delete.cshtml"
       Write(Html.DisplayFor(model => model.ShipAddress));

#line default
#line hidden
            EndContext();
            BeginContext(1308, 45, true);
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1354, 45, false);
#line 62 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\DonHang\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.ShipEmail));

#line default
#line hidden
            EndContext();
            BeginContext(1399, 45, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1445, 41, false);
#line 66 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\DonHang\Delete.cshtml"
       Write(Html.DisplayFor(model => model.ShipEmail));

#line default
#line hidden
            EndContext();
            BeginContext(1486, 45, true);
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1532, 44, false);
#line 70 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\DonHang\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.TongTien));

#line default
#line hidden
            EndContext();
            BeginContext(1576, 45, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1622, 40, false);
#line 74 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\DonHang\Delete.cshtml"
       Write(Html.DisplayFor(model => model.TongTien));

#line default
#line hidden
            EndContext();
            BeginContext(1662, 45, true);
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1708, 47, false);
#line 78 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\DonHang\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.DaThanhToan));

#line default
#line hidden
            EndContext();
            BeginContext(1755, 33, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n");
            EndContext();
#line 82 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\DonHang\Delete.cshtml"
             if (Model.DaThanhToan == 1)
            {

#line default
#line hidden
            BeginContext(1845, 59, true);
            WriteLiteral("                <p style=\"color:black;\">Đã thanh toán</p>\r\n");
            EndContext();
#line 85 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\DonHang\Delete.cshtml"
            }
            else
            {

#line default
#line hidden
            BeginContext(1952, 61, true);
            WriteLiteral("                <p style=\"color:black;\">Chưa thanh toán</p>\r\n");
            EndContext();
#line 89 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\DonHang\Delete.cshtml"
            }

#line default
#line hidden
            BeginContext(2028, 30, true);
            WriteLiteral("        </dd>\r\n\r\n    </dl>\r\n\r\n");
            EndContext();
#line 94 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\DonHang\Delete.cshtml"
     using (Html.BeginForm())
    {
        

#line default
#line hidden
            BeginContext(2105, 23, false);
#line 96 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\DonHang\Delete.cshtml"
   Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(2132, 181, true);
            WriteLiteral("        <div class=\"form-actions no-color\">\r\n            <input type=\"submit\" value=\"Xóa\" class=\"btn btn-danger\" /> &nbsp&nbsp&nbsp&nbsp\r\n            <button class=\"btn btn-default\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 2313, "\"", 2373, 4);
            WriteAttributeValue("", 2323, "location.href=\'", 2323, 15, true);
#line 100 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\DonHang\Delete.cshtml"
WriteAttributeValue("", 2338, Url.Action("Index"), 2338, 20, false);

#line default
#line hidden
            WriteAttributeValue("", 2358, "\';return", 2358, 8, true);
            WriteAttributeValue(" ", 2366, "false;", 2367, 7, true);
            EndWriteAttribute();
            BeginContext(2374, 62, true);
            WriteLiteral("><b>Trở lại</b></button>&nbsp&nbsp&nbsp&nbsp\r\n        </div>\r\n");
            EndContext();
#line 102 "D:\Documents\4th Year\1st Semester\Open-sourced Apps\Project\QL_BanMayTinh\QL_BanMayTinh_Main\QL_BanMayTinh_Main\Areas\Admin\Views\DonHang\Delete.cshtml"
    }

#line default
#line hidden
            BeginContext(2443, 8, true);
            WriteLiteral("</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<QL_BanMayTinh_Main.EF.Donhang> Html { get; private set; }
    }
}
#pragma warning restore 1591
