//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Assigns a K-parametric name to a T-value
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct NamedValue<K,T>
        where K : unmanaged, IAsciSeq<K>
    {
        /// <summary>
        /// The name of the value
        /// </summary>
        public readonly Name<K> Name;

        /// <summary>
        /// The named value
        /// </summary>
        public readonly T Value;

        [MethodImpl(Inline)]
        public NamedValue(Name<K> name, T value)
        {
            Name = name;
            Value = value;
        }

        public string Format()
            => string.Format(RP.Attrib, Name, Value);

        public override string ToString()
            => Format();

        public static NamedValue<K,T> Empty
            => default;
    }
}