//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

using static sys;

using static AsmOpCodeKind;
using static VexMapKind;
using static EvexMapKind;
using static Asm.LegacyMapKind;

using I = AsmOpCodeIndex;
using X = XopMapKind;
using K = AsmOpCodeKind;
using N = XedMapNumber;
using S = AsmOpCodes.Literals;
using E = EvexMapKind;

public partial class AsmOpCodes
{
    public const string group = "asm.opcodes";
    
    public static AsmOpCode opcode(MachineMode mode, AsmOpCodeIndex index, uint value)
        => new(mode,kind(index), value);

    public static byte number(AsmOpCodeKind kind)
    {
        var dst = z8;
        switch(kind)
        {
            case Base00:
                dst = 0;
            break;
            case Base0F:
                dst = 1;
            break;
            case Base0F38:
                dst = 2;
            break;
            case Base0F3A:
                dst = 3;
            break;
            case Amd3DNow:
                dst = 4;
            break;
            case Xop8:
                dst = 8;
            break;
            case Xop9:
                dst = 9;
            break;
            case XopA:
                dst = 10;
            break;
            case Vex0F:
                dst = 1;
            break;
            case Vex0F38:
                dst = 2;
            break;
            case Vex0F3A:
                dst = 3;
            break;
            case Evex0F:
                dst = 1;
            break;
            case Evex0F38:
                dst = 2;
            break;
            case Evex0F3A:
                dst = 3;
            break;
            case Evex5:
                dst = 5;
            break;
            case Evex6:
                dst = 6;
            break;
        }

        return dst;
    }
    public static K kind(AsmOpCodeClass @class, byte number)
    {
        var kind = K.None;
        switch(@class)
        {
            case AsmOpCodeClass.Legacy:
            {
                switch(number)
                {
                    case 0:
                        kind = Base00;
                    break;
                    case 1:
                        kind = Base0F;
                    break;
                    case 2:
                        kind = Base0F38;
                    break;
                    case 3:
                        kind = Base0F3A;
                    break;
                    case 4:
                        kind = Amd3DNow;
                    break;
                }
            }
            break;
            case AsmOpCodeClass.Xop:
            {
                switch(number)
                {
                    case 8:
                        kind = Xop8;
                    break;
                    case 9:
                        kind = Xop9;
                    break;
                    case 10:
                        kind = XopA;
                    break;
                }
            }
            break;
            case AsmOpCodeClass.Vex:
            {
                switch(number)
                {
                    case 1:
                        kind = Vex0F;
                    break;
                    case 2:
                        kind = Vex0F38;
                    break;
                    case 3:
                        kind = Vex0F3A;
                    break;
                }
            }
            break;
            case AsmOpCodeClass.Evex:
            {
                switch(number)
                {
                    case 1:
                        kind = Evex0F;
                    break;
                    case 2:
                        kind = Evex0F38;
                    break;
                    case 3:
                        kind = Evex0F3A;
                    break;
                    case 5:
                        kind = Evex5;
                    break;
                    case 6:
                        kind = Evex6;
                    break;
                }
            }
            break;
        }
        return kind;
    }

    public static ReadOnlySeq<OpCodeMapInfo> info()
    {
        var counter = z8;
        var count = 0u;
        var legacy = Symbols.index<LegacyMapKind>();
        var xop = Symbols.index<XopMapKind>();
        var vex = Symbols.index<VexMapKind>();
        var evex = Symbols.index<E>();

        var counts = legacy.Count + xop.Count + vex.Count + evex.Count;
        var buffer = alloc<OpCodeMapInfo>(counts);

        count = legacy.Count;
        for(var i=0u; i<count; i++)
        {
            ref readonly var sym = ref legacy[i];
            ref var dst = ref seek(buffer, counter);
            dst.Index = counter++;
            dst.Class = AsmOpCodeClass.Legacy;
            dst.Code = sym.Expr.Format();
            dst.Number = (byte)sym.Kind;
            dst.Kind = (K)((ushort)dst.Class | ((ushort)sym.Kind << 8));
            dst.Name = name(dst.Kind);
        }

        count = xop.Count;
        for(var i=0u; i<count; i++)
        {
            ref readonly var sym = ref xop[i];
            ref var dst = ref seek(buffer,counter);
            dst.Index = counter++;
            dst.Class = AsmOpCodeClass.Xop;
            dst.Code = sym.Expr.Format();
            dst.Number = (byte)sym.Kind;
            dst.Kind = (K)((ushort)dst.Class | ((ushort)sym.Kind << 8));
            dst.Name = name(dst.Kind);
        }

        count = vex.Count;
        for(var i=0u; i<count; i++)
        {
            ref readonly var sym = ref vex[i];
            ref var dst = ref seek(buffer,counter);
            dst.Index = counter++;
            dst.Class = AsmOpCodeClass.Vex;
            dst.Code = sym.Expr.Format();
            dst.Number = (byte)sym.Kind;
            dst.Kind = (K)((ushort)dst.Class | ((ushort)sym.Kind << 8));
            dst.Name = name(dst.Kind);
        }

        count = evex.Count;
        for(var i=0u; i<count; i++)
        {
            ref readonly var sym = ref evex[i];
            ref var dst = ref seek(buffer,counter);
            dst.Index = counter++;
            dst.Class = AsmOpCodeClass.Evex;
            dst.Code = sym.Expr.Format();
            dst.Number = (byte)sym.Kind;
            dst.Kind = (K)((ushort)dst.Class | ((ushort)sym.Kind << 8));
            dst.Name = name(dst.Kind);
        }

        return buffer;
    }

    [Parser]
    public static Outcome parse(string src, out OpCodeValue dst)
    {
        var storage = Cells.alloc(w32);
        var result = Hex.parse(src, bytes(storage));
        dst = OpCodeValue.Empty;
        if(result)
            dst = new OpCodeValue(slice(bytes(storage),0, result.Data));
        return result;
    }

    public static ulong convert(AsmOpCode src, out ulong dst)
    {
        dst = @as<AsmOpCode,ulong>(src);
        return dst;
    }

    public static AsmOpCode convert(ulong src, out AsmOpCode dst)
    {
        dst = @as<ulong,AsmOpCode>(src);
        return dst;
    }

    public static int cmp(K a, K b)
    {
        return order(a).CompareTo(order(b));

        static int order(K src)
            => src switch
            {   Base00 => 0,
                Base0F => 1,
                Base0F38 => 2,
                Base0F3A => 3,
                Amd3DNow => 4,
                Xop8 => 5,
                Xop9 => 6,
                XopA => 7,
                Vex0F => 8,
                Vex0F38 => 9,
                Vex0F3A => 10,
                Evex0F => 11,
                Evex0F38 => 12,
                Evex0F3A => 13,
                Evex5 => 14,
                Evex6 => 15,
                _ => 0,
            };
    }

    public static MapName name(K kind)
    {
        var symbol = AsmOpCodes.symbol(kind);
        return new (symbol, selector(kind), $"{symbol}[{value(kind)}]");
    }

    [MethodImpl(Inline), Op]
    public static LegacyMapKind basemap(OpCodeValue value)
    {
        var dst = default(LegacyMapKind);
        if(value[0] == 0x0F)
        {
            if(value[1] == 0x38)
                dst = BaseMap2;
            else if(value[1] == 0x3A)
                dst = BaseMap3;
            else
                dst = BaseMap1;
        }
        else
            dst = BaseMap0;
        return dst;
    }

    [Op]
    public static I index(K kind)
        => kind switch
        {
            Base00 => I.LegacyMap0,
            Base0F => I.LegacyMap1,
            Base0F38 => I.LegacyMap2,
            Base0F3A => I.LegacyMap3,
            Amd3DNow => I.Amd3dNow,
            Xop8 => I.Xop8,
            Xop9 => I.Xop9,
            XopA => I.XopA,
            Vex0F => I.Vex0F,
            Vex0F38 => I.Vex0F38,
            Vex0F3A => I.Vex0F3A,
            Evex0F => I.Evex0F,
            Evex0F38 => I.Evex0F38,
            Evex0F3A => I.Evex0F3A,
            Evex5 => I.Evex5,
            Evex6 => I.Evex6,
            _ => 0
        };

    [Op]
    public static I index(LegacyMapKind kind)
        => kind switch
        {
            BaseMap0 => I.LegacyMap0,
            BaseMap1 => I.LegacyMap1,
            BaseMap2 => I.LegacyMap2,
            BaseMap3 => I.LegacyMap3,
            Amd3dNow => I.Amd3dNow,
            _ => 0
        };

    [Op]
    public static I index(VexMapKind kind)
        => kind switch
        {
            VEX_MAP_0F => I.Vex0F,
            VEX_MAP_0F38 => I.Vex0F38,
            VEX_MAP_0F3A => I.Vex0F3A,
            _ => 0
        };

    [Op]
    public static I index(E kind)
        => kind switch
        {
            EVEX_MAP_0F => I.Evex0F,
            EVEX_MAP_0F38 => I.Evex0F38,
            EVEX_MAP_0F3A => I.Evex0F3A,
            EVEX_MAP_5 => I.Evex5,
            EVEX_MAP_6 => I.Evex6,
            _ => 0
        };

    [Op]
    public static I index(X kind)
        => kind switch
        {
            X.Xop8 => I.Xop8,
            X.Xop9 => I.Xop9,
            X.XopA => I.XopA,
            _ => 0
        };

    [Op]
    public static K kind(I src)
        => src switch {
            I.LegacyMap0 => Base00,
            I.LegacyMap1 => Base0F,
            I.LegacyMap2 => Base0F38,
            I.LegacyMap3 => Base0F3A,
            I.Amd3dNow => Amd3DNow,
            I.Xop8 => Xop8,
            I.Xop9 => Xop9,
            I.XopA => XopA,
            I.Vex0F => Vex0F,
            I.Vex0F38 => Vex0F38,
            I.Vex0F3A => Vex0F3A,
            I.Evex0F => Evex0F,
            I.Evex0F38 => Evex0F38,
            I.Evex0F3A => Evex0F3A,
            I.Evex5 => Evex5,
            I.Evex6 => Evex6,
            _=> AsmOpCodeKind.None
        };

    [Op]
    public static AsmOpCodeClass @class(K src)
        => (AsmOpCodeClass)(byte)src;

    public static asci4 selector(K src)
        => src switch {
            Base00 => "0000",
            Base0F => "000F",
            Base0F38 => "0F38",
            Base0F3A => "0F3A",
            Amd3DNow => "003D",
            Xop8 => "0008",
            Xop9 => "0009",
            XopA => "000A",
            Vex0F => "000F",
            Vex0F38 => "0F38",
            Vex0F3A => "0F3A",
            Evex0F => "000F",
            Evex0F38 => "0F38",
            Evex0F3A => "0F3A",
            _ => asci4.Null,
        };

    public static Hex16 value(K src)
        => src switch {
            Base00 => 0x0000,
            Base0F => 0x000F,
            Base0F38 => 0x0F38,
            Base0F3A => 0x0F3A,
            Amd3DNow => 0x003D,
            Xop8 => 0x0008,
            Xop9 => 0x0009,
            XopA => 0x000A,
            Vex0F => 0x000F,
            Vex0F38 => 0x0F38,
            Vex0F3A => 0x0F3A,
            Evex0F => 0x000F,
            Evex0F38 => 0x0F38,
            Evex0F3A => 0x0F3A,
            _ =>  0x0000,
        };

    [Op]
    public static asci2 symbol(K src)
        => src switch
        {
            Base00 => S.B0,
            Base0F => S.B1,
            Base0F38 => S.B2,
            Base0F3A => S.B3,
            Amd3DNow => S.D3,
            Xop8 => S.X8,
            Xop9 => S.X9,
            XopA => S.XA,
            Vex0F => S.V1,
            Vex0F38 => S.V2,
            Vex0F3A => S.V3,
            Evex0F => S.E1,
            Evex0F38 => S.E2,
            Evex0F3A => S.E3,
            Evex5 => S.E5,
            Evex6 => S.E6,
            _ => EmptyString
        };

    [Op]
    public static AsmOpCodeMap map(K src)
        => new (src, @class(src), index(src), symbol(src), selector(src));

    static string hex(byte src)
        => "0x" + src.ToString("X2");

    public static string format(AsmOpCode src)
    {
        var space = EmptyString;
        switch(src.Map.Class)
        {
            case AsmOpCodeClass.Legacy:
                space = Literals.@base;
            break;
            case AsmOpCodeClass.Xop:
                space = Literals.xop;
            break;
            case AsmOpCodeClass.Vex:
                space = Literals.vex;
            break;
            case AsmOpCodeClass.Evex:
                space = Literals.evex;
            break;
        }
        var a = src.Map.Value;
        var value = src.Value.Bytes;
        var size = src.Value.TrimmedSize;
        var lo = (byte)a;
        var hi = (byte)(a >> 8);
        var symbol = src.Symbol;
        var dst = EmptyString;
        switch(size)
        {
            case 0:
            case 1:
            {
                ref readonly var b0 = ref value[0];
                dst = $"{space}[{src.MapNumber}]:{hex(b0)}";
            }
            break;
            case 2:
            {
                ref readonly var b0 = ref value[1];
                ref readonly var b1 = ref value[0];
                dst = $"{space}[{src.MapNumber}]:{hex(b1)} {hex(b0)}";
                if(lo !=0 && hi == 0)
                {
                    if(lo == b1)
                        dst = $"{space}[{src.MapNumber}]:{hex(b0)}";
                }
            }
            break;
            case 3:
            {
                ref readonly var b0 = ref value[2];
                ref readonly var b1 = ref value[1];
                ref readonly var b2 = ref value[0];
                dst = $"{space}[{src.MapNumber}]:{hex(b2)} {hex(b1)} {hex(b0)}";
                if(lo !=0 && hi != 0)
                {
                    if(hi == b2 && lo == b1)
                        dst = $"{space}[{src.MapNumber}]:{hex(b0)}";
                }
                else if(lo != 0)
                {
                    if(lo == b2)
                        dst = $"{space}[{src.MapNumber}]:{hex(b1)} {hex(b0)}";
                }
            }
            break;
        }

        return dst;
    }

    [LiteralProvider(group)]
    public readonly struct Literals
    {
        /// <summary>
        /// Legacy map 0
        /// </summary>
        public const string B0 = nameof(B0);

        /// <summary>
        /// Legacy map 1
        /// </summary>
        public const string B1 = nameof(B1);

        /// <summary>
        /// Legacy map 2
        /// </summary>
        public const string B2 = nameof(B2);

        /// <summary>
        /// Legacy map 3
        /// </summary>
        public const string B3 = nameof(B3);

        /// <summary>
        /// Vex map 1
        /// </summary>
        public const string V1 = nameof(V1);

        /// <summary>
        /// Vex map 2
        /// </summary>
        public const string V2 = nameof(V2);

        /// <summary>
        /// Vex map 3
        /// </summary>
        public const string V3 = nameof(V3);

        /// <summary>
        /// Evex map 1
        /// </summary>
        public const string E1 = nameof(E1);

        /// <summary>
        /// Evex map 2
        /// </summary>
        public const string E2 = nameof(E2);

        /// <summary>
        /// Evex map 3
        /// </summary>
        public const string E3 = nameof(E3);

        /// <summary>
        /// Evex map 5
        /// </summary>
        public const string E5 = nameof(E5);

        /// <summary>
        /// Evex map 6
        /// </summary>
        public const string E6 = nameof(E6);

        /// <summary>
        /// Xop map 8
        /// </summary>
        public const string X8 = "X8";

        /// <summary>
        /// Xop map 9
        /// </summary>
        public const string X9 = "X9";

        /// <summary>
        /// Xop map A
        /// </summary>
        public const string XA = "XA";

        /// <summary>
        /// AMD 3D Now
        /// </summary>
        public const string D3 = "3D";

        public const string VV0 = nameof(VV0);

        public const string VV1 = nameof(VV1);

        public const string EVV = nameof(EVV);

        public const string KVV = nameof(KVV);

        public const string XOPV = nameof(XOPV);

        public const string BASE = nameof(BASE);

        public const string BaseClassName = BASE;

        public const string VexClassName = VV1;

        public const string EvexClassName = EVV;

        public const string Amd3dClassName = "3D";

        public const string XopClassName = "XOP";

        public const string evex = nameof(evex);

        public const string vex = nameof(vex);

        public const string @base = "base";

        public const string xop = nameof(xop);

    }
}
