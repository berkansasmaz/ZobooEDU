using System;
using System.ComponentModel.DataAnnotations;

namespace ZobooEdu.Entity
{
    public class ZBDCevap
    {
        [Key] public Guid CevapId { get; set; }

        public string DogruCevap { get; set; }
        public string Cevap1 { get; set; }
        public string Cevap2 { get; set; }
        public string Cevap3 { get; set; }
        public string Cevap4 { get; set; }

        public Guid SoruId { get; set; }
        public ZBDSoru Soru { get; set; }
    }
}