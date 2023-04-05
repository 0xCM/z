//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang.Dot
{
    public abstract record class Statement : IExpr
    {
        public virtual bool IsEmpty => false;

        public abstract string Format();

        public sealed override string ToString()
            => Format();

    }

}
