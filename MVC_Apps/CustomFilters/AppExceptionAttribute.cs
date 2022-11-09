using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace MVC_Apps.CustomFilters
{
    public class AppExceptionAttribute : IExceptionFilter
    {
        private IModelMetadataProvider modelMetadataProvider;

        /// <summary>
        /// Inject IModelMetadataProvider
        /// THis will be resolved using ModelBinder used by MvcOptions class
        /// </summary>
        public AppExceptionAttribute(IModelMetadataProvider modelMetadataProvider)
        {
            this.modelMetadataProvider = modelMetadataProvider;
        }

        /// <summary>
        /// The method will be executed when an exception Occurres
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void OnException(ExceptionContext context)
        {
            // 1. Set the Exception Handled as true, to inform to HTTP Pipeline
            // the the exception is Cought
            context.ExceptionHandled = true;    
            // 2. Retriev the Exception Message
            string errorMessage = context.Exception.Message;
            // 3. Create a ViewResult INstance
            ViewResult viewResult = new ViewResult();
            viewResult.ViewName = "Error";
            // 3.a. Create a ViewDataDictionary
            ViewDataDictionary viewData = new ViewDataDictionary(modelMetadataProvider, context.ModelState);
            // 3.b. Set Key:Value for ViewData
            viewData["Controller"] = context.RouteData.Values["controller"].ToString();
            viewData["Action"] = context.RouteData.Values["action"].ToString();
            viewData["ErrorMessage"] = errorMessage;

            // 3.c. Set the viewData to the ViewData property of the ViewResult
            viewResult.ViewData = viewData;

            // 4. Set the REsult as ViewREsult
            context.Result = viewResult;
        }
    }
}
