//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        [MethodImpl(Inline), Op]
        public static NumericKind ToNumericKind(this NumericWidth width, NumericIndicator indicator)
            => NumericKinds.kind(width, indicator);
    }
}