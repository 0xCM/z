//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct PersistentMemory
    {
        public readonly MemoryAddress BaseAddress;

        public readonly ByteSize Size;

        public readonly AllocToken Token;
         
        internal PersistentMemory(AllocToken token)
        {
            Token = token;
            BaseAddress = token.Base;
            Size = token.Size;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Size == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Size != 0;
        }        

        public static PersistentMemory Empty => default;
    }
}