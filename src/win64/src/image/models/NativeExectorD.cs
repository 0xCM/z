//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct NativeExector<D>
        where D : Delegate
    {
        public readonly ImageHandle Image;

        public readonly MemoryAddress Address;

        public readonly string Name;

        public readonly D Invoke;

        [MethodImpl(Inline)]
        public NativeExector(ImageHandle src, MemoryAddress @base, string name, D f)
        {
            Image = src;
            Address = @base;
            Name = name;
            Invoke = f;
        }

        public string Format()
            => string.Format(RP.PSx3, Address, Image, Name);

        public override string ToString()
            => Format();
    }
}