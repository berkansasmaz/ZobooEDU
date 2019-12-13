using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Zoboo.Entity
{
    public class Soru
    {
        [Key]
        public Guid SoruId { get; set; }
        public string Konu { get; set; }
        public string SoruResimYolu { get; set; }
        public string SoruMetni { get; set; }
        public bool isDogruMu { get; set; }
        public Cevap Cevap { get; set; }

    }
}
