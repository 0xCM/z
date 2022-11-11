//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using NK = NumericKind;

    [ApiHost]
    public readonly struct BitMaskData
    {
        [MethodImpl(Inline), Op]
        public static BitMaskInfo describe(NumericLiteral src)
        {
            var dst = new BitMaskInfo();
            return map(src, ref dst);
        }

        [MethodImpl(Inline), Op]
        static ref BitMaskInfo map(in NumericLiteral src, ref BitMaskInfo dst)
        {
            dst.Name = src.Name;
            dst.DataType = src.Data?.GetType() ?? typeof(void);
            dst.MaskData = BitMaskData.infer(src.Data);
            dst.Text = src.Text;
            dst.Base = src.Base;
            return ref dst;
        }

        [Op]
        public static BitMaskData infer(object src)
        {
            if(src == null)
                return BitMaskData.Empty;

            var kind = src.GetType().NumericKind();
            return kind switch{
                NK.U8 => (byte)src,
                NK.U16 => (ushort)src,
                NK.U32 => (uint)src,
                NK.U64 => (ulong)src,
                NK.I8 => (byte)(sbyte)src,
                NK.I16 => (ushort)(short)src,
                NK.I32 => (uint)(int)src,
                NK.I64 => (ulong)(long)src,
                _ => BitMaskData.Empty
            };
        }

        readonly ulong Data;

        public readonly byte DataWidth;

        [MethodImpl(Inline)]
        public BitMaskData(byte src)
        {
            Data = src;
            DataWidth = 8;
        }

        [MethodImpl(Inline)]
        public BitMaskData(ushort src)
        {
            Data = src;
            DataWidth = 16;
        }

        [MethodImpl(Inline)]
        public BitMaskData(uint src)
        {
            Data = src;
            DataWidth = 32;
        }

        [MethodImpl(Inline)]
        public BitMaskData(ulong src)
        {
            Data = src;
            DataWidth = 64;
        }

        [MethodImpl(Inline)]
        public BitMaskData(ulong src, byte width)
        {
            Data = src;
            DataWidth = width;
        }

        [MethodImpl(Inline)]
        public byte Value(out byte value)
        {
            value = (byte)Data;
            return value;
        }

        [MethodImpl(Inline)]
        public ushort Value(out ushort value)
        {
            value = (ushort)Data;
            return value;
        }

        [MethodImpl(Inline)]
        public uint Value(out uint value)
        {
            value = (uint)Data;
            return value;
        }

        [MethodImpl(Inline)]
        public ulong Value(out ulong value)
        {
            value = Data;
            return value;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => DataWidth == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => DataWidth == 0;
        }

        public NumericKind DataKind
        {
            [MethodImpl(Inline)]
            get
            {
                if(DataWidth <=8)
                    return NumericKind.U8;
                else if(DataWidth <=16)
                    return NumericKind.U16;
                else if(DataWidth <=32)
                    return NumericKind.U32;
                else
                    return NumericKind.U64;
            }
        }

        public string Format()
        {
            if(IsEmpty)
                return EmptyString;

            if(DataWidth <=8)
                return ((byte)Data).FormatBits();
            else if(DataWidth <=16)
                return ((ushort)Data).FormatBits();
            else if(DataWidth <=32)
                return ((uint)Data).FormatBits();
            else
                return ((ulong)Data).FormatBits();
        }

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator BitMaskData(byte src)
            => new BitMaskData(src);

        [MethodImpl(Inline)]
        public static implicit operator BitMaskData(ushort src)
            => new BitMaskData(src);

        [MethodImpl(Inline)]
        public static implicit operator BitMaskData(uint src)
            => new BitMaskData(src);

        [MethodImpl(Inline)]
        public static implicit operator BitMaskData(ulong src)
            => new BitMaskData(src);

        public static BitMaskData Empty => default;
    }
}