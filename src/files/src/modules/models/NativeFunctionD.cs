//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct NativeFunction<D> : INativeFunction
        where D : Delegate
    {
        public readonly NativeModule Module {get;}

        public readonly MemoryAddress Address {get;}

        public readonly string Name {get;}

        public readonly D Invoke {get;}

        [MethodImpl(Inline)]
        public NativeFunction(NativeModule src, MemoryAddress @base, string name, D f)
        {
            Module = src;
            Address = @base;
            Name = name;
            Invoke = f;
        }

        public string Format()
            => string.Format(RP.PSx3, Address, Module, Name);

        public override string ToString()
            => Format();

        INativeModule INativeFunction.Module
            => Module;
    }
}