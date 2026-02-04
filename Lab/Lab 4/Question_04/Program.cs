namespace Question_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Q04: Manual Thread vs ThreadPool");
            Stopwatch sw = Stopwatch.StartNew();

            // Cách 1: Manual Thread (Tốn kém)
            // Hệ điều hành phải cấp phát ~1MB Stack cho mỗi luồng
            for (int i = 0; i < 100; i++)
            {
                new Thread(() => { Thread.Sleep(10); }).Start();
            }

            // Cách 2: ThreadPool / Task (Hiệu quả)
            // Tái sử dụng luồng có sẵn
            Task[] tasks = new Task[100];
            for (int i = 0; i < 100; i++)
            {
                tasks[i] = Task.Run(() => { Thread.Sleep(10); });
            }
            Task.WaitAll(tasks);

            sw.Stop();
            Console.WriteLine($"Time elapsed: {sw.ElapsedMilliseconds} ms");
        }
    }
}
