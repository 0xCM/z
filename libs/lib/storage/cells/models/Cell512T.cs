//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
    using static Spans;

    [StructLayout(LayoutKind.Sequential, Size = (int)Size, Pack=1)]
    public struct Cell512<T> : IDataCell<Cell512<T>,W512,ByteBlock64>
        where T : unmanaged
    {
        [MethodImpl(Inline)]
        public static Cell512<T> init(Vector512<T> src)
            => new Cell512<T>(src.As<byte>());

        [MethodImpl(Inline)]
        public static Cell512<T> init(ByteBlock64 src)
            => new Cell512<T>(src);

        public const uint Size = 64;

        public const uint Width = 512;

        ByteBlock64 Data;

        [MethodImpl(Inline)]
        public Cell512(ByteBlock64 data)
        {
            Data = data;
        }

        public CellKind Kind
            => CellKind.Cell512;

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

        public Cell512<T> Zero
        {
            [MethodImpl(Inline)]
            get => Empty;
        }

        public Vector512<byte> V8u
        {
            [MethodImpl(Inline)]
            get => ToVector().As<byte>();
        }

        public Vector512<sbyte> V8i
        {
            [MethodImpl(Inline)]
            get => ToVector().As<sbyte>();
        }

        public Vector512<ushort> V16u
        {
            [MethodImpl(Inline)]
            get => ToVector().As<ushort>();
        }

        public Vector512<short> V16i
        {
            [MethodImpl(Inline)]
            get => ToVector().As<short>();
        }

        public Vector512<uint> V32u
        {
            [MethodImpl(Inline)]
            get => ToVector().As<uint>();
        }

        public Vector512<int> V32i
        {
            [MethodImpl(Inline)]
            get => ToVector().As<int>();
        }

        public Vector512<float> V32f
        {
            [MethodImpl(Inline)]
            get => ToVector().As<float>();
        }

        public Vector512<ulong> V64u
        {
            [MethodImpl(Inline)]
            get => ToVector().As<ulong>();
        }

        public Vector512<long> V64i
        {
            [MethodImpl(Inline)]
            get => ToVector().As<long>();
        }

        public Vector512<double> V64f
        {
            [MethodImpl(Inline)]
            get => ToVector().As<double>();
        }

        [MethodImpl(Inline)]
        public Vector512<T> ToVector()
            => Data.Vector<T>();

        [MethodImpl(Inline)]
        public bool Equals(Cell512<T> src)
            => ToVector().Equals(src.ToVector());

        public string Format()
            => V8u.ToString();

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Data.GetHashCode();

        public override bool Equals(object src)
            => src is Cell512<T> x && Equals(x);

        [MethodImpl(Inline)]
        public static implicit operator Cell512<T>(Vector512<T> x)
            => init(x);

        [MethodImpl(Inline)]
        public static implicit operator Cell512<T>(Cell512 x)
            => init(x.ToVector<T>());

        [MethodImpl(Inline)]
        public static implicit operator Vector512<T>(Cell512<T> x)
            => x.ToVector();

        public static Cell512<T> Empty => default;
    }
}