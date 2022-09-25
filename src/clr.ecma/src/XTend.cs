//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public static partial class XTend
    {
        [MethodImpl(Inline)]
        public static EcmaHandleData Data(this Handle src)
            => EcmaHandleData.from(src);

        [MethodImpl(Inline)]
        public static bool IsValid(this EcmaTableKind src)
            => src != EcmaTableKind.Invalid;
    }
}