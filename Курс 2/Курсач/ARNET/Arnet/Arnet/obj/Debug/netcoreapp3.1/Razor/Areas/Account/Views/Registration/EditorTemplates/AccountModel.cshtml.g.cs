#pragma checksum "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Areas\Account\Views\Registration\EditorTemplates\AccountModel.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e99d227c4a2d77b94e3451e93ba7034e5012fec3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Account_Views_Registration_EditorTemplates_AccountModel), @"mvc.1.0.view", @"/Areas/Account/Views/Registration/EditorTemplates/AccountModel.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e99d227c4a2d77b94e3451e93ba7034e5012fec3", @"/Areas/Account/Views/Registration/EditorTemplates/AccountModel.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"58b71f33367d9da2f4355d9f0d0b76ccfc6d2834", @"/Areas/Account/Views/_ViewImports.cshtml")]
    public class Areas_Account_Views_Registration_EditorTemplates_AccountModel : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Arnet.Web.Areas.Account.Models.Registration.AccountModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "password", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"field\">\r\n    <div class=\"field-name\">\r\n        ");
#nullable restore
#line 5 "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Areas\Account\Views\Registration\EditorTemplates\AccountModel.cshtml"
   Write(Html.DisplayNameFor(m => m.SecondName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n    <div class=\"field-content\">\r\n        ");
#nullable restore
#line 8 "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Areas\Account\Views\Registration\EditorTemplates\AccountModel.cshtml"
   Write(Html.EditorFor(m => m.SecondName, new{ htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 9 "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Areas\Account\Views\Registration\EditorTemplates\AccountModel.cshtml"
   Write(Html.ValidationMessageFor(m => m.SecondName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>\r\n<div class=\"field\">\r\n    <div class=\"field-name\">\r\n        ");
#nullable restore
#line 14 "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Areas\Account\Views\Registration\EditorTemplates\AccountModel.cshtml"
   Write(Html.DisplayNameFor(m => m.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n    <div class=\"field-content\">\r\n        ");
#nullable restore
#line 17 "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Areas\Account\Views\Registration\EditorTemplates\AccountModel.cshtml"
   Write(Html.EditorFor(m => m.FirstName,  new{ htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 18 "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Areas\Account\Views\Registration\EditorTemplates\AccountModel.cshtml"
   Write(Html.ValidationMessageFor(m => m.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>\r\n<div class=\"field\">\r\n    <div class=\"field-name\">\r\n        ");
#nullable restore
#line 23 "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Areas\Account\Views\Registration\EditorTemplates\AccountModel.cshtml"
   Write(Html.DisplayNameFor(m => m.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n    <div class=\"field-content\">\r\n        ");
#nullable restore
#line 26 "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Areas\Account\Views\Registration\EditorTemplates\AccountModel.cshtml"
   Write(Html.EditorFor(m => m.Email,  new{ htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 27 "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Areas\Account\Views\Registration\EditorTemplates\AccountModel.cshtml"
   Write(Html.ValidationMessageFor(m => m.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>\r\n<div class=\"field\">\r\n    <div class=\"field-name\">\r\n        ");
#nullable restore
#line 32 "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Areas\Account\Views\Registration\EditorTemplates\AccountModel.cshtml"
   Write(Html.DisplayNameFor(m => m.Password));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n    <div class=\"field-content\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e99d227c4a2d77b94e3451e93ba7034e5012fec37871", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 35 "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Areas\Account\Views\Registration\EditorTemplates\AccountModel.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Password);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        ");
#nullable restore
#line 36 "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Areas\Account\Views\Registration\EditorTemplates\AccountModel.cshtml"
   Write(Html.ValidationMessageFor(m => m.Password));

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Arnet.Web.Areas.Account.Models.Registration.AccountModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
