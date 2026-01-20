using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========================================\n");
            Console.WriteLine(" THÔNG TIN HỆ THỐNG");
            Console.WriteLine("========================================\n");

            PrintItem("Machine Name", Environment.MachineName);
            PrintItem("User Name", Environment.UserName);
            PrintItem("OS Version", Environment.OSVersion.ToString());
            PrintItem(".NET Version", Environment.Version.ToString());
            PrintItem("64-bit OS", Environment.Is64BitOperatingSystem.ToString());
            PrintItem("64-bit Process", Environment.Is64BitProcess.ToString());
            PrintItem("Processor Count", Environment.ProcessorCount.ToString());

            Console.WriteLine("========================================\n");
            
            var memoryInfo = GC.GetGCMemoryInfo();
            PrintItem("Total Memory (GB)", (memoryInfo.TotalAvailableMemoryBytes / 1024.0 / 1024 / 1024).ToString("F2"));
            PrintItem("High Memory Load", memoryInfo.MemoryLoadBytes > 0 ? "Yes" : "No");
            PrintItem("System Page Size", $"{Environment.SystemPageSize} bytes");
            PrintItem("Uptime (minutes)", (Environment.TickCount64 / 60000).ToString());

            Console.WriteLine("========================================\n");
            PrintItem("Current Directory", Environment.CurrentDirectory);
            PrintItem("System Directory", Environment.SystemDirectory);
            PrintItem("System Time", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            Console.WriteLine("========================================\n");
            Console.WriteLine("DISK INFORMATION");
            Console.WriteLine("========================================\n");

            try
            {
                DriveInfo[] drives = DriveInfo.GetDrives();
                foreach (DriveInfo drive in drives)
                {
                    if (drive.IsReady)
                    {
                        double totalSize = drive.TotalSize / (1024.0 * 1024.0 * 1024.0);
                        double freeSpace = drive.AvailableFreeSpace / (1024.0 * 1024.0 * 1024.0);
                        double usedSpace = totalSize - freeSpace;

                        Console.WriteLine($"Drive {drive.Name}");
                        PrintItem("  Type", drive.DriveType.ToString());
                        PrintItem("  Format", drive.DriveFormat);
                        PrintItem("  Total (GB)", totalSize.ToString("F2"));
                        PrintItem("  Used (GB)", usedSpace.ToString("F2"));
                        PrintItem("  Free (GB)", freeSpace.ToString("F2"));
                        Console.WriteLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading drives: {ex.Message}");
            }

            Console.WriteLine("========================================\n");
            Console.ReadKey();
        }
        static void PrintItem(string key, string value)
        {
            Console.WriteLine($"{key,-25}: {value}");
        }
    }
}
