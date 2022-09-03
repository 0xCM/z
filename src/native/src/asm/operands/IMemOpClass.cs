//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

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