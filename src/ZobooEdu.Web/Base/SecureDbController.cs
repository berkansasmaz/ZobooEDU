using Microsoft.AspNetCore.Authorization;

namespace ZobooEdu.Web
{
    [Authorize]
    public class SecureDbController : DbController
    {
    }
}
