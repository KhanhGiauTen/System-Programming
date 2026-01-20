using System;
using System.Diagnostics;

namespace Question_02
{
    internal class Program
    {
        const int SIZE = 1_000_000; 

        static void Main(string[] args)
        {
            Console.WriteLine($"--- Question 2: Memory & Speed Test (N = {SIZE:N0}) ---");

            // --- 1. TEST CLASS (REFERENCE TYPE) ---
            GC.Collect();
            GC.WaitForPendingFinalizers();
            long initialMemory = GC.GetTotalMemory(true);

            PointClass[] classArray = new PointClass[SIZE];
            for (int i = 0; i < SIZE; i++)
            {
                classArray[i] = new PointClass(i, i);
            }

            long finalMemory = GC.GetTotalMemory(true);
            long classMemoryUsage = finalMemory - initialMemory;

            Console.WriteLine($"\n[Class Array]");
            Console.WriteLine($"Memory Used: {classMemoryUsage / 1024 / 1024} MB");

            Stopwatch sw = Stopwatch.StartNew();
            long sumClass = 0;
            for (int i = 0; i < SIZE; i++)
            {
                sumClass += classArray[i].X;
            }
            sw.Stop();
            Console.WriteLine($"Access Time: {sw.ElapsedMilliseconds} ms (Sum: {sumClass})");

            // --- DỌN DẸP BỘ NHỚ ---
            classArray = null; 
            GC.Collect();
            GC.WaitForPendingFinalizers();

            // --- 2. TEST STRUCT ---
            initialMemory = GC.GetTotalMemory(true);
            PointStruct[] structArray = new PointStruct[SIZE];
            for (int i = 0; i < SIZE; i++)
            {
                structArray[i] = new PointStruct(i, i);
            }

            finalMemory = GC.GetTotalMemory(true);
            long structMemoryUsage = finalMemory - initialMemory;

            Console.WriteLine($"\n[Struct Array]");
            Console.WriteLine($"Memory Used: {structMemoryUsage / 1024 / 1024} MB");

            sw.Restart();
            long sumStruct = 0;
            for (int i = 0; i < SIZE; i++)
            {
                sumStruct += structArray[i].X;
            }
            sw.Stop();
            Console.WriteLine($"Access Time: {sw.ElapsedMilliseconds} ms (Sum: {sumStruct})");

            Console.ReadKey();
        }
    }

    public struct PointStruct
    {
        public int X, Y;
        public PointStruct(int x, int y) { X = x; Y = y; }
    }

    public class PointClass
    {
        public int X, Y;
        public PointClass(int x, int y) { X = x; Y = y; }
    }
}