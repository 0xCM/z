//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------


namespace Z0
{
    public static partial class XTend
    {
        [MethodImpl(Inline)]
        public static T[] Select<S,T>(this S src, Func<S,T> f)
            where S : ICellSeq<S>
                => Cells.map(src,f).Storage;
 
        const NumericKind Closure = UnsignedInts;
    }
}