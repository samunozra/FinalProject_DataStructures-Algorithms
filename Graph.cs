using System.Xml.Linq;

internal class Graph<T>
{
    public Dictionary<string, List<Node>> network { get; set; }
    public Dictionary<string, List<Node>> GetNetwork() => network;

    public Graph()
    {
        network = new Dictionary<string, List<Node>>();
    }

    public void AddUser(string name)
    {
        if (network.ContainsKey(name))
        {
            Console.WriteLine($"{name} already exists.");
            return;
        }
        network[name] = new List<Node>();
        Console.WriteLine($"{name} has been added.");
    }

    public void RemoveUser(string name)
    {
        Node nameAsNode = new Node(name);
        if (network.ContainsKey(name))
        {
            foreach (var friend in network[name])
            {
                network[friend.Data].Remove(nameAsNode);
            }
            network.Remove(name);

            Console.WriteLine($"{name} has been removed from the network.");
            return;
        }

        Console.WriteLine($"{name} does not exist.");
    }

    public void AddFriend(string user1, string user2)
    {
        DoUsersExist(user1, user2);
        Node user1AsNode = new Node(user1);
        Node user2AsNode = new Node(user2);

        if (network[user1].Contains(user2AsNode))
        {
            Console.WriteLine($"{user1} and {user2} are already friends.");
            return;
        }

        network[user1].Add(user2AsNode);
        network[user2].Add(user1AsNode);
        Console.WriteLine($"{user1} and {user2} are now friends.");
    }

    public void RemoveFriend(string user1, string user2)
    {
        DoUsersExist(user1, user2);
        Node user1AsNode = new Node(user1);
        Node user2AsNode = new Node(user2);

        if (!network[user1].Contains(user2AsNode))
        {
            Console.WriteLine($"{user1} and {user2} are not friends.");
            return;
        }

        network[user1].Remove(user2AsNode);
        network[user2].Remove(user1AsNode);
        Console.WriteLine($"{user1} and {user2} are no longer friends.");
    }

    private void DoUsersExist(string user1, string user2)
    {
        if (!network.ContainsKey(user1) || !network.ContainsKey(user2))
        {
            Console.WriteLine("One or both users do not exist.");
            return;
        }
    }

    public void DisplayFriends(string user)
    {
        DoesUserExist(user);

        if (network[user].Count() == 0)
        {
            Console.WriteLine($"{user} has no friends.");
            return;
        }

        Console.WriteLine($"{user}'s friends: {string.Join(", ", network[user])}");

    }

    private void DoesUserExist(string user)
    {
        if (!network.ContainsKey(user))
        {
            Console.WriteLine($"{user} does not exist.");
            return;
        }
    }

    public void FindMutualFriends(string user1, string user2)
    {
        DoUsersExist(user1, user2);
        Node user1AsNode = new Node(user1);
        Node user2AsNode = new Node(user2);

        List<Node> mutualFriends = network[user1].Intersect(network[user2]).ToList();

        if (mutualFriends.Count == 0)
        {
            Console.WriteLine($"{user1} and {user2} have no mutual friends.");
            return;
        }

        Console.WriteLine($"Mutual friends of {user1} and {user2}: {string.Join(", ", mutualFriends)}");
    }

    public void SuggestFriends(string user)
    {
        DoesUserExist(user);

        //var directFriends = network[user];
        //Dictionary<string> potentialFriends = new Dictionary<string>();

        //foreach (var friend in directFriends)
        //{

        //}

        //List<string> mutualFriends = network[user1].Intersect(network[user2]).ToList();
        //compare our friendlist to our friends friendlists
        //except our friend, not

        /*
         *    - Suggests friends of friends (not direct friends or the user themselves). 
         *    Sorting by most mutual friends is recommended but not required.

   - If no suggestions, outputs: "No friend suggestions for {user}."
   - Otherwise, outputs: "Friend suggestions for {user}: {suggestions}" (suggestions as "name (X mutual friends)", separated by ", ").
         */
        //TODO
    }

    public bool DepthFirstSearchRecursive(string current, string target, HashSet<string> visited, List<string> path)
    {
        path.Add(current);
        visited.Add(current);

        // Base case
        if (current == target)
        {
            return true;
        }

        // Explore all neighbors
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
