//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class GlobalBuffer<B,S>
        where B : GlobalBuffer<B,S>, new()
        where S : struct
    {
        [FixedAddressValueType]
        protected static S Storage = new S();

        protected GlobalBuffer()
        {
            StoreLocation = LocateStore();
        }

        public MemoryAddress StoreLocation {get;}

        public unsafe ref S Buffer
        {
            [MethodImpl(Inline)]
            get => ref LocateStore().Ref<S>();
        }

        protected virtual void Init() { }

        static unsafe MemoryAddress LocateStore()
            => new MemoryAddress(Unsafe.AsPointer(ref Storage));
    }
}