//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        public static Seq<T> Sort<T>(this Seq<T> src)
            where T : IComparable<T>
                => src.Storage.Sort();

        public static ReadOnlySeq<T> Sort<T>(this ReadOnlySeq<T> src)
            where T : IComparable<T>                
                => src.Storage.Sort();
    }
}