//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    [Free]
    public interface IAsmEncoding : IExpr
    {
        ReadOnlySpan<byte> Encoded {get;}

        byte EncodingSize {get;}

        AsmHexCode ToAsmHex()
            => Encoded;
    }

    [Free]    
    public interface IAsmEncoding<T> : IAsmEncoding
        where T : unmanaged
    {
        Span<byte> Buffer {get;}
    }

    [Free]    
    public interface IAsmEncoding<K,T> : IAsmEncoding<T>
        where T : unmanaged
        where K : unmanaged
    {
        K Kind {get;}
    }
}