//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class Render32<S,T> : BlockedRender<S,CharBlock32>
        where T : unmanaged
    {

    }

    public abstract class Render32<S> : Render32<S,char>
    {


    }

    public abstract class AsciRender32<S> : Render32<S,AsciSymbol>
    {

    }

}