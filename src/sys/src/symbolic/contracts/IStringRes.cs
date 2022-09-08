//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IStringRes : IContented<string>
    {
        ulong Identifier {get;}

        MemoryAddress Address {get;}
    }

    public interface IStringRes<E> : IStringRes
        where E : unmanaged, Enum
    {
        new E Identifier {get;}
    }
}