using System.Text.RegularExpressions;

class Program
{
    public static void Main()
    {
        try
        {
            Console.WriteLine("Unesi putanju do Markdown (*.md) datoteke:");
            string? mdPath = Console.ReadLine();
            // brojaci naslova i podnaslova (npr. naslov 3.2.5 je odredjen listom {3, 2, 5})
            var brojaci = new List<int>();
            // Naslov u md pocinju tarabicama na pocetku linije
            Regex r = new Regex(@"^\s*(#+)\s*(.*)");
            foreach (string line in File.ReadLines(mdFile))
            {
                Match m = r.Match(line);
                if (m.Success)
                {
                    // nivo naslova je odredjen brojem simbola #
                    int nivo = m.Groups[1].Value.Length;
                    // tekst naslova
                    string naslov = m.Groups[2].Value;
   
                    // duzina niza brojaca mora da odgovara nivou naslova
                    while (brojaci.Count < nivo)
                        brojaci.Add(0);
                    brojaci.RemoveRange(nivo, brojaci.Count - nivo);
   
                    // uvecavamo poslednji brojac
                    brojaci[brojaci.Count - 1]++;
   
                    // gradimo string (npr. 3.2.5) na osnovu niza brojaca 
                    string brojac = String.Join(".", brojaci);
   
                    // ispisujemo liniju sadrzaja
                    Console.WriteLine("{0} {1}", brojac.PadRight(60 - naslov.Length, '.'), naslov);
                }
   
            }
        }
        catch (Exception e)
        {
            Console.Error.WriteLine("Greška prilikom čitanja md datoteke");
            Console.Error.WriteLine(e.Message);
            return;
        }
    }
}
