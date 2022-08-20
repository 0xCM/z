//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref char @char<E>(in E src)
            where E : unmanaged
                => ref @as<E,char>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe ref char @char(string src)
            =>  ref @ref(pchar(src));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe ref char @char(string src, int index)
            => ref seek(@ref(pchar(src)), index);
    }
}