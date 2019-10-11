using System;
using System.ComponentModel.DataAnnotations;

namespace Racunala.Models
{
    public class Racunalo
    {
        public int Id { get; set; }
        public string Lokacija { get; set; }
        [Display(Name = "Datum Puštanja u Promet")]
        [DataType(DataType.Date)]
        public DateTime DatumPustanjaUPromet { get; set; }
        public string Aktivno { get; set; }
        [Display(Name = "Danas Aktivno")]
        public string DanasAktivno { get; set; }
        //public bool Aktivno { get; set; }
        //[DisplayFormat(DataFormatString="{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        //public TimeSpan DanasAktivno { get; set; }
    }
}