//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Numeric
    {
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static NumericParser<T> parser<T>()
            where T : unmanaged
                => default;
    }
}