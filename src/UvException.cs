using System;
using static libuv;

// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

public class UvException : Exception
{
    public int ErrorCode { get; }
    public string ErrorName { get; }
    public string ErrorDescription { get; }

    private UvException(int statusCode, string name, string description)
        : base($"{name}({statusCode}): {description}")
    {
        ErrorCode = statusCode;
        ErrorName = name;
        ErrorDescription = description;
    }
        
    public UvException(int statusCode)
        : this(statusCode, uv_err_name(statusCode), uv_strerror(statusCode))
    {
    }
}