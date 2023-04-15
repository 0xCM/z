//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines a value-parametric environment variable
    /// </summary>
    [Record(TableId)]
    public readonly record struct EnvVar<T> : IDataType<EnvVar<T>>, IVarAssignment<T>
        where T : IEquatable<T>
    {
        const string TableId = "env.vars.{0}";

        public readonly @string Name;

        public readonly T Value;

        [MethodImpl(Inline)]
        public EnvVar(string name, T value)
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

        public VarDef Def 
            => new VarDef(Name, EmptyString, EmptyString);

        T IVarAssignment<T>.Value 
            => Value;

        public override int GetHashCode()
            => Hash;

        public EnvVar<T> WithValue(T value)
            => new EnvVar<T>(Name, value);

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


        [MethodImpl(Inline)]
        public static implicit operator T (EnvVar<T> src)
            => src.Value;
            
        public static EnvVar<T> Empty => new EnvVar<T>(EmptyString, default);
    }
}