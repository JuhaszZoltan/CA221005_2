namespace CA221005_2
{
    static class Kommunikacio
    {
        public const string Altalanos = "Hello!";

        public static void Koszones(string napszak)
        {
            if (napszak == "reggel")
            {
                Console.WriteLine("Jóreggelt kívánok!");
            }
            else if (napszak == "délután" || napszak == "délelőtt")
            {
                Console.WriteLine("Jónapot kívánok!");
            }
            else if (napszak == "esete" || napszak == "éjszaka")
            {
                Console.WriteLine("Jóestét kívánok!");
            }
            else throw new Exception("Ilyen napszak nincs!");
        }
    }

    class Allat
    {
        public string Nev { get; set; }
        public DateTime Szuletes { get; set; }
        public string KedvencEtel { get; set; }

        public virtual void HangotAdKi()
        {
            Console.WriteLine("dolog - dolog!");
        }
    }

    class Macska : Allat
    {
        public int EletekSzama { get; set; } = 9;

        public override void HangotAdKi()
        {
            Console.WriteLine("miaú - miaú");
        }

        public void Dorombolt()
        {
            Console.WriteLine("doromb - doromb!");
        }
    }

    class Kutya : Allat
    {
        public bool Huseges { get; set; } = true;

        public override void HangotAdKi()
        {
            Console.WriteLine("vau vau!");
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Allat allat = new Allat()
            {
                Nev = "Pityu",
                Szuletes = new DateTime(2009, 03, 21),
                KedvencEtel = "tejszínhabos disznósajt borsóval",
            };

            Console.Write($"{allat.Nev} azt mondja: ");
            allat.HangotAdKi();

            Kutya kutya = new Kutya()
            {
                Nev = "Héfaisztosz",
                Szuletes = new DateTime(2004, 01, 01),
                KedvencEtel = "papucs",
            };

            Console.WriteLine($"{kutya.Nev} egy {kutya.GetType().ToString().Split('.')[1]}");
            Console.WriteLine($"{kutya.Nev} {(kutya.Huseges ? "nagyon hűséges" : "leszarja, hogy létezel")}");

            Console.Write($"{kutya.Nev} éppen tüzel? ");
            kutya.Huseges = Console.ReadLine() != "igen";

            Console.WriteLine($"{kutya.Nev} {(kutya.Huseges ? "nagyon hűséges" : "leszarja, hogy létezel")}");

            Console.Write($"{kutya.Nev} azt mondja: ");
            kutya.HangotAdKi();

            //Console.WriteLine(Kommunikacio.Altalanos);
            //Kommunikacio.Koszones("reggel");

            Macska macska = new()
            {
                Nev = "Macska",
                Szuletes = DateTime.Now,
                KedvencEtel = "tetra hidrogén klorid"
            };

            List<Allat> allatok = new();

            allatok.Add(macska);
            allatok.Add(allat);
            allatok.Add(kutya);

            Allat valtozo = new Macska();

            foreach (var a in allatok)
            {
                Console.Write($"{a.Nev} azt mondja: ");
                a.HangotAdKi(); 
            }
        }
    }
}