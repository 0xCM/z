//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Binary
{
    public abstract class ByteStream : Stream<byte> 
    {
        protected ByteStream(MemoryAddress @base, uint length)
            : base(@base,length)            
        {

        }
    }
}