internal class Graph<T>
{
    public Dictionary<string, List<Node>> network { get; set; }
    public Dictionary<string, List<Node>> GetNetwork() => network;

    public Graph()
    {
        network = new Dictionary<string, List<Node>>();
    }

    public void AddNode(string node)
    {
        if (network.ContainsKey(node))
        {
            Console.WriteLine($"{node} already exists.");
            return;
        }
        network[node] = new List<Node>();
        Console.WriteLine($"{node} has been added.");
    }
    public void AddNode(Node node)
    {
        if (network.ContainsKey(node.Data))
        {
            Console.WriteLine($"{node} already exists.");
            return;
        }
        network[node.Data] = new List<Node>();
        Console.WriteLine($"{node} has been added.");
    }

    public void RemoveNode(string node)
    {
        Node nameAsNode = new Node(node);
        if (network.ContainsKey(node))
        {
            foreach (var friend in network[node])
            {
                network[friend.Data].Remove(nameAsNode);
            }
            network.Remove(node);

            Console.WriteLine($"{node} has been removed.");
            return;
        }

        Console.WriteLine($"{node} does not exist.");
    }

    public void AddEdge(string node1, string node2)
    {
        DoNodesExist(node1, node2);
        Node node1AsNode = new Node(node1);
        Node node2AsNode = new Node(node2);

        if (network[node1].Contains(node2AsNode))
        {
            Console.WriteLine($"{node1} and {node2} already have an edge.");
            return;
        }

        network[node1].Add(node2AsNode);
        network[node2].Add(node1AsNode);
        Console.WriteLine($"{node1} and {node2} edge created.");
    }

    public void RemoveEdge(string node1, string node2)
    {
        DoNodesExist(node1, node2);
        Node node1AsNode = new Node(node1);
        Node node2AsNode = new Node(node2);

        if (!network[node1].Contains(node2AsNode))
        {
            Console.WriteLine($"{node1} and {node2} don't have an edge.");
            return;
        }

        network[node1].Remove(node2AsNode);
        network[node2].Remove(node1AsNode);
        Console.WriteLine($"{node1} and {node2} edge no longer exists.");
    }

    public void DisplayEdges(string node)
    {
        DoesNodeExist(node);

        if (network[node].Count() == 0)
        {
            Console.WriteLine($"{node} has no edges.");
            return;
        }

        Console.WriteLine($"{node}'s edges: {string.Join(", ", network[node])}");

    }

    private void DoesNodeExist(string node)
    {
        if (!network.ContainsKey(node))
        {
            Console.WriteLine($"Node {node} does not exist.");
            return;
        }
    }
    private void DoNodesExist(string node1, string node2)
    {
        if (!network.ContainsKey(node1) || !network.ContainsKey(node2))
        {
            Console.WriteLine("One or both nodes do not exist.");
            return;
        }
    }

    public void FindPath(string node1, string node2)
    {
        DoNodesExist(node1, node2);
        Node node1AsNode = new Node(node1);
        Node node2AsNode = new Node(node2);

        List<Node> mutualFriends = network[node1].Intersect(network[node2]).ToList();

        if (mutualFriends.Count == 0)
        {
            Console.WriteLine($"{node1} and {node2} have no mutual edges.");
            return;
        }

        Console.WriteLine($"Mutual edges of {node1} and {node2}: {string.Join(", ", mutualFriends)}.");
    }

    public bool DepthFirstSearchRecursive(string current, string target, HashSet<string> visited, List<string> path)
    {
        path.Add(current);
        visited.Add(current);

        if (current == target)
        {
            return true;
        }

        foreach (var neighbor in network[current])
        {
            if (!visited.Contains(neighbor.Data))
            {
                if (DepthFirstSearchRecursive(neighbor.Data, target, visited, path))
                {
                    return true;
                }
            }

        }

        path.Remove(current);
        return false;
    }
}