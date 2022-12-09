//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public abstract class StaticBuffer<H,T> : StaticBuffer<T>
        where H : StaticBuffer<H,T>, new()
    {
        static H Instance;

        [FixedAddressValueType]
        static Index<T> Buffer;

        static object locker = new object();

        [MethodImpl(Inline)]
        public static H fetch()
        {
            lock(locker)
            {
                if(Instance == null)
                {
                    Instance = new H();
                    var count = Instance.CellCount;
                    Buffer = alloc<T>(Instance.CellCount);
                    Instance.Fill(Buffer.Storage);
                    Instance.Address = address(Buffer);
                }
                return Instance;
            }
        }

        public override uint CellCount
            => Buffer.Count;
    }
}