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
