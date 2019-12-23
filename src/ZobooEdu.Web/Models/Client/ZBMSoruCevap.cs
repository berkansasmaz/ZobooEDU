using System;
using System.ComponentModel.DataAnnotations;

namespace ZobooEdu.Web.Models
{
    public class ZBMSoruCevap
    {
		public Guid SoruId { get; set; }
		[Required]
        public string Konu { get; set; }
        public string SoruResimYolu { get; set; }
		[Required]
        public string SoruMetni { get; set; }
		[Required]
	    public string DogruCevap { get; set; }
		[Required]
        public string Cevap1 { get; set; }
		[Required]
        public string Cevap2 { get; set; }
		[Required]
        public string Cevap3 { get; set; }
		[Required]
        public string Cevap4 { get; set; }
		
		public bool isDogruMu { get; set; }
    }
}