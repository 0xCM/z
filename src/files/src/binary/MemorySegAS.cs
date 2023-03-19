//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct MemorySeg<A,S>
        where A : unmanaged, IAddress
        where S : unmanaged
    {
        public readonly A Address;

        public readonly S Size;

        public MemorySeg(A address, S size)
        {
            Address = address;
            Size = size;
        }
        public string Format()
            => $"{Address}[{Size}]";

        public override string ToString()
            => Format();
    }
}