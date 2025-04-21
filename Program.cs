internal class Program
{
    private static void Main(string[] args)
    {
     //TODO
    }

    internal static Graph<Node> RandomTreeGeneration()
    {
        //TODO 

        return new Graph<Node>();
    }
    public static int GetInt32()
    {
        string text = Console.ReadLine();
        int num;
        if (text == null)
        {
            Console.WriteLine("No number entered, try again");
            num = GetInt32();
        }
        if (!int.TryParse(text, out num))
        {
            num = GetInt32();
        }
        return num;
    }
}
internal class Game
{
    internal Hero Player;
    internal Graph<Node> Map;
    internal BinarySearchTree<Node> Challenges;
    internal Node Exit;

    internal Game() : this("The Chosen One") {}

    internal Game(string name)
    {
        Player = new Hero(name);
        Map = Program.RandomTreeGeneration(); //TODO
        Challenges = new BinarySearchTree<Node>();
        //TODO add Exit to the constructor
    }
    
}