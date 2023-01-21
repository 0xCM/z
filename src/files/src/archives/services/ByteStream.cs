//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct ByteStream : IDisposable
    {
        readonly BinaryCode Store;

        readonly MemoryStream Stream;

        [MethodImpl(Inline)]
        public ByteStream(byte[] src)
        {
            Store = src;
            Stream =  new MemoryStream(src);
        }

        public void Dispose()
            => Stream.Dispose();
    }
}