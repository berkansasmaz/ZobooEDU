using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Zoboo.Entity
{
    public class Cevap
    {
        [Key]
        public Guid CevapId { get; set; }
        public string Cevap1 { get; set; }
        public string Cevap2 { get; set; }
        public string Cevap3 { get; set; }
        public string Cevap4 { get; set; }
        public string DogruCevap { get; set; }

        public Guid SoruId { get; set; }
        public Soru Soru { get; set; }


    }
}
