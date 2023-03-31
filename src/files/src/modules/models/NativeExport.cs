//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct NativeExport
    {
        public readonly string Name;

        public readonly MemoryAddress Address;

        public NativeExport(string name, MemoryAddress address)
        {
            Name = name;
            Address = address;
        }
        
    }
}