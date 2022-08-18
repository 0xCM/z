//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public interface IRegOpClass : IAsmOpClass
    {
        AsmOpClass IAsmOpClass.OpClass
            => AsmOpClass.Reg;
    }

    public interface IRegOpClass<T> : IRegOpClass, IAsmOpClass<T>
        where T : unmanaged, IRegOpClass<T>
    {
        RegClassCode RegClass {get;}
    }
}