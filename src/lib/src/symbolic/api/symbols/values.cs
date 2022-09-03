//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Arrays;
    using static Refs;

    partial struct Symbols
    {
        // public static ReadOnlySeq<LabeledValue<byte>> values8u<E>()
        //     where E : unmanaged, Enum
        //         => values<E,byte>();

        // public static ReadOnlySeq<LabeledValue<sbyte>> values8i<E>()
        //     where E : unmanaged, Enum
        //         => values<E,sbyte>();

        // public static ReadOnlySeq<LabeledValue<ushort>> values16u<E>()
        //     where E : unmanaged, Enum
        //         => values<E,ushort>();

        // public static ReadOnlySeq<LabeledValue<short>> values16i<E>()
        //     where E : unmanaged, Enum
        //         => values<E,short>();

        // public static ReadOnlySeq<LabeledValue<uint>> values32u<E>()
        //     where E : unmanaged, Enum
        //         => values<E,uint>();

        // public static ReadOnlySeq<LabeledValue<int>> values32i<E>()
        //     where E : unmanaged, Enum
        //         => values<E,int>();

        // public static ReadOnlySeq<LabeledValue<ulong>> values64u<E>()
        //     where E : unmanaged, Enum
        //         => values<E,ulong>();

        // public static ReadOnlySeq<LabeledValue<long>> values64i<E>()
        //     where E : unmanaged, Enum
        //         => values<E,long>();

        public static ReadOnlySeq<KeyedValue<E,T>> values<E,T>()
            where E : unmanaged, Enum
            where T : unmanaged
        {
            var src = index<E>();
            var count = src.Count;
            var dst = sys.alloc<KeyedValue<E,T>>(count);
            for(var i=0u; i<count; i++)
            {
                ref readonly var s = ref src[i];
                seek(dst,i) = new KeyedValue<E,T>(s.Kind, sys.@as<ulong,T>(s.Value));
            }
            return dst;
        }
    }
}