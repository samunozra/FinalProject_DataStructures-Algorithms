internal class Node
{
    internal string Data;
    private int NextID;
    internal int ID { get; set; }
    //not implement4ed properly in BST and Graph classes
    internal Node? Left { get; set; }
    internal Node? Right { get; set; }
    internal List<Node> Connections;

    internal Node() : this(0) { }

    internal Node(int id)
    {
        Data = "";
        ID = id;
        NextID = id++;
        Connections = [Left, Right];
    }
    internal Node(int id, string data)
    {
        Data = data;
        ID = id;
    }
    internal Node(string data)
    {
        Data = data;
        ID = NextID;
        NextID++;
    }
}