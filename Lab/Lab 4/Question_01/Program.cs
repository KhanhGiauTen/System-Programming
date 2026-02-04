namespace Question_01
{
    class Playerclass
    {
        public int Score;
    }
    struct PointStruct
    {
        public int X;
        public int Y;
    }
    internal class Program
    {
        static Playerclass globalplayer = new Playerclass();
        static void Main(string[] args)
        {
            Console.WriteLine("Q01: Stack vs Heap");
            ProcessData();
            Console.WriteLine("End of ProcessData. 'p1' is now out of scope");
        }
        static void ProcessData()
        {
            int localInt = 100;
            PointStruct localPoint = new PointStruct { X = 1, Y = 2 };
            Playerclass p1 = new Playerclass();
            p1.Score = localInt;

            Console.WriteLine($"p1 Score = {p1.Score}");
        }
    }
}
