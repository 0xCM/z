//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static PrimalData;

    using W = PrimalData.SegWidth;
    using M = PrimalData.SegMask;
    using P = PrimalData.SegPos;
    using I = PrimalData.Field;

    using static sys;

    [ApiHost, Free]
    public class PrimalBits
    {
        /// <summary>
        /// Computes 2^i where i is an integer value in the interval [0,63]
        /// </summary>
        /// <param name="i">The exponent</param>
        [MethodImpl(Inline), Op]
        static ulong pow(byte i)
            => 1ul << i;

        /// <summary>
        /// Computes the bit-width of the represented primitive
        /// </summary>
        /// <param name="f">The literal's bitfield</param>
        [MethodImpl(Inline), Op]
        public static NativeTypeWidth width(PrimalKind f)
            => (NativeTypeWidth)pow(select(f, Field.Width));

        /// <summary>
        /// Determines the numeric sign, if any, of the represented primitive
        /// </summary>
        /// <param name="f">The literal's bitfield</param>
        [MethodImpl(Inline), Op]
        public static PolarityKind sign(PrimalKind f)
            => (PolarityKind)select(f, Field.Sign);

        [MethodImpl(Inline), Op]
        public static TypeCode typecode(PrimalKind f)
            => (TypeCode)select(f, Field.KindId);

        /// <summary>
        /// Computes the bit-width of the represented primitive
        /// </summary>
        /// <param name="f">The literal's bitfield</param>
        [MethodImpl(Inline), Op]
        public static NativeTypeWidth width(ClrEnumKind kind)
            => width((PrimalKind)kind);

        /// <summary>
        /// Computes the bit-width of the represented primitive
        /// </summary>
        /// <param name="f">The literal's bitfield</param>
        [MethodImpl(Inline), Op]
        public static PolarityKind sign(ClrEnumKind kind)
            => sign((PrimalKind)kind);

        [MethodImpl(Inline), Op]
        public static TypeCode typecode(ClrEnumKind kind)
            => typecode(kind);

        [MethodImpl(Inline), Op]
        public static ClrPrimitiveInfo describe(PrimalKind src)
            => new ClrPrimitiveInfo(src, width(src), sign(src), (PrimalCode)typecode(src));

        [MethodImpl(Inline), Op]
        public static ClrPrimitiveInfo describe(ClrEnumKind src)
            => new ClrPrimitiveInfo((PrimalKind)src, width(src), sign(src), (PrimalCode)typecode(src));

        [MethodImpl(Inline), Op]
        public static PrimalKind filter(byte src, SegMask mask)
            => (PrimalKind)(src & (byte)mask);

        /// <summary>
        /// Isolates an identified bitfield segment
        /// </summary>
        /// <param name="src">The source bitfield</param>
        /// <param name="i">The segment identifier</param>
        [MethodImpl(Inline), Op]
        public static PrimalKind filter(PrimalKind src, Field i)
            => filter((byte)src, filter(i));

        /// <summary>
        /// Gets the value of an identified bitfield segment
        /// </summary>
        /// <param name="src">The source bitfield</param>
        /// <param name="i">The segment identifier</param>
        [MethodImpl(Inline), Op]
        public static byte select(PrimalKind src, Field i)
            => (byte)view(filter(src,i), index(i));

        /// <summary>
        /// Returns the type-code identified primal kind
        /// </summary>
        /// <param name="src">The type code</param>
        [MethodImpl(Inline), Op]
        public static PrimalKind kind(TypeCode src)
            => skip(Kinds, (uint)src);

        [MethodImpl(Inline), Op]
        public static PrimalCode code(PrimalKind f)
            => (PrimalCode)select(f, Field.KindId);

        [Op]
        public static PrimalKind kind(Type src)
            => kind(sys.typecode(src));

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static PrimalKind kind<T>()
            => kind(sys.typecode<T>());

        public static ReadOnlySpan<PrimalKind> Kinds
        {
            [MethodImpl(Inline), Op]
            get => recover<PrimalKind>(PrimalKindData);
        }

        [MethodImpl(Inline), Op]
        static ref readonly SegMask filter(Field i)
            => ref skip(Masks, (byte)i);

        [MethodImpl(Inline), Op]
        static ref readonly SegPos index(Field i)
            => ref skip(Positions, (byte)i);

        [MethodImpl(Inline), Op]
        static PrimalKind view(PrimalKind src, SegPos offset)
            => (PrimalKind)((byte)src >> (byte)offset);

        static ReadOnlySpan<byte> PrimalKindData => new byte[19]{
            (byte)PrimalKind.None, //0:Empty/null
            (byte)PrimalKind.Object, //1:Object
            (byte)PrimalKind.DBNull, //2:DbNull
            (byte)PrimalKind.U1, //3:Bool
            (byte)PrimalKind.C16, //4:char
            (byte)PrimalKind.I8, //5:int8
            (byte)PrimalKind.U8, //6:uint8
            (byte)PrimalKind.I16, //7:short
            (byte)PrimalKind.U16, //8:ushort
            (byte)PrimalKind.I32, //9:int32
            (byte)PrimalKind.U32, //10:uint32
            (byte)PrimalKind.I64, //11:int64
            (byte)PrimalKind.U64, //12:uint64
            (byte)PrimalKind.F32, //13:float32
            (byte)PrimalKind.F64, //14:float64
            (byte)PrimalKind.F128, //15:decimal
            (byte)PrimalKind.DateTime, //16:datetime
            (byte)PrimalKind.None, // 17:empty
            (byte)PrimalKind.String //18:string
        };

        /// <summary>
        /// The bitfield segment count
        /// </summary>
        public const byte SegCount = 3;

        /// <summary>
        /// The total bitfield width
        /// </summary>
        public const byte TotalWidth = (byte)W.KindId + (byte)W.Width + (byte)W.Sign;

        /// <summary>
        /// The defined fields
        /// </summary>
        public static ReadOnlySpan<I> Fields
            => new I[SegCount]{I.Width, I.KindId, I.Sign};

        /// <summary>
        /// Segment mask filters
        /// </summary>
        public static ReadOnlySpan<M> Masks
            => new M[SegCount]{M.Size, M.KindId, M.Sign};

        /// <summary>
        /// The segment starting positions
        /// </summary>
        public static ReadOnlySpan<P> Positions
            => new P[SegCount]{P.Width, P.KindId, P.Sign};

        /// <summary>
        /// Segment widths
        /// </summary>
        public static ReadOnlySpan<W> Widths
            => new W[SegCount]{W.Width, W.KindId, W.Sign};
    }
}