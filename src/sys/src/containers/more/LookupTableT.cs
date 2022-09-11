//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = LookupTables;

    public readonly struct LookupTable<T>
    {
        readonly Index<T> Cells;

        readonly GridDim<ushort> Dim;

        [MethodImpl(Inline)]
        internal LookupTable(GridDim<ushort> dim, T[] cells)
        {
            Dim = dim;
            Cells = cells;
        }

        [MethodImpl(Inline)]
        public ref T Value(LookupKey key)
            => ref Cells[api.offset(Dim,key)];

        [MethodImpl(Inline)]
        public KeyMap<T> Map(LookupKey key)
            => (key,Value(key));

        public ref T this[LookupKey key]
        {
            [MethodImpl(Inline)]
            get => ref Value(key);
        }
    }
}