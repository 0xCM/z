//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using api = DataLayouts;

    /// <summary>
    /// Defines identity for a <see cref 'DataLayout{T}'/> component
    /// </summary>
    public readonly struct LayoutIdentity<T> : ITextual
        where T : unmanaged
    {
        public uint Index {get;}

        public T Kind {get;}

        [MethodImpl(Inline)]
        internal LayoutIdentity(uint index, T kind)
        {
            Index = index;
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