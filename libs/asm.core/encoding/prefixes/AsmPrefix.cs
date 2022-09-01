//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;
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
    }
}