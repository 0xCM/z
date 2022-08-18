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
    /// Defines identity for a <see cref 'IDataLayout'/> component
    /// </summary>
    public readonly struct LayoutIdentity : ITextual
    {
        /// <summary>
        /// The 0-based index of the layout within the enclosing scope
        /// </summary>
        public uint Index {get;}

        /// <summary>
        /// The unrefined layout kind
        /// </summary>
        public ulong Kind {get;}

        [MethodImpl(Inline)]
        public LayoutIdentity(uint index, ulong src)
        {
            Index = index;
            Kind = src;
        }

        [MethodImpl(Inline)]
        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();
    }
}