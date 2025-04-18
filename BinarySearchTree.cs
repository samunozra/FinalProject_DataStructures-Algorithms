using System.Xml.Linq;

internal class BinarySearchTree<T> 
{
    public Node? RootNode { get; set; }
    public int DepthCounter { get; set; }

    public BinarySearchTree()
    {
        RootNode = null;
    }

    public void Insert(string data)
    {
        RootNode = InsertNode(RootNode, data);
    }

    public Node InsertNode(Node node, string data)
    {
        if (node == null)
        {
            return new Node(data);
        }

        if (Convert.ToInt32(data) < node.ID)
        {
            node.Left = InsertNode(node.Left, data);
        }
        else if (Convert.ToInt32(data) > node.ID)
        {
            node.Right = InsertNode(node.Right, data);
        }

        return node;
    }

    public void DeleteNode(Node target)
    {
        DeleteNode(Convert.ToInt32(target.Data));
    }

    public void DeleteNode(int target)
    {
        RootNode = DeleteNode(RootNode, target);
    }
    public Node? DeleteNode(Node currentNode, int target) //Deletes numerically
    {
        if (currentNode == null)
        {
            return currentNode;
        }

        if (target < currentNode.ID)
        {
            currentNode.Left = DeleteNode(currentNode.Left, target);//search left
        }
        else if (target > currentNode.ID)
        {
            currentNode.Right = DeleteNode(currentNode.Right, target);//search right
        }
        else
        {
            //Found the number

            //Leaf
            if (currentNode.Left == null && currentNode.Right == null)
            {
                return null;
            }

            // 1 Child
            if (currentNode.Left == null || currentNode.Right == null)
            {
                //Node? result = currentNode.Left == null ? currentNode.Right : currentNode.Left;
                return currentNode.Left == null ? currentNode.Right : currentNode.Left;
            }

            // 2 Children
            currentNode.Data = currentNode.Right.Data;
            currentNode.Right = DeleteNode(currentNode.Right, currentNode.ID);

        }

        return currentNode;
    }
    public int CheckHeight(Node? node)
    {
        if (node == null)
        {
            return 0;
        }

        int leftHeight = CheckHeight(node.Left);
        if (leftHeight == -1)
        {
            return -1;
        }

        int rightHeight = CheckHeight(node.Right);
        if (rightHeight == -1)
        {
            return -1;
        }

        if (Math.Abs(leftHeight - rightHeight) > 1)
        {
            return -1;
        }

        return Math.Max(leftHeight, rightHeight) + 1;
    }

    public void DisplayNode(Node? node)
    {
        Console.WriteLine($"Name: {node.Data}, ID: {node.ID}");
    }
    public void InOrderTraversal()
    {
        InOrderTraversal(RootNode);
    }

    public void InOrderTraversal(Node? node)
    {
        if (node == null)
        {
            return;
        }

        InOrderTraversal(node.Left);
        DisplayNode(node);
        InOrderTraversal(node.Right);
    }

    public void DescendingOrder()
    {
        DescendingOrder(RootNode);
    }
    public void DescendingOrder(Node? node)
    {
        if (node == null)
        {
            return;
        }

        DescendingOrder(node.Right);
        DisplayNode(node);
        DescendingOrder(node.Left);
    }


    public void PostOrderTraversal()
    {
        PostOrderTraversal(RootNode);
    }
    public void PostOrderTraversal(Node? node)
    {
        if (node == null)
        {
            return;
        }

        PostOrderTraversal(node.Left);
        PostOrderTraversal(node.Right);
        DisplayNode(node);
    }


    public void PreOrderTraversal()
    {
        PreOrderTraversal(RootNode);
    }
    public void PreOrderTraversal(Node? node)
    {
        if (node == null)
        {
            return;
        }

        DisplayNode(node);
        PreOrderTraversal(node.Left);
        PreOrderTraversal(node.Right);
    }

    public void LevelOrderTraversal()
    {
        if (RootNode == null)
        {
            return;
        }

        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(RootNode);

        while (queue.Count > 0)
        {
            Node current = queue.Dequeue();
            Console.WriteLine(current.Data);

            if (current.Left != null)
            {
                queue.Enqueue(current.Left);
            }
            if (current.Right != null)
            {
                queue.Enqueue(current.Right);
            }
        }
    }

    public bool Search(int target)
    {
        return Search(RootNode, target);
    }

    public bool Search(Node node, int target) //searches numerically
    {
        if (node == null)
        {
            return false;
        }
        DepthCounter++;

        //NODE
        if (target == node.ID)
        {
            DisplayNode(node);
            return true;
        }
        //LEFT
        if (target < node.ID)
        {
            return Search(node.Left, target);
        }
        //RIGHT
        else
        {
            return Search(node.Right, target);
        }
    }

    public int GetMinValue(Node? currentNode)
    {
        if (currentNode == null)
        {
            throw new ArgumentNullException(nameof(currentNode), "Tree is empty.");
        }

        while (currentNode.Left != null)
        {
            currentNode = currentNode.Left;
        }

        return Convert.ToInt32(currentNode.Data);
    }


    public int GetMaxValue()
    {
        Node result = RootNode;

        while (result.Right != null)
        {
            result = result.Right;
        }
        return Convert.ToInt32(result.Data);
    }
    internal void RebalanceTree()
    {
        if (GetMaxValue() - GetMinValue(RootNode)  <= 1 ) return; 

        //TODO



    }
}