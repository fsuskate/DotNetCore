using System;

namespace MyList
{
    public class Node 
    {
        public int Data { get; set; }
        public Node Next { get; set; }
        
        public Node(int data)
        {
            Data = data;
            Next = null;
        }
    }
    
    public class SinglyList
    {
        public Node Head { get; set; }
        
        public void Add(int data)
        {
            if (Head == null)
            {
                Head = new Node(data);     
                return;
            }
            
            Add(data, Head);
        }
        
        private Node Add(int data, Node node)
        {
            if (node == null)
            {
                return new Node(data);
            }
            
            node.Next = Add(data, node.Next);
            return node;
        }
        
        public int Find(int data)
        {
            if (Head == null)
            {
                return -1;
            }
            
            var current = Head;
            var position = 0;
            while (current != null)
            {
                if (current.Data == data)
                {
                    return position;
                }
                current = current.Next;
                position++;
            }
            
            return -1;
        }
        
        public int ElementAt(int index)
        {
            if (Head == null)
            {
                return -1;
            }
            
            var current = Head;
            var position = -1;
            while (current != null)
            {
                position++;
                if (position == index)
                {
                    return current.Data;
                }
                current = current.Next;
            }
            
            return -1;
        }
        
        public void PrintList()
        {
            if (Head == null)
            {
                return;
            }
            
            var current = Head;
            
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }
    }
    
    public class Program 
    {
        public static void Main()
        {
            Console.WriteLine("//// List Demo /////");
            
            var list = new SinglyList();
            Random random = new Random();
            
            for (int i = 0; i < 10; i++)
            {
                list.Add(random.Next(0, 100));
            }           
            
            list.PrintList();
            var data = list.ElementAt(4);
            Console.WriteLine("Element At Index 4 = " + list.ElementAt(4));
            Console.WriteLine($"Find Data {data} = " + list.Find(data));
        }
    }
    
}