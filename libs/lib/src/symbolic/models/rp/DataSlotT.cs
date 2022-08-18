//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct DataSlot<T>
    {
        public byte Index {get;}

        public short Pad {get;}

        [MethodImpl(Inline)]
        public DataSlot(byte index, short pad)
        {
            Index = index;
            Pad = pad;
        }

        public string Format()
            => string.Format(RpOps.slot(Index,Pad));

        public override string ToString()
            => Format();

        public static implicit operator DataSlot(DataSlot<T> src)
            => new DataSlot(src.Index, src.Pad);
    }
}
