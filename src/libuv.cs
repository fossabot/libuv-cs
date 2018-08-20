using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using static Native.Platform;

// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global

public static class libuv
{
    private static readonly IntPtr Handle = LoadLibUv();

    private static IntPtr LoadLibUv()
    {
        var name = string.Empty;
        if (IsLinux) name = "libuv.so";
        if (IsWindows) name = "libuv.dll";
        if (IsDarwin) name = "libuv.dylib";
        return LoadLibrary(name);
    }

    public enum uv_run_mode
    {
        UV_RUN_DEFAULT = 0,
        UV_RUN_ONCE,
        UV_RUN_NOWAIT
    }

    public enum uv_handle_type
    {
        UV_UNKNOWN_HANDLE = 0,
        UV_ASYNC,
        UV_CHECK,
        UV_FS_EVENT,
        UV_FS_POLL,
        UV_HANDLE,
        UV_IDLE,
        UV_NAMED_PIPE,
        UV_POLL,
        UV_PREPARE,
        UV_PROCESS,
        UV_STREAM,
        UV_TCP,
        UV_TIMER,
        UV_TTY,
        UV_UDP,
        UV_SIGNAL,
        UV_FILE,
    }

    public enum uv_req_type
    {
        UV_UNKNOWN_REQ = 0,
        UV_REQ,
        UV_CONNECT,
        UV_WRITE,
        UV_SHUTDOWN,
        UV_UDP_SEND,
        UV_FS,
        UV_WORK,
        UV_GETADDRINFO,
        UV_GETNAMEINFO,
        UV_REQ_TYPE_PRIVATE,
        UV_REQ_TYPE_MAX,
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int d_uv_loop_init(IntPtr loop);

    public static readonly d_uv_loop_init uv_loop_init =
        GetLibraryFunction<d_uv_loop_init>(Handle, "uv_loop_init");

    [EditorBrowsable(EditorBrowsableState.Never)]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int d_uv_loop_close(IntPtr loop);

    public static readonly d_uv_loop_close uv_loop_close =
        GetLibraryFunction<d_uv_loop_close>(Handle, "uv_loop_close");

    [EditorBrowsable(EditorBrowsableState.Never)]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int d_uv_run(IntPtr loop, uv_run_mode mode);

    public static readonly d_uv_run uv_run =
        GetLibraryFunction<d_uv_run>(Handle, "uv_run");

    [EditorBrowsable(EditorBrowsableState.Never)]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int d_uv_loop_alive(IntPtr loop);

    public static readonly d_uv_loop_alive uv_loop_alive =
        GetLibraryFunction<d_uv_loop_alive>(Handle, "uv_loop_alive");

    [EditorBrowsable(EditorBrowsableState.Never)]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int d_uv_stop(IntPtr loop);

    public static readonly d_uv_stop uv_stop =
        GetLibraryFunction<d_uv_stop>(Handle, "uv_stop");

    [EditorBrowsable(EditorBrowsableState.Never)]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int d_uv_loop_size();

    public static readonly d_uv_loop_size uv_loop_size =
        GetLibraryFunction<d_uv_loop_size>(Handle, "uv_loop_size");

    [EditorBrowsable(EditorBrowsableState.Never)]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate long d_uv_now(IntPtr loop);

    public static readonly d_uv_now uv_now =
        GetLibraryFunction<d_uv_now>(Handle, "uv_now");

    [EditorBrowsable(EditorBrowsableState.Never)]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr d_uv_loop_get_data(IntPtr loop);

    public static readonly d_uv_loop_get_data uv_loop_get_data =
        GetLibraryFunction<d_uv_loop_get_data>(Handle, "uv_loop_get_data");

    [EditorBrowsable(EditorBrowsableState.Never)]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_uv_loop_set_data(IntPtr loop, IntPtr data);

    public static readonly d_uv_loop_set_data uv_loop_set_data =
        GetLibraryFunction<d_uv_loop_set_data>(Handle, "uv_loop_set_data");

    [EditorBrowsable(EditorBrowsableState.Never)]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int d_uv_is_active(IntPtr handle);

    public static readonly d_uv_is_active uv_is_active =
        GetLibraryFunction<d_uv_is_active>(Handle, "uv_is_active");

    [EditorBrowsable(EditorBrowsableState.Never)]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int d_uv_is_closing(IntPtr handle);

    public static readonly d_uv_is_closing uv_is_closing =
        GetLibraryFunction<d_uv_is_closing>(Handle, "uv_is_closing");

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void uv_close_cb(IntPtr handle);

    [EditorBrowsable(EditorBrowsableState.Never)]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_uv_close(IntPtr handle, uv_close_cb close_cb);

    public static readonly d_uv_close uv_close =
        GetLibraryFunction<d_uv_close>(Handle, "uv_close");

    [EditorBrowsable(EditorBrowsableState.Never)]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_uv_ref(IntPtr handle);

    public static readonly d_uv_ref uv_ref =
        GetLibraryFunction<d_uv_ref>(Handle, "uv_ref");

    [EditorBrowsable(EditorBrowsableState.Never)]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_uv_unref(IntPtr handle);

    public static readonly d_uv_unref uv_unref =
        GetLibraryFunction<d_uv_unref>(Handle, "uv_unref");

    [EditorBrowsable(EditorBrowsableState.Never)]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int d_uv_has_ref(IntPtr handle);

    public static readonly d_uv_has_ref uv_has_ref =
        GetLibraryFunction<d_uv_has_ref>(Handle, "uv_has_ref");

    [EditorBrowsable(EditorBrowsableState.Never)]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int d_uv_handle_size(uv_handle_type type);

    public static readonly d_uv_handle_size uv_handle_size =
        GetLibraryFunction<d_uv_handle_size>(Handle, "uv_handle_size");

    [EditorBrowsable(EditorBrowsableState.Never)]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr d_uv_handle_get_loop(IntPtr handle);

    public static readonly d_uv_handle_get_loop uv_handle_get_loop =
        GetLibraryFunction<d_uv_handle_get_loop>(Handle, "uv_handle_get_loop");

    [EditorBrowsable(EditorBrowsableState.Never)]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr d_uv_handle_get_data(IntPtr handle);

    public static readonly d_uv_handle_get_data uv_handle_get_data =
        GetLibraryFunction<d_uv_handle_get_data>(Handle, "uv_handle_get_data");

    [EditorBrowsable(EditorBrowsableState.Never)]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_uv_handle_set_data(IntPtr handle, IntPtr data);

    public static readonly d_uv_handle_set_data uv_handle_set_data =
        GetLibraryFunction<d_uv_handle_set_data>(Handle, "uv_handle_set_data");

    [EditorBrowsable(EditorBrowsableState.Never)]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uv_handle_type d_uv_handle_get_type(IntPtr handle);

    public static readonly d_uv_handle_get_type uv_handle_get_type =
        GetLibraryFunction<d_uv_handle_get_type>(Handle, "uv_handle_get_type");

    [EditorBrowsable(EditorBrowsableState.Never)]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate string d_uv_handle_type_name(uv_handle_type type);

    public static readonly d_uv_handle_type_name uv_handle_type_name =
        GetLibraryFunction<d_uv_handle_type_name>(Handle, "uv_handle_type_name");

    [EditorBrowsable(EditorBrowsableState.Never)]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int d_uv_timer_init(IntPtr loop, IntPtr timer);

    public static readonly d_uv_timer_init uv_timer_init =
        GetLibraryFunction<d_uv_timer_init>(Handle, "uv_timer_init");

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void uv_timer_cb(IntPtr handle);

    [EditorBrowsable(EditorBrowsableState.Never)]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int d_uv_timer_start(IntPtr timer, uv_timer_cb cb, ulong timeout, ulong repeat);

    public static readonly d_uv_timer_start uv_timer_start =
        GetLibraryFunction<d_uv_timer_start>(Handle, "uv_timer_start");

    [EditorBrowsable(EditorBrowsableState.Never)]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int d_uv_timer_stop(IntPtr timer);

    public static readonly d_uv_timer_stop uv_timer_stop =
        GetLibraryFunction<d_uv_timer_stop>(Handle, "uv_timer_stop");

    [EditorBrowsable(EditorBrowsableState.Never)]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int d_uv_timer_again(IntPtr timer);

    public static readonly d_uv_timer_again uv_timer_again =
        GetLibraryFunction<d_uv_timer_again>(Handle, "uv_timer_again");

    [EditorBrowsable(EditorBrowsableState.Never)]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_uv_timer_set_repeat(IntPtr timer, ulong repeat);

    public static readonly d_uv_timer_set_repeat uv_timer_set_repeat =
        GetLibraryFunction<d_uv_timer_set_repeat>(Handle, "uv_timer_set_repeat");

    [EditorBrowsable(EditorBrowsableState.Never)]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ulong d_uv_timer_get_repeat(IntPtr timer);

    public static readonly d_uv_timer_get_repeat uv_timer_get_repeat =
        GetLibraryFunction<d_uv_timer_get_repeat>(Handle, "uv_timer_get_repeat");

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void uv_connection_cb(IntPtr handle, int status);

    [EditorBrowsable(EditorBrowsableState.Never)]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int d_uv_listen(IntPtr stream, int backlog, uv_connection_cb cb);

    public static readonly d_uv_listen uv_listen =
        GetLibraryFunction<d_uv_listen>(Handle, "uv_listen");

    [EditorBrowsable(EditorBrowsableState.Never)]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int d_uv_accept(IntPtr server, IntPtr client);

    public static readonly d_uv_accept uv_accept =
        GetLibraryFunction<d_uv_accept>(Handle, "uv_accept");

    [EditorBrowsable(EditorBrowsableState.Never)]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int d_uv_tcp_init(IntPtr loop, IntPtr tcp);

    public static readonly d_uv_tcp_init uv_tcp_init =
        GetLibraryFunction<d_uv_tcp_init>(Handle, "uv_tcp_init");

    [EditorBrowsable(EditorBrowsableState.Never)]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int d_uv_tcp_init_ex(IntPtr loop, IntPtr tcp, uint flags);

    public static readonly d_uv_tcp_init_ex uv_tcp_init_ex =
        GetLibraryFunction<d_uv_tcp_init_ex>(Handle, "uv_tcp_init_ex");

    [EditorBrowsable(EditorBrowsableState.Never)]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int d_uv_tcp_open(IntPtr tcp, IntPtr sock);

    public static readonly d_uv_tcp_open uv_tcp_open =
        GetLibraryFunction<d_uv_tcp_open>(Handle, "uv_tcp_open");

    [EditorBrowsable(EditorBrowsableState.Never)]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int d_uv_tcp_nodelay(IntPtr tcp, int enable);

    public static readonly d_uv_tcp_nodelay uv_tcp_nodelay =
        GetLibraryFunction<d_uv_tcp_nodelay>(Handle, "uv_tcp_nodelay");

    [EditorBrowsable(EditorBrowsableState.Never)]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int d_uv_tcp_keepalive(IntPtr tcp, int enable, uint delay);

    public static readonly d_uv_tcp_keepalive uv_tcp_keepalive =
        GetLibraryFunction<d_uv_tcp_keepalive>(Handle, "uv_tcp_keepalive");

    [EditorBrowsable(EditorBrowsableState.Never)]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int d_uv_tcp_simultaneous_accepts(IntPtr tcp, int enable);

    public static readonly d_uv_tcp_simultaneous_accepts uv_tcp_simultaneous_accepts =
        GetLibraryFunction<d_uv_tcp_simultaneous_accepts>(Handle, "uv_tcp_simultaneous_accepts");

    [EditorBrowsable(EditorBrowsableState.Never)]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int d_uv_tcp_bind(IntPtr tcp, IntPtr addr, uint flags);

    public static readonly d_uv_tcp_bind uv_tcp_bind =
        GetLibraryFunction<d_uv_tcp_bind>(Handle, "uv_tcp_bind");

    [EditorBrowsable(EditorBrowsableState.Never)]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int d_uv_tcp_getsockname(IntPtr tcp, IntPtr addr, ref int namelen);

    public static readonly d_uv_tcp_getsockname uv_tcp_getsockname =
        GetLibraryFunction<d_uv_tcp_getsockname>(Handle, "uv_tcp_getsockname");

    [EditorBrowsable(EditorBrowsableState.Never)]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int d_uv_tcp_getpeername(IntPtr tcp, IntPtr addr, ref int namelen);

    public static readonly d_uv_tcp_getpeername uv_tcp_getpeername =
        GetLibraryFunction<d_uv_tcp_getpeername>(Handle, "uv_tcp_getpeername");

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void uv_connect_cb(IntPtr handle, int status);

    [EditorBrowsable(EditorBrowsableState.Never)]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int d_uv_tcp_connect(IntPtr req, IntPtr tcp, IntPtr addr, uv_connect_cb cb);

    public static readonly d_uv_tcp_connect uv_tcp_connect =
        GetLibraryFunction<d_uv_tcp_connect>(Handle, "uv_tcp_connect");

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void uv_async_cb(IntPtr handle);

    [EditorBrowsable(EditorBrowsableState.Never)]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int d_uv_async_init(IntPtr loop, IntPtr async, uv_async_cb async_cb);

    public static readonly d_uv_async_init uv_async_init =
        GetLibraryFunction<d_uv_async_init>(Handle, "uv_async_init");

    [EditorBrowsable(EditorBrowsableState.Never)]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int d_uv_async_send(IntPtr async);

    public static readonly d_uv_async_send uv_async_send =
        GetLibraryFunction<d_uv_async_send>(Handle, "uv_async_send");

    [EditorBrowsable(EditorBrowsableState.Never)]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int d_uv_req_size(uv_req_type type);

    public static readonly d_uv_req_size uv_req_size =
        GetLibraryFunction<d_uv_req_size>(Handle, "uv_req_size");

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void uv_work_cb(IntPtr req);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void uv_after_work_cb(IntPtr req, int status);

    [EditorBrowsable(EditorBrowsableState.Never)]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int d_uv_queue_work(IntPtr loop, IntPtr req, uv_work_cb work_cb, uv_after_work_cb after_work_cb);

    public static readonly d_uv_queue_work uv_queue_work =
        GetLibraryFunction<d_uv_queue_work>(Handle, "uv_queue_work");

    [EditorBrowsable(EditorBrowsableState.Never)]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int d_uv_ip4_addr(string ip, int port, IntPtr addr);

    public static readonly d_uv_ip4_addr uv_ip4_addr =
        GetLibraryFunction<d_uv_ip4_addr>(Handle, "uv_ip4_addr");

    [EditorBrowsable(EditorBrowsableState.Never)]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int d_uv_ip6_addr(string ip, int port, IntPtr addr);

    public static readonly d_uv_ip6_addr uv_ip6_addr =
        GetLibraryFunction<d_uv_ip6_addr>(Handle, "uv_ip6_addr");

    [EditorBrowsable(EditorBrowsableState.Never)]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.LPStr)]
    public delegate string d_uv_strerror(int err);

    public static readonly d_uv_strerror uv_strerror =
        GetLibraryFunction<d_uv_strerror>(Handle, "uv_strerror");

    [EditorBrowsable(EditorBrowsableState.Never)]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.LPStr)]
    public delegate string d_uv_err_name(int err);

    public static readonly d_uv_err_name uv_err_name =
        GetLibraryFunction<d_uv_err_name>(Handle, "uv_err_name");
}