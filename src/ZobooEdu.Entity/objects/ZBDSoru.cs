using System;
using System.ComponentModel.DataAnnotations;

namespace ZobooEdu.Entity
{
    public class ZBDSoru
    {
        [Key]
        public Guid SoruId { get; set; }
        public string Konu { get; set; }
        public string SoruResimYolu { get; set; }
        public string SoruMetni { get; set; }
        public bool isDogruMu { get; set; }
        public ZBDCevap Cevap { get; set; }
    }
}