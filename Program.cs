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

    internal bool ReachedChallenge(Game game)
    {
        /*
        From the player's position obtain the level of difficulty of the challenge
        Choose to go back and not face the challenge

        */
        string challenge = game.Challenges.Search(game.CurrentNode.ID);
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine($"You got to challenge room: {challenge}");
        int difficulty = int.Parse($"{challenge[^1]}{challenge[^2]}");
        difficulty = difficulty / 3;
        bool passed = false;
        switch (challenge[0])
        {
            case 'C':
                passed = CombatChallenge(game, difficulty);
                break;

            case 'P':
                PuzzleChallenge(game, difficulty);
                break;

            case 'T':
                TrapChallenge(game, difficulty);
                break;

            case 'I':
                ItemChallenge(game, difficulty);
                break;
        }
        Console.ForegroundColor = ConsoleColor.Gray;
        return passed;
        //TODO
    }
    internal bool CombatChallenge(Game game, int difficulty)
    {
        string keyPress;
        bool challengePassed = false;
        switch (difficulty)
        {
            default:
            case 0:
                Console.WriteLine("You encounter some bats \n Would you like to go fight or go back? type: (F/B) then Enter");
                keyPress = GetString().ToLower();
                if ("f" == keyPress)
                {
                    if (game.Player.Strength >= 4)
                    {
                        challengePassed = true;
                        Console.WriteLine("You won!");
                    }
                    else
                    {
                        game.Player.Health -= 4 / 2;
                        Console.WriteLine($"You lost, -{4/2} HP");
                    }
                }
                else if ("b" == keyPress)
                {
                    challengePassed = false;
                }

                break;

            case 1:
                Console.WriteLine("You encounter a bunny monster \n Would you like to go fight or go back? type: (F/B) then Enter");
                keyPress = GetString().ToLower();
                if ("f" == keyPress)
                {
                    if (game.Player.Strength >= 5)
                    {
                        challengePassed = true;
                        Console.WriteLine("You won!");
                    }
                    else
                    {
                        game.Player.Health -= 5 / 2;
                        Console.WriteLine($"You lost, -{5/2} HP");
                    }
                }
                else if ("b" == keyPress)
                {
                    challengePassed = false;
                }
                break;

            case 2:
                Console.WriteLine("You encounter a giant spider \n Would you like to go fight or go back? type: (F/B) then Enter");
                keyPress = GetString().ToLower();
                if ("f" == keyPress)
                {
                    if (game.Player.Strength >= 6)
                    {
                        challengePassed = true;
                        Console.WriteLine("You won!");
                    }
                    else
                    {
                        game.Player.Health -= 6 / 2;
                        Console.WriteLine($"You lost, -{6/2} HP");
                    }
                }
                else if ("b" == keyPress)
                {
                    challengePassed = false;
                }
                break;

            case 3:
            case 4:
                Console.WriteLine("You encounter some skeletons \n Would you like to go fight or go back? type: (F/B) then Enter");
                keyPress = GetString().ToLower();
                if ("f" == keyPress)
                {
                    if (game.Player.Strength >= 7)
                    {
                        challengePassed = true;
                        Console.WriteLine("You won!");
                    }
                    else
                    {
                        game.Player.Health -= 7 / 2;
                        Console.WriteLine($"You lost, -{7/2} HP");
                    }
                }
                else if ("b" == keyPress)
                {
                    challengePassed = false;
                }
                break;

            case 5:
                Console.WriteLine("You encounter some zombies \n Would you like to go fight or go back? type: (F/B) then Enter");
                keyPress = GetString().ToLower();
                if ("f" == keyPress)
                {
                    if (game.Player.Strength >= 8)
                    {
                        challengePassed = true;
                        Console.WriteLine("You won!");
                    }
                    else
                    {
                        game.Player.Health -= 8 / 2;
                        Console.WriteLine($"You lost, -{8/2} HP");
                    }
                }
                else if ("b" == keyPress)
                {
                    challengePassed = false;
                }
                break;

            case 6:
                Console.WriteLine("You encounter a chimera \n Would you like to go fight or go back? type: (F/B) then Enter");
                keyPress = GetString().ToLower();
                if ("f" == keyPress)
                {
                    if (game.Player.Strength >= 9)
                    {
                        challengePassed = true;
                        Console.WriteLine("You won!");
                    }
                    else
                    {
                        game.Player.Health -= 9 / 2;
                        Console.WriteLine($"You lost, -{9/2} HP");
                    }
                }
                else if ("b" == keyPress)
                {
                    challengePassed = false;
                }
                break;

            case 7:
                Console.WriteLine("You encounter the minotaur \n Would you like to go fight or go back? type: (F/B) then Enter");
                keyPress = GetString().ToLower();
                if ("f" == keyPress)
                {
                    if (game.Player.Strength >= 10)
                    {
                        challengePassed = true;
                        Console.WriteLine("You won!");
                    }
                    else
                    {
                        game.Player.Health -= 10 / 2;
                        Console.WriteLine($"You lost, -{10/2} HP");
                    }
                }
                else if ("b" == keyPress)
                {
                    challengePassed = false;
                }
                break;

        }
        return challengePassed;
    }
    internal bool PuzzleChallenge(Game game, int difficulty)
    {
        string keyPress;
        bool challengePassed = false;
        switch (difficulty)
        {
            default:
            case 0:
                Console.WriteLine("You encounter a locked door \n Would you like to go try or go back? type: (T/B) then Enter");
                keyPress = GetString().ToLower();
                if ("t" == keyPress)
                {
                    if (game.Player.Intelligence >= 4)
                    {
                        challengePassed = true;
                        Console.WriteLine("You passed!");
                    }
                    else
                    {
                        Console.WriteLine("You failed!");
                    }
                }
                else if ("b" == keyPress)
                {
                    challengePassed = false;
                }

                break;

            case 1:
                Console.WriteLine("You stumble upon a broken bridge \n Would you like to go try or go back? type: (T/B) then Enter");
                keyPress = GetString().ToLower();
                if ("t" == keyPress)
                {
                    if (game.Player.Intelligence >= 5)
                    {
                        challengePassed = true;
                        Console.WriteLine("You passed!");
                    }
                    else
                    {
                        Console.WriteLine("You failed!");
                    }
                }
                else if ("b" == keyPress)
                {
                    challengePassed = false;
                }
                break;

            case 2:
                Console.WriteLine("You find a broken key \n Would you like to try and fix it or go back? type: (T/B) then Enter");
                keyPress = GetString().ToLower();
                if ("t" == keyPress)
                {
                    if (game.Player.Intelligence >= 6)
                    {
                        challengePassed = true;
                        Console.WriteLine("You passed!");
                    }
                    else
                    {
                        Console.WriteLine("You failed!");
                    }
                }
                else if ("b" == keyPress)
                {
                    challengePassed = false;
                }
                break;

            case 3:
                Console.WriteLine("You are blocked by a lever puzzle \n Would you like to try or go back? type: (T/B) then Enter");
                keyPress = GetString().ToLower();
                if ("t" == keyPress)
                {
                    if (game.Player.Intelligence >= 7)
                    {
                        challengePassed = true;
                        Console.WriteLine("You passed!");
                    }
                    else
                    {
                        Console.WriteLine("You failed!");
                    }
                }
                else if ("b" == keyPress)
                {
                    challengePassed = false;
                }
                break;

            case 4:
            case 5:
                Console.WriteLine("You encounter a doubly locked door \n Would you like to try or go back? type: (T/B) then Enter");
                keyPress = GetString().ToLower();
                if ("t" == keyPress)
                {
                    if (game.Player.Intelligence >= 8)
                    {
                        challengePassed = true;
                        Console.WriteLine("You passed!");
                    }
                    else
                    {
                        Console.WriteLine("You failed!");
                    }
                }
                else if ("b" == keyPress)
                {
                    challengePassed = false;
                }
                break;

            case 6:
                Console.WriteLine("You are blocked by a sphinx \n Would you like to try or go back? type: (T/B) then Enter");
                keyPress = GetString().ToLower();
                if ("f" == keyPress)
                {
                    if (game.Player.Intelligence >= 9)
                    {
                        challengePassed = true;
                        Console.WriteLine("You passed!");
                    }
                    else
                    {
                        Console.WriteLine("You failed!");
                    }
                }
                else if ("b" == keyPress)
                {
                    challengePassed = false;
                }
                break;

            case 7:
                Console.WriteLine("You stumble upon a chess puzzle \n Would you like to try or go back? type: (T/B) then Enter");
                keyPress = GetString().ToLower();
                if ("f" == keyPress)
                {
                    if (game.Player.Intelligence >= 10)
                    {
                        challengePassed = true;
                        Console.WriteLine("You passed!");
                    }
                    else
                    {
                        Console.WriteLine("You failed!");
                    }
                }
                else if ("b" == keyPress)
                {
                    challengePassed = false;
                }
                break;

        }
        return challengePassed;
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
        //sword > +3 strength
        //shield > +2 strength
        //potion > +5 hp
        //wing boots > +3 agility
        //speed necklace > +2 agility
        //focus ring > +3 intelligence 
        //lockpick > +2 intelligence

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
            Console.WriteLine("Nothing entered, try again");
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
    internal Node CurrentNode = new();
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
