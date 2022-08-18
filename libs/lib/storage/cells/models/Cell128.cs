//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
    using static Spans;

    using F = Cell128;

    public struct Cell128 : IDataCell<F,W128,Vector128<ulong>>
    {
        public const uint Width = 128;

        readonly Vector128<ulong> Data;

        [MethodImpl(Inline)]
        public Cell128(Vector128<ulong> src)
            => Data = src;

        [MethodImpl(Inline)]
        public Cell128(ByteBlock16 src)
            => Data = src.Vector<ulong>();

        [MethodImpl(Inline)]
        public Cell128(ulong src)
            => Data = Vector128.CreateScalarUnsafe(src);

        [MethodImpl(Inline)]
        public Cell128(ulong x0, ulong x1)
            => Data = Vector128.Create(x0,x1);

        [MethodImpl(Inline)]
        public Cell128(uint a00, uint a01, uint a10, uint a11)
            => Data = Vector128.Create(a00, a01,a10,a11).AsUInt64();

        public CellKind Kind
            => CellKind.Cell128;

        public Vector128<ulong> Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ulong Lo
        {
            [MethodImpl(Inline)]
            get => Data.GetElement(0);
        }

        public ulong Hi
        {
            [MethodImpl(Inline)]
            get => Data.GetElement(1);
        }

        public Cell128 Zero
        {
            [MethodImpl(Inline)]
            get => Empty;
        }

        public Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => bytes(this);
        }

        public Vector128<byte> V8u
        {
            [MethodImpl(Inline)]
            get => Content.AsByte();
        }

        public Vector128<sbyte> V8i
        {
            [MethodImpl(Inline)]
            get => Content.AsSByte();
        }

        public Vector128<ushort> V16u
        {
            [MethodImpl(Inline)]
            get => Content.AsUInt16();
        }

        public Vector128<short> V16i
        {
            [MethodImpl(Inline)]
            get => Content.AsInt16();
        }

        public Vector128<uint> V32u
        {
            [MethodImpl(Inline)]
            get => Content.AsUInt32();
        }

        public Vector128<int> V32i
        {
            [MethodImpl(Inline)]
            get => Content.AsInt32();
        }

        public Vector128<float> V32f
        {
            [MethodImpl(Inline)]
            get => Content.AsSingle();
        }

        public Vector128<ulong> V64u
        {
            [MethodImpl(Inline)]
            get => Content.AsUInt64();
        }

        public Vector128<long> V64i
        {
            [MethodImpl(Inline)]
            get => Content.AsInt64();
        }

        public Vector128<double> V64f
        {
            [MethodImpl(Inline)]
            get => Content.AsDouble();
        }

        [MethodImpl(Inline)]
        public ref Cell8 Cell8(byte i)
            => ref @as<Cell8>(Bytes);

        [MethodImpl(Inline)]
        public ref Cell16 Cell16(byte i)
            => ref @as<Cell16>(Bytes);

        [MethodImpl(Inline)]
        public ref Cell32 Cell32(byte i)
            => ref @as<Cell32>(Bytes);

        [MethodImpl(Inline)]
        public ref Cell64 Cell64(byte i)
            => ref @as<Cell64>(Bytes);

        [MethodImpl(Inline)]
        public byte Cell(W8 w, byte index)
            => V8u.GetElement(index);

        [MethodImpl(Inline)]
        public ushort Cell(W16 w, byte index)
            => V16u.GetElement(index);

        [MethodImpl(Inline)]
        public uint Cell(W32 w, byte index)
            => V32u.GetElement(index);

        [MethodImpl(Inline)]
        public ulong Cell(W64 w, byte index)
            => V64u.GetElement(index);

        [MethodImpl(Inline)]
        public bool Equals(Cell128 src)
            => Data.Equals(src.Data);

        [MethodImpl(Inline)]
        public bool Equals(Vector128<ulong> src)
            => Data.Equals(src);

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Data.GetHashCode();
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Empty.Equals(this);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        [MethodImpl(Inline)]
        public T As<T>()
            where T : struct
                => @as<F,T>(this);

        [MethodImpl(Inline)]
        public Vector128<T> ToVector<T>()
            where T : struct
                => Data.As<ulong,T>();
        public string Format()
            => Content.ToString();

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Hash;

        public override bool Equals(object src)
            => src is Cell128 x && Equals(x);

        public static Cell128 Empty
            => default;

        [MethodImpl(Inline)]
        public static implicit operator Cell128((ulong x0, ulong x1) x)
            => new Cell128(x.x0, x.x1);

        [MethodImpl(Inline)]
        public static implicit operator Cell128(ulong src)
            => new Cell128(src);

        [MethodImpl(Inline)]
        public static implicit operator Cell128(Vector128<byte> x)
            => @as<Vector128<byte>,Cell128>(x);

        [MethodImpl(Inline)]
        public static implicit operator Cell128(Vector128<ushort> x)
            => @as<Vector128<ushort>,Cell128>(x);

        [MethodImpl(Inline)]
        public static implicit operator Cell128(Vector128<uint> x)
            => @as<Vector128<uint>,Cell128>(x);

        [MethodImpl(Inline)]
        public static implicit operator Cell128(Vector128<ulong> x)
            => @as<Vector128<ulong>,Cell128>(x);

        [MethodImpl(Inline)]
        public static implicit operator Vector128<byte>(Cell128 x)
            => x.Data.AsByte();

        [MethodImpl(Inline)]
        public static implicit operator Vector128<sbyte>(Cell128 x)
            => x.Data.AsSByte();

        [MethodImpl(Inline)]
        public static implicit operator Vector128<ushort>(Cell128 x)
            => x.Data.AsUInt16();

        [MethodImpl(Inline)]
        public static implicit operator Vector128<short>(Cell128 x)
            => x.Data.AsInt16();

        [MethodImpl(Inline)]
        public static implicit operator Vector128<int>(Cell128 x)
            => x.Data.AsInt32();

        [MethodImpl(Inline)]
        public static implicit operator Vector128<uint>(Cell128 x)
            => x.Data.AsUInt32();

       [MethodImpl(Inline)]
        public static implicit operator Vector128<long>(Cell128 x)
            => x.Data.AsInt64();

        [MethodImpl(Inline)]
        public static implicit operator Vector128<ulong>(Cell128 x)
            => x.Data.AsUInt64();
    }
}