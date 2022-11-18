//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines a command option
    /// </summary>
    public readonly record struct OptionSpec : IOptionSpec
    {
        /// <summary>
        /// The option name
        /// </summary>
        public @string Name {get;}

        /// <summary>
        /// The option's use
        /// </summary>
        public @string Description {get;}

        [MethodImpl(Inline)]
        public OptionSpec(string name)
        {
            Name = name;
            Description = EmptyString;
        }

        [MethodImpl(Inline)]
        public OptionSpec(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Name.Hash | hash(Description);
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
            => IsEmpty ? EmptyString : string.Format("{0,-32}:{1}", Name, Description);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator OptionSpec(string src)
            => new OptionSpec(src);

        public static OptionSpec Empty
        {
            [MethodImpl(Inline)]
            get => new OptionSpec(EmptyString);
        }
    }
}