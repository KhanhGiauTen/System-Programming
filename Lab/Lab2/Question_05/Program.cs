using System;
using System.IO;
using System.Runtime.InteropServices; 

namespace Question_05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- System Programming: Font API Demo ---");

            MembershipCardPrinter printer = new MembershipCardPrinter();
            printer.PrintCard("Nguyen Quoc Khanh", "MS31231021198");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }

    public class MembershipCardPrinter
    {
        [DllImport("gdi32.dll", EntryPoint = "AddFontResourceW", SetLastError = true)]
        public static extern int AddFontResource([In][MarshalAs(UnmanagedType.LPWStr)] string lpFileName);

        [DllImport("gdi32.dll", EntryPoint = "RemoveFontResourceW", SetLastError = true)]
        public static extern int RemoveFontResource([In][MarshalAs(UnmanagedType.LPWStr)] string lpFileName);

        public void PrintCard(string memberName, string memberId)
        {
            string fontPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CustomFont.ttf");
            if (!File.Exists(fontPath))
            {
                Console.WriteLine($"Lỗi: Không tìm thấy file font tại {fontPath}");
            }

            int result = 0;

            try
            {
                result = AddFontResource(fontPath);

                if (result == 0)
                {
                    Console.WriteLine("Không thể cài đặt font. Cần quyền Administrator hoặc file lỗi.");
                }
                else
                {
                    Console.WriteLine($"Đã cài đặt thành công {result} font vào hệ thống.");
                }

                Console.WriteLine("\n--------------------------------");
                Console.WriteLine($"      MEMBERSHIP CARD");
                Console.WriteLine($" Name:  {memberName}");
                Console.WriteLine($" ID:    {memberId}");
                Console.WriteLine($" Level: VIP Gold");
                Console.WriteLine("--------------------------------\n");
            }
            finally
            {
                if (result != 0)
                {
                    RemoveFontResource(fontPath);
                    Console.WriteLine(" Đã gỡ font khỏi hệ thống.");
                }
            }
        }
    }
}