//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IAsmInstruction
    {

    }

    public interface IAsmInstruction<T> : IAsmInstruction
        where T : unmanaged, IAsmInstruction<T>
    {

    }
}