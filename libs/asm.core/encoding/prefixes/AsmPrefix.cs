//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;
    using static AsmPrefixCodes;

    [ApiHost]
    public readonly struct AsmPrefix
    {
        [MethodImpl(Inline), Op]
        public static SizeOverride opsz()
            => SizeOverrideCode.OPSZ;

        [MethodImpl(Inline), Op]
        public static SizeOverride adsz()
            => SizeOverrideCode.ADSZ;

        [MethodImpl(Inline), Op]
        public static SizeOverride szov(bit ad)
            => ad ? adsz() : opsz();

        [MethodImpl(Inline), Op]
        public static LockPrefix @lock()
            =>  LockPrefixCode.LOCK;

        [MethodImpl(Inline), Op]
        public static RepPrefix repz()
            => RepPrefixCode.REPZ;

        [MethodImpl(Inline), Op]
        public static RepPrefix repnz()
            => RepPrefixCode.REPNZ;

        [MethodImpl(Inline), Op]
        public static RepPrefix rep(bit z)
            => z ?repz() : repnz();

        public static RexPrefix rex(bit w, bit r, bit x, bit b)
            => default;

        [MethodImpl(Inline)]
        public static EvexPrefix evex(byte b0, byte b1, byte b2, byte b3)
            => new EvexPrefix(Bytes.join(b0,b1,b2,b3));

        [MethodImpl(Inline)]
        public static EvexPrefix evex(ReadOnlySpan<byte> src)
        {
            var count = min(src.Length,4);
            var data = 0u;
            for(var i=0; i<count; i++)
                data |= ((uint)skip(src,i) << (i*8));
            return new EvexPrefix(data);
        }
    }
}