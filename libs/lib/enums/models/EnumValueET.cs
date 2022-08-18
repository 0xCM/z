//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Captures an <typeparamname name='E'/> parametric enum value and the integral <typeparamref name='E'/> value along with the <see cref='FieldInfo'/>
    /// that defines the corresponding enum literal
    /// </summary>
    public readonly struct EnumValue<E,T>
        where E : unmanaged, Enum
    {
        public FieldInfo Field {get;}

        public E LiteralValue {get;}

        public T NumericValue {get;}

        [MethodImpl(Inline)]
        public EnumValue(FieldInfo field,  E eValue, T tValue)
        {
            Field = field;
            LiteralValue = eValue;
            NumericValue = tValue;
        }

        [MethodImpl(Inline)]
        public string FormatEnum()
            => LiteralValue.ToString();

        [MethodImpl(Inline)]
        public string FormatNumeric()
            => NumericValue.ToString();

        [MethodImpl(Inline)]
        public string Format()
            =>$"{LiteralValue}:{NumericValue}";

        public override string ToString()
            => Format();
    }
}