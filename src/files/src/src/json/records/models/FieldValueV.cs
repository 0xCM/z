//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class JsonRecords
    {
        public record class FieldValue<V>
        {
            public readonly V Value;

            public FieldValue(V value)
            {
                Value = value;
            }

            [MethodImpl(Inline)]
            public static implicit operator FieldValue<V>(V value)
                => new FieldValue<V>(value);

            [MethodImpl(Inline)]
            public static implicit operator V(FieldValue<V> src)
                => src.Value;

            public static implicit operator FieldValue(FieldValue<V> src)
                => new FieldValue(src.Value);
        }
    }
}