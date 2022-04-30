using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Goodis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController: ControllerBase
    {
        protected int? GetIdFromToken()
        {
            string userId = ((ClaimsIdentity)HttpContext.User.Identity).FindFirst("userId").Value;
            if (string.IsNullOrEmpty(userId))
                return null;
            int.TryParse(userId, out int intId);
            return intId;
        }
    }
}
