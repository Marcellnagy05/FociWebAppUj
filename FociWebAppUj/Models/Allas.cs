using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FociWebAppUj.Models
{
    public class Allas
    {
        public Allas(int helyezes, string nev, int gyozelem, int vereseg, int dontetlen, int lottGolok, int kapottGolok, int pontok)
        {
            Helyezes = helyezes;
            Nev = nev;
            Gyozelem = gyozelem;
            Vereseg = vereseg;
            Dontetlen = dontetlen;
            LottGolok = lottGolok;
            KapottGolok = kapottGolok;
            Pontok = pontok;
        }

        public int Helyezes { get; set; }
        public string Nev { get; set; }
        public int Gyozelem { get; set; }
        public int Vereseg { get; set; }
        public int Dontetlen { get; set; }
        public int LottGolok { get; set; }
        public int KapottGolok { get; set; }
        public int Pontok { get; set; }
    }
}
