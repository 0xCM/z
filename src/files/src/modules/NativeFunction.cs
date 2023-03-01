//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct NativeFunction : INativeFunction
    {
        public readonly NativeModule Module;

        public readonly MemoryAddress Address;

        public readonly string Name;

        [MethodImpl(Inline)]
        public NativeFunction(NativeModule src, MemoryAddress @base, string name)
        {
            Module = src;
            Address = @base;
            Name = name;
        }

        string INativeFunction.Name
            => Name;

        INativeModule INativeFunction.Module
            => Module;

        MemoryAddress INativeFunction.Address
            => Address;

        public string Format()
            => Address.Format();

       public override string ToString()
            => Format();
    }
}