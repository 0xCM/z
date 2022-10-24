//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = DataLayouts;

    /// <summary>
    /// Defines identity for a <see cref 'IDataLayout'/> component
    /// </summary>
    public readonly struct LayoutIdentity
    {
        /// <summary>
        /// The 0-based index of the layout within the enclosing scope
        /// </summary>
        public readonly uint Pos;

        /// <summary>
        /// The unrefined layout kind
        /// </summary>
        public readonly ulong Kind;

        [MethodImpl(Inline)]
        public LayoutIdentity(uint index, ulong src)
        {
            Pos = index;
            Kind = src;
        }

        [MethodImpl(Inline)]
        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();
    }
}