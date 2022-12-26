//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines a nonparametric environment variable
    /// </summary>
    [Record(TableId)]
    public readonly record struct EnvVar : IVarValue, IDataType<EnvVar>
    {
        const string TableId = "env";

        [Render(64)]
        public readonly @string Name;

        /// <summary>
        /// The environment variable value
        /// </summary>
        [Render(1)]
        public readonly @string Value;

        [MethodImpl(Inline)]
        public EnvVar(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => sys.hash(Name) | hash(Value);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => sys.empty(Name);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => sys.nonempty(Name);
        }

        public bool Contains(string match)
            => text.contains(Value,match);

        public bool Contains(ReadOnlySpan<char> match)
            => text.contains(Value, match);

        public bool Contains(char match)
            => text.contains(Value,match);

        public EnvVar Revalue(@string value)
            => new EnvVar(Name, value);

        [MethodImpl(Inline)]
        public string Format()
            => sys.nonempty(Value) ? string.Format("{0}={1}", Name, Value) : $"{Name}=";


        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public bool Equals(EnvVar src)
            => Name.Equals(src.Name) && string.Equals(Value, src.Value, NoCase);

        public int CompareTo(EnvVar src)
            => Name.CompareTo(src.Name);

        [MethodImpl(Inline)]
        public static implicit operator string(EnvVar src)
            => src.Value;

        string IVarValue.Name
            => Name;

        object IVarValue.Value
            => Value;

        public static EnvVar Empty
        {
            [MethodImpl(Inline)]
            get => new EnvVar(EmptyString, EmptyString);
        }
    }
}