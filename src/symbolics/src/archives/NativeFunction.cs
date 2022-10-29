//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct NativeFunction : INativeFunction
    {
        public readonly NativeModule Source;

        public readonly MemoryAddress Address;

        public readonly string Name;

        [MethodImpl(Inline)]
        public NativeFunction(NativeModule src, MemoryAddress @base, string name)
        {
            Source = src;
            Address = @base;
            Name = name;
        }

        string INativeFunction.Name
            => Name;

        NativeModule INativeFunction.Source
            => Source;

        MemoryAddress INativeFunction.Address
            => Address;

        public string Format()
            => Address.Format();
    }
}