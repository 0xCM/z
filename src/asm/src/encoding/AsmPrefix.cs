//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static sys;
using static AsmPrefixTokens;

using Code = NominalPrefix;
using Kind = AsmPrefixKind;
using Class = AsmPrefixClass;

[ApiHost, Free]
public class AsmPrefix
{        
    [MethodImpl(Inline)]
    public static EvexPrefix evex(byte b1, byte b2, byte b3)
        => new (Bytes.join(0x62, b1, b2, b3));

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

    [MethodImpl(Inline), Op]
    public static RexPrefix rex(bit w, bit r, bit x, bit b)
        => new (w,r,x,b);

    [Op]
    public static Kind kinds(ReadOnlySpan<byte> src)
    {
        var count = src.Length;
        var result = Kind.None;
        for(var i=0; i<count; i++)
        {
            var c = code(skip(src,i));
            if(c != 0)
                result |= kind(c);
        }
        return result;
    }

    [Op]
    public static Class @class(Code src)
        => src switch
        {
            Code.SsSegOverride => Class.Legacy,
            Code.EsSegOverride => Class.Legacy,
            Code.FsSegOverride => Class.Legacy,
            Code.GsSegOverride => Class.Legacy,
            Code.OSZ => Class.Legacy,
            Code.ASZ => Class.Legacy,
            Code.BranchTaken => Class.Legacy,
            Code.BranchNotTaken => Class.Legacy,
            Code.Lock => Class.Legacy,
            Code.RepF2 => Class.Legacy,
            Code.RepF3 => Class.Legacy,
            Code.Rex => Class.REX,
            Code.VexC4 => Class.VEX,
            Code.VexC5 => Class.VEX,
            _ => Class.None,
        };

    [Op]
    public static Class @class(Kind src)
        => src switch
        {
            Kind.SsSegOverride => Class.Legacy,

            Kind.EsSegOverride => Class.Legacy,

            Kind.FsSegOverride => Class.Legacy,

            Kind.GsSegOverride => Class.Legacy,

            Kind.OSZ => Class.Legacy,

            Kind.ASZ => Class.Legacy,

            Kind.BranchTaken => Class.Legacy,

            Kind.BranchNotTaken => Class.Legacy,

            Kind.Lock => Class.Legacy,

            Kind.RepF2 => Class.Legacy,

            Kind.RepF3 => Class.Legacy,

            Kind.Rex => Class.REX,

            Kind.VexC4 => Class.VEX,

            Kind.VexC5 => Class.VEX,
            _ => Class.None,
        };

    [Op]
    public static Kind kind(Code code)
        => code switch
        {
            Code.CsSegOverride => Kind.CsSegOverride,

            Code.SsSegOverride => Kind.SsSegOverride,

            Code.EsSegOverride => Kind.EsSegOverride,

            Code.FsSegOverride => Kind.FsSegOverride,

            Code.GsSegOverride => Kind.GsSegOverride,

            Code.DsSegOverride => Kind.DsSegOverride,

            Code.Rex => Kind.Rex,

            Code.OSZ => Kind.OSZ,

            Code.ASZ => Kind.ASZ,

            Code.Lock => Kind.Lock,

            Code.RepF2 => Kind.RepF2,

            Code.RepF3 => Kind.RepF3,

            Code.VexC4 => Kind.VexC4,

            Code.VexC5 => Kind.VexC5,

            _ => Kind.None,
        };

    [Op]
    public static Code code(byte src)
        => src switch
        {
            0x0F => Code.Escape,

            0x36 => Code.SsSegOverride,

            0x26 => Code.EsSegOverride,

            0x64 => Code.FsSegOverride,

            0x65 => Code.GsSegOverride,

            0x40 => Code.Rex,

            0x66 => Code.OSZ,

            0x67 => Code.ASZ,

            0xF0 => Code.Lock,

            0xF2 => Code.RepF2,

            0xF3 => Code.RepF3,

            0xC4 => Code.VexC4,

            0xC5 => Code.VexC5,

            _ => Code.None,
        };            
}
