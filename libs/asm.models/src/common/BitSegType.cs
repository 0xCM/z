//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct BitSegType
    {
        readonly uint Data;

        [MethodImpl(Inline)]
        public static BitSegType define(NativeClass @class, ushort total, ushort cell)
            => new BitSegType(@class, total, cell == 0 ? (ushort)1 : cell);

        [MethodImpl(Inline)]
        internal BitSegType(NativeClass @class, ushort total, ushort cell)
        {
            var count = ((uint)total)/((uint)cell);
            Data = (uint)((uint)@class | ((uint)total << 3) | (count << 24));
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Data != 0;
        }

        public byte CellCount
        {
            [MethodImpl(Inline)]
            get => IsEmpty ? z8 :  (byte)(Data >> 24);
        }

        public ushort DataWidth
        {
            [MethodImpl(Inline)]
            get => IsEmpty ? z16 : (ushort)((Data & 0x00FFFFFF) >> 3);
        }

        public ushort CellWidth
        {
            [MethodImpl(Inline)]
            get => CellCount == 0 ? DataWidth : (ushort)(DataWidth/CellCount);
        }

        public NativeClass Class
        {
            [MethodImpl(Inline)]
            get => IsEmpty ? 0 :  (NativeClass)(Data & 0b111);
        }

        public static string format(BitSegType src)
        {
            var dst = EmptyString;
            if(src.CellCount <= 1)
                dst = EmptyString;
            else
                dst = string.Format("{0}x{1}{2}", src.DataWidth, src.CellWidth, src.Class.ToString().ToLower());
            return dst;
        }

        public string Format()
            => format(this);

        public override string ToString()
            => Format();

        public static BitSegType Empty => default;
    }
}