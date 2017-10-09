using System;

namespace ConsoleApplication
{
    public class BubbleSort
    {
        static void bubblesortfromwiki(int[] a) {
            int n = a.Length;
            do {
                int newn = 0;
                for (var i = 1; i <= n-1; i++) {
                    if (a[i-1] > a[i]) {
                        var t = a[i-1];
                        a[i-1] = a[i];
                        a[i] = t;
                        newn = i;
                    }
                    Console.WriteLine($"//// i = {i}, n = {n} ////");
                    foreach (var y in a) {
                        Console.WriteLine(y);
                    }
                }
                n = newn;
            } while (n != 0);
        }

        static void bubblesort (int[] a) {
            for (var i = 0; i < a.Length; i++) {
                int swaps = 0;
                for (var j = 0; j < a.Length-1; j++) {
                    if (a[j] > a[j+1]) {
                        var t = a[j+1];
                        a[j+1] = a[j];
                        a[j] = t;
                        swaps++;
                    }

                    Console.WriteLine($"//// i = {i}, j = {j} ////");
                    foreach (var y in a) {
                        Console.WriteLine(y);
                    }
                }

                if (swaps == 0) {
                    break;
                }
            }
        }

        public static void Main(string[] args)
        {
            int[] arr = {8,1,16,5,3,9,0,10};
            bubblesort(arr);
            foreach (var i in arr) {
                Console.WriteLine(i);
            }
        }
    }
}
