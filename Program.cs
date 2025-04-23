internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome to DungeonMatters \n Enter your name to start the game:");
        Game game= new Game(GetString());
        game.Start();
     //TODO
    }

    internal static Graph<Node> RandomTreeGeneration()
    {
        Random random = new Random();
        Graph<Node> generatedTree = new Graph<Node>();

        for (int i = 0; i <= random.Next(15, 21); i++)
        {
            generatedTree.AddNode(new Node($"{(char)i}"));
        }

        //TODO 

        return generatedTree;
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
    public static string GetString()
    {
        string text = Console.ReadLine();
        if (text == null)
        {
            Console.WriteLine("No number entered, try again");
            text = GetString();
        }
        return text;
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
    internal void Start()
    {

    }
}