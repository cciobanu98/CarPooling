#pragma checksum "D:\Internship\SQL\CarPoolingEF\CarPooling.Web\Views\Settings\General.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6986584cba0da85f5bed4c5c06500a7ee6e40f1a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Settings_General), @"mvc.1.0.view", @"/Views/Settings/General.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Settings/General.cshtml", typeof(AspNetCore.Views_Settings_General))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6986584cba0da85f5bed4c5c06500a7ee6e40f1a", @"/Views/Settings/General.cshtml")]
    public class Views_Settings_General : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CarPooling.Web.ViewModels.Settings.GeneralInformationViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(121, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 5 "D:\Internship\SQL\CarPoolingEF\CarPooling.Web\Views\Settings\General.cshtml"
  
    Layout = "_Settingslayout";
    ViewBag.Title = "Settings";

#line default
#line hidden
            BeginContext(267, 46, true);
            WriteLiteral("<form name=\"general_information\" method=\"post\"");
            EndContext();
            BeginWriteAttribute("action", " action=\"", 313, "\"", 367, 1);
#line 9 "D:\Internship\SQL\CarPoolingEF\CarPooling.Web\Views\Settings\General.cshtml"
WriteAttributeValue("", 322, Url.Action("GeneralInformation", "Settings"), 322, 45, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(368, 507, true);
            WriteLiteral(@" novalidate=""novalidate"" class=""form-container"">
    <fieldset class=""span9"">
        <section>
            <div>
                <div class=""control-label"">
                    Gender
                </div>
            </div>
            <div>
                <div>
                    <label for=""profile_general_firstname"">First name</label>
                </div>
                <div>
                    <input name=""Username"" type=""text"" id=""profile_general_username"" required=""required""");
            EndContext();
            BeginWriteAttribute("value", " value=", 875, "", 915, 1);
#line 22 "D:\Internship\SQL\CarPoolingEF\CarPooling.Web\Views\Settings\General.cshtml"
WriteAttributeValue("", 882, Html.DisplayFor(x => x.Username), 882, 33, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(915, 156, true);
            WriteLiteral(">\r\n                </div>\r\n                <div>\r\n                    <input name=\"Firstname\" type=\"text\" id=\"profile_general_firstname\" required=\"required\"");
            EndContext();
            BeginWriteAttribute("value", " value=", 1071, "", 1112, 1);
#line 25 "D:\Internship\SQL\CarPoolingEF\CarPooling.Web\Views\Settings\General.cshtml"
WriteAttributeValue("", 1078, Html.DisplayFor(x => x.Firstname), 1078, 34, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1112, 154, true);
            WriteLiteral(">\r\n                </div>\r\n                <div>\r\n                    <input name=\"Lastname\" type=\"text\" id=\"profile_general_lastname\" required=\"required\"");
            EndContext();
            BeginWriteAttribute("value", " value=", 1266, "", 1306, 1);
#line 28 "D:\Internship\SQL\CarPoolingEF\CarPooling.Web\Views\Settings\General.cshtml"
WriteAttributeValue("", 1273, Html.DisplayFor(x => x.Lastname), 1273, 33, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1306, 248, true);
            WriteLiteral(">\r\n                </div>\r\n                <div class=\"field buttons\">\r\n                    <button type=\"submit\" class=\"submit btn green-color\">Save</button>\r\n                </div>\r\n            </div>\r\n        </section>\r\n    </fieldset>\r\n</form>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CarPooling.Web.ViewModels.Settings.GeneralInformationViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
