//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Lifts literal values to type
    /// </summary>
    /// <typeparam name="K"></typeparam>
    public class LiteralType<V> : ILiteralType<V>
    {
        public Identifier Name {get;}

        public V Value {get;}

        public ulong Kind {get;}

        public LiteralType(Identifier name, V value)
        {
            Name = name;
            Value = value;
            Kind = 0;
        }

        public bool IsEmpty
        {
            get => Name.IsEmpty;
        }

        public string Format()
            => string.Format("{0}:{1}", Value, Name);
    }
}