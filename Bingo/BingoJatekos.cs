using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo
{
    internal class BingoJatekos
    {
        private string nev;
        private int?[,] kartya;
        private bool[,] talalat;

        public BingoJatekos(string nev, int?[,] kartya)
        {
            this.nev = nev;
            this.kartya = kartya;
            this.talalat = new bool[5, 5];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (this.kartya[i, j] == null)
                        this.talalat[i, j] = true;
                }
            }
        }

    }
}
