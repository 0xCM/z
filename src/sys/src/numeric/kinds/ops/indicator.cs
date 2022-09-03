//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class NumericKinds
    {
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static NumericIndicator indicator<T>()
            where T : unmanaged
                => indicator(kind<T>());

        [MethodImpl(Inline), Op]
        public static NumericIndicator indicator(Type src)
            => indicator(kind(src));

        /// <summary>
        /// Determines the indicator of a numeric kind
        /// </summary>
        /// <param name="src">The source kind</param>
        [MethodImpl(Inline), Op]
        public static NumericIndicator indicator(NumericKind src)
        {
            if(unsigned(src))
                return NumericIndicator.Unsigned;
            else if(signed(src))
                return NumericIndicator.Signed;
            else if(float32(src))
                return NumericIndicator.Float;
            else
                return NumericIndicator.None;
        }
    }
}