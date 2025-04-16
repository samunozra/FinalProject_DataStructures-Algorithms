internal class Program
{
    private static void Main(string[] args)
    {
     //TODO
    }

    internal void RandomTreeGeneration()
    {
        //TODO 
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
        int.TryParse(text, out num);

        return num;
    }
}
internal class Game
{
    internal Hero Player;
    internal Graph<Node> Map;
    internal BinarySearchTree<Node> Challenges;
    internal Node Exit;

}