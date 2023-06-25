//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct TreePath<V>
        where V : IDataType<V>, IExpr, ITree<V>
    {
        Index<V> Data;

        [MethodImpl(Inline)]
        public TreePath(V[] nodes)
        {
            Data = nodes;
        }

        public ReadOnlySpan<V> Segs
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public uint SegCount
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public string Format()
        {
            var dst = text.buffer();
            var count = SegCount;
            for(var i=0; i<count; i++)
            {
                dst.Append(Data[i].Format());
                if(i != count - 1)
                    dst.Append(" -> ");
            }
            return dst.Emit();
        }

        public override string ToString()
            => Format();
    }
}