//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ts
{
    public abstract class Cg<G,S,T>
        where G : Cg<G,S,T>, new()
    {

        public abstract T Gen(S src);
    }
}