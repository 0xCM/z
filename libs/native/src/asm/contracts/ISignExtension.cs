//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ISignExtension<S,X>
        where S : unmanaged
        where X : unmanaged
    {
        S Source {get;}

        X Target {get;}
    }
}