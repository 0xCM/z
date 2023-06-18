//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[StructLayout(LayoutKind.Sequential,Pack=1)]
public record class ProcessMemoryMap
{
    [Render(64)]
    public readonly string ProcessName;

    [Render(16)]
    public readonly uint ProcessId;

    [Render(16)]
    public readonly MemoryAddress BaseAddress;

    [Render(16)]
    public readonly ByteSize Size;

    public readonly ReadOnlySeq<ModuleMemory> Modules;

    [MethodImpl(Inline)]
    public ProcessMemoryMap(string name, uint id, MemoryAddress @base, ByteSize size, Index<ModuleMemory> modules)
    {
        ProcessName = name;
        ProcessId = id;
        BaseAddress = @base;
        Size = size;
        Modules = modules;
    }
}
