//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class Tool<T,L>
        where T : Tool<T,L>, new()
        where L : IExpr
    {
        public @string Name {get;}

        protected Tool(string name)
        {
            Name = name;
        }
    
        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Name.Hash;
        }
    }
}