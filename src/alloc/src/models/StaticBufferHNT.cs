//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public abstract class StaticBuffer<H,N,T> : StaticBuffer<T>
        where H : StaticBuffer<H,N,T>, new()
        where N : unmanaged, ITypeNat
    {
        static H Instance;

        static N n => default;

        [FixedAddressValueType]
        static Index<T> Buffer = alloc<T>(n.NatValue);

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
                    Instance.Fill(Buffer.Storage);
                    Instance.Address = address(Buffer);
                }
                return Instance;
            }
        }

        public override uint CellCount
            => (uint)n.NatValue;
    }
}