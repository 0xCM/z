//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public interface IAsmOpClass
    {
        AsmOpClass OpClass {get;}
    }

    public interface IAsmOpClass<T> : IAsmOpClass
        where T : unmanaged
    {

    }
}
