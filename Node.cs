internal class Node
{
    internal string Data;
    internal int ID { get; set; }
    internal Node? Left { get; set; }
    internal Node? Right { get; set; } 
    internal List<Node> Conections;

    internal Node() : this(-1) { }

    internal Node(int data)
    {
        Data = data.ToString();
        ID = 0;
    }
    internal Node(string data)
    { Data = data; }
    internal Node(double data)
    { Data = data.ToString(); }
}