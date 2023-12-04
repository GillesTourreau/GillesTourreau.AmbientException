//-----------------------------------------------------------------------
// <copyright file="ExceptionHelper.cs" company="Gilles TOURREAU">
//     Copyright (c) Gilles TOURREAU. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace GillesTourreau.AmbientException
{
using System;
#if NETSTANDARD
using System.Linq.Expressions;
#endif
using System.Runtime.InteropServices;

public static class ExceptionHelper
{
    public static bool IsExceptionOnGoing()
    {
        var ptr = GetExceptionPointers();

        if (ptr == IntPtr.Zero)
        {
            return false;
        }

        return true;
    }

#if NETSTANDARD
    private static readonly Func<IntPtr> GetExceptionPointers = BuildGetExceptionPointersFunc();

    private static Func<IntPtr> BuildGetExceptionPointersFunc()
    {
        var memberAccess = Expression.Call(typeof(Marshal).GetMethod("GetExceptionPointers"));

        var lambda = Expression.Lambda<Func<IntPtr>>(memberAccess);

        return lambda.Compile();
    }
#else
    private static IntPtr GetExceptionPointers()
    {
        return Marshal.GetExceptionPointers();
    }
#endif
}
}
