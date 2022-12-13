//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = DataLayouts;

    /// <summary>
    /// Defines identity for a <see cref 'DataLayout{T}'/> component
    /// </summary>
    public readonly struct LayoutIdentity<T>
        where T : unmanaged
    {
        public readonly uint Pos;

        public readonly T Kind;

        [MethodImpl(Inline)]
        public LayoutIdentity(uint index, T kind)
        {
            Pos = index;
            Kind = kind;
        }

        [MethodImpl(Inline)]
        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator LayoutIdentity(LayoutIdentity<T> src)
            => api.untyped(src);
    }
}