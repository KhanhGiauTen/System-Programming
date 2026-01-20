using System;

namespace Question_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PointStruct ps1 = new PointStruct(1, 2);
            PointClass pc1 = new PointClass(1, 2);

            PointStruct ps2 = ps1; 
            PointClass pc2 = pc1;  

            ps2.X = 10;
            pc2.X = 10;

            Console.WriteLine($"Original Struct (ps1): {ps1.X}"); 
            Console.WriteLine($"Copied Struct (ps2):   {ps2.X}");

            Console.WriteLine($"Original Class (pc1):  {pc1.X}"); 
            Console.WriteLine($"Copied Class (pc2):    {pc2.X}"); 

            Console.ReadKey();
        }
    }

    public struct PointStruct
    {
        public int X;
        public int Y;
        public PointStruct(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class PointClass
    {
        public int X;
        public int Y;
        public PointClass(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}