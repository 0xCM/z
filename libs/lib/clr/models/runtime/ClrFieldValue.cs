//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ClrFieldValue : IFieldValue<object,object>
    {
        public readonly FieldInfo Field {get;}

        public readonly object Value {get;}

        [MethodImpl(Inline)]
        public ClrFieldValue(FieldInfo field, object value)
        {
            Field = field;
            Value = value;
        }

        [MethodImpl(Inline)]
        public static implicit operator ClrFieldValue((FieldInfo f, object val) src)
            => new ClrFieldValue(src.f,src.val);
    }
}