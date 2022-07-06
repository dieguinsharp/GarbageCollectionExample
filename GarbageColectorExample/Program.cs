using System;
using System.Diagnostics;
using System.Text;

namespace GarbageCollectionExample {
    internal class Program {

        static Stopwatch sw = new Stopwatch();

        static void Main (string[] args) {

            // Garbage collection is the responsible to remove all instances that are no longer being used on the application.

            // Then we avoid more memory allocation on the application because this garbage collector are a bad idea when the subject is good performance.

            //Below I show one small example the bad performance because the 'allHello' string are be relocated 50k times:

            BadCase();

            // Now using same logic but using a StringBuilder class to realize the concat.

            GoodCase();
        }

        static void BadCase () {

            string hello = "Hello";
            string allHello = "";

            var gc2 = GC.CollectionCount(2);
            var gc1 = GC.CollectionCount(1);
            var gc0 = GC.CollectionCount(0);

            sw.Start();

            for(int x = 0; x < 100000; x++) {
                allHello += " " + hello;
            }

            Console.WriteLine("Time of result: " + sw.ElapsedMilliseconds);
            Console.WriteLine("GC 1: " + (GC.CollectionCount(2) - gc2));
            Console.WriteLine("GC 2: " + (GC.CollectionCount(1) - gc1));
            Console.WriteLine("GC 3: " + (GC.CollectionCount(0) - gc0));

            Console.WriteLine();
            Console.WriteLine(" Next case ");
            Console.WriteLine();

            sw.Reset();
        }

        static void GoodCase () {

            string hello = "Hello";
            var allHello = new StringBuilder();

            var gc2 = GC.CollectionCount(2);
            var gc1 = GC.CollectionCount(1);
            var gc0 = GC.CollectionCount(0);

            sw.Start();

            for(int x = 0; x < 100000; x++) {
                allHello.Append(" " + hello);
            }

            Console.WriteLine("Time of result: " + sw.ElapsedMilliseconds);
            Console.WriteLine("GC 1: " + (GC.CollectionCount(2) - gc2));
            Console.WriteLine("GC 2: " + (GC.CollectionCount(1) - gc1));
            Console.WriteLine("GC 3: " + (GC.CollectionCount(0) - gc0));

            sw.Reset();
        }
    }
}
