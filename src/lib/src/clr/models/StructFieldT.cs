//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Covers a field along with a value that was either extracted from a field instance or that may be pushed into a field instance
    /// </summary>
    /// <typeparam name="T">The field value type</param>
    public readonly struct StructField<T> : IFieldValue<T,object>
        where T : struct
    {
        public readonly FieldInfo Field;

        public readonly object Value;

        [MethodImpl(Inline)]
        public StructField(FieldInfo field, object value)
        {
            Field = field;
            Value = value;
        }

        object IFieldValue<T, object>.Value
            => Value;

        FieldInfo IFieldValue.Field
            => Field;
    }
}