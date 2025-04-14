internal class Node
{
    internal string Data;
    internal List<Node> Conections;

    internal Node() : this(-1) { }

    internal Node(int data)
    {
        Data = data.ToString();
    }
    internal Node(string data)
    { Data = data; }
    internal Node(double data)
    { Data = data.ToString(); }
}