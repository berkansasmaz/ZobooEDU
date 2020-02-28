using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZobooEdu.Entity;

namespace ZobooEdu.Web.Controllers
{
    public class IstatistikController : ApiController
    {
        public static int TestSayisi = 1;

        [Authorize]
        [HttpGet("{id?}")]
        public async Task<IActionResult> Get([FromRoute] Guid? id)
        {
            if (id.HasValue)
            {
                var sonucList = await Db.Sonuclar.ToListAsync();
                var TumSonuclar = new List<ZBDSonuc>();

                for (var i = 0; i < sonucList.Count; i++) TumSonuclar.Add(sonucList[i]);
                return Success(null, TumSonuclar);
            }

            var testList = await Db.Testler.ToListAsync();
            return Success(null, testList);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] ZBDTest value)
        {
            var rnd = new Random();
            var randomSayi = rnd.Next();
            TestSayisi += 1;
            var zbSonuc = await Db.Sonuclar.ToListAsync();
            for (var i = 0; i < zbSonuc.Count; i++)
                if (zbSonuc[i].sınavID == 0)
                {
                    zbSonuc[i].isBittiMi = true;
                    zbSonuc[i].sınavID = randomSayi;
                    Db.Sonuclar.Update(zbSonuc[i]);
                }

            var test = new ZBDTest
            {
                TestId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                SonQuizTarihi = DateTime.Now,
                DogruSayisi = value.DogruSayisi,
                YanlisSayisi = value.YanlisSayisi
            };
            test.BasariOrani = value.DogruSayisi * 2; //TODO  Limit değişince burayıda değiştir.
            Db.Testler.Add(test);

            var result = await Db.SaveChangesAsync();

            if (result > 0)
                return Success("Monitoring saved successfully.", new
                {
                    Id = value.TestId
                });
            return Error("Something is wrong with your model.");
        }


        [HttpDelete]
        [Authorize]
        public IActionResult Delete()
        {
            return Success("HOŞ GELDİNİZ SAYIN ÖĞRETMENİM");
        }
    }
}
