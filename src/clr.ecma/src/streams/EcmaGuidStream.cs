//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class EcmaGuidStream : EcmaStream
    {
        public EcmaGuidStream(MemoryAddress @base, ByteSize size)
            : base(@base,size,EcmaStreamKind.Blob)
        {

        }
    }
}