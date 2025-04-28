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
        Random rand = new();
        Player = new Hero(name);
        Challenges = Program.RandomTreeGeneration();
        Map = Program.RandomGraphGeneration(Challenges.NodeCounter);
        CurrentNode = Map.network["A"][0];
        string tempRoom = Map.network.Keys.ToArray()[rand.Next(Map.network.Keys.Count)];
        Exit = Map.network[tempRoom][0];
    }
    internal Node PlayerMove(List<Node> edges, string nodeName)
    {
        Node node = new Node(nodeName);
        Node target = new Node();
        if (edges.Contains(node))
        {
            target = node;
            CurrentNode = target;
        }
        else 
        {
            Console.WriteLine("Cannot move to the selected node");
        }
        return target;
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
