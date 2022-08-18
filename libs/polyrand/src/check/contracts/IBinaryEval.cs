//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IBinaryEval<T> : IEval
    {
        T A {get;}

        T B {get;}
    }
}