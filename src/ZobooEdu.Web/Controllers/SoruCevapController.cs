using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZobooEdu.Entity;
using ZobooEdu.Web.Models;

namespace ZobooEdu.Web.Controllers
{
    public class SoruCevapController : ApiController
    {
		// [Authorize(Roles = "Ogrenci")]  
		 [HttpGet("{id?}")]
        public async Task<IActionResult> Get([FromRoute]Guid? id)
        {
			if (id.HasValue == false)
			{
				 var list = await Db.Sorular.ToListAsync();
			
				 Random rnd = new Random();
				 int rastgeleSoruSecimi = rnd.Next(0, list.Count);			
						for (int i = 0; i < list.Count; i++)
						{	
								if (rastgeleSoruSecimi == i)
								{
										var rastgeleSoru = list[i];
										id =  rastgeleSoru.SoruId;		 
										break;
							}
						}
				 
			}
            if (id.HasValue)
            {
                if (id.Value == Guid.Empty)
                {
                    return Error("You must send monitor id to get.");
                }

                var soru = await Db.Sorular.FirstOrDefaultAsync( x => x.SoruId == id.Value);
				var cevap = await Db.Cevaplar.FirstOrDefaultAsync( x => x.SoruId == id.Value);
                if (soru == null)
                    return Error("Monitor not found.", code: 404);

                return Success(data: new
                {
					soru.SoruId,
					soru.Konu,
					soru.SoruMetni,
					soru.SoruResimYolu,
					soru.isDogruMu,
					cevap.Cevap1,
					cevap.Cevap2,
					cevap.Cevap3,
					cevap.Cevap4,
					cevap.DogruCevap
                });
            }

            var soruList = await Db.Sorular.ToListAsync();
			var cevapList = await Db.Cevaplar.ToListAsync();
            return Success(null, soruList,cevapList);
        }

		// [Authorize(Roles = "Ogretmen")]  
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ZBMSoruCevap value)
        {
            if (string.IsNullOrEmpty(value.Konu))
            {
                return Error("Konu gerekli.");
            }
			else if (string.IsNullOrEmpty(value.SoruMetni))
			{
		       return Error("Soru gerekli.");
			}
			else if (string.IsNullOrEmpty(value.Cevap1))
			{
		       return Error("Cevap-1 gerekli.");
			}
			else if (string.IsNullOrEmpty(value.Cevap2))
			{
		       return Error("Cevap-2 gerekli.");
			}
			else if (string.IsNullOrEmpty(value.Cevap3))
			{
		       return Error("Cevap-3 gerekli.");
			}
			else if (string.IsNullOrEmpty(value.Cevap4))
			{
		       return Error("Cevap-4 gerekli.");
			}
			else if (string.IsNullOrEmpty(value.DogruCevap))
			{
		       return Error("Doğru cevap gerekli.");
			}
			
			
            var zbSoru = new ZBDSoru
            {
				SoruId = Guid.NewGuid(),
				isDogruMu = false
            };
			zbSoru.Konu = value.Konu;
			zbSoru.SoruResimYolu = value.SoruResimYolu;
			zbSoru.SoruMetni = value.SoruMetni;

			var zbCevap =  new ZBDCevap{
				CevapId = Guid.NewGuid(),
				SoruId = zbSoru.SoruId
			};

			zbCevap.Cevap1 = value.Cevap1;
			zbCevap.Cevap2 = value.Cevap2;
			zbCevap.Cevap3 = value.Cevap3;
			zbCevap.Cevap4 = value.Cevap4;
			zbCevap.DogruCevap = value.DogruCevap;

			Db.Sorular.Add(zbSoru);
			Db.Cevaplar.Add(zbCevap);

            var result = await Db.SaveChangesAsync();

            if (result > 0)
                return Success("Monitoring saved successfully.", new
                {
                    Id = zbSoru.SoruId
                });
            else
                return Error("Something is wrong with your model.");
        }
		// [Authorize(Roles = "Ogrenci")]  
 		[HttpPut]
        public async Task<IActionResult> Put([FromBody]ZBMSoruCevap value)
        {
				if (value != null)
				{
					var soru = await Db.Sorular.FirstOrDefaultAsync( x => x.SoruId == value.SoruId);
					soru.isDogruMu = value.isDogruMu;
					Db.Sorular.Update(soru);
					var result = await Db.SaveChangesAsync();
					  if (result > 0)
							return Success("Sıradaki soru geliyor.", new
							{
								Id = soru.SoruId
							});
						else
                			return Error("Something is wrong with your model.");
				}
				 return Error("Something is wrong with your model.");		
		}

    }

 }
