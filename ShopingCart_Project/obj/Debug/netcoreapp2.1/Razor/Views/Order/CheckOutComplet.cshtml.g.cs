#pragma checksum "D:\Mvc\ShopingCart_Project\ShopingCart_Project\Views\Order\CheckOutComplet.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5d4c52ec68789c0b6768c798b2016857340d96d6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_CheckOutComplet), @"mvc.1.0.view", @"/Views/Order/CheckOutComplet.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Order/CheckOutComplet.cshtml", typeof(AspNetCore.Views_Order_CheckOutComplet))]
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
#line 1 "D:\Mvc\ShopingCart_Project\ShopingCart_Project\Views\_ViewImports.cshtml"
using ShopingCart_Project.Data.Models;

#line default
#line hidden
#line 2 "D:\Mvc\ShopingCart_Project\ShopingCart_Project\Views\_ViewImports.cshtml"
using ShopingCart_Project.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d4c52ec68789c0b6768c798b2016857340d96d6", @"/Views/Order/CheckOutComplet.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3856ec4c23347d9dbaf3dbc6618fc52b60bf56c8", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_CheckOutComplet : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "D:\Mvc\ShopingCart_Project\ShopingCart_Project\Views\Order\CheckOutComplet.cshtml"
  
    ViewData["Title"] = "CheckOutComplet";

#line default
#line hidden
            BeginContext(53, 75, true);
            WriteLiteral("<div calss=\"container\">\r\n\r\n    <h2 class=\"alert alert-success text-center\">");
            EndContext();
            BeginContext(129, 15, false);
#line 7 "D:\Mvc\ShopingCart_Project\ShopingCart_Project\Views\Order\CheckOutComplet.cshtml"
                                           Write(ViewBag.Message);

#line default
#line hidden
            EndContext();
            BeginContext(144, 17, true);
            WriteLiteral("</h2>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591