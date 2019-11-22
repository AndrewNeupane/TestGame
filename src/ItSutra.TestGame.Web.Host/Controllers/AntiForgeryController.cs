using Microsoft.AspNetCore.Antiforgery;
using ItSutra.TestGame.Controllers;

namespace ItSutra.TestGame.Web.Host.Controllers
{
    public class AntiForgeryController : TestGameControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
