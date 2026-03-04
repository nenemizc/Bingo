using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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

        public void SorsoltSzamotJelol(int szam)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (kartya[i, j] == szam)
                        talalat[i, j] = true;
                }
            }
        }

        public bool BingoEll()
        {
            for (int i = 0; i < 5; i++)
            {
                bool sor = true;
                for (int j = 0; j < 5; j++)
                    if (!talalat[i, j]) sor = false;

                if (sor) return true;
            }

            for (int j = 0; j < 5; j++)
            {
                bool oszlop = true;
                for (int i = 0; i < 5; i++)
                    if (!talalat[i, j]) oszlop = false;

                if (oszlop) return true;
            }

            bool atlo1 = true;
            for (int i = 0; i < 5; i++)
                if (!talalat[i, i]) atlo1 = false;

            if (atlo1) return true;

            bool atlo2 = true;
            for (int i = 0; i < 5; i++)
                if (!talalat[i, 4 - i]) atlo2 = false;

            return atlo2;
        }

        public void KartyaMegjelenit()
        {
            Console.WriteLine($"\nJátékos: {nev}");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (talalat[i, j])
                    {
                        if (kartya[i, j] == null)
                            Console.Write(" X ");
                        else
                            Console.Write($"{kartya[i, j],2} ");
                    }
                    else
                        Console.Write(" 0 ");
                }
                Console.WriteLine();
            }
        }

    }
}
