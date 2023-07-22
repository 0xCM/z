//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using F = Cell512;

    partial class XTend
    {
        public static Vector512<T> As<S,T>(this Vector512<S> src)
            where S : unmanaged
            where T : unmanaged
                => @as<Vector512<S>,Vector512<T>>(src);                
    }
    
    public record struct Cell512 : IDataCell<F,W512,Vector512<ulong>>
    {
        public const uint Width = 512;

        Cell256 X0;

        Cell256 X1;

        public readonly CellKind Kind
            => CellKind.Cell512;

        public readonly Cell256 Lo
        {
            [MethodImpl(Inline)]
            get => X0;
        }

        public readonly Cell256 Hi
        {
            [MethodImpl(Inline)]
            get => X1;
        }

        public readonly F Zero
        {
            [MethodImpl(Inline)]
            get => Empty;
        }

        [MethodImpl(Inline)]
        public Cell512(Cell256 x0, Cell256 x1)
        {
            X0 = x0;
            X1 = x1;
        }

        [MethodImpl(Inline)]
        public Cell512(in Vector512<ulong> src)
        {
            @as<Cell512,Vector512<ulong>>(this) = src;
        }

        [MethodImpl(Inline)]
        public static F init<T>(in Vector512<T> src)
            where T : unmanaged
                => new (src.As<T,ulong>());

        [MethodImpl(Inline)]
        public readonly Vector512<T> ToVector<T>()
            where T : unmanaged
                => @as<Cell512,Vector512<T>>(this);

        public readonly string Format()
            => sys.array(X0, X1).FormatList();

        [MethodImpl(Inline)]
        public bool Equals(Cell512 src)
            => X0.Equals(src.X0) && X1.Equals(src.X1);

        [MethodImpl(Inline)]
        public bool Equals(Vector512<ulong> src)
            => ToVector<ulong>() == src;

        public override int GetHashCode()
            => HashCode.Combine(X0,X1);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public T As<T>()
            where T : struct
                => @as<F,T>(this);

        [MethodImpl(Inline)]
        public static implicit operator F((Cell256 x0, Cell256 x1) x)
            => new (x.x0,x.x1);

        [MethodImpl(Inline)]
        public static implicit operator F(in Vector512<byte> x)
            => init(x);

        [MethodImpl(Inline)]
        public static implicit operator F(in Vector512<ushort> x)
            => init(x);

        [MethodImpl(Inline)]
        public static implicit operator F(in Vector512<uint> x)
            => init(x);

        [MethodImpl(Inline)]
        public static implicit operator F(in Vector512<ulong> x)
            => init(x);

        [MethodImpl(Inline)]
        public static implicit operator Vector512<byte>(in Cell512 src)
            => src.ToVector<byte>();

        [MethodImpl(Inline)]
        public static implicit operator Vector512<sbyte>(in Cell512 src)
            => src.ToVector<sbyte>();

        public static Cell512 Empty => default;
    }
}