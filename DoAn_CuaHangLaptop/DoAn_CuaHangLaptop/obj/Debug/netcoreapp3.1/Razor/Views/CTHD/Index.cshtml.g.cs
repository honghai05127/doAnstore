#pragma checksum "D:\Nam3\framework\framework_IS220.M11_11-main\DoAn_CuaHangLaptop\DoAn_CuaHangLaptop\Views\CTHD\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b03614721efa89b9e3feb133d6199e67c4b112c3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CTHD_Index), @"mvc.1.0.view", @"/Views/CTHD/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b03614721efa89b9e3feb133d6199e67c4b112c3", @"/Views/CTHD/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b82c55cdd948a4af3c47cf11254186f2db43d8c", @"/Views/_ViewImports.cshtml")]
    public class Views_CTHD_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<DoAn_CuaHangLaptop.Models.CTHD>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Nam3\framework\framework_IS220.M11_11-main\DoAn_CuaHangLaptop\DoAn_CuaHangLaptop\Views\CTHD\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<<div class=""card m-5"">
    <div class=""card-header"">
        <div class=""row"">
            <div class=""col-md-6"">
                <strong>Danh s??ch t??i kho???n</strong>
            </div>
            <div class=""col-md-6 d-flex justify-content-end"">
                <a");
            BeginWriteAttribute("href", " href=\"", 418, "\"", 453, 1);
#nullable restore
#line 15 "D:\Nam3\framework\framework_IS220.M11_11-main\DoAn_CuaHangLaptop\DoAn_CuaHangLaptop\Views\CTHD\Index.cshtml"
WriteAttributeValue("", 425, Url.Action("Create","CTHD"), 425, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-success\">Th??m</a>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div class=\"card-body p-3\">\r\n        <table class=\"table\">\r\n            <thead>\r\n                <tr>\r\n                    <th>\r\n                        ");
#nullable restore
#line 24 "D:\Nam3\framework\framework_IS220.M11_11-main\DoAn_CuaHangLaptop\DoAn_CuaHangLaptop\Views\CTHD\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.MaHD));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 27 "D:\Nam3\framework\framework_IS220.M11_11-main\DoAn_CuaHangLaptop\DoAn_CuaHangLaptop\Views\CTHD\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.MaSP));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 30 "D:\Nam3\framework\framework_IS220.M11_11-main\DoAn_CuaHangLaptop\DoAn_CuaHangLaptop\Views\CTHD\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.SoLuong));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th></th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 36 "D:\Nam3\framework\framework_IS220.M11_11-main\DoAn_CuaHangLaptop\DoAn_CuaHangLaptop\Views\CTHD\Index.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 40 "D:\Nam3\framework\framework_IS220.M11_11-main\DoAn_CuaHangLaptop\DoAn_CuaHangLaptop\Views\CTHD\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.MaHD));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 43 "D:\Nam3\framework\framework_IS220.M11_11-main\DoAn_CuaHangLaptop\DoAn_CuaHangLaptop\Views\CTHD\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.MaSP));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 46 "D:\Nam3\framework\framework_IS220.M11_11-main\DoAn_CuaHangLaptop\DoAn_CuaHangLaptop\Views\CTHD\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.SoLuong));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 49 "D:\Nam3\framework\framework_IS220.M11_11-main\DoAn_CuaHangLaptop\DoAn_CuaHangLaptop\Views\CTHD\Index.cshtml"
                       Write(Html.ActionLink("C???p nh???t", "Edit", new { mahd = item.MaHD, masp = item.MaSP }, new { @class = "btn btn-info" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            ");
#nullable restore
#line 50 "D:\Nam3\framework\framework_IS220.M11_11-main\DoAn_CuaHangLaptop\DoAn_CuaHangLaptop\Views\CTHD\Index.cshtml"
                       Write(Html.ActionLink("Xem chi ti???t", "Details", new { mahd = item.MaHD, masp = item.MaSP }, new { @class = "btn btn-secondary" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            ");
#nullable restore
#line 51 "D:\Nam3\framework\framework_IS220.M11_11-main\DoAn_CuaHangLaptop\DoAn_CuaHangLaptop\Views\CTHD\Index.cshtml"
                       Write(Html.ActionLink("X??a", "Delete", new { mahd = item.MaHD, masp = item.MaSP }, new { onclick = "return confirm('B???n ch???c ch???n x??a CTHD n??y?');", @class = "btn btn-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 55 "D:\Nam3\framework\framework_IS220.M11_11-main\DoAn_CuaHangLaptop\DoAn_CuaHangLaptop\Views\CTHD\Index.cshtml"

                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n\r\n    </div>\r\n</div>\r\n<style>\r\n    table th {\r\n        font-weight: bold !important;\r\n    }\r\n</style>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<DoAn_CuaHangLaptop.Models.CTHD>> Html { get; private set; }
    }
}
#pragma warning restore 1591
