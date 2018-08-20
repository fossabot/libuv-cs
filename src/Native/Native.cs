using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable ConvertIfStatementToReturnStatement

namespace Native
{
    internal static class Platform
    {
        public static bool IsWindows
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return RuntimeInformation.IsOSPlatform(OSPlatform.Windows); }
        }

        public static bool IsDarwin
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return RuntimeInformation.IsOSPlatform(OSPlatform.OSX); }
        }

        public static bool IsLinux
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return RuntimeInformation.IsOSPlatform(OSPlatform.Linux); }
        }

        public static IntPtr LoadLibrary(string name)
        {
            if (IsLinux) return libdl.dlopen(name, 0x101); // RTLD_GLOBAL | RTLD_LAZY
            if (IsWindows) return Kernel32.LoadLibrary(name);
            if (IsDarwin) return libSystem.dlopen(name, 0x101); // RTLD_GLOBAL | RTLD_LAZY
            return IntPtr.Zero;
        }

        public static void FreeLibrary(IntPtr handle)
        {
            if (IsLinux) libdl.dlclose(handle);
            if (IsWindows) Kernel32.FreeLibrary(handle);
            if (IsDarwin) libSystem.dlclose(handle);
        }

        public static IntPtr GetLibraryFunctionPointer(IntPtr handle, string functionName)
        {
            if (IsLinux) return libdl.dlsym(handle, functionName);
            if (IsWindows) return Kernel32.GetProcAddress(handle, functionName);
            if (IsDarwin) return libSystem.dlsym(handle, functionName);
            return IntPtr.Zero;
        }

        public static T GetLibraryFunction<T>(IntPtr handle, string functionName)
        {
            var functionHandle = GetLibraryFunctionPointer(handle, functionName);
            return Marshal.GetDelegateForFunctionPointer<T>(functionHandle);
        }
    }
}
