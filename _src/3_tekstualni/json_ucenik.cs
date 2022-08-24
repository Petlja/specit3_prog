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
        string json = @"{ ""ime"": ""Pera"", ""prezime"": ""Peric"" }";
        Ucenik? pera = JsonSerializer.Deserialize<Ucenik>(json);
        Console.WriteLine(pera?.ime);
        Console.WriteLine(pera?.prezime);
    }
}
