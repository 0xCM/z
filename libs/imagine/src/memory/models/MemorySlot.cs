//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    [ApiHost]
    public struct MemorySlot
    {
        [MethodImpl(Inline), Op]
        public static ref MemorySlot advance(ref MemorySlot slot)
        {
            if(slot.Index == MemorySlot.LastKey)
                slot.Index = MemorySlot.FirstKey;
            else
                slot.Index += 1;
            return ref slot;
        }

        [MethodImpl(Inline)]
        public static ref MemorySlot<I> advance<I>(ref MemorySlot<I> slot)
            where I : unmanaged
        {
            add(slot.Index, 1);
            return ref slot;
        }

        [MethodImpl(Inline), Op]
        public static ref MemorySlot retreat(ref MemorySlot slot)
        {
            if(slot.Index == MemorySlot.FirstKey)
                slot.Index = MemorySlot.LastKey;
            else
                slot.Index -= 1;
            return ref slot;
        }

        [MethodImpl(Inline)]
        public static ref MemorySlot<I> retreat<I>(ref MemorySlot<I> slot)
            where I : unmanaged
        {
            sub(slot.Index, 1);
            return ref slot;
        }

        internal Hex8Kind Index;

        [MethodImpl(Inline)]
        public MemorySlot(Hex8Kind value)
            => Index = value;

        [MethodImpl(Inline)]
        public MemorySlot(byte value)
            => Index = (Hex8Kind)value;

        [MethodImpl(Inline)]
        public MemorySlot Advance()
            => advance(ref this);

        [MethodImpl(Inline)]
        public MemorySlot Retreat()
            => retreat(ref this);

        [MethodImpl(Inline)]
        public static MemorySlot operator++(MemorySlot src)
            => src.Advance();

        [MethodImpl(Inline)]
        public static MemorySlot operator--(MemorySlot src)
            => src.Retreat();

        [MethodImpl(Inline)]
        public static implicit operator byte(MemorySlot src)
            => (byte)src.Index;

        [MethodImpl(Inline)]
        public static implicit operator MemorySlot(int src)
            => new MemorySlot((Hex8Kind)src);

        [MethodImpl(Inline)]
        public static implicit operator MemorySlot(byte src)
            => new MemorySlot((Hex8Kind)src);

        internal const Hex8Kind FirstKey = Hex8Kind.x00;

        internal const Hex8Kind LastKey = Hex8Kind.xff;
    }
}