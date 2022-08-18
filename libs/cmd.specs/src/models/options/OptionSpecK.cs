//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Specifies a kinded option
    /// </summary>
    public readonly struct OptionSpec<K> : IOptionSpec<K>
        where K : unmanaged
    {
        /// <summary>
        /// The option name
        /// </summary>
        public readonly @string Name {get;}

        /// <summary>
        /// The option kind
        /// </summary>
        public readonly K Kind {get;}

        /// <summary>
        /// A description for the option, if available
        /// </summary>
        public readonly @string Description {get;}

        [MethodImpl(Inline)]
        public OptionSpec(K kind)
        {
            Name = kind.ToString();
            Kind = kind;
            Description = EmptyString;
        }

        [MethodImpl(Inline)]
        public OptionSpec(string name, K kind)
        {
            Name = name;
            Kind = kind;
            Description = EmptyString;
        }

        [MethodImpl(Inline)]
        public OptionSpec(string name, K kind, string description)
        {
            Name = name;
            Kind = kind;
            Description = description;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => core.hash(Name.Hash, core.bw32(Kind), core.hash(Description));
        }
        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsNonEmpty;
        }

        [MethodImpl(Inline)]
        public string Format()
            => Name;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator OptionSpec(OptionSpec<K> src)
            => new OptionSpec(src.Name, src.Description);

        /// <summary>
        /// Specifies the empty option
        /// </summary>
        public static OptionSpec<K> Empty
        {
            [MethodImpl(Inline)]
            get => new OptionSpec<K>(EmptyString, default(K));
        }
    }
}