//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public static partial class XTend
    {
        [MethodImpl(Inline)]
        public static CliHandleData Data(this Handle src)
            => CliHandleData.from(src);

        [MethodImpl(Inline)]
        public static bool IsValid(this CliTableKind src)
            => src != CliTableKind.Invalid;
    }
}