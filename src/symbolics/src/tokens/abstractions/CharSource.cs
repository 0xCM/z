//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class CharSource : ITokenSource<char>
    {            
        public virtual void Dispose(){ }

        public abstract bool Next(out char atom);
    }   
}