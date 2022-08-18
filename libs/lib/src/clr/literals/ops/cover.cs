//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct ClrLiterals
    {
        [MethodImpl(Inline), Op]
        public static CoveredLiterals cover(ValueType src)
            => new CoveredLiterals(src, src.GetType().Fields());

        [MethodImpl(Inline), Op]
        public static CoveredLiterals cover(ValueType src, FieldInfo[] fields)
            => new CoveredLiterals(src,fields);

        [MethodImpl(Inline)]
        public static CoveredLiterals<C> cover<C>(C src)
            where C : struct, ICoveredLiterals<C>
                => new CoveredLiterals<C>(src, typeof(C).Fields());
    }
}