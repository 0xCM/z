//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Z0.Asm;

    [ApiHost]
    public readonly struct Capture
    {

        [MethodImpl(Inline),Op]
        public static CaptureExchange exchange(byte[] buffer)
            => new CaptureExchange(buffer);
    }
}