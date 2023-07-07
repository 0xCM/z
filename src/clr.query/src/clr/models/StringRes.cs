//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Describes/models a literal text resource
    /// </summary>
    public readonly record struct StringRes
    {
        /// <summary>
        /// The resource identifier
        /// </summary>
        public readonly FieldInfo Source;

        /// <summary>
        /// The resource address
        /// </summary>
        public readonly StringAddress Address;

        [MethodImpl(Inline)]
        public StringRes(FieldInfo src, StringAddress address)
        {
            Source = src;
            Address = address;
        }

        /// <summary>
        /// The resource value extracted from the accompanying location
        /// </summary>
        public string Value
        {
            [MethodImpl(Inline)]
            get => Address.Format();
        }

        public string Format()
            => string.Format(RenderPattern, Address.Address, Source.DeclaringType.Name, Source.Name, Value);

        public override string ToString()
            => Format();

        const string RenderPattern = "{0} {1}::{2} = \"{3}\"";
    }
}