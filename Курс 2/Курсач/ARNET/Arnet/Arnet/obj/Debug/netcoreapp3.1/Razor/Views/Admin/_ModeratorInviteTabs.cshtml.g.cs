#pragma checksum "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Views\Admin\_ModeratorInviteTabs.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3d4f130807a078021053565cc9914953ea5241c1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin__ModeratorInviteTabs), @"mvc.1.0.view", @"/Views/Admin/_ModeratorInviteTabs.cshtml")]
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
#line 1 "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Views\_ViewImports.cshtml"
using Arnet.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Views\_ViewImports.cshtml"
using Arnet.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Views\_ViewImports.cshtml"
using Arnet.Library.Claims;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Views\_ViewImports.cshtml"
using Arnet.Library.TagHelpers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3d4f130807a078021053565cc9914953ea5241c1", @"/Views/Admin/_ModeratorInviteTabs.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9c19edf76cdb04d3885e6b791de6d253aed615f0", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin__ModeratorInviteTabs : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<ul class=\"nav nav-tabs\">\r\n    <li class=\"nav-item\">\r\n        <a");
            BeginWriteAttribute("class", " class=\"", 64, "\"", 118, 2);
            WriteAttributeValue("", 72, "nav-link", 72, 8, true);
#nullable restore
#line 3 "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Views\Admin\_ModeratorInviteTabs.cshtml"
WriteAttributeValue(" ", 80, Html.IsActive("Moderators", "Admin"), 81, 37, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("href", " href=\"", 119, "\"", 160, 1);
#nullable restore
#line 3 "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Views\Admin\_ModeratorInviteTabs.cshtml"
WriteAttributeValue("", 126, Url.Action("Moderators", "Admin"), 126, 34, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Модераторы</a>\r\n    </li>\r\n    <li class=\"nav-item\">\r\n        <a");
            BeginWriteAttribute("class", " class=\"", 226, "\"", 277, 2);
            WriteAttributeValue("", 234, "nav-link", 234, 8, true);
#nullable restore
#line 6 "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Views\Admin\_ModeratorInviteTabs.cshtml"
WriteAttributeValue(" ", 242, Html.IsActive("Invites", "Admin"), 243, 34, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("href", " href=\"", 278, "\"", 316, 1);
#nullable restore
#line 6 "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Views\Admin\_ModeratorInviteTabs.cshtml"
WriteAttributeValue("", 285, Url.Action("Invites", "Admin"), 285, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Приглашения</a>\r\n    </li>\r\n</ul>\r\n<br />");
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
