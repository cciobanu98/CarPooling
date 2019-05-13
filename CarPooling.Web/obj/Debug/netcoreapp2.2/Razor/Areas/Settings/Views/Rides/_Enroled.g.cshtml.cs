#pragma checksum "D:\Internship\CarPooling\CarPooling.Web\Areas\Settings\Views\Rides\_Enroled.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "98cc66e0b65beca85a630ec96df55c5098b59ce0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Settings_Views_Rides__Enroled), @"mvc.1.0.view", @"/Areas/Settings/Views/Rides/_Enroled.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Settings/Views/Rides/_Enroled.cshtml", typeof(AspNetCore.Areas_Settings_Views_Rides__Enroled))]
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
#line 1 "D:\Internship\CarPooling\CarPooling.Web\Areas\Settings\Views\_ViewImports.cshtml"
using CarPooling;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"98cc66e0b65beca85a630ec96df55c5098b59ce0", @"/Areas/Settings/Views/Rides/_Enroled.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6d7056b4eeb1cc58291750a6e88ffb174224f343", @"/Areas/Settings/Views/_ViewImports.cshtml")]
    public class Areas_Settings_Views_Rides__Enroled : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<CarPooling.DTO.EnroledRideDTO>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/scripts/Pagination.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/scripts/RateRide.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "D:\Internship\CarPooling\CarPooling.Web\Areas\Settings\Views\Rides\_Enroled.cshtml"
  
    int? number = ViewData["Count"] as int?;
    int tpages = (int)number / 10;

#line default
#line hidden
#line 6 "D:\Internship\CarPooling\CarPooling.Web\Areas\Settings\Views\Rides\_Enroled.cshtml"
 foreach (var ride in Model)
{

#line default
#line hidden
            BeginContext(166, 22, true);
            WriteLiteral("    <tr>\r\n        <td>");
            EndContext();
            BeginContext(189, 9, false);
#line 9 "D:\Internship\CarPooling\CarPooling.Web\Areas\Settings\Views\Rides\_Enroled.cshtml"
       Write(ride.From);

#line default
#line hidden
            EndContext();
            BeginContext(198, 19, true);
            WriteLiteral("</td>\r\n        <td>");
            EndContext();
            BeginContext(218, 10, false);
#line 10 "D:\Internship\CarPooling\CarPooling.Web\Areas\Settings\Views\Rides\_Enroled.cshtml"
       Write(ride.Where);

#line default
#line hidden
            EndContext();
            BeginContext(228, 19, true);
            WriteLiteral("</td>\r\n        <td>");
            EndContext();
            BeginContext(248, 9, false);
#line 11 "D:\Internship\CarPooling\CarPooling.Web\Areas\Settings\Views\Rides\_Enroled.cshtml"
       Write(ride.Date);

#line default
#line hidden
            EndContext();
            BeginContext(257, 39, true);
            WriteLiteral("</td>\r\n        <td>\r\n            <ul>\r\n");
            EndContext();
#line 14 "D:\Internship\CarPooling\CarPooling.Web\Areas\Settings\Views\Rides\_Enroled.cshtml"
                 foreach (var p in ride.PassengersName)
                {

#line default
#line hidden
            BeginContext(372, 36, true);
            WriteLiteral("                    <li><a href=\"#\">");
            EndContext();
            BeginContext(409, 1, false);
#line 16 "D:\Internship\CarPooling\CarPooling.Web\Areas\Settings\Views\Rides\_Enroled.cshtml"
                               Write(p);

#line default
#line hidden
            EndContext();
            BeginContext(410, 11, true);
            WriteLiteral("</a></li>\r\n");
            EndContext();
#line 17 "D:\Internship\CarPooling\CarPooling.Web\Areas\Settings\Views\Rides\_Enroled.cshtml"
                }

#line default
#line hidden
            BeginContext(440, 46, true);
            WriteLiteral("            </ul>\r\n        </td>\r\n        <td>");
            EndContext();
            BeginContext(487, 10, false);
#line 20 "D:\Internship\CarPooling\CarPooling.Web\Areas\Settings\Views\Rides\_Enroled.cshtml"
       Write(ride.Price);

#line default
#line hidden
            EndContext();
            BeginContext(497, 19, true);
            WriteLiteral("</td>\r\n        <td>");
            EndContext();
            BeginContext(517, 10, false);
#line 21 "D:\Internship\CarPooling\CarPooling.Web\Areas\Settings\Views\Rides\_Enroled.cshtml"
       Write(ride.Rider);

#line default
#line hidden
            EndContext();
            BeginContext(527, 50, true);
            WriteLiteral("</td>\r\n        <td><button class=\"btn btn-primary\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 577, "\"", 597, 1);
#line 22 "D:\Internship\CarPooling\CarPooling.Web\Areas\Settings\Views\Rides\_Enroled.cshtml"
WriteAttributeValue("", 585, ride.RideId, 585, 12, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(598, 49, true);
            WriteLiteral(" id=\"RateRide\">Rate IT</button></td>\r\n    </tr>\r\n");
            EndContext();
#line 24 "D:\Internship\CarPooling\CarPooling.Web\Areas\Settings\Views\Rides\_Enroled.cshtml"
}

#line default
#line hidden
            BeginContext(650, 83, true);
            WriteLiteral("<tr>\r\n    <td colspan=\"5\" style=\"border:hidden\">\r\n        <ul class=\"pagination\">\r\n");
            EndContext();
#line 28 "D:\Internship\CarPooling\CarPooling.Web\Areas\Settings\Views\Rides\_Enroled.cshtml"
             for (int i = 1; i <= tpages + 1; i++)
            {

#line default
#line hidden
            BeginContext(800, 52, true);
            WriteLiteral("                <li><a class=\"myPage changeToClick\">");
            EndContext();
            BeginContext(853, 1, false);
#line 30 "D:\Internship\CarPooling\CarPooling.Web\Areas\Settings\Views\Rides\_Enroled.cshtml"
                                               Write(i);

#line default
#line hidden
            EndContext();
            BeginContext(854, 11, true);
            WriteLiteral("</a></li>\r\n");
            EndContext();
#line 31 "D:\Internship\CarPooling\CarPooling.Web\Areas\Settings\Views\Rides\_Enroled.cshtml"
            }

#line default
#line hidden
            BeginContext(880, 158, true);
            WriteLiteral("        </ul>\r\n    </td>\r\n</tr>\r\n<script>\r\n    $(\'.changeToClick\').css(\'cursor\', \'pointer\');\r\n    $(\'.changeToDefault\').css(\'cursor\', \'default\');\r\n</script>\r\n");
            EndContext();
            BeginContext(1038, 47, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "98cc66e0b65beca85a630ec96df55c5098b59ce08990", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1085, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(1087, 45, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "98cc66e0b65beca85a630ec96df55c5098b59ce010169", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<CarPooling.DTO.EnroledRideDTO>> Html { get; private set; }
    }
}
#pragma warning restore 1591
