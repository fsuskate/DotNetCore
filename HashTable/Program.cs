using System;

namespace MyHashTable
{
    public class Dictionary
    {
        private int[] _keys;
        private string[] _values;
        private int _size;
        
        public Dictionary(int size)
        {
            _size = size;
            _keys = new int[size];
            _values = new string[size];
        }
        
        public int Add(int key, string value)
        {
            var position = GetPosition(key);
            _values[position] = value;
            return position;
        }
        
        private int GetPosition(int key)
        {
            var position = key.GetHashCode();
            position = position % _size;
            return position;
        }
        
        public string Get(int key)
        {
            var position = GetPosition(key);
            return _values[position];
        }
        
    }
    
    public class HashTable
    {
        private int[] _table;
        private int _size;
        
        public HashTable(int size)
        {
            _table = new int[size];
            _size = size;
        }
        
        public int Add(int data)
        {
            var key = data.GetHashCode();
            Console.WriteLine($"Adding {data} with key {key}");
            var position = key % _size;
            
            // TODO: handle collisions
            _table[position] = data;
            return key;
        }
        
        public int Get(int key)
        {
            return _table[key];
        }
        
    }
    
    
    public class Program 
    {
        public static void Main()
        {
            Console.WriteLine("//// List Demo /////");
            
            var ht = new HashTable(100);
            Random random = new Random();
            
            int[] keys = new int[10];
                       
            for (int i = 0; i < 10; i++)
            {
                keys[i] = ht.Add(random.Next(0, 100));
            }           
            
            foreach (int key in keys)
            {
                Console.WriteLine($"key = {key}, value = {ht.Get(key)}");
            }
            
            var dict = new Dictionary(100);
            dict.Add(keys[1], "Cisco");
            dict.Add(keys[2], "Test");
            dict.Add(keys[3], "Liz");
            dict.Add(keys[4], "Tyler");
            dict.Add(keys[5], "Fracis");
            dict.Add(keys[6], "Ahab");
            dict.Add(keys[7], "Montreal");
            dict.Add(keys[8], "Yankee");
            dict.Add(keys[9], "Potos");
            
            Console.WriteLine($"key = keys[3], value = {dict.Get(keys[3])}");
            
        }
    }
    
}