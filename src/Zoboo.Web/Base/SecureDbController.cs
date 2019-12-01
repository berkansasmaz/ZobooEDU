using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Zoboo.Web
{
    [Authorize]
    public class SecureDbController : DbController
    {
        
    }
}