//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Assings a name to a value
    /// </summary>
    public readonly struct NamedValue<V>
    {
        /// <summary>
        /// The name of the value
        /// </summary>
        public readonly NameOld Name;

        /// <summary>
        /// The named value
        /// </summary>
        public readonly V Value;

        [MethodImpl(Inline)]
        public NamedValue(string name, V value)
        {
            Name = name;
            Value = value;
        }

        [MethodImpl(Inline)]
        public NamedValue((string name, V value) nv)
        {
            Name = nv.name;
            Value = nv.value;
        }

        [MethodImpl(Inline)]
        public void Deconstruct(out NameOld name, out V value)
        {
            name = Name;
            value = Value;
        }

        public string Format()
            => $"{Name}:={Value}";

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator NamedValue<V>((string name, V value) src)
            => new NamedValue<V>(src);

        [MethodImpl(Inline)]
        public static implicit operator NamedValue<V>((NameOld name, V value) src)
            => new NamedValue<V>(src);

        [MethodImpl(Inline)]
        public static implicit operator (NameOld name, V value)(NamedValue<V> src)
            => (src.Name, src.Value);

        [MethodImpl(Inline)]
        public static implicit operator NamedValue(NamedValue<V> src)
            => new NamedValue(src.Name, src.Value?.ToString() ?? EmptyString);

        public static NamedValue<V> Empty
        {
            [MethodImpl(Inline)]
            get => new NamedValue<V>(EmptyString, default);
        }
    }
}