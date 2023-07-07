//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Represents an identified string resource
    /// </summary>
    public readonly record struct StringRes<E>
        where E : unmanaged
    {
        /// <summary>
        /// The resource identifier
        /// </summary>
        public readonly E Identifier;

        /// <summary>
        /// The resource address
        /// </summary>
        public readonly StringAddress Address;

        /// <summary>
        /// The Size of the resource, in bytes
        /// </summary>
        public readonly uint Size;

        [MethodImpl(Inline)]
        public StringRes(E id, StringAddress address, uint size)
        {
            Identifier = id;
            Address = address;
            Size = size;
        }

        [MethodImpl(Inline)]
        public string Format()
            => Address.Format();

        public override string ToString()
            => Format();
    }
}