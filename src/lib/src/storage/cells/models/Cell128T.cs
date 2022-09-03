//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public struct Cell128<T> : IDataCell<Cell128<T>,W128,ByteBlock16>
        where T : unmanaged
    {
        public const uint Width = 128;

        [MethodImpl(Inline)]
        public static Cell128<T> init(Vector128<T> src)
            => new Cell128<T>(src.AsByte());

        [MethodImpl(Inline)]
        public static Cell128<T> init(ByteBlock16 src)
            => new Cell128<T>(src);

        ByteBlock16 Data;

        [MethodImpl(Inline)]
        public Cell128(ByteBlock16 data)
            => Data = data;

        public CellKind Kind
            => CellKind.Cell128;

        public Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => Data.Bytes;
        }

        public ref T First
        {
            [MethodImpl(Inline)]
            get => ref @as<T>(Data.First);
        }

        public Span<T> Cells
        {
            [MethodImpl(Inline)]
            get => recover<T>(Data.Bytes);
        }

        public ref T this[int i]
        {
            [MethodImpl(Inline)]
            get => ref seek(First,i);
        }

        public ref T this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref seek(First,i);
        }

        public Cell128<T> Zero
        {
            [MethodImpl(Inline)]
            get => Empty;
        }

        public Vector128<byte> V8u
        {
            [MethodImpl(Inline)]
            get => ToVector().AsByte();
        }

        public Vector128<sbyte> V8i
        {
            [MethodImpl(Inline)]
            get => ToVector().AsSByte();
        }

        public Vector128<ushort> V16u
        {
            [MethodImpl(Inline)]
            get => ToVector().AsUInt16();
        }

        public Vector128<short> V16i
        {
            [MethodImpl(Inline)]
            get => ToVector().AsInt16();
        }

        public Vector128<uint> V32u
        {
            [MethodImpl(Inline)]
            get => ToVector().AsUInt32();
        }

        public Vector128<int> V32i
        {
            [MethodImpl(Inline)]
            get => ToVector().AsInt32();
        }

        public Vector128<float> V32f
        {
            [MethodImpl(Inline)]
            get => ToVector().AsSingle();
        }

        public Vector128<ulong> V64u
        {
            [MethodImpl(Inline)]
            get => ToVector().AsUInt64();
        }

        public Vector128<long> V64i
        {
            [MethodImpl(Inline)]
            get => ToVector().AsInt64();
        }

        public Vector128<double> V64f
        {
            [MethodImpl(Inline)]
            get => ToVector().AsDouble();
        }

        [MethodImpl(Inline)]
        public bit TestBit(byte index)
            => bit.test(Data[(byte)(index/8)], (byte)(index%8));

        [MethodImpl(Inline)]
        public void SetBit(byte index, bit state)
        {
            ref var b = ref Data[index];
            b = bit.set(b, (byte)(index%8), state);
        }

        [MethodImpl(Inline)]
        public Vector128<T> ToVector()
            => Data.Vector<T>();

        [MethodImpl(Inline)]
        public bool Equals(Cell128<T> src)
            => ToVector().Equals(src.ToVector());

        public string Format()
            => V8u.ToString();

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Data.GetHashCode();

        public override bool Equals(object src)
            => src is Cell128<T> x && Equals(x);

        [MethodImpl(Inline)]
        public static implicit operator Cell128<T>(Vector128<T> x)
            => init(x);

        [MethodImpl(Inline)]
        public static implicit operator Cell128<T>(Cell128 x)
            => init(x.ToVector<T>());

        [MethodImpl(Inline)]
        public static implicit operator Vector128<T>(Cell128<T> x)
            => x.ToVector();

        public static Cell128<T> Empty => default;
    }
}