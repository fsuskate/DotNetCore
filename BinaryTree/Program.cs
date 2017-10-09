using System;

// To execute C#, please define "static void Main" on a class
// named Solution.

namespace MyBST
{
    public class Node 
    {
        public int Data { get; set; }
        public Node Right { get; set; }
        public Node Left { get; set; }
        
        public Node(int data)
        {
            Data = data;
            Right = null;
            Left = null;
        }
    }
    
    public class BST
    {
        public enum TraverseType 
        {
            SORTED = 0,
            INORDER,
            PREORDER,
            POSTORDER,
            LEVEL
        }
        
        public Node Root { get; set; }
        
        public void Add(int data) 
        {
            if (Root == null)
            {
                Root = new Node(data);
                return;
            }
            
            Add(data, Root);
        }
        
        private Node Add(int data, Node node)
        {
            if (node == null)
            {
                node = new Node(data);
                return node;
            }
            
            if (data > node.Data)
            {
                node.Right = Add(data, node.Right);
            }
            else if (data < node.Data)
            {
                node.Left = Add(data, node.Left);
            }
            return node;            
        }
        
        public void Traverse(TraverseType type)
        {
            if (Root == null)
            {
                return;
            }
            
            switch (type)
            {
                case TraverseType.SORTED:
                    Console.WriteLine("/////// SORTED ////////");
                    Traverse(Root);
                    break;
                case TraverseType.INORDER:
                    Console.WriteLine("/////// INORDER ////////");
                    TraverseInOrder(Root);
                    break;
                case TraverseType.LEVEL:
                    Console.WriteLine("/////// LEVEL ////////");
                    TraverseLevel(Root);
                    break;
                case TraverseType.PREORDER:
                    Console.WriteLine("/////// PREORDER ////////");
                    TraversePreOrder(Root);
                    break;
                case TraverseType.POSTORDER:
                    Console.WriteLine("/////// POSTORDER ////////");
                    TraversePostOrder(Root);
                    break;
                default:
                    break;
            }
            
        }
        
        private void Traverse(Node node)
        {
            if (node == null)
            {
                return;
            }
            
            Traverse(node.Left);
            
            Console.WriteLine(node.Data);
            
            Traverse(node.Right);            
        }
        
        private void TraverseInOrder(Node node)
        {
            if (node == null)
            {
                return;
            }
            
            TraverseInOrder(node.Left);
            
            Console.WriteLine(node.Data);
            
            Traverse(node.Right);            
        }
        
        private void TraversePreOrder(Node node)
        {
            if (node == null)
            {
                return;
            }
            
            Console.WriteLine(node.Data);
            
            TraversePreOrder(node.Left);            
            
            TraversePreOrder(node.Right);            
        }
        
        private void TraversePostOrder(Node node)
        {
            if (node == null)
            {
                return;
            }
            
            Traverse(node.Left);
            
            Traverse(node.Right);            
            
            Console.WriteLine(node.Data);
            
        }
        
        private void TraverseLevel(Node node)
        {
            if (node == null)
            {
                return;
            }
            
            var height = Height();
            
            for (var i = 0; i < height; i++)
            {
                PrintLevel(node, i);
            }          
        }
        
        private void PrintLevel(Node node, int level)
        {
            if (node == null)
            {
                return;                
            }
            
            if (level == 1)
            {
                Console.WriteLine(node.Data);
            }
            else if (level > 1)
            {
                PrintLevel(node.Left, level - 1);
                PrintLevel(node.Right, level - 1);
            }
        
        }
        
        public int Height()
        {
            return Height(Root);
        }
        
        private int Height(Node node)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                var leftH = Height(node.Left);
                var rightH = Height(node.Right);
                
                if(leftH > rightH)
                {
                    return leftH + 1;
                }
                else
                {
                    return rightH + 1;
                }
            }
        }
        
    }

    class Solution
    {
        static void Main(string[] args)
        {
            var bst = new BST();

            Random random = new Random();

            for (var i = 0; i < 10; i++)
            {
                int randomNumber = random.Next(0, 100);

                bst.Add(randomNumber);
            }

            bst.Traverse(BST.TraverseType.SORTED);
            bst.Traverse(BST.TraverseType.POSTORDER);
            bst.Traverse(BST.TraverseType.PREORDER);
            bst.Traverse(BST.TraverseType.INORDER);
            bst.Traverse(BST.TraverseType.LEVEL);
            
            Console.WriteLine(bst.Height());

        }
    }
}
