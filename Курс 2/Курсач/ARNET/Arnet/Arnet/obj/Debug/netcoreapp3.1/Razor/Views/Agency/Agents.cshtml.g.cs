#pragma checksum "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Views\Agency\Agents.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "999d97adf916ad87beb72795a92e38fc58d9a73f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Agency_Agents), @"mvc.1.0.view", @"/Views/Agency/Agents.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"999d97adf916ad87beb72795a92e38fc58d9a73f", @"/Views/Agency/Agents.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9c19edf76cdb04d3885e6b791de6d253aed615f0", @"/Views/_ViewImports.cshtml")]
    public class Views_Agency_Agents : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Arnet.Web.Models.Agency.AgentsViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Agency/Agents.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Views\Agency\Agents.cshtml"
  
    ViewData["Title"] = "Агенты";
    bool isOwner = bool.Parse(ViewData["isOwner"].ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Styles", async() => {
                WriteLiteral(@"
    <style>
        .table td {
            vertical-align: middle;
        }

        .dropdown-item-danger {
            color: red
        }

            .dropdown-item-danger:hover {
                color: red
            }
    </style>
");
            }
            );
            WriteLiteral("\r\n");
#nullable restore
#line 23 "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Views\Agency\Agents.cshtml"
Write(Html.Partial("_AgentInviteTabs"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 24 "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Views\Agency\Agents.cshtml"
 if (isOwner)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>\r\n        <input id=\"add-agent\" type=\"button\" class=\"btn btn-primary\" value=\"Добавить агента\"");
            BeginWriteAttribute("href", " href=\"", 599, "\"", 678, 1);
#nullable restore
#line 27 "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Views\Agency\Agents.cshtml"
WriteAttributeValue("", 606, Url.Action("AddAgent", "Agency", new { companyId = ViewBag.CompanyId }), 606, 72, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n    </p>\r\n");
#nullable restore
#line 29 "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Views\Agency\Agents.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>ФИО</th>\r\n            <th>Открыто</th>\r\n            <th>Закрыто</th>\r\n");
#nullable restore
#line 36 "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Views\Agency\Agents.cshtml"
             if (isOwner)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <th>Управление</th>\r\n");
#nullable restore
#line 39 "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Views\Agency\Agents.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 43 "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Views\Agency\Agents.cshtml"
         foreach (var agent in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td><a");
            BeginWriteAttribute("href", " href=\"", 1047, "\"", 1120, 1);
#nullable restore
#line 46 "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Views\Agency\Agents.cshtml"
WriteAttributeValue("", 1054, Url.Action("Profile", "Account", new { id=agent.Agent.AccountId}), 1054, 66, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 46 "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Views\Agency\Agents.cshtml"
                                                                                            Write(agent.Agent.SecondName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 46 "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Views\Agency\Agents.cshtml"
                                                                                                                    Write(agent.Agent.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 46 "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Views\Agency\Agents.cshtml"
                                                                                                                                           Write(agent.Agent.MiddleName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></td>\r\n                <td>");
#nullable restore
#line 47 "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Views\Agency\Agents.cshtml"
               Write(agent.OpenedApartments.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 48 "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Views\Agency\Agents.cshtml"
               Write(agent.ClosedApartments.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 49 "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Views\Agency\Agents.cshtml"
                 if (isOwner)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <td>
                        <div class=""btn-group"">
                            <button type=""button"" class=""btn btn-outline-primary dropdown-toggle"" data-toggle=""dropdown"">Управление</button>
                            <div class=""dropdown-menu"">
");
#nullable restore
#line 55 "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Views\Agency\Agents.cshtml"
                                 if (agent.OpenedApartments.Count() > 0)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <a class=\"dropdown-item\"");
            BeginWriteAttribute("href", "\r\n                                       href=\"", 1812, "\"", 1942, 1);
#nullable restore
#line 58 "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Views\Agency\Agents.cshtml"
WriteAttributeValue("", 1859, Url.Action("AgentApartments", "Agency", new { accountId = agent.Agent.AccountId }), 1859, 83, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Объявления (");
#nullable restore
#line 58 "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Views\Agency\Agents.cshtml"
                                                                                                                                         Write(agent.OpenedApartments.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral(")</a>\r\n");
#nullable restore
#line 59 "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Views\Agency\Agents.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <a class=\"dropdown-item\">Объявления (0)</a>\r\n");
#nullable restore
#line 63 "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Views\Agency\Agents.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <a class=\"dropdown-item dropdown-item-danger\" name=\"remove-agent-btn\"");
            BeginWriteAttribute("href", "\r\n                                   href=\"", 2319, "\"", 2467, 1);
#nullable restore
#line 65 "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Views\Agency\Agents.cshtml"
WriteAttributeValue("", 2362, Url.Action("RemoveAgent", "Agency", new {companyId=ViewBag.CompanyId,  accountId=agent.Agent.AccountId}), 2362, 105, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Удалить</a>\r\n                            </div>\r\n                        </div>\r\n                    </td>\r\n");
#nullable restore
#line 69 "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Views\Agency\Agents.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tr>\r\n");
#nullable restore
#line 71 "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Views\Agency\Agents.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
#nullable restore
#line 74 "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Views\Agency\Agents.cshtml"
 if (isOwner)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div id=""add-agent-modal"" class=""modal"" tabindex=""-1"" role=""dialog"">
        <div class=""modal-dialog"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"">Добавление агента</h5>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                </div>
                <div class=""modal-body"">
                    <div class=""form-group"">
                        <label>Ссылка для регистрации агента:</label>
                        <div class=""input-group"">
                            <input id=""url-text"" class=""form-control"" readonly />
                            <div class=""input-group-append"">
                                <button id=""copy-btn"" class=""btn btn-primary"">Копировать</button>
                            </div>
                        </div>
     ");
            WriteLiteral(@"                   <p>Агент будет добавлен, как только он пройдет регистрацию</p>
                    </div>
                </div>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-primary"" data-dismiss=""modal"">Закрыть</button>
                </div>
            </div>
        </div>
    </div>
    <div id=""remove-agent-modal"" class=""modal"" tabindex=""-1"" role=""dialog"">
        <div class=""modal-dialog"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"">Удаление агента</h5>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                </div>
                <div class=""modal-body"">
                    <p>Вы уверены, что хотите удалить агента? Все его объявления будут закрыты. Если вы хотите сохранить объявле");
            WriteLiteral(@"ния, передайте их другому агенту</p>
                </div>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Закрыть</button>
                    <a id=""remove-agent"" class=""btn btn-danger"">Удалить</a>
                </div>
            </div>
        </div>
    </div>
");
#nullable restore
#line 122 "C:\Users\vadim\OneDrive\Рабочий стол\HSE\Курсовая\ARNET\Arnet\Arnet\Views\Agency\Agents.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "999d97adf916ad87beb72795a92e38fc58d9a73f15772", async() => {
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
                WriteLiteral("\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Arnet.Web.Models.Agency.AgentsViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
