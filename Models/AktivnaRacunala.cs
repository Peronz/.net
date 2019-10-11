using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Racunala.Models
{
    public class AktivnaRacunala
    {
        public List<Racunalo> Racunala { get; set; }
        public SelectList Aktivna { get; set; }
        public string AktivnoRačunalo { get; set; }
        public string SearchString { get; set; }
    }
}