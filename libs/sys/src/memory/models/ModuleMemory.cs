//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ModuleMemory : IExpr
    {
        public readonly string ModuleName;

        public readonly MemoryAddress BaseAddress;

        public readonly ByteSize MemorySize;

        [MethodImpl(Inline)]
        public ModuleMemory(string module, MemoryAddress @base, ByteSize size)
        {
            ModuleName = module;
            BaseAddress = @base;
            MemorySize = size;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => MemorySize == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => MemorySize != 0;
        }

        public MemorySeg Segment
        {
            [MethodImpl(Inline)]
            get => new (BaseAddress, MemorySize);
        }

        public MemoryAddress MaxAddress
        {
            [MethodImpl(Inline)]
            get => BaseAddress + MemorySize;
        }

        public string Format()
            => string.Format("{0,-64}: {1}({2})", ModuleName, Segment, MemorySize);

        public override string ToString()
            => Format();
    }
}