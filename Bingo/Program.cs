using System.Collections;

namespace Bingo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<BingoJatekos> jatekosok = new List<BingoJatekos>();
            string[] fajlok = File.ReadAllLines("nevek.text");

            foreach (string fajl in fajlok)
            {
                string nev = Path.GetFileNameWithoutExtension(fajl);
                int?[,] kartya = BeolvasKartya(fajl);
                jatekosok.Add(new BingoJatekos(nev, kartya));
                if (jatekosok.Count == 100)
                {
                    Console.WriteLine("Elérte a maximum játékos számot");
                    break;
                }
            }

            Console.WriteLine($"4. feladat: Játékosok száma: {jatekosok.Count}");
        }
        static int?[,] BeolvasKartya(string fajl)
        {
            
                string[] sorok = File.ReadAllLines(fajl);
                int?[,] kartya = new int?[5, 5];
                for (int i = 0; i < 5; i++)
                {
                    string[] szamok = sorok[i].Split(';');

                    for (int j = 0; j < 5; j++)
                    {
                        if (szamok[j] == "X")
                            kartya[i, j] = null;
                        else
                            kartya[i, j] = int.Parse(szamok[j]);
                    }
                }
            return kartya;
        }
    }
}
