using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZobooEdu.Entity;

namespace ZobooEdu.Web.Controllers
{
    public class IstatistikController : ApiController
    {
        // [Authorize(Roles = "Ogrenci")]  
   		 [HttpGet("{id?}")]
        public async Task<IActionResult> Get([FromRoute]int? id)
        {
			
			if (id.HasValue)
			{
				var sonucList = await Db.Sonuclar.ToListAsync();
				List<ZBDSonuc> TumSonuclar = new List<ZBDSonuc>();

				for (int i = 0; i < sonucList.Count; i++)
				{
					if (sonucList[i].sınavID == id)
					{
						Console.WriteLine(sonucList[i] + "=================================");
						TumSonuclar.Add(sonucList[i]);
					}
				}
					return Success(null,TumSonuclar);
			}

				var testList = await Db.Testler.ToListAsync();
				return Success(null, testList);
        }

		  [HttpPost]
        public async Task<IActionResult> Post([FromBody]ZBDTest value)
        {
		
			var zbSonuc = await Db.Sonuclar.ToListAsync();
			for (int i = 0; i < zbSonuc.Count; i++)
			{
				if (zbSonuc[i].sınavID == 0)
				{
					zbSonuc[i].isBittiMi = true;
					zbSonuc[i].sınavID = 1;
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
			test.BasariOrani = (int)(value.DogruSayisi * 33); //Todo Limit değişince burayıda değiştir. 
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

    }
}