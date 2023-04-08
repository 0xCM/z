//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class LiteralType<V>
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