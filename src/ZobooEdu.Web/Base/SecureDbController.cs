using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ZobooEdu.Web
{
	 [Authorize]
    public class SecureDbController : DbController
    {
    	
    }
}