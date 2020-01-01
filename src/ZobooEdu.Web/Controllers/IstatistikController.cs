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
        [Authorize(Roles = "Ogrenci,Admin")]  
   		 [HttpGet("{id?}")]
        public async Task<IActionResult> Get([FromRoute]Guid? id)
        {
			if (id.HasValue)
			{
				var sonucList = await Db.Sonuclar.ToListAsync();
				List<ZBDSonuc> TumSonuclar = new List<ZBDSonuc>();

				for (int i = 0; i < sonucList.Count; i++)
				{
						TumSonuclar.Add(sonucList[i]);
				}
					return Success(null,TumSonuclar);
			}

				var testList = await Db.Testler.ToListAsync();
				return Success(null, testList);
        }

		  [HttpPost]
		  [Authorize(Roles = "Admin,Ogretmen,Ogrenci")]
        public async Task<IActionResult> Post([FromBody]ZBDTest value)
        {
			Random rnd = new Random();
			int randomSayi = rnd.Next();
			TestSayisi += 1;
			var zbSonuc = await Db.Sonuclar.ToListAsync();
			for (int i = 0; i < zbSonuc.Count; i++)
			{
				if (zbSonuc[i].sınavID == 0)
				{
					zbSonuc[i].isBittiMi = true;
					zbSonuc[i].sınavID = randomSayi;
					Db.Sonuclar.Update(zbSonuc[i]);
				}
			}
            var test =  new ZBDTest(){
				TestId = Guid.NewGuid(),
				UserId = Guid.NewGuid(),
				SonQuizTarihi = DateTime.Now,
				DogruSayisi = value.DogruSayisi,
				YanlisSayisi = value.YanlisSayisi
			};
			test.BasariOrani = (int)(value.DogruSayisi * 0.2); //TODO  Limit değişince burayıda değiştir. 
			Db.Testler.Add(test);

            var result = await Db.SaveChangesAsync();

            if (result > 0)
                return Success("Monitoring saved successfully.", new
                {
                    Id = value.TestId
                });
            else
                return Error("Something is wrong with your model.");
        }

		
		
		[HttpDelete]
		[Authorize(Roles = "Admin,Ogretmen")]
		public IActionResult Delete()
		{
                return Success("HOŞ GELDİNİZ SAYIN ÖĞRETMENİM");
		}
    }
}
