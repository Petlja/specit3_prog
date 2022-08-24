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
        string fileName = "ucenici.json";
        string json;
        try
        {
            json = File.ReadAllText(fileName);
        } catch (Exception e)
        {
            Console.WriteLine("Greska prilikom citanja json datoteke");
            Console.WriteLine(e.Message);
            return;
        }
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
