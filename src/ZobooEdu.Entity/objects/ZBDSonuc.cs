using System;
using System.ComponentModel.DataAnnotations;

namespace ZobooEdu.Entity
{
    public class ZBDSonuc
    {
        [Key] public Guid SonucId { get; set; }

        public string Konu { get; set; }
        public bool isDogruMu { get; set; }
        public int sınavID { get; set; }
        public bool isBittiMi { get; set; }
    }
}