//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static NumericKinds;

    partial class XTend
    {
        [MethodImpl(Inline), Op]
        public static TypeCode ToTypeCode(this NumericKind src)
            => Type.GetTypeCode(type(src));
    }
}