using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Arnet.Library.TagHelpers
{
    public static class HtmlAttributeExtensions
    {
        public static string IsActive(this IHtmlHelper htmlHelper, string action, string controller)
        {
            var routeData = htmlHelper.ViewContext.RouteData;

            var routeAction = (string)routeData.Values["action"];
            var routeController = (string)routeData.Values["controller"];

            var isActive = string.Equals(controller, routeController, StringComparison.InvariantCultureIgnoreCase)
                           && string.Equals(action, routeAction, StringComparison.InvariantCultureIgnoreCase);

            return isActive ? "active" : null;
        }
    }
}
