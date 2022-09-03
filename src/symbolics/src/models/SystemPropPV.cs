//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract record class SystemProp<P,V> : IEquatable<P>, ISystemProp<V>
        where P : SystemProp<P,V>, new()
    {
        public Name Name;

        public V Value;

        protected SystemProp()
        {
            Name = EmptyString;
            Value = default;
        }

        protected SystemProp(Name name)
        {
            Name = name;
            Value = default;
        }

        protected SystemProp(Name name, V value)
        {
            Name = name;
            Value = value;
        }

        public virtual string Format()
            => $"{Name}={Value}";

        public override string ToString()
            => Format();

        public abstract int Hash {get;}

        V ISystemProp<V>.Value
            => Value;

        string ISystemProp.Name
            => Name;

        public abstract bool Parse(string name, string src, out P dst);

        public abstract bool Equals(P? other);

        public abstract P Default {get;}

        public static implicit operator SystemProp<V>(SystemProp<P,V> src)
            => new SystemProp<V>(src.Name,src.Value);
    }
}