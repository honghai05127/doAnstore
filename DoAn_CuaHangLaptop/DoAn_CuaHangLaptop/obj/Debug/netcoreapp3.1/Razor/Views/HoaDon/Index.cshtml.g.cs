#pragma checksum "D:\Nam3\framework\framework_IS220.M11_11-main\DoAn_CuaHangLaptop\DoAn_CuaHangLaptop\Views\HoaDon\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "524f55f1d6bc7e994e5488a46baec8d29d825319"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_HoaDon_Index), @"mvc.1.0.view", @"/Views/HoaDon/Index.cshtml")]
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
#line 1 "D:\Nam3\framework\framework_IS220.M11_11-main\DoAn_CuaHangLaptop\DoAn_CuaHangLaptop\Views\_ViewImports.cshtml"
using DoAn_CuaHangLaptop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Nam3\framework\framework_IS220.M11_11-main\DoAn_CuaHangLaptop\DoAn_CuaHangLaptop\Views\_ViewImports.cshtml"
using DoAn_CuaHangLaptop.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"524f55f1d6bc7e994e5488a46baec8d29d825319", @"/Views/HoaDon/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b82c55cdd948a4af3c47cf11254186f2db43d8c", @"/Views/_ViewImports.cshtml")]
    public class Views_HoaDon_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<DoAn_CuaHangLaptop.Models.HoaDon>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Nam3\framework\framework_IS220.M11_11-main\DoAn_CuaHangLaptop\DoAn_CuaHangLaptop\Views\HoaDon\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""card m-5"">
    <div class=""card-header"">
        <div class=""row"">
            <div class=""col-md-6"">
                <strong>Danh s??ch h??a ????n</strong>
            </div>
            <div class=""col-md-6 d-flex justify-content-end"">
                <a");
            BeginWriteAttribute("href", " href=\"", 417, "\"", 454, 1);
#nullable restore
#line 15 "D:\Nam3\framework\framework_IS220.M11_11-main\DoAn_CuaHangLaptop\DoAn_CuaHangLaptop\Views\HoaDon\Index.cshtml"
WriteAttributeValue("", 424, Url.Action("Create","HoaDon"), 424, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-success\">Th??m</a>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div class=\"card-body p-3\">\r\n        <table class=\"table\">\r\n            <thead>\r\n                <tr>\r\n                    <th>\r\n                        ");
#nullable restore
#line 24 "D:\Nam3\framework\framework_IS220.M11_11-main\DoAn_CuaHangLaptop\DoAn_CuaHangLaptop\Views\HoaDon\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.MaKH));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 27 "D:\Nam3\framework\framework_IS220.M11_11-main\DoAn_CuaHangLaptop\DoAn_CuaHangLaptop\Views\HoaDon\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.MaNV));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 30 "D:\Nam3\framework\framework_IS220.M11_11-main\DoAn_CuaHangLaptop\DoAn_CuaHangLaptop\Views\HoaDon\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.MaSK));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 33 "D:\Nam3\framework\framework_IS220.M11_11-main\DoAn_CuaHangLaptop\DoAn_CuaHangLaptop\Views\HoaDon\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.NgayHD));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 36 "D:\Nam3\framework\framework_IS220.M11_11-main\DoAn_CuaHangLaptop\DoAn_CuaHangLaptop\Views\HoaDon\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.DiaChiGiaoHang));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 39 "D:\Nam3\framework\framework_IS220.M11_11-main\DoAn_CuaHangLaptop\DoAn_CuaHangLaptop\Views\HoaDon\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.TongTien));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 42 "D:\Nam3\framework\framework_IS220.M11_11-main\DoAn_CuaHangLaptop\DoAn_CuaHangLaptop\Views\HoaDon\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.ThanhTien));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th></th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 48 "D:\Nam3\framework\framework_IS220.M11_11-main\DoAn_CuaHangLaptop\DoAn_CuaHangLaptop\Views\HoaDon\Index.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 52 "D:\Nam3\framework\framework_IS220.M11_11-main\DoAn_CuaHangLaptop\DoAn_CuaHangLaptop\Views\HoaDon\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.MaKH));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 55 "D:\Nam3\framework\framework_IS220.M11_11-main\DoAn_CuaHangLaptop\DoAn_CuaHangLaptop\Views\HoaDon\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.MaNV));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 58 "D:\Nam3\framework\framework_IS220.M11_11-main\DoAn_CuaHangLaptop\DoAn_CuaHangLaptop\Views\HoaDon\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.MaSK));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 61 "D:\Nam3\framework\framework_IS220.M11_11-main\DoAn_CuaHangLaptop\DoAn_CuaHangLaptop\Views\HoaDon\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.NgayHD));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 64 "D:\Nam3\framework\framework_IS220.M11_11-main\DoAn_CuaHangLaptop\DoAn_CuaHangLaptop\Views\HoaDon\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.DiaChiGiaoHang));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 67 "D:\Nam3\framework\framework_IS220.M11_11-main\DoAn_CuaHangLaptop\DoAn_CuaHangLaptop\Views\HoaDon\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.TongTien));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 70 "D:\Nam3\framework\framework_IS220.M11_11-main\DoAn_CuaHangLaptop\DoAn_CuaHangLaptop\Views\HoaDon\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.ThanhTien));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 73 "D:\Nam3\framework\framework_IS220.M11_11-main\DoAn_CuaHangLaptop\DoAn_CuaHangLaptop\Views\HoaDon\Index.cshtml"
                       Write(Html.ActionLink("C???p nh???t", "Edit", new { mahd = item.MaHD }, new { @class = "btn btn-info" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            ");
#nullable restore
#line 74 "D:\Nam3\framework\framework_IS220.M11_11-main\DoAn_CuaHangLaptop\DoAn_CuaHangLaptop\Views\HoaDon\Index.cshtml"
                       Write(Html.ActionLink("Xem chi ti???t", "Details", new { mahd = item.MaHD }, new { @class = "btn btn-secondary" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                            ");
#nullable restore
#line 76 "D:\Nam3\framework\framework_IS220.M11_11-main\DoAn_CuaHangLaptop\DoAn_CuaHangLaptop\Views\HoaDon\Index.cshtml"
                       Write(Html.ActionLink("X??a", "Delete", new { mahd = item.MaHD}, new { onclick = "return confirm('B???n ch???c ch???n x??a h??a ????n n??y?');", @class = "btn btn-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 79 "D:\Nam3\framework\framework_IS220.M11_11-main\DoAn_CuaHangLaptop\DoAn_CuaHangLaptop\Views\HoaDon\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n<style>\r\n    table th {\r\n        font-weight: bold !important;\r\n    }\r\n</style>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<DoAn_CuaHangLaptop.Models.HoaDon>> Html { get; private set; }
    }
}
#pragma warning restore 1591
