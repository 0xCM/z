//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IDivisionRing<S> : IRing<S>, IDivisive<S>, IReciprocative<S>
        where S : IDivisionRing<S>, new()
    {

    }
}