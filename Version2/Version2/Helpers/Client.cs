using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Version2.Helpers
{
    internal class Client
    {
        #region Imports

        [DllImport("kernel32.dll")]
        internal static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);
        internal const int AllAccess = 0x1f0fff;

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, out int lpNumberOfBytesRead);

        #endregion

        internal static Process? Proc;
        internal static IntPtr Handle;
        internal static IntPtr Base => Proc?.MainModule?.BaseAddress ?? IntPtr.Zero;
        internal static string? Build => Version.Split('.').LastOrDefault();
        internal static string Version => Proc?.MainModule?.FileVersionInfo.FileVersion ?? string.Empty;
        private static string Time => $"[{DateTime.Now.ToShortTimeString()}]";

        internal static bool Attach(int processId)
        {
            try
            {
                Proc = Process.GetProcessById(processId);
                if (null == Proc)
                    throw new Exception("Could not load input process.");

                Handle = OpenProcess(AllAccess, false, Proc.Id);
                if (Handle == IntPtr.Zero)
                    throw new Exception("Could not open handle to process.");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"{Time} {e.Message}");
                return false;
            }
        }
        internal static T1 Read<T1>(IntPtr address)
        {
            var size = 1;
            if (typeof(T1) != typeof(bool))
                size = Marshal.SizeOf(typeof(T1));

            var data = ReadBytes(address, size);
            var hand = GCHandle.Alloc(data, GCHandleType.Pinned);
            var stuff = (T1)Marshal.PtrToStructure(hand.AddrOfPinnedObject(), typeof(T1))!;

            hand.Free();
            return stuff;

        }
        internal static byte[] ReadBytes(IntPtr address, int size)
        {
            var data = new byte[size];
            ReadProcessMemory(Handle, address, data,
                data.Length, out var bytesRead);
            return bytesRead == 0 ? BitConverter.GetBytes(0) : data;
        }
    }
}