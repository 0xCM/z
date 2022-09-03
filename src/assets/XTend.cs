//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    [ApiHost]
    public static partial class XTend
    {
        const NumericKind Closure = Root.UnsignedInts;


        [MethodImpl(Inline), Op]
        public static string Utf8(this Asset src)
            => Assets.utf8(src);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<byte> Bytes(this Asset src)
            => core.view(src.Address, src.Size);

    }
}