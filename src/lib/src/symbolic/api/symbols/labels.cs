//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Arrays;

    partial struct Symbols
    {
       public static ReadOnlySeq<LabeledValue<T>> labels<E,T>()
            where E : unmanaged, Enum
            where T : unmanaged
        {
            var src = index<E>();
            var count = src.Count;
            var dst = sys.alloc<LabeledValue<T>>(count);
            for(var i=0u; i<count; i++)
            {
                ref readonly var s = ref src[i];
                seek(dst,i) = new LabeledValue<T>(s.Name, sys.@as<ulong,T>(s.Value));
            }
            return dst;
        }

    }
}