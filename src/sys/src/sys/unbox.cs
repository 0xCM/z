//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.CompilerServices.Unsafe;

    partial class sys
    {
        [MethodImpl(Options), Op, Closures(Closure)]
        public static ref T unbox<T>(object src)
             where T : struct
               => ref Unbox<T>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T unbox<T>(Enum src)
            where T : struct
                => ref Unbox<T>(src);                
    }
}