#pragma checksum "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Areas\Account\Views\Registration\EditorTemplates\CompanyModel.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b4df8fb6c52e4e24ccb53720001a486113b50446"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Account_Views_Registration_EditorTemplates_CompanyModel), @"mvc.1.0.view", @"/Areas/Account/Views/Registration/EditorTemplates/CompanyModel.cshtml")]
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
#line 1 "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Areas\Account\Views\_ViewImports.cshtml"
using Arnet.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Areas\Account\Views\_ViewImports.cshtml"
using Arnet.Web.Areas.Account.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b4df8fb6c52e4e24ccb53720001a486113b50446", @"/Areas/Account/Views/Registration/EditorTemplates/CompanyModel.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"58b71f33367d9da2f4355d9f0d0b76ccfc6d2834", @"/Areas/Account/Views/_ViewImports.cshtml")]
    public class Areas_Account_Views_Registration_EditorTemplates_CompanyModel : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Arnet.Web.Areas.Account.Models.Registration.CompanyModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"field\">\r\n    <div class=\"field-name\">");
#nullable restore
#line 4 "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Areas\Account\Views\Registration\EditorTemplates\CompanyModel.cshtml"
                       Write(Html.DisplayNameFor(m=>m.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n    <div class=\"field-content\">\r\n        ");
#nullable restore
#line 6 "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Areas\Account\Views\Registration\EditorTemplates\CompanyModel.cshtml"
   Write(Html.EditorFor(m=>m.Name, new{ htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 7 "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Areas\Account\Views\Registration\EditorTemplates\CompanyModel.cshtml"
   Write(Html.ValidationMessageFor(m=>m.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Arnet.Web.Areas.Account.Models.Registration.CompanyModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
