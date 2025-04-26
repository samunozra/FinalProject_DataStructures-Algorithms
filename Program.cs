internal class Program
{
    private static void Main(string[] args)
    {
        ConsoleKey presedKey;
        Console.WriteLine("Welcome to DungeonMatters \n Enter your name to start the game:");
        Game game = new Game(GetString());
        // game.Start();
        //TODO
    }

    internal void ReachedChallenge(Game game)
    {
        /*
        From the player's position obtain the level of difficulty of the challenge
        Choose to go back and not face the challenge

        */
        // string challenge = game.Challenges.Search(game.Map.CurrentNode());

        Console.WriteLine("You got to a challenge room");

        //TODO
    }
    internal static BinaryTree<Node> RandomTreeGeneration()
    {
        Random random = new Random();
        BinaryTree<Node> generatedTree = new BinaryTree<Node>();

        for (int i = 0; i <= random.Next(15, 21); i++)
        {
            //create the string that sets the challenges
            Challenge r = (Challenge)(random.Next() % 3);
            string room = $"{r}{i:##}";
            generatedTree.Insert(i, room);
        }
        //Store the challenge and treasure type in the node's data eg: Combat01 
        //combat needs strength, puzzles need intelligence, traps use agility and treasure
        //treasure won items increase base stats
        //sword > +3 attack
        //potion > +5 hp
        //wing boots > +3 agility
        //focus ring > +3 intelligence 

        return generatedTree;
    }
    internal static Graph<Node> RandomGraphGeneration(int nodeNumber)
    {
        Random random = new();
        Graph<Node> generatedGraph = new();
        for (int i = 0; i < nodeNumber; i++)
        {
            string room = $"{(char)i}";
            generatedGraph.AddNode(room);
        } //TODO
        return generatedGraph;
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
    internal BinaryTree<Node> Challenges;
    Node CurrentNode = new();
    internal Node Exit;

    internal Game() : this("The Chosen One") { }

    internal Game(string name)
    {
        Player = new Hero(name);
        Challenges = Program.RandomTreeGeneration();
        Map = Program.RandomGraphGeneration(Challenges.NodeCounter);
        CurrentNode = Map.network["A"][0];
        //TODO add Exit to the constructor
    }
    internal void Start()
    {

    }
    internal bool EndGame()
    {
        bool endCheck = false;
        if (Exit == CurrentNode || Player.Health == 0)
        {
            endCheck = true;
        }
        
        return endCheck;
    }
}
internal enum Challenge { Combat, Puzzle, Trap, Item }
