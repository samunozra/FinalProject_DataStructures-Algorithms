internal class Node
{
    internal string Data;
    internal int ID { get; set; }
    internal Node? Left { get; set; }
    internal Node? Right { get; set; }
    internal List<Node> Connections;

    internal Node() : this(-1) { }

    internal Node(int data)
    {
        Connections = new List<Node>();
        Data = data.ToString();
        ID = 0;
        Connections.Add(Left);
        Connections.Add(Right);
    }
    internal Node(string data)
    { Data = data; }
    internal Node(double data)
    { Data = data.ToString(); }
}