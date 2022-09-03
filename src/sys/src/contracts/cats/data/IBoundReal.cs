//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IBoundReal<S> :  IRealNumeric<S>
        where S : IBoundReal<S>, new()
    {

    }

}