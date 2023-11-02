//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;


using static sys;

using K = VexPrefixKind;

public class Vex
{
    public static string format(VexPrefix src)
    {
        var kind = src.VexKind;
        if(kind == K.xC4)
            return c4(src).Format();
        else if(kind == K.xC5)
            return c5(src).Format();
        else
            return EmptyString;
    }

    public static string bitstring(VexPrefix src)
        => src.VexKind == K.xC4 
        ? c4(src).Bitstring() 
        : src.VexKind == K.xC5 
        ? c5(src).Bitstring() 
        : EmptyString;

    [MethodImpl(Inline), Op]
    public static VexPrefix define(K kind, byte b1)
        => new (kind, b1);

    [MethodImpl(Inline), Op]
    public static VexPrefix define(K kind, byte b1, byte b2)
        => new (kind, b1, b2);

    [MethodImpl(Inline)]
    public static VexC4 c4(VexPrefix src)
    {
        var data = slice(bytes(src), 1, 2);
        return VexC4.define(skip(data,0), skip(data,1));
    }

    [MethodImpl(Inline)]
    public static VexC5 c5(VexPrefix src)
        => VexC5.define((byte)(src._Data >> 8));

    [MethodImpl(Inline)]
    public static BitfieldSeg<K> code(ReadOnlySpan<byte> src)
    {
        var seg = BitfieldSeg<K>.Empty;
        var count = src.Length;
        for(var i=z8; i<count; i++)
        {
            ref readonly var b = ref skip(src,i);
            if(b == (byte)K.xC4)
            {
                seg = BitfieldSeg.define(K.xC4, i, 8);
                break;
            }
            if(b == (byte)K.xC5)
            {
                seg = BitfieldSeg.define(K.xC5, i, 8);
                break;
            }
        }
        return seg;
    }

    [MethodImpl(Inline), Op]
    public static AsmOpCodeMap map(VexM src)
        => src switch {
            VexM.x0F => AsmOpCodes.map(AsmOpCodeKind.Vex0F),
            VexM.x0F38 => AsmOpCodes.map(AsmOpCodeKind.Vex0F38),
            VexM.x0F3A => AsmOpCodes.map(AsmOpCodeKind.Vex0F3A),
            _ => AsmOpCodeMap.Empty,
        };

    [MethodImpl(Inline), Op]
    public static byte decode(VexPP src)
        => src switch {
            VexPP.X66 => 0x66,
            VexPP.F2 => 0xF2,
            VexPP.F3 => 0xF3,
            _ => 0,
        };

    [MethodImpl(Inline), Op]
    public static byte size(K src)
        => src switch{
            K.xC4 => 3,
            K.xC5 => 2,
            _ => 0
        };
}