//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    
    partial struct ValueGraphs
    {
        public static Index<ValueNode<V,T>> nodes<V,T>(V s0, params T[] data)
            where V : unmanaged
        {
            var start = sys.u32(s0);
            var dst = sys.alloc<ValueNode<V,T>>(data.Length);
            for(var i=0; i<data.Length; i++, start++)
                seek(dst,i) = new ValueNode<V,T>(Numeric.force<V>(start), data[i]);
            return dst;
        }

        public static Index<ValueNode<V>> nodes<V>(uint count)
            where V : unmanaged
        {
            var dst = sys.alloc<ValueNode<V>>(count);
            for(var i=0u; i<count; i++)
                seek(dst,i) = new ValueNode<V>(i, Numeric.force<V>(i));
            return dst;
        }
    }
}