//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct NamedValue
    {
        /// <summary>
        /// The name of the value
        /// </summary>
        public string Name {get;}

        /// <summary>
        /// The named value
        /// </summary>
        public object Value {get;}

        [MethodImpl(Inline)]
        public NamedValue(string name, object value)
        {
            Name = name;
            Value = value ?? string.Empty;
        }

        public string Format()
            => $"{Name}:={Value}";

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator NamedValue((string name, object value) src)
            => new NamedValue(src.name, src.value);

        public static NamedValue Empty
        {
            [MethodImpl(Inline)]
            get => new NamedValue(EmptyString, EmptyString);
        }
    }
}