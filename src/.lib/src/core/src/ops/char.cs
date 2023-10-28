//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct core
    {
        /// <summary>
        /// Reimagines a boolean value as a character value
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static char @char(bool src)
            => (char)(u8(src) + 48);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref char @char<E>(in E src)
            where E : unmanaged
                => ref @as<E,char>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe ref char @char(string src)
            =>  ref @ref(memory.pchar(src));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe ref char @char(string src, int index)
            => ref seek(@ref(memory.pchar(src)), index);
    }
}