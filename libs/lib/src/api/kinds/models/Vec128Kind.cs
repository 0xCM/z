//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct Vec128Kind<T> : IVectorType<Vec128Kind<T>,W128,T>
        where T : unmanaged
    {
        public W128 W
            => default;

        public Identifier Name
            => string.Format("v{0}<{1}>", W, typeof(T).Name);

        public string Format()
            => Name;
        public NativeVectorWidth Width
            => NativeVectorWidth.W128;

        public BitWidth ContentWidth
            => (BitWidth)(ushort)Width;

        public BitWidth StorageWidth
            => ContentWidth;

        public ulong Kind => default;

        public NumericKind CellKind
            => NumericKinds.kind<T>();

        public NumericWidth CellWidth
            => (NumericWidth)Widths.bits<T>();

        [MethodImpl(Inline)]
        public static implicit operator NativeVectorWidth(Vec128Kind<T> src)
            => NativeVectorWidth.W128;

        [MethodImpl(Inline)]
        public static implicit operator Vec128Type(Vec128Kind<T> src)
            => default;
    }
}