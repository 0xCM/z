//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;

    using static Root;

    /// <summary>
    /// Captures an <typeparamname name='E'/> parametric enum value along with the <see cref='FieldInfo'/> that defines the corresponding enum literal
    /// </summary>
    public readonly struct EnumValue<E>
        where E : unmanaged, Enum
    {
        public FieldInfo Field {get;}

        public E LiteralValue {get;}

        [MethodImpl(Inline)]
        public EnumValue(FieldInfo field, E value)
        {
            Field = field;
            LiteralValue = value;
        }

        public string Format()
            => LiteralValue.ToString();

        public override string ToString()
            => Format();
    }
}