//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[StructLayout(StructLayout,Pack=1)]
public readonly struct CilEntryPoint
{
    public readonly CilCode Code;

    public readonly MemoryAddress EntryPoint;

    [MethodImpl(Inline)]
    public CilEntryPoint(CilCode msil, MemoryAddress entry)
    {
        Code = msil;
        EntryPoint = entry;
    }
}
