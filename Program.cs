internal class Program
{
    private static void Main(string[] args)
    {
        // Console.WriteLine("Welcome to DungeonMatters \n Enter your name to start the game:");
        // Game game= new Game(GetString());
        // game.Start();
     //TODO
    }

    internal void ReachedChallenge(Game game)
    {
        Console.WriteLine("You got to a challenge room");
        /*
        From the player's position obtain the level of difficulty of the challenge
        Choose to go back and not face the challenge

        */
        //TODO
    }
    internal static Graph<Node> RandomTreeGeneration()
    {
        Random random = new Random();
        Graph<Node> generatedTree = new Graph<Node>();

        for (int i = 0; i <= random.Next(15, 21); i++)
        {
            //create the string that sets the challenges
            Challenge r = (Challenge)(random.Next() % 3);
            string room = $"{r}{i}";
            generatedTree.AddNode(new Node(i, room));
        }
        //Store the challenge and treasure type in the node's data eg: C1 (combat, level 1)
        //combat needs strength, puzzles need intelligence, traps use agility and treasure
        //treasure won items increase base stats
            //sword > +3 attack
            //potion > +5 hp
            //wing boots > +3 agility
            //focus ring > +3 intelligence 

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
internal enum Challenge { C, P, T, I }//Combat, Puzzle, Trap, Item
