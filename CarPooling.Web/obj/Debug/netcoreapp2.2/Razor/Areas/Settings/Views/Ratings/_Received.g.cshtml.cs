#pragma checksum "D:\Internship\CarPooling\CarPooling.Web\Areas\Settings\Views\Ratings\_Received.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e13cbafeba8c66b63fd029771314f475d7851ee5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Settings_Views_Ratings__Received), @"mvc.1.0.view", @"/Areas/Settings/Views/Ratings/_Received.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Settings/Views/Ratings/_Received.cshtml", typeof(AspNetCore.Areas_Settings_Views_Ratings__Received))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e13cbafeba8c66b63fd029771314f475d7851ee5", @"/Areas/Settings/Views/Ratings/_Received.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6d7056b4eeb1cc58291750a6e88ffb174224f343", @"/Areas/Settings/Views/_ViewImports.cshtml")]
    public class Areas_Settings_Views_Ratings__Received : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<CarPooling.DTO.RatingReceivedDTO>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/scripts/Pagination.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/scripts/Profile.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "D:\Internship\CarPooling\CarPooling.Web\Areas\Settings\Views\Ratings\_Received.cshtml"
  
    int? number = ViewData["Count"] as int?;
    int tpages = (int)number / 10;

#line default
#line hidden
#line 6 "D:\Internship\CarPooling\CarPooling.Web\Areas\Settings\Views\Ratings\_Received.cshtml"
 foreach (var rate in Model)
{

#line default
#line hidden
            BeginContext(169, 22, true);
            WriteLiteral("    <tr>\r\n        <td>");
            EndContext();
            BeginContext(192, 12, false);
#line 9 "D:\Internship\CarPooling\CarPooling.Web\Areas\Settings\Views\Ratings\_Received.cshtml"
       Write(rate.General);

#line default
#line hidden
            EndContext();
            BeginContext(204, 19, true);
            WriteLiteral("</td>\r\n        <td>");
            EndContext();
            BeginContext(224, 13, false);
#line 10 "D:\Internship\CarPooling\CarPooling.Web\Areas\Settings\Views\Ratings\_Received.cshtml"
       Write(rate.Accuracy);

#line default
#line hidden
            EndContext();
            BeginContext(237, 19, true);
            WriteLiteral("</td>\r\n        <td>");
            EndContext();
            BeginContext(257, 14, false);
#line 11 "D:\Internship\CarPooling\CarPooling.Web\Areas\Settings\Views\Ratings\_Received.cshtml"
       Write(rate.Talkative);

#line default
#line hidden
            EndContext();
            BeginContext(271, 49, true);
            WriteLiteral("</td>\r\n        <td><a id=\"profile changeToClick\">");
            EndContext();
            BeginContext(321, 17, false);
#line 12 "D:\Internship\CarPooling\CarPooling.Web\Areas\Settings\Views\Ratings\_Received.cshtml"
                                     Write(rate.ReceivedFrom);

#line default
#line hidden
            EndContext();
            BeginContext(338, 22, true);
            WriteLiteral("</a></td>\r\n    </tr>\r\n");
            EndContext();
#line 14 "D:\Internship\CarPooling\CarPooling.Web\Areas\Settings\Views\Ratings\_Received.cshtml"
}

#line default
#line hidden
            BeginContext(363, 83, true);
            WriteLiteral("<tr>\r\n    <td colspan=\"5\" style=\"border:hidden\">\r\n        <ul class=\"pagination\">\r\n");
            EndContext();
#line 18 "D:\Internship\CarPooling\CarPooling.Web\Areas\Settings\Views\Ratings\_Received.cshtml"
             for (int i = 1; i <= tpages + 1; i++)
            {

#line default
#line hidden
            BeginContext(513, 52, true);
            WriteLiteral("                <li><a class=\"myPage changeToClick\">");
            EndContext();
            BeginContext(566, 1, false);
#line 20 "D:\Internship\CarPooling\CarPooling.Web\Areas\Settings\Views\Ratings\_Received.cshtml"
                                               Write(i);

#line default
#line hidden
            EndContext();
            BeginContext(567, 11, true);
            WriteLiteral("</a></li>\r\n");
            EndContext();
#line 21 "D:\Internship\CarPooling\CarPooling.Web\Areas\Settings\Views\Ratings\_Received.cshtml"
            }

#line default
#line hidden
            BeginContext(593, 158, true);
            WriteLiteral("        </ul>\r\n    </td>\r\n</tr>\r\n<script>\r\n    $(\'.changeToClick\').css(\'cursor\', \'pointer\');\r\n    $(\'.changeToDefault\').css(\'cursor\', \'default\');\r\n</script>\r\n");
            EndContext();
            BeginContext(751, 47, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e13cbafeba8c66b63fd029771314f475d7851ee57293", async() => {
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
            BeginContext(798, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(800, 44, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e13cbafeba8c66b63fd029771314f475d7851ee58470", async() => {
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<CarPooling.DTO.RatingReceivedDTO>> Html { get; private set; }
    }
}
#pragma warning restore 1591
