//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IModular<S>
        where S : IModular<S>
    {
        S Mod(S rhs);
    }
}