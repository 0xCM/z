//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [Free]
    public interface IMemOpClass : IAsmOpClass
    {
        AsmOpClass IAsmOpClass.OpClass
            => AsmOpClass.Mem;

    }

    [Free]
    public interface IMemOpClass<T> :  IMemOpClass, IAsmOpClass<T>
        where T : unmanaged, IMemOpClass<T>
    {

    }
}