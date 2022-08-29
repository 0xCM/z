//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        /// <summary>
        /// Determines the numeric kind of a type-code identified type
        /// </summary>
        /// <param name="tc">The type code to evaluate</param>
        [MethodImpl(Inline), Op]
        public static NumericKind ToNumericKind(this TypeCode tc)
            => NumericKinds.kind(tc);

        [MethodImpl(Inline)]
        public static NumericKind NumericKind(this ClrEnumCode k)
            => k.TypeCode().ToNumericKind();

        [MethodImpl(Inline)]
        public static TypeCode TypeCode(this ClrEnumCode k)
            =>(System.TypeCode)k;

    }
}