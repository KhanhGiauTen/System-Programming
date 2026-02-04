namespace Question_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Q03: Memory Efficient (Span)");

            string text = "User:JohnDoe|ID:12345|Role:Admin";

            // CÁCH CŨ: Dùng Substring (Tạo ra string mới trên Heap -> Tốn bộ nhớ)
            string idString = text.Substring(14, 5);
            int id = int.Parse(idString);
            Console.WriteLine($"ID (Substring): {id}");

            // CÁCH MỚI: Dùng Span (Zero-allocation -> Không tạo rác)
            ReadOnlySpan<char> span = text.AsSpan();
            ReadOnlySpan<char> idSpan = span.Slice(14, 5);
            int idSpanParsed = int.Parse(idSpan); // int.Parse hỗ trợ Span từ .NET Core
            Console.WriteLine($"ID (Span): {idSpanParsed}");
        }
    }
    }
}
