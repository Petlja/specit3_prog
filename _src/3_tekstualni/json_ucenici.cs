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
        string json = @"[{ ""ime"": ""Pera"", ""prezime"": ""Peric"" },
                         { ""ime"": ""Ana"", ""prezime"": ""Anic"" }]";
        IList<Ucenik?>? ucenici = JsonSerializer.Deserialize<IList<Ucenik?>>(json);
        if (ucenici != null)
        {
            foreach (Ucenik? u in ucenici)
            {
                Console.WriteLine(u?.ime);
                Console.WriteLine(u?.prezime);
            }
        }
    }
}
