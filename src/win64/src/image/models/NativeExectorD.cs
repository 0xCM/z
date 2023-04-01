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

        public readonly MemoryAddress ProcAddress;

        public readonly string ProcName;

        public readonly D F;

        [MethodImpl(Inline)]
        public NativeExector(ImageHandle src, MemoryAddress @base, string name, D f)
        {
            Image = src;
            ProcAddress = @base;
            ProcName = name;
            F = f;
        }

        public string Format()
            => string.Format(RP.PSx3, ProcAddress, Image, ProcName);

        public override string ToString()
            => Format();
    }
}