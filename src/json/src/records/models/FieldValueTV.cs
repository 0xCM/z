//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class JsonRecords
    {
        public record class FieldValue<T,V>
            where T : IJsonDataType,new()
        {
            public readonly V Value;

            [MethodImpl(Inline)]
            public FieldValue(V value)
            {
                Value = value;
            }

            [MethodImpl(Inline)]
            public static implicit operator FieldValue(FieldValue<T,V> src)
                => new FieldValue(src.Value);

            [MethodImpl(Inline)]
            public static implicit operator FieldValue<V>(FieldValue<T,V> src)
                => new FieldValue<V>(src.Value);

            [MethodImpl(Inline)]
            public static implicit operator FieldValue<T,V>(V value)
                => new FieldValue<T,V>(value);

            [MethodImpl(Inline)]
            public static implicit operator V(FieldValue<T,V> src)
                => src.Value;
        }
    }
}