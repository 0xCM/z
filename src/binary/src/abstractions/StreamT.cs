//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Binary
{
    public abstract class Stream<T> : IBinaryStream<T>
        where T : unmanaged
    {
        public MemoryAddress BaseAddress {get;}

        public uint Length {get;}

        public abstract bool Next(out T value);

        protected virtual void Dispose(){}

        void IDisposable.Dispose()
            => Dispose();

        protected Stream(MemoryAddress @base, uint length)
        {
            BaseAddress = @base;
            Length = length;
        }
    }
}