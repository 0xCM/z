//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct NativeExport
    {
        public readonly Label Name;

        public readonly MemoryAddress Address;

        public NativeExport(Label name, MemoryAddress address)
        {
            Name = name;
            Address = address;
        }       
    }
}