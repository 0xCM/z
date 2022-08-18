//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct Vec512Kind<T> : IVectorType<Vec512Kind<T>,W512,T>
        where T : unmanaged
    {
        public W512 W => default;

        public Identifier Name
            => string.Format("v{0}<{1}>", W, typeof(T).Name);

        public string Format()
            => Name;

        public NativeVectorWidth Width
            => NativeVectorWidth.W512;

        public NumericKind CellKind
            => NumericKinds.kind<T>();

        public NumericWidth CellWidth
            => (NumericWidth)Widths.bits<T>();

        public BitWidth ContentWidth
            => (BitWidth)(ushort)Width;

        public BitWidth StorageWidth
            => ContentWidth;

        public ulong Kind => default;

        [MethodImpl(Inline)]
        public static implicit operator NativeVectorWidth(Vec512Kind<T> src)
            => src.Width;

        [MethodImpl(Inline)]
        public static implicit operator Vec512Type(Vec512Kind<T> src)
            => default;
    }
}