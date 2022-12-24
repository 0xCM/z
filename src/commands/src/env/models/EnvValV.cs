//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
   public abstract record class EnvVal<V> : IExpr
        where V : EnvVal<V>, new()
    {        
        public static V Empty => new();

        public abstract Hash32 Hash {get;}
        public abstract string Format();

        public override string ToString()
            => Format();

        public abstract bool IsEmpty {get;}

    }
}