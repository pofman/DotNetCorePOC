using Microsoft.AspNetCore.Mvc;
using DotNetCorePOC.Support.Web;

namespace DotNetCorePOC.Web.Controllers
{
    public class Homecontroller : BaseController
    {
        public IActionResult Index()
        {
            return View();
        } 
    }
}