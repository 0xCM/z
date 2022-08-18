//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;
    using static core;

    [StructLayout(LayoutKind.Sequential)]
    public readonly struct PartitionSegment<T>
        where T : unmanaged
    {
        public T Min {get;}

        public T Max {get;}

        [MethodImpl(Inline)]
        public PartitionSegment(T min, T max)
        {
            Min = min;
            Max = max;
        }

        public ulong Width
        {
            [MethodImpl(Inline)]
            get => uint64(Max) - uint64(Min);
        }

        public string Format()
            => format(this);
        static string format(PartitionSegment<T> src)
            => RenderPart().Format(src.Min, src.Max);

        [MethodImpl(Inline)]
        static RenderPattern<T,T> RenderPart()
            => "[{0},{1})";

        [MethodImpl(Inline)]
        public static implicit operator PartitionSegment<T>((T min, T max) src)
            => new PartitionSegment<T>(src.min, src.max);
    }
}