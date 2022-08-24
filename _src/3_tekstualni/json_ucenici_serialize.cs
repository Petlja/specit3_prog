using System.Text.Json;

class Ucenik
{
    public string? ime { get; set; }
    public string? prezime { get; set; }
}

class Program
{
    public static void Main()
    {
        var ucenici = new List<Ucenik>
        {
            new Ucenik{ime = "Pera", prezime = "Peric"},
            new Ucenik{ime = "Ana", prezime = "Anic"}
        };
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(ucenici, options);
        Console.WriteLine(json);
    }
}
