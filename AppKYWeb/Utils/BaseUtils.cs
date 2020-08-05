using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AppKYWeb.Utils
{
    public static class BaseUtils
    {
        //https://stackoverflow.com/questions/40912375/return-view-as-string-in-net-core
        //use example
        //viewHtml = await this.RenderViewAsync("Report", model);
        //partialViewHtml = await this.RenderViewAsync("Report", model, true);
        public static async Task<string> RenderViewAsync<TModel>(this Controller controller, string viewName, TModel model, bool partial = false)
        {
            if (string.IsNullOrEmpty(viewName))
            {
                viewName = controller.ControllerContext.ActionDescriptor.ActionName;
            }

            controller.ViewData.Model = model;

            using (var writer = new StringWriter())
            {
                IViewEngine viewEngine = controller.HttpContext.RequestServices.GetService(typeof(ICompositeViewEngine)) as ICompositeViewEngine;
                ViewEngineResult viewResult = viewEngine.FindView(controller.ControllerContext, viewName, !partial);

                if (viewResult.Success == false)
                {
                    return $"A view with the name {viewName} could not be found";
                }

                ViewContext viewContext = new ViewContext(
                    controller.ControllerContext,
                    viewResult.View,
                    controller.ViewData,
                    controller.TempData,
                    writer,
                    new HtmlHelperOptions()
                );

                await viewResult.View.RenderAsync(viewContext);

                return writer.GetStringBuilder().ToString();
            }
        }


        public static IEnumerable<SelectListItem> convertSelectListItem<T>(string text, string value, IEnumerable<T> lst, string selected) where T : class
        {
            List<SelectListItem> list = new List<SelectListItem>();
            IEnumerable<T> result = lst;
            list.Add(new SelectListItem { Text = "-- Seleccione valor --", Value = string.Empty });
            try
            {

                var lisData = (from items in result
                               select items)
                                .AsEnumerable().Select(m => new SelectListItem
                                {
                                    Text = m.GetType().GetProperty(text).GetValue(m).ToString(),
                                    Value = m.GetType().GetProperty(value).GetValue(m).ToString(),
                                    Selected = false
                                }).ToList();
                list.AddRange(lisData);
                return list;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("The process to convert listitem failed :" + ex.Message.ToString());
            }
        }
    }
}
