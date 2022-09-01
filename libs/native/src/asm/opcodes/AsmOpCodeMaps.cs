//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using static XedOpCodeKind;
    using static VexMapKind;
    using static EvexMapKind;
    using static AsmBaseMapKind;
    using static XedLiterals;

    using V = XedLiterals.XedVexClass;
    using I = AsmOpCodeIndex;
    using D = XedOpCodeKind;
    using X = XopMapKind;
    using K = XedOpCodeKind;
    using N = XedMapNumber;
    using S = AsmOpCodeMaps.Literals;

    public partial class AsmOpCodeMaps
    {
        public const string group = "asm.opcodes";

        public static ref ulong convert(XedOpCode src, out ulong dst)
        {
            dst = @as<XedOpCode,ulong>(src);
            return ref dst;
        }

        public static ref XedOpCode convert(ulong src, out XedOpCode dst)
        {
            dst = @as<ulong,XedOpCode>(src);
            return ref dst;
        }

        public static int cmp(XedOpCodeKind a, XedOpCodeKind b)
        {
            return order(a).CompareTo(order(b));

            static int order(XedOpCodeKind src)
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

        public static char indicator(AsmOpCodeClass src)
            => src switch {
                AsmOpCodeClass.Base => 'B',
                AsmOpCodeClass.Xop => 'X',
                AsmOpCodeClass.Vex => 'V',
                AsmOpCodeClass.Evex => 'E',
                AsmOpCodeClass.Amd3D => 'A',
                _ => (char)0
            };

        public static MapName name(XedOpCodeKind kind)
        {
            var symbol = AsmOpCodeMaps.symbol(kind);
            return new (symbol, selector(kind), $"{symbol}[{value(kind)}]");
        }

        [MethodImpl(Inline), Op]
        public static AsmBaseMapKind? basemap(byte code)
            => code <= 4? (AsmBaseMapKind)code : null;

        [MethodImpl(Inline), Op]
        public static AsmBaseMapKind basemap(AsmOcValue value)
        {
            var dst = default(AsmBaseMapKind);
            if(value[0] == 0x0F)
            {
                if(value[1] == 0x38)
                    dst = AsmBaseMapKind.BaseMap2;
                else if(value[1] == 0x3A)
                    dst = AsmBaseMapKind.BaseMap3;
                else
                    dst = AsmBaseMapKind.BaseMap1;
            }
            else
                dst = AsmBaseMapKind.BaseMap0;
            return dst;
        }

        [Op]
        public static I index(XedOpCodeKind kind)
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
        public static I index(VexMapKind kind)
            => kind switch
            {
                VEX_MAP_0F => I.Vex0F,
                VEX_MAP_0F38 => I.Vex0F38,
                VEX_MAP_0F3A => I.Vex0F3A,
                _ => 0
            };

        [Op]
        public static I index(EvexMapKind kind)
            => kind switch
            {
                EVEX_MAP_0F => I.Evex0F,
                EVEX_MAP_0F38 => I.Evex0F38,
                EVEX_MAP_0F3A => I.Evex0F3A,
                _ => 0
            };

        [Op]
        public static I index(XopMapKind kind)
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
        public static I index(AsmBaseMapKind kind)
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
        public static I? index(XedVexClass @class, byte map)
        {
            var dst = default(AsmOpCodeIndex?);
            switch(@class)
            {
                case XedVexClass.VV1:
                    dst = index((VexMapKind)map);
                break;
                case XedVexClass.EVV:
                    dst = index((EvexMapKind)map);
                break;
                case XedVexClass.XOPV:
                    dst = index((XopMapKind)map);
                break;
                default:
                    dst = index((AsmBaseMapKind)map);
                break;
            }
            return dst;
        }

        public static D kind(V vc, byte number)
        {
            var ock = D.None;
            switch(vc)
            {
                case V.VV1:
                    ock = kind(index((VexMapKind)number));
                break;
                case V.XOPV:
                    ock = kind(index((XopMapKind)number));
                break;
                case V.EVV:
                case V.KVV:
                    ock = kind(index((EvexMapKind)number));
                break;
                default:
                    ock = kind((I)basemap(number));
                break;
            }
            return ock;
        }

        [Op]
        public static D kind(I src)
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
                _=> XedOpCodeKind.None
            };

        [Op]
        public static AsmOpCodeClass @class(AsmOpCodeIndex src)
            => @class(kind(src));

        [Op]
        public static AsmOpCodeClass @class(XedOpCodeKind src)
            => (AsmOpCodeClass)(byte)src;

        [MethodImpl(Inline), Op]
        public static VexMapKind? vexmap(XedVexClass kind, byte code)
            => kind == XedVexClass.VV1 ? (VexMapKind)code : null;

        [MethodImpl(Inline), Op]
        public static EvexMapKind? evexmap(XedVexClass kind, byte code)
            => kind == XedVexClass.EVV ? (EvexMapKind)code : null;

        [MethodImpl(Inline), Op]
        public static XopMapKind? xopmap(XedVexClass kind, byte code)
            => kind == XedVexClass.XOPV ? (XopMapKind)code : null;

        [Op]
        public static XedVexClass vexclass(AsmOpCodeIndex src)
            => vexclass(@class(src));

        [Op]
        public static XedVexClass vexclass(AsmOpCodeClass src)
        {
            var vc = XedVexClass.None;
            switch(src)
            {
                case AsmOpCodeClass.Vex:
                    vc = XedVexClass.VV1;
                break;
                case AsmOpCodeClass.Evex:
                    vc = XedVexClass.VV1;
                break;
                case AsmOpCodeClass.Xop:
                    vc = XedVexClass.XOPV;
                break;
            }
            return vc;
        }

        public static asci4 selector(XedOpCodeKind src)
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

        public static Hex16 value(XedOpCodeKind src)
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
        public static asci2 symbol(XedOpCodeKind src)
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
        public static AsmOpCodeMap map(D src)
            => new AsmOpCodeMap(src, @class(src), index(src), symbol(src), selector(src));

        [MethodImpl(Inline), Op]
        public static AsmOpCodeMap map(I src)
            => map(kind(src));

        public static bool map(I src, out N dst)
        {
            var result = true;
            dst = default;
            switch(src)
            {
                case I.LegacyMap0:
                    dst = (N)AsmBaseMapKind.BaseMap0;
                break;
                case I.LegacyMap1:
                    dst = (N)AsmBaseMapKind.BaseMap1;
                break;
                case I.LegacyMap2:
                    dst = (N)AsmBaseMapKind.BaseMap2;
                break;
                case I.LegacyMap3:
                    dst = (N)AsmBaseMapKind.BaseMap3;
                break;
                case I.Amd3dNow:
                    dst = (N)src;
                break;

                case I.Vex0F:
                    dst = (N)VexMapKind.VEX_MAP_0F;
                break;
                case I.Vex0F38:
                    dst = (N)VexMapKind.VEX_MAP_0F38;
                break;
                case I.Vex0F3A:
                    dst = (N)VexMapKind.VEX_MAP_0F3A;
                break;
                case I.Evex0F:
                    dst = (N)EvexMapKind.EVEX_MAP_0F;
                break;
                case I.Evex0F38:
                    dst = (N)EvexMapKind.EVEX_MAP_0F38;
                break;
                case I.Evex0F3A:
                    dst = (N)EvexMapKind.EVEX_MAP_0F3A;
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
                default:
                    result = false;
                break;

            }
            return result;
        }


         static string hex(byte src)
            => "0x" + src.ToString("X2");

        public static string format(XedOpCode src)
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
}