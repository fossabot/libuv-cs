using System;
using System.Runtime.InteropServices;
using System.Security;

// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global

namespace Native
{
    [SuppressUnmanagedCodeSecurity]
    public static class Kernel32
    {
        [DllImport("kernel32",
            CallingConvention = CallingConvention.StdCall,
            CharSet = CharSet.Ansi,
            ExactSpelling = true,
            SetLastError = true
        )]
        public static extern IntPtr LoadLibrary(string fileName);

        [DllImport("kernel32",
            CallingConvention = CallingConvention.StdCall,
            CharSet = CharSet.Ansi,
            ExactSpelling = true,
            SetLastError = true
        )]
        public static extern IntPtr GetProcAddress(IntPtr module, string procName);

        [DllImport("kernel32",
            CallingConvention = CallingConvention.StdCall,
            SetLastError = true
        )]
        public static extern int FreeLibrary(IntPtr module);
    }
}