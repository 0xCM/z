//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    /// <summary>
    /// Defines a value-parametric environment variable
    /// </summary>
    [Record(TableId)]
    public readonly record struct EnvVar<T> : IDataType<EnvVar<T>>, IExpr
        where T : IEquatable<T>
    {
        const string TableId = "env.vars.{0}";

        public readonly Name Name;

        public readonly T Value;

        [MethodImpl(Inline)]
        public EnvVar(Name name, T value)
        {
            Name = name;
            Value = value;
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

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => hash(Format());
        }

        public override int GetHashCode()
            => Hash;

        public string Format()
            => $"{Name}={Value}";

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public int CompareTo(EnvVar<T> src)
            => Name.CompareTo(src.Name);

        [MethodImpl(Inline)]
        public bool Equals(EnvVar<T> src)
            => Name.Equals(src.Name) && Value.Equals(src.Value);

        public static EnvVar<T> Empty => new EnvVar<T>(Name.Empty, default);
    }
}