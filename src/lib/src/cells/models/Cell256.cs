//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Avx2;
    using static sys;

    public struct Cell256 : IDataCell<Cell256,W256,Vector256<ulong>>
    {
        public const uint Width = 256;

        readonly Vector256<ulong> Data;

        [MethodImpl(Inline)]
        public Cell256(Vector256<ulong> src)
            => Data = src;

        [MethodImpl(Inline)]
        public Cell256(ByteBlock32 src)
            => Data = src.Vector<ulong>();

        [MethodImpl(Inline)]
        public Cell256(ulong src)
            => Data = Vector256.CreateScalarUnsafe(src);

        public CellKind Kind
            => CellKind.Cell256;

        public Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => bytes(this);
        }

        public Cell128 Lo
        {
            [MethodImpl(Inline)]
            get => Vector256.GetLower(Data);
        }

        public Cell128 Hi
        {
            [MethodImpl(Inline)]
            get => Vector256.GetUpper(Data);
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

        public int BitWidth => 256;

        public int Size => 32;

        public Cell256 Zero
        {
            [MethodImpl(Inline)]
            get => Empty;
        }

        public Vector256<byte> V8u
        {
            [MethodImpl(Inline)]
            get => Data.AsByte();
        }

        public Vector256<sbyte> V8i
        {
            [MethodImpl(Inline)]
            get => Data.AsSByte();
        }

        public Vector256<ushort> V16u
        {
            [MethodImpl(Inline)]
            get => Data.AsUInt16();
        }

        public Vector256<short> V16i
        {
            [MethodImpl(Inline)]
            get => Data.AsInt16();
        }

        public Vector256<uint> V32u
        {
            [MethodImpl(Inline)]
            get => Data.AsUInt32();
        }

        public Vector256<int> V32i
        {
            [MethodImpl(Inline)]
            get => Data.AsInt32();
        }

        public Vector256<float> V32f
        {
            [MethodImpl(Inline)]
            get => Data.AsSingle();
        }

        public Vector256<ulong> V64u
        {
            [MethodImpl(Inline)]
            get => Data.AsUInt64();
        }

        public Vector256<long> V64i
        {
            [MethodImpl(Inline)]
            get => Data.AsInt64();
        }

        public Vector256<double> V64f
        {
            [MethodImpl(Inline)]
            get => Data.AsDouble();
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
        public static Cell256 init<T>(Vector256<T> src)
            where T : unmanaged
                => new Cell256(src.AsUInt64());

        [MethodImpl(Inline)]
        public static Cell256 init<T>(Vector128<T> a, Vector128<T> b)
            where T : unmanaged
        {
            var c = vinsert(a.AsUInt64(), default, (byte)LaneIndex.L0);
            var d = vinsert(b.AsUInt64(), c, (byte)LaneIndex.L1);
            return new Cell256(d);
        }

        [MethodImpl(Inline)]
        public static Cell256 init(Cell128 a, Cell128 b)
        {
            var a1 = a.ToVector<ulong>();
            var b1 = b.ToVector<ulong>();
            var c = vinsert(a1, default, 0);
            return new Cell256(vinsert(b1, c, 1));
        }

        [MethodImpl(Inline)]
        public bool Equals(Cell256 src)
            => Data.Equals(src.Data);

        [MethodImpl(Inline)]
        public bool Equals(Vector256<ulong> src)
            => Data.Equals(src);

        [MethodImpl(Inline)]
        public Vector256<T> ToVector<T>()
            where T : unmanaged
                => Data.As<ulong,T>();

       public string Format()
            => Data.ToString();

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Data.GetHashCode();

        public override bool Equals(object src)
            => src is Cell256 x && Equals(x);

        [MethodImpl(Inline), Op]
        static Vector256<ulong> vinsert(Vector128<ulong> src, Vector256<ulong> dst, [Imm] byte index)
            => InsertVector128(dst, src, index);

        [MethodImpl(Inline)]
        public static implicit operator Cell256((Cell128 x, Cell128 y) src)
            => init(src.x,src.y);

        [MethodImpl(Inline)]
        public static implicit operator Cell256(ulong x)
            => new Cell256(x);

        [MethodImpl(Inline)]
        public static implicit operator Cell256(Vector256<byte> x)
            => init(x);

        [MethodImpl(Inline)]
        public static implicit operator Cell256(Vector256<ushort> x)
            => init(x);

        [MethodImpl(Inline)]
        public static implicit operator Cell256(Vector256<uint> x)
            => init(x);

        [MethodImpl(Inline)]
        public static implicit operator Cell256(Vector256<ulong> x)
            => init(x);

        [MethodImpl(Inline)]
        public static implicit operator Vector256<byte>(Cell256 x)
            => x.V8u;

        [MethodImpl(Inline)]
        public static implicit operator Vector256<sbyte>(Cell256 x)
            => x.V8i;

        [MethodImpl(Inline)]
        public static implicit operator Vector256<ushort>(Cell256 x)
            => x.V16u;

        [MethodImpl(Inline)]
        public static implicit operator Vector256<short>(Cell256 x)
            => x.V16i;

        [MethodImpl(Inline)]
        public static implicit operator Vector256<uint>(Cell256 x)
            => x.V32u;

        [MethodImpl(Inline)]
        public static implicit operator Vector256<int>(Cell256 x)
            => x.V32i;

        [MethodImpl(Inline)]
        public static implicit operator Vector256<long>(Cell256 x)
            => x.V64i;

        [MethodImpl(Inline)]
        public static implicit operator Vector256<ulong>(Cell256 x)
            => x.V64u;

        public static Cell256 Empty => default;
    }
}