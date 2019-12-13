using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zoboo.Entity;

namespace Zoboo.Web.Models
{
    public class MultipleModels
    {
        public Tuple<List<Soru>, List<Cevap>> MyProperty { get; set; }
    }
}
