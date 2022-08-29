//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        [MethodImpl(Inline), Op]
        public static bool IsSigned(this PrimalKind src)
            => PrimalBits.sign(src) == PolarityKind.Left ? true : false;

        [MethodImpl(Inline), Op]
        public static NativeTypeWidth BitWidth(this PrimalKind src)
            => PrimalBits.width(src);
    }
}