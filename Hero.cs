internal class Hero
{
    internal string HeroName { get => _name; }
    internal int Strength { get; set; }
    internal int Agility { get; set; }
    internal int Intelligence { get; set; }
    internal int Health { get; set; }
    internal Stack<Node> Visited { get; set; }
    internal Queue<string> Inventory { get; }
    private string _name;

    internal Hero() : this("The Chosen One") { }
    internal Hero(string name)
    { 
        _name = name; 
        Health = 20;
        Strength = 5;
        Agility = 5;
        Intelligence = 5;
        Visited = new Stack<Node>();
        Inventory = new Queue<string>();
    }
    internal void AddItem(string name)
    {
        if (Inventory.Count >= 5)
        {
            Console.WriteLine($"Inventory is full, cannot add {name}.");
            return;
        }
        Inventory.Enqueue(name);
    }

    internal void RemoveItem()
    {
        if (Inventory.Count == 0)
        {
            Console.WriteLine($"{HeroName}'s Inventory is empty");
            return;
        }
        Inventory.Dequeue();
    }
    internal void DisplayInventory()
    {
        if (Inventory.Count == 0)
        {
            Console.WriteLine($"{HeroName}'s Inventory is empty");
            return;
        }
        
            Console.WriteLine($"Inventory: {string.Join("\n- ", Inventory)}");
    }

}
