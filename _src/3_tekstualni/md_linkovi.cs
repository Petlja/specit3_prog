using System.Text.RegularExpressions;

class Program
{
    // izdvaja i vraca prvi glavni naslov iz datog markdown teksta
    // vraca praznu nisku ako ne postoji ni jedan glavni naslov
    public static string getHeading(string text)
    {
        Regex r = new Regex(@"^\s*#\s*(.*)");
        foreach (string line in text.Split(System.Environment.NewLine.ToCharArray()))
        {
            Match m = r.Match(line);
            if (m.Success)
                return m.Groups[1].Value;
        }
        return "";  
    }
 
    public static void Main()
    {
        Console.WriteLine("Unesi putanju do direktorijuma koji sadrži Markdown (*.md) datoteke:");
        string? dir = Console.ReadLine();
        try
        {
            // prolazimo kroz sve md datoteke u datom direktorijumu i svim njegovim poddirektorijumima
            string[] mdFiles = Directory.GetFiles(dir, "*.md", SearchOption.AllDirectories);
            // gradimo recnik koji preslikava imena md datoteka u pune putanje do njih i naslove procitane iz datoteka
            var fileData = new Dictionary<string, (string path, string heading)>();
            foreach (string mdFile in mdFiles)
            {
                string fileName = Path.GetFileName(mdFile);
                string text = File.ReadAllText(mdFile);
                string heading = getHeading(text);
                fileData.Add(fileName, (mdFile, heading));
            }


            // prolazimo drugi put kroz sve fajlove i obradjujemo linkove
            foreach (string mdFile in mdFiles)
            {
                // citamo ceo sadrzaj datoteke u jedan string
                string text = File.ReadAllText(mdFile);
                // belezimo da li je bilo nekih promena
                bool changed = false;
                // prolazimo redom kroz sve linkove
                Regex r = new Regex(@"\[([^]]*)\]\(([^)]+)\)");
                MatchCollection matches = r.Matches(text);
                foreach (Match match in matches)
                {
                    // ekstrahujemo samo naziv navedene datoteke (zanemarujemo putanju
                    // ako je navedena u linku)
                    string fileName = Path.GetFileName(match.Groups[2].Value);
                    // ako ne znamo nista o na toj datoteci, ne menjamo link
                    if (!fileData.ContainsKey(fileName))
                        continue;
                    // podaci o linkovanoj datoteci - putanja i naslov
                    string fullPath, heading;
                    (fullPath, heading) = fileData[fileName];
                    // odredjujemo relativnu putanju u odnosu na tekucu md datoteku
                    string relPPath = Path.GetRelativePath(Path.GetDirectoryName(mdPath), fullPath);
                    text = text.Replace(match.Value, $"[{heading}]({relPath})");
                    // belezimo da je bilo promena, da bi se izmenjen tekst upisao
                    // nazad u datoteku
                    changed = true;
                }
                // ako je bilo izmena, upisujemo izmenjen tekst nazad u datoteku
                if (changed)
                    File.WriteAllText(mdFile, text);
            }

        } 
        catch (Exception e)
        {
            Console.Error.WriteLine("Greška prilikom čitanja direktorijuma");
            Console.Error.WriteLine(e.Message);
            return;
        }
    }
}
