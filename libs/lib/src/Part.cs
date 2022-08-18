//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
global using System;
global using System.Collections.Generic;
global using System.Collections.Concurrent;
global using System.Collections;
global using System.Reflection.Metadata;
global using System.Reflection.Metadata.Ecma335;
global using System.Reflection;
global using System.Reflection.Emit;
global using System.Runtime.Intrinsics;
global using System.Runtime.CompilerServices;
global using System.Runtime.InteropServices;
global using System.Threading;
global using System.Threading.Tasks;
global using System.Xml;
global using System.Globalization;
global using System.Text;

global using static Z0.Root;
global using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;
global using SQ = Z0.SymbolicQuery;

global using CallerName = System.Runtime.CompilerServices.CallerMemberNameAttribute;
global using CallerFile = System.Runtime.CompilerServices.CallerFilePathAttribute;
global using CallerLine = System.Runtime.CompilerServices.CallerLineNumberAttribute;

global using System.Diagnostics;
global using System.IO;

[assembly: PartId(PartId.Lib)]

namespace Z0.Parts
{
    public sealed partial class Lib : Part<Lib>
    {

    }
}

namespace Z0
{
    using static Root;

    [ApiHost]
    public static partial class XTend
    {
        const NumericKind Closure = Root.UnsignedInts;
    }

    [ApiHost]
    public static partial class XApi
    {

    }

    partial struct Msg
    {
        const NumericKind Closure = Root.UnsignedInts;

        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static RenderPattern<T,ClosedInterval<T>> NotIn<T>()
            where T : unmanaged, IEquatable<T>
                => "not({0} in {1})";

        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static RenderPattern<T,T> NotEqual<T>()
            where T : unmanaged
                => "not({0}=={1})";

        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static RenderPattern<T,T> NotGreaterThan<T>()
            where T : unmanaged
                => "not({0}>{1})";

        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static RenderPattern<T,T> NotLessThan<T>()
            where T : unmanaged
                => "not({0}<{1})";

        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static RenderPattern<T,T> NotGreaterThanOrEqual<T>()
            where T : unmanaged
                => "not({0}>={1})";

        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static RenderPattern<T,T> NotLessThanOrEqual<T>()
            where T : unmanaged
                => "not({0}<={1})";
    }
}