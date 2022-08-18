//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Rules
    {
        public abstract class ValueProduction<T> : Production<T,T>
            where T : IRuleExpr
        {
            protected ValueProduction(T src, T dst)
                : base(src,dst)
            {

            }
        }
    }
}