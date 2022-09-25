//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ClrFieldValue<T>
    {
        public FieldInfo Definition {get;}

        public T Value {get;}

        [MethodImpl(Inline)]
        public ClrFieldValue(FieldInfo field, T value)
        {
            Definition = field;
            Value = value;
        }
    }
}