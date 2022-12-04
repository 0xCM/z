//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class gmath
    {
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T recip<T>(T value)
            where T : unmanaged
        {
            var x = Numeric.force<T,double>(value);
            var r = 1.0/x;
            return Numeric.force<T>(r);
        }
    }
}