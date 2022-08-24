using YamlDotNet.Serialization;

class Ucenik
{
    public string ime { get; set; }
    public string prezime { get; set; }
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

        var serializer = new SerializerBuilder().Build();
        var yaml = serializer.Serialize(ucenici);
        System.Console.WriteLine(yaml);
    }
}
