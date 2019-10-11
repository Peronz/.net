using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Racunala.Data;

namespace Racunala.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RacunalaContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RacunalaContext>>()))
            {
                // Look for any movies.
                if (context.Racunalo.Any())
                {
                    return;   // DB has been seeded
                }

                context.Racunalo.AddRange(
                    new Racunalo
                    {
                        Lokacija = "Zagreb",
                        DatumPustanjaUPromet = DateTime.Parse("2012-2-12"),
                        Aktivno = "Da",
                        DanasAktivno = "7 sati i 20 min"
                    },

                    new Racunalo
                    {
                        Lokacija = "Zagreb",
                        DatumPustanjaUPromet = DateTime.Parse("2018-2-12"),
                        Aktivno = "Da",
                        DanasAktivno = "4 sata i 33 minute"
                    },

                    new Racunalo
                    {
                        Lokacija = "Zagreb",
                        DatumPustanjaUPromet = DateTime.Parse("2014-2-12"),
                        Aktivno = "Da",
                        DanasAktivno = "4 sata"
                    },

                    new Racunalo
                    {
                        Lokacija = "Velika Gorica",
                        DatumPustanjaUPromet = DateTime.Parse("2015-9-10"),
                        Aktivno = "Da",
                        DanasAktivno = "9 sati i 5 minuta"
                    },

                    new Racunalo
                    {
                        Lokacija = "Sisak",
                        DatumPustanjaUPromet = DateTime.Parse("2005-7-25"),
                        Aktivno = "Ne",
                        DanasAktivno = "5 sati i 22 minute"
                    },
                    new Racunalo
                    {
                        Lokacija = "Požega",
                        DatumPustanjaUPromet = DateTime.Parse("2012-2-04"),
                        Aktivno = "Da",
                        DanasAktivno = "7 sati i 10 minuta"
                    },
                    new Racunalo
                    {
                        Lokacija = "Split",
                        DatumPustanjaUPromet = DateTime.Parse("2017-2-1"),
                        Aktivno = "Ne",
                        DanasAktivno = "3 sata" 
                    },
                    new Racunalo
                    {
                        Lokacija = "Osijek",
                        DatumPustanjaUPromet = DateTime.Parse("2010-2-12"),
                        Aktivno = "Ne",
                        DanasAktivno = "10 sati i 10 minuta"
                    },
                    new Racunalo
                    {
                        Lokacija = "Kutina",
                        DatumPustanjaUPromet = DateTime.Parse("2007-2-11"),
                        Aktivno = "Da",
                        DanasAktivno = "8 sati"
                    },
                    new Racunalo
                    {
                        Lokacija = "Krapina",
                        DatumPustanjaUPromet = DateTime.Parse("2011-2-11"),
                        Aktivno = "Ne",
                        DanasAktivno = "7 sati i 15 minuta"
                    },
                    new Racunalo
                    {
                        Lokacija = "Pula",
                        DatumPustanjaUPromet = DateTime.Parse("2016-2-12"),
                        Aktivno = "Da",
                        DanasAktivno = "6 sati"
                    },
                    new Racunalo
                    {
                        Lokacija = "Rijeka",
                        DatumPustanjaUPromet = DateTime.Parse("2012-2-1"),
                        Aktivno = "Da",
                        DanasAktivno = "8 sati i 12 minuta"
                    },
                    new Racunalo
                    {
                        Lokacija = "Zadar",
                        DatumPustanjaUPromet = DateTime.Parse("2018-2-12"),
                        Aktivno = "Da",
                        DanasAktivno = "6 sati"
                    },
                    new Racunalo
                    {
                        Lokacija = "Dubrovnik",
                        DatumPustanjaUPromet = DateTime.Parse("2015-5-3"),
                        Aktivno = "Da",
                        DanasAktivno = "7 sati"
                    }        

                );
                context.SaveChanges();
            }
        }
    }
}