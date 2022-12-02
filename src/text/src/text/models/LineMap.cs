//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class LineMap<T> : Seq<LineMap<T>, LineInterval<T>>
    {
        public LineMap()
        {

        }

        [MethodImpl(Inline)]
        public LineMap(LineInterval<T>[] src)
            : base(src)
        {
        }

        public uint IntervalCount
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        [MethodImpl(Inline)]
        public uint CountLines()
        {
            var k = 0u;
            for(var i=0; i<Data.Count; i++)
                k += this[i].LineCount;
            return k;
        }

        [MethodImpl(Inline)]
        public static implicit operator LineMap<T>(LineInterval<T>[] src)
            => new LineMap<T>(src);

        // public static LineMap<T> operator +(LineMap<T> a, LineMap<T> b)
        //     => Seq.concat(a,b);
    }
}