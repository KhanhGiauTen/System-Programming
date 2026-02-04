namespace Question_02
{
    class LargeObject
    {
        byte[] data = new byte[1024 * 10]; // 10 KB
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Q02: Garbage Collection");
            long before = GC.GetTotalMemory(false);
            Console.WriteLine($"Memory Before: {before / 1024} KB");

            // Tạo áp lực bộ nhớ (Memory Pressure)
            for (int i = 0; i < 5000; i++)
            {
                var obj = new LargeObject();
                // obj chết ngay sau mỗi vòng lặp
            }

            long allocated = GC.GetTotalMemory(false);
            Console.WriteLine($"Memory Allocated (Pressure): {allocated / 1024} KB");

            // Kích hoạt GC thủ công (Chỉ dùng cho mục đích học tập!)
            GC.Collect();
            GC.WaitForPendingFinalizers();

            long after = GC.GetTotalMemory(true);
            Console.WriteLine($"Memory After GC: {after / 1024} KB");
        }
    }
}
