//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract record class EcmaStream
    {        
        public readonly MemoryAddress BaseAddress;

        public readonly ByteSize Size;

        public readonly EcmaStreamKind Kind;

        public EcmaStream(MemoryAddress @base, ByteSize size, EcmaStreamKind kind)
        {
            BaseAddress = @base;
            Size = size;
            Kind = kind;
        }
        
    }

}