internal class Program
{
    private static void Main(string[] args)
    {
        ConsoleKey presedKey;
        Console.WriteLine("Welcome to DungeonMatters \n Enter your name to start the game:");
        string name = GetString();
        Console.WriteLine($"You are {name}, a hero of the kingdom\n"
        + "\nYou have been tasked by the King to explore this randomly generated dungon");
        Game game = new Game(name);
        //TODO
    }
    internal void DropItem(Game game)
    {
        string keyPress;
        if (game.Player.Inventory.Count < 0 || game.Player.Inventory.Count == null)
        {
            Console.WriteLine($"{game.Player.HeroName}'s inventory is empty");
            return;
        }
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        game.Player.DisplayInventory();
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine($"Would you like to drop {game.Player.Inventory.First()}? Type Y/N, then press Enter");
        do
        {
            keyPress = GetString().ToLower();
        } while (keyPress != "y" || keyPress != "n");
        switch (keyPress)
        {
            case "y":
                Console.WriteLine($"You discarded {game.Player.Inventory.First()}");
                switch (game.Player.Inventory.First())
                {
                    case "shield":
                        game.Player.Strength = -2;
                        break;
                    case "sword":
                        game.Player.Strength = -3;
                        break;
                    case "speed necklace":
                        game.Player.Agility = -2;
                        break;
                    case "wing set":
                        game.Player.Agility = -3;
                        break;
                    case "lockpick":
                        game.Player.Intelligence = -2;
                        break;
                    case "focus ring":
                        game.Player.Intelligence = -3;
                        break;
                }
                game.Player.Inventory.Dequeue();
                break;
            case "n":
                break;

        }

    }

    internal bool ReachedChallenge(Game game)
    {
        /*
        From the player's position obtain the level of difficulty of the challenge
        Choose to go back and not face the challenge
        Items: choose to pick up, but pass anyway
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
                passed = PuzzleChallenge(game, difficulty);
                break;

            case 'T':
                passed = TrapChallenge(game, difficulty);
                break;

            case 'I':
                passed = ItemChallenge(game, difficulty);
                break;
        }
        Console.ForegroundColor = ConsoleColor.Gray;
        return passed;
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
                        Console.WriteLine($"You lost, -{4 / 2} HP");
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
                        Console.WriteLine($"You lost, -{5 / 2} HP");
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
                        Console.WriteLine($"You lost, -{6 / 2} HP");
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
                        Console.WriteLine($"You lost, -{7 / 2} HP");
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
                        Console.WriteLine($"You lost, -{8 / 2} HP");
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
                        Console.WriteLine($"You lost, -{9 / 2} HP");
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
                        Console.WriteLine($"You lost, -{10 / 2} HP");
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
    internal bool TrapChallenge(Game game, int difficulty)
    {
        string keyPress;
        bool challengePassed = false;
        switch (difficulty)
        {
            default:
            case 0:
                Console.WriteLine("You almost trip on a tripwire \n Would you like to try crossing or go back? type: (T/B) then Enter");
                keyPress = GetString().ToLower();
                if ("t" == keyPress)
                {
                    if (game.Player.Agility >= 4)
                    {
                        challengePassed = true;
                        Console.WriteLine("You passed!");
                    }
                    else
                    {
                        game.Player.Health -= 4 / 2;
                        Console.WriteLine($"You activated the trap and lost -{4 / 2} HP");
                    }
                }
                else if ("b" == keyPress)
                {
                    challengePassed = false;
                }

                break;

            case 1:
                Console.WriteLine("You notice a differently colored tile \n Would you like to try or go back? type: (T/B) then Enter");
                keyPress = GetString().ToLower();
                if ("t" == keyPress)
                {
                    if (game.Player.Agility >= 5)
                    {
                        challengePassed = true;
                        Console.WriteLine("You won!");
                    }
                    else
                    {
                        game.Player.Health -= 5 / 2;
                        Console.WriteLine($"You activated it lost -{5 / 2} HP");
                    }
                }
                else if ("b" == keyPress)
                {
                    challengePassed = false;
                }
                break;

            case 2:
                Console.WriteLine("You notice that this room has spiked walls and ceiling \n Would you like to try going through or go back? type: (T/B) then Enter");
                keyPress = GetString().ToLower();
                if ("t" == keyPress)
                {
                    if (game.Player.Agility >= 6)
                    {
                        challengePassed = true;
                        Console.WriteLine("You passed!");
                    }
                    else
                    {
                        game.Player.Health -= 6 / 2;
                        Console.WriteLine($"You almost got crushed and lost -{6 / 2} HP");
                    }
                }
                else if ("b" == keyPress)
                {
                    challengePassed = false;
                }
                break;

            case 3:
            case 4:
                Console.WriteLine("You stumble into a hole in the ground \n Would you like to try or go back? type: (T/B) then Enter");
                keyPress = GetString().ToLower();
                if ("t" == keyPress)
                {
                    if (game.Player.Agility >= 7)
                    {
                        challengePassed = true;
                        Console.WriteLine("You passed!");
                    }
                    else
                    {
                        game.Player.Health -= 7 / 2;
                        Console.WriteLine($"You almost fell into the hole lost -{7 / 2} HP, and managed to recover");
                    }
                }
                else if ("b" == keyPress)
                {
                    challengePassed = false;
                }
                break;

            case 5:
                Console.WriteLine("You encounter a mimic blocking your path \n Would you like to try and check or go back? type: (T/B) then Enter");
                keyPress = GetString().ToLower();
                if ("t" == keyPress)
                {
                    if (game.Player.Agility >= 8)
                    {
                        challengePassed = true;
                        Console.WriteLine("You passed!");
                    }
                    else
                    {
                        game.Player.Health -= 8 / 2;
                        Console.WriteLine($"You lost, -{8 / 2} HP");
                    }
                }
                else if ("b" == keyPress)
                {
                    challengePassed = false;
                }
                break;

            case 6:
                Console.WriteLine("You find yourself after a long chain that needs to be crossed \n Would you like to try or go back? type: (T/B) then Enter");
                keyPress = GetString().ToLower();
                if ("f" == keyPress)
                {
                    if (game.Player.Agility >= 9)
                    {
                        challengePassed = true;
                        Console.WriteLine("You won!");
                    }
                    else
                    {
                        game.Player.Health -= 9 / 2;
                        Console.WriteLine($"You fell, -{9 / 2} HP");
                    }
                }
                else if ("b" == keyPress)
                {
                    challengePassed = false;
                }
                break;

            case 7:
                Console.WriteLine("You encounter timing stones \n Would you like to try or go back? type: (T/B) then Enter");
                keyPress = GetString().ToLower();
                if ("t" == keyPress)
                {
                    if (game.Player.Strength >= 10)
                    {
                        challengePassed = true;
                        Console.WriteLine("You won!");
                    }
                    else
                    {
                        game.Player.Health -= 10 / 2;
                        Console.WriteLine($"You fell hard and lost -{10 / 2} HP");
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
    internal bool ItemChallenge(Game game, int difficulty)
    {
        string keyPress;
        switch (difficulty)
        {
            default:
            case 0:
                Console.WriteLine("You find a potion");
                game.Player.Health = 25;
                Console.WriteLine("Health recovered and increased to 25");
                break;

            case 1:
                string item = "shield";
                Console.WriteLine($"You find a {item} \n Would you like to pick it up? type: (Y/N) then Enter");
                keyPress = GetString().ToLower();
                if ("y" == keyPress)
                {
                    if (game.Player.Inventory.Count > 5)
                    {
                        game.Player.Inventory.Enqueue(item);
                        Console.WriteLine($"Picked up {item}");
                        game.Player.Strength += 2;
                    }
                    else
                    {
                        Console.WriteLine("Inventory full");
                    }
                }
                else if ("n" == keyPress)
                {
                    Console.WriteLine($"You didn't pick up the {item}");
                }
                break;

            case 2:
                item = "speed necklace";
                Console.WriteLine($"You find a {item} \n Would you like to pick it up? type: (Y/N) then Enter");
                keyPress = GetString().ToLower();
                if ("y" == keyPress)
                {
                    if (game.Player.Inventory.Count > 5)
                    {
                        game.Player.Inventory.Enqueue(item);
                        Console.WriteLine($"Picked up {item}");
                        game.Player.Agility += 2;
                    }
                    else
                    {
                        Console.WriteLine("Inventory full");
                    }
                }
                else if ("n" == keyPress)
                {
                    Console.WriteLine($"You didn't pick up the {item}");
                }
                break;

            case 3:
                item = "lockpick";
                Console.WriteLine($"You find a {item} \n Would you like to pick it up? type: (Y/N) then Enter");
                keyPress = GetString().ToLower();
                if ("y" == keyPress)
                {
                    if (game.Player.Inventory.Count > 5)
                    {
                        game.Player.Inventory.Enqueue(item);
                        Console.WriteLine($"Picked up {item}");
                        game.Player.Intelligence += 2;
                    }
                    else
                    {
                        Console.WriteLine("Inventory full");
                    }
                }
                else if ("n" == keyPress)
                {
                    Console.WriteLine($"You didn't pick up the {item}");
                }
                break;
            case 4:
                item = "wing set";
                Console.WriteLine($"You find a {item} \n Would you like to pick it up? type: (Y/N) then Enter");
                keyPress = GetString().ToLower();
                if ("y" == keyPress)
                {
                    if (game.Player.Inventory.Count > 5)
                    {
                        game.Player.Inventory.Enqueue(item);
                        Console.WriteLine($"Picked up {item}");
                        game.Player.Agility += 3;
                    }
                    else
                    {
                        Console.WriteLine("Inventory full");
                    }
                }
                else if ("n" == keyPress)
                {
                    Console.WriteLine($"You didn't pick up the {item}");
                }
                break;

            case 5:
                item = "sword";
                Console.WriteLine($"You find a {item} \n Would you like to pick it up? type: (Y/N) then Enter");
                keyPress = GetString().ToLower();
                if ("y" == keyPress)
                {
                    if (game.Player.Inventory.Count > 5)
                    {
                        game.Player.Inventory.Enqueue(item);
                        Console.WriteLine($"Picked up {item}");
                        game.Player.Strength += 3;
                    }
                    else
                    {
                        Console.WriteLine("Inventory full");
                    }
                }
                else if ("n" == keyPress)
                {
                    Console.WriteLine($"You didn't pick up the {item}");
                }
                break;

            case 6:
                item = "focus ring";
                Console.WriteLine($"You find a {item} \n Would you like to pick it up? type: (Y/N) then Enter");
                keyPress = GetString().ToLower();
                if ("y" == keyPress)
                {
                    if (game.Player.Inventory.Count > 5)
                    {
                        game.Player.Inventory.Enqueue(item);
                        Console.WriteLine($"Picked up {item}");
                        game.Player.Intelligence += 3;
                    }
                    else
                    {
                        Console.WriteLine("Inventory full");
                    }
                }
                else if ("n" == keyPress)
                {
                    Console.WriteLine($"You didn't pick up the {item}");
                }
                break;
        }
        return true;
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
        //wing set > +3 agility
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
        }
        string[] keysArray = generatedGraph.network.Keys.ToArray();

        int n = keysArray.Length; // array randomizer
        while (n > 1)
        {
            int k = random.Next(n--);
            string temp = keysArray[n];
            keysArray[n] = keysArray[k];
            keysArray[k] = temp;
        }

        for (int i = 0; i < keysArray.Length; i++)
        {
            generatedGraph.AddEdge(keysArray[i], keysArray[i + 1]);
        }
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
internal enum Challenge { Combat, Puzzle, Trap, Item }
