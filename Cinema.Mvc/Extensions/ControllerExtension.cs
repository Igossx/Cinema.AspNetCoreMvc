using Cinema.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Cinema.Mvc.Extensions
{
    public static class ControllerExtension
    {
        public static void SetNotificaton(this Controller controller, string type, string message)
        {
            var notification = new Notification(type, message);

            controller.TempData["Notification"] = JsonConvert.SerializeObject(notification);
        }
    }
}
