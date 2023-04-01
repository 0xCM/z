//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct NativeFunction
    {
        public readonly MemoryAddress Address;

        public readonly string Name;

        [MethodImpl(Inline)]
        public NativeFunction(MemoryAddress @base, string name)
        {
            Address = @base;
            Name = name;
        }
        
       public string Format()
            => Address.Format();

       public override string ToString()
            => Format();
    }
}