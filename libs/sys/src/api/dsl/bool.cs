//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.CompilerServices.Unsafe;

    partial class sys
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref bool @bool<T>(in T src)
            => ref As<T,bool>(ref edit(src));
    }
}