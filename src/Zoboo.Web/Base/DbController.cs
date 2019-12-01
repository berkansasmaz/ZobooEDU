using Microsoft.AspNetCore.Mvc;
using Zoboo.Entity;

namespace Zoboo.Web
{
    public class DbController : Controller
    {
        private ZBDBContext _db;
        public ZBDBContext Db => _db ?? (ZBDBContext)HttpContext?.RequestServices.GetService(typeof(ZBDBContext));
        //Db, db null değilse _db' yi ver eğer db null ise git HttpContext? üstünden RequestServices bölümünden GetService kullanarak bana KTDBContext tipteki servisi ver.
        //HttpContext?.RequestServices.GetService(typeof(KTDBContext)) object veri döndüğü için KTDBContext cast ettim
        //Artık bu kontrolleri inheritance alanlar DB nesnesini erişime sahip olucaklar ve işlemleri gerçekleştirebilecekler.
    }
}