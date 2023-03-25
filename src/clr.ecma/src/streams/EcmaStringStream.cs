//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class EcmaStringStream : EcmaStream
    {
        public EcmaStringStream(MemoryAddress @base, ByteSize size, bool user)
            : base(@base,size,user ? EcmaStreamKind.UserString : EcmaStreamKind.String)
        {

        }
    }
}