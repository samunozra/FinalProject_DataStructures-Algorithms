﻿internal class BinaryTree<T>
{
    public Node? RootNode { get; set; }
    public int DepthCounter { get; set; }
    public int NodeCounter { get; set; }

    public BinaryTree()
    {
        RootNode = null;
    }

    public void Insert(int id, string data)
    {
        NodeCounter++;
        RootNode = InsertNode(RootNode, id, data);
    }

    public Node InsertNode(Node node, int id, string data)
    {
        if (node == null)
        {
            return new Node(id, data);
        }

        if (id < node.ID)
        {
            node.Left = InsertNode(node.Left, id, data);
        }
        else if (id > node.ID)
        {
            node.Right = InsertNode(node.Right, id, data);
        }
        else if (id == node.ID)
        {
            throw new ArgumentException($"Node with the id \"{id}\" already exists");
        }
        RebalanceTree();
        return node;
    }

    public void DeleteNode(Node target)
    {
        DeleteNode(target.ID);
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
            //Leaf
            if (currentNode.Left == null && currentNode.Right == null)
                return null;


            // 1 Child
            if (currentNode.Left == null || currentNode.Right == null)
                return currentNode.Left == null ? currentNode.Right : currentNode.Left;


            // 2 Children
            currentNode.Data = currentNode.Right.Data;
            currentNode.Right = DeleteNode(currentNode.Right, currentNode.ID);

        }

        RebalanceTree();

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
        Console.WriteLine($"ID: {node.ID}, Name: {node.Data}");
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

    public string Search(int target)
    {
        return Search(RootNode, target);
    }

    public string Search(Node node, int target)
    {
        string name = null;
        if (node == null)
        {
            return name;
        }
        DepthCounter++;

        //NODE
        if (target == node.ID)
        {
            name = node.Data;
            return name;
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
        int.TryParse(currentNode.Data, out int minValue);
        return minValue;
    }
    public int GetMaxValue()
    {
        Node result = RootNode;

        while (result.Right != null)
        {
            result = result.Right;
        }
        int.TryParse(result.Data, out int maxValue);
        return maxValue;
    }
    private int BalanceFactor(Node node)
    {
        int factor = CheckHeight(node.Left) - CheckHeight(node.Right);
        return factor;
    }
    internal void RebalanceTree()
    {
        if (BalanceFactor(RootNode) > 1)
        {
            if (BalanceFactor(RootNode.Left) > 0)
            {
                RootNode = RotateLL(RootNode);
            }
            else
            {
                RootNode = RotateLR(RootNode);
            }
        }
        else if (BalanceFactor(RootNode) < -1)
        {
            if (BalanceFactor(RootNode.Right) > 0)
            {
                RootNode = RotateLR(RootNode);
                return;
            }
            RootNode = RotateRR(RootNode);
        }
    }
    private Node RotateRR(Node parent)
    {
        Node pivot = parent.Right;
        parent.Right = pivot.Left;
        pivot.Left = parent;
        return pivot;
    }
    private Node RotateLL(Node parent)
    {
        Node pivot = parent.Left;
        parent.Left = pivot.Right;
        pivot.Right = parent;
        return pivot;
    }
    private Node RotateLR(Node parent)
    {
        Node pivot = parent.Left;
        parent.Left = RotateRR(pivot);
        return RotateLL(parent);
    }
    private Node RotateRL(Node parent)
    {
        Node pivot = parent.Right;
        parent.Right = RotateLL(pivot);
        return RotateRR(parent);
    }
}