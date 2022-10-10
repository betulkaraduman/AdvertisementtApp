using AspNetCore.AdvertisementApp.Common;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.AdvertisementApp.UI.Extentions
{
    public static class ControllerExtentions
    {
        public static IActionResult ResponseRedirectToAction<T>(this Controller controller, IResponse<T> response, string action, string controllerName = "")
        {
            if (response.ResponseType == ResponseType.NotFound)
                return controller.NotFound();
            if (response.ResponseType == ResponseType.ValidationError)
            {
                foreach (var item in response.customValidationErrors)
                {
                    controller.ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                return controller.ViewBag(response.Data);
            };
            if (string.IsNullOrWhiteSpace(controllerName))
            {

                return controller.RedirectToAction(action);
            }
            else
                return controller.RedirectToAction(action, controller);
        }

        public static IActionResult ResponseView<T>(this Controller controller, IResponse<T> response)
        {
            if (response.ResponseType == ResponseType.NotFound)
                return controller.NotFound();
            return controller.View(response.Data);
        }


        public static IActionResult ResponseRedirectToAction(this Controller controller, IResponse response, string action)
        {
            if (response.ResponseType == ResponseType.NotFound)
                return controller.NotFound();
            return controller.View(action);
        }
    }
}
