//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public readonly struct AsmRowSet<T>
    {
        public readonly T Key {get;}

        readonly Index<AsmDetailRow> Rows;

        [MethodImpl(Inline)]
        public AsmRowSet(T key, AsmDetailRow[] data)
        {
            Key = key;
            Rows = data;
        }

        public AsmDetailRow[] Sequenced
        {
            [MethodImpl(Inline)]
            get => Rows.Storage.OrderBy(x => x.Sequence);
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Rows.Count;
        }

        [MethodImpl(Inline)]
        public static implicit operator AsmDetailRow[](AsmRowSet<T> src)
            => src.Rows.Storage;
    }
}