//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct TableId<T> : ITableId
        where T : struct, IRecord<T>
    {
        public TableId Value {get;}

        [MethodImpl(Inline)]
        public TableId(TableId src)
            => Value = src;

        public Type RecordType
            => typeof(T);

        public Identifier Identifier
            => Value.Identifier;

        [MethodImpl(Inline)]
        public string Format()
            => Identifier.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator TableId(TableId<T> src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator TableId<T>(TableId src)
            => new TableId<T>(src);
    }
}