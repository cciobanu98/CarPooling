#pragma checksum "D:\Internship\CarPooling\CarPooling.Web\Views\Home\_Rides.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ed82df6777008603536b55649848c651cc150ad8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home__Rides), @"mvc.1.0.view", @"/Views/Home/_Rides.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/_Rides.cshtml", typeof(AspNetCore.Views_Home__Rides))]
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
#line 1 "D:\Internship\CarPooling\CarPooling.Web\Views\_ViewImports.cshtml"
using CarPooling;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ed82df6777008603536b55649848c651cc150ad8", @"/Views/Home/_Rides.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6d7056b4eeb1cc58291750a6e88ffb174224f343", @"/Views/_ViewImports.cshtml")]
    public class Views_Home__Rides : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<CarPooling.Web.ViewModels.LastRideViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(121, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 7 "D:\Internship\CarPooling\CarPooling.Web\Views\Home\_Rides.cshtml"
 foreach (var m in Model)
{

#line default
#line hidden
            BeginContext(218, 110, true);
            WriteLiteral("    <article class=\"ride-box clearfix\">\r\n        <div class=\"ride-content\">\r\n            <h3><a href=\"#\">From ");
            EndContext();
            BeginContext(329, 8, false);
#line 11 "D:\Internship\CarPooling\CarPooling.Web\Views\Home\_Rides.cshtml"
                            Write(m.Source);

#line default
#line hidden
            EndContext();
            BeginContext(337, 4, true);
            WriteLiteral(" to ");
            EndContext();
            BeginContext(342, 13, false);
#line 11 "D:\Internship\CarPooling\CarPooling.Web\Views\Home\_Rides.cshtml"
                                         Write(m.Destination);

#line default
#line hidden
            EndContext();
            BeginContext(355, 30, true);
            WriteLiteral("</a></h3> ride by <a href=\"#\">");
            EndContext();
            BeginContext(386, 6, false);
#line 11 "D:\Internship\CarPooling\CarPooling.Web\Views\Home\_Rides.cshtml"
                                                                                     Write(m.User);

#line default
#line hidden
            EndContext();
            BeginContext(392, 262, true);
            WriteLiteral(@"</a>
        </div>
        <ul class=""ride-meta"">
            <li class=""ride-date"">
                <a href=""#"" class=""tooltip-link"" dara-original0title=""Date"" data-toggle=""tooltip"">
                    <i class=""fa fa-calendar""></i>
                    ");
            EndContext();
            BeginContext(655, 15, false);
#line 17 "D:\Internship\CarPooling\CarPooling.Web\Views\Home\_Rides.cshtml"
               Write(m.StartDateTime);

#line default
#line hidden
            EndContext();
            BeginContext(670, 249, true);
            WriteLiteral("\r\n                </a>\r\n            </li>\r\n            <li class=\"ride-people\">\r\n                <a href=\"#\" class=\"tooltip-link\" dara-original-title=\"Date\" data-toggle=\"tooltip\">\r\n                    <i class=\"fa fa-user\"></i>\r\n                    ");
            EndContext();
            BeginContext(920, 7, false);
#line 23 "D:\Internship\CarPooling\CarPooling.Web\Views\Home\_Rides.cshtml"
               Write(m.Seats);

#line default
#line hidden
            EndContext();
            BeginContext(927, 242, true);
            WriteLiteral("\r\n                </a>\r\n            </li>\r\n            <li>\r\n                <a href=\"#\">\r\n                    <i class=\"fa fa-file\"></i>\r\n                    Read more\r\n                </a>\r\n            </li>\r\n        </ul>\r\n    </article>\r\n");
            EndContext();
#line 34 "D:\Internship\CarPooling\CarPooling.Web\Views\Home\_Rides.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<CarPooling.Web.ViewModels.LastRideViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
