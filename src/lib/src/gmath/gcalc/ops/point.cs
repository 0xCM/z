//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct gcalc
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly T point<T>(in Histogram<T> src, uint ix)
            where T : unmanaged, IEquatable<T>, IComparable<T>
                => ref src.Partitions[ix];
    }
}