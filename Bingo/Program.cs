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

            Console.WriteLine($"4. feladat: Játékosok száma: {jatekosok.Count}\n");

            Console.WriteLine("7. feladat: Kihúzott számok");
            Random rnd = new Random();
            List<int> huzottSzamok = new List<int>();
            List<BingoJatekos> nyertesek = new List<BingoJatekos>();

            int huzasSorszam = 1;

            while (nyertesek.Count == 0 && huzottSzamok.Count < 75)
            {
                int szam;
                do
                {
                    szam = rnd.Next(1, 76);
                } while (huzottSzamok.Contains(szam));

                huzottSzamok.Add(szam);

                Console.WriteLine($"{huzasSorszam,2}. -> {szam,2}");
                huzasSorszam++;

                foreach (var j in jatekosok)
                {
                    j.SorsoltSzamotJelol(szam);
                    if (j.BingoEll() && !nyertesek.Contains(j))
                        nyertesek.Add(j);
                }
            }

            if (nyertesek.Count > 0)
            {
                Console.WriteLine("\n8. feladat: Lehetséges nyertes(ek)");
                foreach (var j in nyertesek)
                {
                    j.KartyaMegjelenit();
                }
            }
            else
            {
                Console.WriteLine("\nNem lett nyertes.");
            }

            Console.ReadKey();
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
