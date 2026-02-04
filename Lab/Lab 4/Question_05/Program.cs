namespace Question_05
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("--- Question 5: Async/Await ---");

            Console.WriteLine("Starting Download...");
            await DownloadDataAsync(); // Non-blocking wait
            Console.WriteLine("Download Completed.");

            // Lỗi Async Void (Nguy hiểm!)
            // UnsafeVoidMethod(); 
        }

        static async Task DownloadDataAsync()
        {
            // Giả lập I/O (Network call)
            // await trả luồng về Pool, CPU không bị block
            await Task.Delay(1000);
            Console.WriteLine("Data received!");
        }

        // BAD PRACTICE: Async void
        // Nếu lỗi xảy ra ở đây, App sẽ crash mà không catch được
        static async void UnsafeVoidMethod()
        {
            throw new Exception("Crash!");
        }
    }
}
