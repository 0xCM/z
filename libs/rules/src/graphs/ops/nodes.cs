//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Arrays;
    
    partial struct Graphs
    {
        public static Index<Node<V,T>> nodes<V,T>(V s0, params T[] data)
            where V : unmanaged
        {
            var start = sys.u32(s0);
            var dst = sys.alloc<Node<V,T>>(data.Length);
            for(var i=0; i<data.Length; i++, start++)
                seek(dst,i) = new Node<V,T>(Numeric.force<V>(start), data[i]);
            return dst;
        }

        public static Index<Node<V>> nodes<V>(uint count)
            where V : unmanaged
        {
            var dst = sys.alloc<Node<V>>(count);
            for(var i=0u; i<count; i++)
                seek(dst,i) = new Node<V>(i, Numeric.force<V>(i));
            return dst;
        }
    }
}