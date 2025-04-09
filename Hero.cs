internal class Hero
{
    internal string Name { get => _name; }
    internal int Strength { get; set; }
    internal int Agility { get; set; }
    internal int Intelligence { get; set; }
    internal int Health { get; set; }
    internal Stack<Node> Visited { get; set; }
    internal Queue<string> Inventory { get; }
    private string _name;

    internal Hero() { }
    internal Hero(string name)
    { _name = name; }
}
