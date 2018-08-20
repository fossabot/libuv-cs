using System;
using System.Runtime.InteropServices;
using System.Security;

// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global

namespace Native
{
    [SuppressUnmanagedCodeSecurity]
    internal static class libSystem
    {
        private const string LibraryName = "libSystem";

        [DllImport(LibraryName,
            CallingConvention = CallingConvention.StdCall,
            CharSet = CharSet.Ansi
        )]
        public static extern IntPtr dlopen(string fileName, int flags);

        [DllImport(LibraryName,
            CallingConvention = CallingConvention.StdCall,
            CharSet = CharSet.Ansi
        )]
        public static extern IntPtr dlsym(IntPtr handle, string name);

        [DllImport(LibraryName,
            CallingConvention = CallingConvention.StdCall
        )]
        public static extern int dlclose(IntPtr handle);

        [DllImport(LibraryName,
            CallingConvention = CallingConvention.StdCall,
            CharSet = CharSet.Ansi
        )]
        public static extern string dlerror();
    }
}