//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IBinaryStream<T> : IDisposable
        where T : unmanaged        
    {
        MemoryAddress BaseAddress {get;}

        MemoryAddress LastAddress {get;}

        public ByteSize Alignment 
            => sys.size<T>();

        /// <summary>
        /// Specifies the number of available T-cells
        /// </summary>
        uint Length {get;}        

        bool Next(out T value);        
    }

    [Free]
    public interface IBinaryStream : IBinaryStream<byte>
    {
        
    }
}