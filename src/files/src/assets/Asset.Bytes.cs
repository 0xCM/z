//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<byte> Bytes(this Asset src)
            => sys.view(src.Address, src.Size);
    }
}