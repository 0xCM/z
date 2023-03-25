//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class EcmaBlobStream : EcmaStream
    {
        public EcmaBlobStream(MemoryAddress @base, ByteSize size)
            : base(@base,size,EcmaStreamKind.Blob)
        {

        }
    }
}