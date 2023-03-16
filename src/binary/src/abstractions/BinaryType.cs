//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract record class BinaryType : IBinaryType
    {
        public readonly @string Name;

        protected BinaryType(@string name)
        {
            Name = name;
        }

        public string Format()
            => Name;

        public override string ToString()        
            => Format();

        @string IBinaryType.Name 
            => Name;
    }
}