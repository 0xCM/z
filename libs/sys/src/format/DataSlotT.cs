//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct DataSlot<T>
    {
        public readonly byte Index;

        public readonly short Pad;

        [MethodImpl(Inline)]
        public DataSlot(byte index, short pad)
        {
            Index = index;
            Pad = pad;
        }

        public string Format()
            => string.Format(RP.slot(Index,Pad));

        public override string ToString()
            => Format();

        public static implicit operator DataSlot(DataSlot<T> src)
            => new DataSlot(src.Index, src.Pad);
    }
}
