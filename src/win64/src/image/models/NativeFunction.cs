//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct NativeFunction
    {
        public readonly ImageHandle Image;

        public readonly MemoryAddress Address;

        public readonly string Name;

        [MethodImpl(Inline)]
        public NativeFunction(ImageHandle src, MemoryAddress @base, string name)
        {
            Image = src;
            Address = @base;
            Name = name;
        }
        
       public string Format()
            => Address.Format();

       public override string ToString()
            => Format();
    }
}