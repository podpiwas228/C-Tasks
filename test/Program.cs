class Program
{
    static void Main (string[] args)
    {
        string a = File.ReadAllText("test.txt");
        Console.WriteLine(a);
    }
}