using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

namespace WowScanner
{
    internal class WoW
    {
        #region Imports

        [DllImport("kernel32.dll")]
        internal static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);
        internal const int ALL_ACCESS = 0x1f0fff;

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, out int lpNumberOfBytesRead);

        #endregion

        internal static Process Proc;
        internal static IntPtr Base => Proc?.MainModule.BaseAddress ?? IntPtr.Zero;
        internal static IntPtr Handle;

        internal static bool FindWow()
        {
            try
            {
                var Procs = Process.GetProcessesByName("WowClassic");
                if (Procs.Length <= 0)
                    Procs = Process.GetProcessesByName("Wow");
                Proc = Procs.Length > 0 ? Procs.FirstOrDefault() : null;
                return null != Proc;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        internal static bool GetHandle()
        {
            try
            {
                if (null == Proc) return false;
                Handle = OpenProcess(ALL_ACCESS, false, Proc.Id);
                return Handle != IntPtr.Zero;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        internal static T1 Read<T1>(IntPtr Address)
        {
            var size = 1;
            if (typeof(T1) != typeof(bool))
                size = Marshal.SizeOf(typeof(T1));

            var data = ReadBytes(Address, size);
            var hand = GCHandle.Alloc(data, GCHandleType.Pinned);
            var stuff = (T1)Marshal.PtrToStructure(hand.AddrOfPinnedObject(), typeof(T1));

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