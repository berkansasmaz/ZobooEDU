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
        [Authorize]
        [HttpGet("{id?}")]
        public async Task<IActionResult> Get([FromRoute] Guid? id)
        {
            if (id.HasValue == false)
            {
                var list = await Db.Sorular.ToListAsync();

                var rnd = new Random();
                var rastgeleSoruSecimi = rnd.Next(0, list.Count);
                for (var i = 0; i < list.Count; i++)
                    if (rastgeleSoruSecimi == i)
                    {
                        var rastgeleSoru = list[i];
                        id = rastgeleSoru.SoruId;
                        break;
                    }
            }

            if (id.HasValue)
            {
                if (id.Value == Guid.Empty) return Error("You must send monitor id to get.");

                var soru = await Db.Sorular.FirstOrDefaultAsync(x => x.SoruId == id.Value);
                var cevap = await Db.Cevaplar.FirstOrDefaultAsync(x => x.SoruId == id.Value);
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
                    cevap.DogruCevap,
                    IstatistikController.TestSayisi
                });
            }

            var soruList = await Db.Sorular.ToListAsync();
            var cevapList = await Db.Cevaplar.ToListAsync();
            return Success(null, soruList, cevapList);
        }

        // [Authorize(Roles = "Ogretmen")]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] ZBMSoruCevap value)
        {
            if (string.IsNullOrEmpty(value.Konu))
                return Error("Konu gerekli.");
            if (string.IsNullOrEmpty(value.SoruMetni))
                return Error("Soru gerekli.");
            if (string.IsNullOrEmpty(value.Cevap1))
                return Error("Cevap-1 gerekli.");
            if (string.IsNullOrEmpty(value.Cevap2))
                return Error("Cevap-2 gerekli.");
            if (string.IsNullOrEmpty(value.Cevap3))
                return Error("Cevap-3 gerekli.");
            if (string.IsNullOrEmpty(value.Cevap4))
                return Error("Cevap-4 gerekli.");
            if (string.IsNullOrEmpty(value.DogruCevap)) return Error("Doğru cevap gerekli.");

            var zbSoru = new ZBDSoru
            {
                SoruId = Guid.NewGuid(),
                isDogruMu = false
            };
            zbSoru.Konu = value.Konu;
            zbSoru.SoruResimYolu = value.SoruResimYolu;
            zbSoru.SoruMetni = value.SoruMetni;

            var zbCevap = new ZBDCevap
            {
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
            return Error("Something is wrong with your model.");
        }

        // [Authorize(Roles = "Ogrenci")]
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Put([FromBody] ZBMSoruCevap value)
        {
            if (value != null)
            {
                var soru = await Db.Sorular.FirstOrDefaultAsync(x => x.SoruId == value.SoruId);
                var zbSonuc = new ZBDSonuc
                {
                    Konu = value.Konu,
                    isBittiMi = false,
                    sınavID = 0,
                    isDogruMu = value.isDogruMu,
                    SonucId = Guid.NewGuid()
                };
                soru.isDogruMu = value.isDogruMu;
                Db.Sorular.Update(soru);
                Db.Sonuclar.Add(zbSonuc);
                var result = await Db.SaveChangesAsync();
                if (result > 0)
                    return Success("Sıradaki soru geliyor.", new
                    {
                        Id = soru.SoruId
                    });
                return Error("Something is wrong with your model.");
            }

            return Error("Something is wrong with your model.");
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            var zbSonuc = await Db.Sonuclar.ToListAsync();
            for (var i = 0; i < zbSonuc.Count; i++)
                if (zbSonuc[i].isBittiMi == false)
                    Db.Sonuclar.Remove(zbSonuc[i]);

            var result = await Db.SaveChangesAsync();


            return Success("Başarılar");
        }
    }
}
