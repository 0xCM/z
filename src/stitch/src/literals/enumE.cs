//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 4040
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = @enum;

    [ApiHost]
    public class @enum
    {
        [Op, Closures(Integers)]
        public static @enum<E> init<E>(E src)
            where E : unmanaged
                => new (cpu.vparts(w128, Sized.bw64(src), (ulong)Enums.kind<E>()));
    }

    public struct @enum<E>
        where E : unmanaged
    {
        Vector128<ulong> Data;

        [MethodImpl(Inline)]
        internal @enum(Vector128<ulong> src)
        {
            Data = src;
        }

        [MethodImpl(Inline)]
        public static implicit operator @enum<E>(E src)
            => api.init(src);
    }
}