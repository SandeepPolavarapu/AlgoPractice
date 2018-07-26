using System;

namespace CodePractice.Tree
{

    class Node
    {
        public int Data;
        public Node Left, Right;

        public Node(int data)
        {
            Data = data;
            Left = Right = null;
        }
    }
    class Tree
    {
        public Node Root;

        public int Height(Node node)
        {
            if (node == null)
                return 0;

            return 1 + Math.Max(Height(node.Left), Height(node.Right));
        }

        private int Diameter(Node node)
        {
            if (node == null)
                return 0;

            return Math.Max(1 + Height(node.Left) + Height(node.Right), Math.Max(Diameter(node.Left), Diameter(node.Right)));

        }

        public int Diameter()
        {
            return Diameter(Root);
        }

        private void PrintGivenLevel(Node root, int level)
        {
            if (root == null)
                return;
            if (level == 1)
                Console.Write(root.Data + " ");
            else if (level > 1)
            {
                PrintGivenLevel(root.Left, level - 1);
                PrintGivenLevel(root.Right, level - 1);
            }
        }

        public void PrintLevelOrder()
        {
            int h = Height(Root);
            int i;
            for (i = 1; i <= h; i++)
                PrintGivenLevel(Root, i);
        }

        public void PreOrder(Node root)
        {
            if (root == null)
                return;
            Console.Write(root.Data + " ");
            PreOrder(root.Left);
            PreOrder(root.Right);
        }

        public void InOrder(Node root)
        {
            if (root == null)
                return;
            InOrder(root.Left);
            Console.Write(root.Data + " ");
            InOrder(root.Right);
        }

        public void PostOrder(Node root)
        {
            if (root == null)
                return;
            PostOrder(root.Left);
            PostOrder(root.Right);
            Console.Write(root.Data + " ");
        }

        public Node Mirror(Node node)
        {
            if (node == null)
                return node;
            Node left = Mirror(node.Left);
            Node Right = Mirror(node.Right);

            node.Left = Right;
            node.Right = left;

            return node;
        }
    }

    class TreeExt
    {
        public static void Execute()
        {
            Tree tree = new Tree();
            tree.Root = new Node(1);
            tree.Root.Left = new Node(2);
            tree.Root.Right = new Node(3);
            tree.Root.Left.Left = new Node(4);
            tree.Root.Left.Right = new Node(5);

            Console.WriteLine("Tree Diameter is : {0}", tree.Diameter());

            Console.WriteLine("Level Order Traversal is : ");
            tree.PrintLevelOrder();

            Console.WriteLine("\nPreOrder Recursive Traversal is : ");
            tree.PreOrder(tree.Root);

            Console.WriteLine("\nPreOrder Iterative Traversal is : ");
            TreeTraversalIterative.PreOrder(tree.Root);

            Console.WriteLine("\nPostOrder Recursive Traversal is : ");
            tree.PostOrder(tree.Root);

            Console.WriteLine("\nPostOrder Iterative Traversal is : ");
            TreeTraversalIterative.PostOrder(tree.Root);

            Console.WriteLine("\nPostOrder Iterative Traversal with one stack is : ");
            TreeTraversalIterative.PostOrderWithOneStack(tree.Root);

            Console.WriteLine("\nInOrder Recursive Traversal is : ");
            tree.InOrder(tree.Root);

            Console.WriteLine("\nInOrder Iterative Traversal is : ");
            TreeTraversalIterative.InOrder(tree.Root);

            Console.WriteLine("\nInOrder Traversal of Mirror : ");
            tree.Mirror(tree.Root);
            tree.InOrder(tree.Root);


        }
    }
}
