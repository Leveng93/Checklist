using Microsoft.AspNetCore.Mvc;

namespace Checklist.Controllers
{
    public class Home : Controller
    {
        public Home()
        {
            
        }
        public string Index() => "Hello World!";
    }
}