//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.CompilerServices.Unsafe;
    using static System.Runtime.InteropServices.MemoryMarshal;

    partial class Widths
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        static ref T edit<T>(in T src)
            => ref AsRef(src);

        [MethodImpl(Inline)]
        static ref T @as<S,T>(in S src)
            => ref As<S,T>(ref edit(src));
    }
}