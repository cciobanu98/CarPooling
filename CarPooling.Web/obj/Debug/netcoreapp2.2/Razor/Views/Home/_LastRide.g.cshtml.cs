#pragma checksum "D:\Internship\CarPooling\CarPooling.Web\Views\Home\_LastRide.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ce6b2ae0e78fc7e5685403c939358f2d81cd73f6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home__LastRide), @"mvc.1.0.view", @"/Views/Home/_LastRide.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/_LastRide.cshtml", typeof(AspNetCore.Views_Home__LastRide))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ce6b2ae0e78fc7e5685403c939358f2d81cd73f6", @"/Views/Home/_LastRide.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6d7056b4eeb1cc58291750a6e88ffb174224f343", @"/Views/_ViewImports.cshtml")]
    public class Views_Home__LastRide : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<CarPooling.DTO.SelectedRidesDTO>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(121, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 7 "D:\Internship\CarPooling\CarPooling.Web\Views\Home\_LastRide.cshtml"
 if (Model != null)
{

#line default
#line hidden
#line 9 "D:\Internship\CarPooling\CarPooling.Web\Views\Home\_LastRide.cshtml"
 foreach (var m in Model)
{

#line default
#line hidden
            BeginContext(230, 127, true);
            WriteLiteral("    <article class=\"ride-box clearfix\">\r\n\r\n        <div class=\"ride-content\">\r\n            <h3><a class=\"changeToDefault\">From ");
            EndContext();
            BeginContext(358, 8, false);
#line 14 "D:\Internship\CarPooling\CarPooling.Web\Views\Home\_LastRide.cshtml"
                                           Write(m.Source);

#line default
#line hidden
            EndContext();
            BeginContext(366, 4, true);
            WriteLiteral(" to ");
            EndContext();
            BeginContext(371, 13, false);
#line 14 "D:\Internship\CarPooling\CarPooling.Web\Views\Home\_LastRide.cshtml"
                                                        Write(m.Destination);

#line default
#line hidden
            EndContext();
            BeginContext(384, 93, true);
            WriteLiteral("</a></h3> <span class=\"changeToDefault\">ride by </span><a id=\"profile\" class=\"changeToClick\">");
            EndContext();
            BeginContext(478, 10, false);
#line 14 "D:\Internship\CarPooling\CarPooling.Web\Views\Home\_LastRide.cshtml"
                                                                                                                                                                   Write(m.Username);

#line default
#line hidden
            EndContext();
            BeginContext(488, 207, true);
            WriteLiteral("</a>\r\n        </div>\r\n        <ul class=\"ride-meta\">\r\n            <li class=\"ride-date\">\r\n                <a class=\"changeToDefault\">\r\n                    <i class=\"fa fa-calendar\"></i>\r\n                    ");
            EndContext();
            BeginContext(696, 21, false);
#line 20 "D:\Internship\CarPooling\CarPooling.Web\Views\Home\_LastRide.cshtml"
               Write(m.TravelStartDateTime);

#line default
#line hidden
            EndContext();
            BeginContext(717, 194, true);
            WriteLiteral("\r\n                </a>\r\n            </li>\r\n            <li class=\"ride-people\">\r\n                <a class=\"changeToDefault\">\r\n                    <i class=\"fa fa-user\"></i>\r\n                    ");
            EndContext();
            BeginContext(912, 7, false);
#line 26 "D:\Internship\CarPooling\CarPooling.Web\Views\Home\_LastRide.cshtml"
               Write(m.Seats);

#line default
#line hidden
            EndContext();
            BeginContext(919, 79, true);
            WriteLiteral("\r\n                </a>\r\n            </li>\r\n            <li>\r\n                <a");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 998, "\"", 1018, 2);
            WriteAttributeValue("", 1003, "read-more", 1003, 9, true);
#line 30 "D:\Internship\CarPooling\CarPooling.Web\Views\Home\_LastRide.cshtml"
WriteAttributeValue(" ", 1012, m.Id, 1013, 5, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1019, 176, true);
            WriteLiteral(" class=\"changeToClick\">\r\n                    <i class=\"fa fa-file\"></i>\r\n                    Read more\r\n                </a>\r\n            </li>\r\n        </ul>\r\n    </article>\r\n");
            EndContext();
#line 37 "D:\Internship\CarPooling\CarPooling.Web\Views\Home\_LastRide.cshtml"
}

#line default
#line hidden
#line 37 "D:\Internship\CarPooling\CarPooling.Web\Views\Home\_LastRide.cshtml"
 
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<CarPooling.DTO.SelectedRidesDTO>> Html { get; private set; }
    }
}
#pragma warning restore 1591
