using Microsoft.AspNetCore.Mvc;
using ZobooEdu.Entity;

namespace ZobooEdu.Web
{
    public class DbController : Controller
    {
        private ZBDBContext _db;
        public ZBDBContext Db => _db ?? (ZBDBContext)HttpContext?.RequestServices.GetService(typeof(ZBDBContext));
    }
}