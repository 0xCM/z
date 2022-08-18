//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct NativeFunction<D> : INativeFunction
        where D : Delegate
    {
        public readonly MemoryAddress Address {get;}

        public readonly NativeModule Source {get;}

        public readonly string Name {get;}

        public readonly D Invoke {get;}

        [MethodImpl(Inline)]
        public NativeFunction(NativeModule src, MemoryAddress @base, string name, D f)
        {
            Source = src;
            Address = @base;
            Name = name;
            Invoke = f;
        }

        public string Format()
            => string.Format(RpOps.PSx3, Address, Source, Name);
    }
}