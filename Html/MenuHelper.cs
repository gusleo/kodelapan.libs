using System;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Kodelapan.Libs.Html
{
    /// <summary>
    ///  Menu current active item helper class.
    /// </summary>
    public static class MenuHelper
    {
        /// <summary>
        /// Determines whether the specified controller is selected.
        /// </summary>
        /// <param name="html">The HTML.</param>
        /// <param name="controller">The controller.</param>
        /// <param name="action">The action.</param>
        /// <returns></returns>
        public static string IsSelected(this IHtmlHelper html, string controller = null, string action = null)
        {
            const string cssClass = "active";
            var currentAction = (string)html.ViewContext.RouteData.Values["action"];
            var currentController = (string)html.ViewContext.RouteData.Values["controller"];

            if ( String.IsNullOrEmpty(controller) )
                controller = currentController;

            if ( String.IsNullOrEmpty(action) )
                action = currentAction;

            return controller == currentController && action == currentAction ?
                cssClass : String.Empty;
        }
    }
}
