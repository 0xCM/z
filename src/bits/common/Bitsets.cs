//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly struct Bitsets
    {
        [MethodImpl(Inline)]
        public static Bitset128<T> init<T>(N128 n, params T[] src)
            where T : unmanaged
                => new Bitset128<T>(src);

        public static string format<T>(Bitset128<T> src, string sep = ",", int pad = 0)
            where T : unmanaged
        {
            var dst = text.buffer();
            Span<T> kinds = stackalloc T[Bitset128<T>.Capacity];
            var count = src.Members(kinds);
            var slot = RpOps.slot(0,(sbyte)pad);
            for(var i=0; i<count; i++)
            {
                if(i != 0)
                    dst.Append(sep);
                dst.AppendFormat(slot, skip(kinds,i).ToString());
            }
            return dst.Emit();
        }
    }
}