//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = LookupTables;

    [StructLayout(LayoutKind.Sequential, Size=4)]
    public readonly struct LookupKey : ITextual, IEquatable<LookupKey>
    {
        [MethodImpl(Inline)]
        public ushort Row()
            => (ushort)(api.data(this));

        [MethodImpl(Inline)]
        public ushort Col()
            => (ushort)(api.data(this) >> 16);

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => api.data(this) == Unspecified;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => api.data(this) != Unspecified;
        }

        [MethodImpl(Inline)]
        public bool Equals(LookupKey src)
            => api.eq(this,src);

        [MethodImpl(Inline)]
        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator LookupKey((ushort row, ushort col) src)
            => api.key(src.row, src.col);

        [MethodImpl(Inline)]
        public static implicit operator LookupKey(Pair<ushort> src)
            => api.key(src.Left, src.Right);

        const uint Unspecified = uint.MaxValue;

        public static LookupKey Empty => api.key(Unspecified);
    }
}