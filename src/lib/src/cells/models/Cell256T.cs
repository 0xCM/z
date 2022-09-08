//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public struct Cell256<T> : IDataCell<Cell256<T>,W256,ByteBlock32>
        where T : unmanaged
    {
        public const uint Width = 256;

        public const ushort Size = 32;

        [MethodImpl(Inline)]
        public static Cell256<T> init(Vector256<T> src)
            => new Cell256<T>(src.AsByte());

        [MethodImpl(Inline)]
        public static Cell256<T> init(ByteBlock32 src)
            => new Cell256<T>(src);

        ByteBlock32 Data;

        [MethodImpl(Inline)]
        public Cell256(ByteBlock32 data)
        {
            Data = data;
        }

        public CellKind Kind
            => CellKind.Cell256;

        public Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => Data.Bytes;
        }

        [MethodImpl(Inline)]
        public Vector256<T> ToVector()
            => Data.Vector<T>();

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

        public Cell256<T> Zero
        {
            [MethodImpl(Inline)]
            get => Empty;
        }

        public Vector256<byte> V8u
        {
            [MethodImpl(Inline)]
            get => ToVector().AsByte();
        }

        public Vector256<sbyte> V8i
        {
            [MethodImpl(Inline)]
            get => ToVector().AsSByte();
        }

        public Vector256<ushort> V16u
        {
            [MethodImpl(Inline)]
            get => ToVector().AsUInt16();
        }

        public Vector256<short> V16i
        {
            [MethodImpl(Inline)]
            get => ToVector().AsInt16();
        }

        public Vector256<uint> V32u
        {
            [MethodImpl(Inline)]
            get => ToVector().AsUInt32();
        }

        public Vector256<int> V32i
        {
            [MethodImpl(Inline)]
            get => ToVector().AsInt32();
        }

        public Vector256<float> V32f
        {
            [MethodImpl(Inline)]
            get => ToVector().AsSingle();
        }

        public Vector256<ulong> V64u
        {
            [MethodImpl(Inline)]
            get => ToVector().AsUInt64();
        }

        public Vector256<long> V64i
        {
            [MethodImpl(Inline)]
            get => ToVector().AsInt64();
        }

        public Vector256<double> V64f
        {
            [MethodImpl(Inline)]
            get => ToVector().AsDouble();
        }

        [MethodImpl(Inline)]
        public bool Equals(Cell256<T> src)
            => ToVector().Equals(src.ToVector());

        public string Format()
            => V8u.ToString();

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Data.GetHashCode();

        public override bool Equals(object src)
            => src is Cell256<T> x && Equals(x);

        [MethodImpl(Inline)]
        public static implicit operator Cell256<T>(Vector256<T> x)
            => init(x);

        [MethodImpl(Inline)]
        public static implicit operator Cell256<T>(Cell256 x)
            => init(x.ToVector<T>());

        [MethodImpl(Inline)]
        public static implicit operator Vector256<T>(Cell256<T> x)
            => x.ToVector();

        public static Cell256<T> Empty => default;
    }
}