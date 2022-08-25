//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = ClrIntegerKind;
    using C = ClrIntegerType;
    using L = ClrIntegerType.Symbols;

    public readonly record struct ClrIntegerType
    {
        [MethodImpl(Inline), Op]
        public static string keyword(C src)
            => CsData.keyword(src.Kind);

        public static C I8 => K.I8;

        public static C U8 => K.U8;

        public static C I16 => K.I16;

        public static C U16 => K.U16;

        public static C I32 => K.I32;

        public static C U32 => K.U32;

        public static C I64 => K.I64;

        public static C U64 => K.U64;

        [LiteralProvider("clr")]
        public readonly struct Symbols
        {
            public const string I8 ="i8";

            public const string U8 ="u8";

            public const string I16 ="i16";

            public const string U16 ="u16";

            public const string I32 ="i32";

            public const string U32 ="u32";

            public const string I64 ="i64";

            public const string U64 ="u64";
        }

        public static string format(C src)
        {
           var dst = EmptyString;
            if(src.Kind != 0)
            {
                switch(src.Kind)
                {
                    case K.I8:
                        dst = L.I8;
                    break;
                    case K.U8:
                        dst = L.U8;
                    break;
                    case K.I16:
                        dst = L.I16;
                    break;
                    case K.U16:
                        dst = L.U16;
                    break;
                    case K.I32:
                        dst = L.I32;
                    break;
                    case K.U32:
                        dst = L.U32;
                    break;
                    case K.I64:
                        dst = L.I64;
                    break;
                    case K.U64:
                        dst = L.U16;
                    break;
                }
            }
            return dst;
        }

        [Parser]
        public static bool parse(string src, out C dst)
        {
            dst = Empty;
            switch(src)
            {
                case L.I8:
                    dst = I8;
                break;
                case L.U8:
                    dst = U8;
                break;
                case L.I16:
                    dst = I16;
                break;
                case L.U16:
                    dst = U16;
                break;
                case L.I32:
                    dst = I32;
                break;
                case L.U32:
                    dst = U32;
                break;
                case L.I64:
                    dst = I64;
                break;
                case L.U64:
                    dst = U16;
                break;
            }
            return dst != Empty;
        }

        public readonly K Kind;

        [MethodImpl(Inline)]
        public ClrIntegerType(K kind)
        {
            Kind = kind;
        }

        public string Keyword
        {
            [MethodImpl(Inline)]
            get => keyword(this);
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => (uint)Kind;
        }


        public override int GetHashCode()
            => Hash;

        public string Format()
            => format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator C(K src)
            => new (src);

        [MethodImpl(Inline)]
        public static implicit operator K(C src)
            => src.Kind;

        [MethodImpl(Inline)]
        public static implicit operator C(ClrEnumKind src)
            => new ((K)src);

        public static C Empty => default;
    }
}