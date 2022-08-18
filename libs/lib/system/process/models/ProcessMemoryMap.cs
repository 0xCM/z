//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public class ProcessMemoryMap
    {
        public readonly string ProcessName;

        public readonly uint ProcessId;

        public readonly MemoryAddress BaseAddress;

        public readonly ByteSize MemorySize;

        public readonly Index<ModuleMemory> Modules;

        [MethodImpl(Inline)]
        public ProcessMemoryMap(string name, uint id, MemoryAddress @base, ByteSize size, Index<ModuleMemory> modules)
        {
            ProcessName = name;
            ProcessId = id;
            BaseAddress = @base;
            MemorySize = size;
            Modules = modules;
        }
    }
}