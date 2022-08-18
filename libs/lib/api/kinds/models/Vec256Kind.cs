//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct Vec256Kind<T> : IVectorType<Vec256Kind<T>,W256,T>
        where T : unmanaged
    {
        public Identifier Name
            => string.Format("v{0}<{1}>", W, typeof(T).Name);

        public string Format()
            => Name;

        public W256 W => default;

        public NativeVectorWidth Width
            => NativeVectorWidth.W256;

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
        public static implicit operator NativeVectorWidth(Vec256Kind<T> src)
            => src.Width;

        [MethodImpl(Inline)]
        public static implicit operator Vec256Type(Vec256Kind<T> src)
            => default;
    }
}