//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IDivisive<S> : IModular<S>
        where S : IDivisive<S>, new()
    {
        S Div(S rhs);

        S Gcd(S rhs);
    }
}