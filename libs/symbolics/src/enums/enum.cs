//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 4040
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public class @enum
    {
        [Op, Closures(Integers)]
        public static @enum<E> init<E>(E src)
            where E : unmanaged
                => new (cpu.vparts(w128, Sized.bw64(src), (ulong)Enums.kind<E>()));

    }
}