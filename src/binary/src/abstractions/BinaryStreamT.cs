//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public unsafe abstract class BinaryStream<T> : IBinaryStream<T>
        where T : unmanaged
    {
        public MemoryAddress BaseAddress {get;}

        public MemoryAddress LastAddress {get;}
        
        public ByteSize Alignment {get;}

        public uint CellCount {get;}

        public uint CellSize {get;}

        protected MemoryAddress Offset;

        public uint Length {get;}

        public virtual bool Next(out T value)
        {
            while(Offset < LastAddress)
            {
                value = *Offset.Pointer<T>();
                Offset += CellSize;
                return true;
            }
            value = default;
            return false;            
        }

        protected virtual void Dispose(){}

        void IDisposable.Dispose()
            => Dispose();

        protected BinaryStream(MemoryAddress @base, uint length)
        {
            BaseAddress = @base;
            Length = length;
            CellSize = size<T>();
            CellCount = length/CellSize;
            Offset = BaseAddress;
            LastAddress = BaseAddress + (CellCount*CellSize);
            Alignment = size<T>();
        }
    }
}