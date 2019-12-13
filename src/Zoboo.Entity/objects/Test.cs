using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Zoboo.Entity
{
    public class Test
    {
        [Key]
        public Guid TestId { get; set; }
        public Guid UserId { get; set; }
        public DateTime SonQuizTarihi { get; set; }
        public int DogruSayisi { get; set; }
        public int YanlisSayisi { get; set; }
        public int Zaman { get; set; }
        public int BasariOrani { get; set; }

    }
}
