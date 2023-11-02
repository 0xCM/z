//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static sys;

[ApiHost, Free]
public class AsmPrefix
{        
    [MethodImpl(Inline)]
    public static EvexPrefix evex(ReadOnlySpan<byte> src)
    {
        if(src.Length < 4)
            return EvexPrefix.Empty;
        else
            return @as<EvexPrefix>(src);
    }

    [MethodImpl(Inline), Op]
    public static SizeOverride opsz()
        => SizeOverrideCode.OSZ;

    [MethodImpl(Inline), Op]
    public static SizeOverride adsz()
        => SizeOverrideCode.ASZ;

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

    [MethodImpl(Inline), Op]
    public static RexPrefix rex(bit w, bit r, bit x, bit b)
        => new (w,r,x,b);

}
