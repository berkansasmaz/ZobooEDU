using System;
using System.ComponentModel.DataAnnotations;

namespace ZobooEdu.Entity
{
    public class ZBDTest
    {
        [Key] public Guid TestId { get; set; }

        public Guid UserId { get; set; }
        public DateTime SonQuizTarihi { get; set; }
        public int DogruSayisi { get; set; }
        public int YanlisSayisi { get; set; }
        public int BasariOrani { get; set; }
    }
}