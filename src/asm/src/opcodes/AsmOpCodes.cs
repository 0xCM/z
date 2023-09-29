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

using V = XedVexClass;
using I = AsmOpCodeIndex;
using X = XopMapKind;
using K = AsmOpCodeKind;
using N = XedMapNumber;
using S = AsmOpCodes.Literals;
using E = EvexMapKind;

public partial class AsmOpCodes
{
    public const string group = "asm.opcodes";

    public static byte number(K kind)
        => kind switch {
            Base00 => (byte)BaseMap0,
            Base0F => (byte)BaseMap1,
            Base0F38 => (byte)BaseMap2,
            Base0F3A => (byte)BaseMap3,
            Amd3DNow => (byte)Amd3dNow,
            Xop8 => (byte)X.Xop8,
            Xop9 => (byte)X.Xop9,
            XopA => (byte)X.XopA,
            Vex0F => (byte)VEX_MAP_0F,
            Vex0F38 => (byte)VEX_MAP_0F38,
            Vex0F3A => (byte)VEX_MAP_0F3A,
            Evex0F => (byte)EVEX_MAP_0F,
            Evex0F38 => (byte)EVEX_MAP_0F38,
            Evex0F3A => (byte)EVEX_MAP_0F3A,
            _ => 0xFF,
        };

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
                        kind = K.Base00;
                    break;
                    case 1:
                        kind = K.Base0F;
                    break;
                    case 2:
                        kind = K.Base0F38;
                    break;
                    case 3:
                        kind = K.Base0F3A;
                    break;
                    case 4:
                        kind = K.Amd3DNow;
                    break;
                }
            }
            break;
            case AsmOpCodeClass.Xop:
            {
                switch(number)
                {
                    case 1:
                        kind = K.Xop8;
                    break;
                    case 2:
                        kind = K.Xop9;
                    break;
                    case 3:
                        kind = K.XopA;
                    break;
                }
            }
            break;
            case AsmOpCodeClass.Vex:
            {
                switch(number)
                {
                    case 1:
                        kind = K.Vex0F;
                    break;
                    case 2:
                        kind = K.Vex0F38;
                    break;
                    case 3:
                        kind = K.Vex0F3A;
                    break;
                }
            }
            break;
            case AsmOpCodeClass.Evex:
            {
                switch(number)
                {
                    case 1:
                        kind = K.Evex0F;
                    break;
                    case 2:
                        kind = K.Evex0F38;
                    break;
                    case 3:
                        kind = K.Evex0F3A;
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
                Vex0F => 5,
                Vex0F38 => 6,
                Vex0F3A => 7,
                Evex0F => 8,
                Evex0F38 => 9,
                Evex0F3A => 10,
                Xop8 => 11,
                Xop9 => 12,
                XopA => 13,
                _ => 0,
            };
    }

    public static MapName name(K kind)
    {
        var symbol = AsmOpCodes.symbol(kind);
        return new (symbol, selector(kind), $"{symbol}[{value(kind)}]");
    }

    [MethodImpl(Inline), Op]
    public static LegacyMapKind? basemap(byte code)
        => code <= 4? (LegacyMapKind)code : null;

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
            K.Base00 => I.LegacyMap0,
            K.Base0F => I.LegacyMap1,
            K.Base0F38 => I.LegacyMap2,
            K.Base0F3A => I.LegacyMap3,
            K.Amd3DNow => I.Amd3dNow,
            K.Xop8 => I.Xop8,
            K.Xop9 => I.Xop9,
            K.XopA => I.XopA,
            K.Vex0F => I.Vex0F,
            K.Vex0F38 => I.Vex0F38,
            K.Vex0F3A => I.Vex0F3A,
            K.Evex0F => I.Evex0F,
            K.Evex0F38 => I.Evex0F38,
            K.Evex0F3A => I.Evex0F3A,
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

    public static I? index(byte code)
    {
        var kind = basemap(code);
        if(kind != null)
            return index(kind.Value);
        else
            return null;
    }

    [Op]
    public static I? index(V @class, byte map)
    {
        var dst = default(I?);
        switch(@class)
        {
            case V.VV1:
                dst = index((VexMapKind)map);
            break;
            case V.EVV:
                dst = index((E)map);
            break;
            case V.XOPV:
                dst = index((X)map);
            break;
            default:
                dst = index((LegacyMapKind)map);
            break;
        }
        return dst;
    }

    public static K kind(V vc, byte number)
    {
        var ock = K.None;
        switch(vc)
        {
            case V.VV1:
                ock = kind(index((VexMapKind)number));
            break;
            case V.XOPV:
                ock = kind(index((X)number));
            break;
            case V.EVV:
            case V.KVV:
                ock = kind(index((E)number));
            break;
            default:
                ock = kind((I)basemap(number));
            break;
        }
        return ock;
    }

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
            _=> AsmOpCodeKind.None
        };

    [Op]
    public static AsmOpCodeClass @class(I src)
        => @class(kind(src));

    [Op]
    public static AsmOpCodeClass @class(K src)
        => (AsmOpCodeClass)(byte)src;

    [MethodImpl(Inline), Op]
    public static VexMapKind? vexmap(V kind, byte code)
        => kind == V.VV1 ? (VexMapKind)code : null;

    [MethodImpl(Inline), Op]
    public static E? evexmap(V kind, byte code)
        => kind == V.EVV ? (E)code : null;

    [MethodImpl(Inline), Op]
    public static X? xopmap(V kind, byte code)
        => kind == V.XOPV ? (X)code : null;

    [Op]
    public static V vexclass(I src)
        => vexclass(@class(src));

    [Op]
    public static V vexclass(AsmOpCodeClass src)
    {
        var vc = V.None;
        switch(src)
        {
            case AsmOpCodeClass.Vex:
                vc = V.VV1;
            break;
            case AsmOpCodeClass.Evex:
                vc = V.VV1;
            break;
            case AsmOpCodeClass.Xop:
                vc = V.XOPV;
            break;
        }
        return vc;
    }

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

            _ => EmptyString
        };

    [Op]
    public static AsmOpCodeMap map(K src)
        => new (src, @class(src), index(src), symbol(src), selector(src));

    [MethodImpl(Inline), Op]
    public static AsmOpCodeMap map(I src)
        => map(kind(src));

    public static IEnumerable<AsmOpCodeMap> maps(AsmOpCodeClass @class)
    {
        switch(@class)
        {
            case AsmOpCodeClass.Legacy:
            {
                yield return map(I.LegacyMap0);
                yield return map(I.LegacyMap1);
                yield return map(I.LegacyMap2);
                yield return map(I.LegacyMap3);
                yield return map(I.Amd3dNow);
            }
            break;
            case AsmOpCodeClass.Xop:
            {
                yield return map(I.Xop8);
                yield return map(I.Xop9);
                yield return map(I.XopA);
            }
            break;
            case AsmOpCodeClass.Vex:
            {
                yield return map(I.Vex0F);
                yield return map(I.Vex0F38);
                yield return map(I.Vex0F3A);            
            }
            break;
            case AsmOpCodeClass.Evex:
            {
                yield return map(I.Evex0F);
                yield return map(I.Evex0F38);
                yield return map(I.Evex0F3A);            
            }
            break;
        }
    }

    public static IEnumerable<AsmOpCodeMap> maps()
    {
        foreach(var map in maps(AsmOpCodeClass.Legacy))
            yield return map;
        foreach(var map in maps(AsmOpCodeClass.Xop))
            yield return map;
        foreach(var map in maps(AsmOpCodeClass.Vex))
            yield return map;
        foreach(var map in maps(AsmOpCodeClass.Evex))
            yield return map;
    }    

    public static N? number(I src)
    {
        var dst = default(N?);
        switch(src)
        {
            case I.LegacyMap0:
                dst = (N)BaseMap0;
            break;
            case I.LegacyMap1:
                dst = (N)BaseMap1;
            break;
            case I.LegacyMap2:
                dst = (N)BaseMap2;
            break;
            case I.LegacyMap3:
                dst = (N)BaseMap3;
            break;
            case I.Amd3dNow:
                dst = (N)src;
            break;

            case I.Vex0F:
                dst = (N)VEX_MAP_0F;
            break;
            case I.Vex0F38:
                dst = (N)VEX_MAP_0F38;
            break;
            case I.Vex0F3A:
                dst = (N)VEX_MAP_0F3A;
            break;
            case I.Evex0F:
                dst = (N)EVEX_MAP_0F;
            break;
            case I.Evex0F38:
                dst = (N)EVEX_MAP_0F38;
            break;
            case I.Evex0F3A:
                dst = (N)EVEX_MAP_0F3A;
            break;
            case I.Xop8:
                dst = (N)XopMapKind.Xop8;
            break;
            case I.Xop9:
                dst = (N)XopMapKind.Xop9;
            break;
            case I.XopA:
                dst = (N)XopMapKind.XopA;
            break;
        }
        return dst;
    }

    static string hex(byte src)
        => "0x" + src.ToString("X2");

    public static string format(AsmOpCode src)
    {
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
                dst = $"{symbol}[{a}]:{hex(b0)}";
            }
            break;
            case 2:
            {
                ref readonly var b0 = ref value[1];
                ref readonly var b1 = ref value[0];
                dst = $"{symbol}[{a}]:{hex(b1)} {hex(b0)}";
                if(lo !=0 && hi == 0)
                {
                    if(lo == b1)
                        dst = $"{symbol}[{a}]:{hex(b0)}";
                }
            }
            break;
            case 3:
            {
                ref readonly var b0 = ref value[2];
                ref readonly var b1 = ref value[1];
                ref readonly var b2 = ref value[0];
                dst = $"{symbol}[{a}]:{hex(b2)} {hex(b1)} {hex(b0)}";
                if(lo !=0 && hi != 0)
                {
                    if(hi == b2 && lo == b1)
                        dst = $"{symbol}[{a}]:{hex(b0)}";
                }
                else if(lo != 0)
                {
                    if(lo == b2)
                        dst = $"{symbol}[{a}]:{hex(b1)} {hex(b0)}";
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
        /// Evex map 1
        /// </summary>
        public const string E2 = nameof(E2);

        /// <summary>
        /// Evex map 1
        /// </summary>
        public const string E3 = nameof(E3);

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
    }
}
