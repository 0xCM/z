
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IBufferTokenSource
    {
        /// <summary>
        /// Returns the token of an index-identified buffer
        /// </summary>
        ref readonly BufferToken this[BufferSeqId id] {get;}
    }

    [Free]
    public interface IBufferToken
    {
        IntPtr Handle {get;}

        int Size {get;}

        MemoryAddress Address
            => Handle;
    }

    [Free]
    public interface IBufferToken<F> : IBufferToken
        where F : unmanaged
    {

    }
}