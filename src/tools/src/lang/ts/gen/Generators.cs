//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ts
{
    public partial class Generators
    {

        public abstract class Template<T,M> 
            where T : Template<T,M>, new()
        {            
            public abstract T Bind(M src);

            public abstract string Format();

            protected abstract string Expr();
        }
    }
}