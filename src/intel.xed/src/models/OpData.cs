//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedModels
{
    public readonly record struct OpData
    {
        public readonly OpName Name;

        public readonly object Value;

        [MethodImpl(Inline)]
        public OpData(Operand value)
        {
            Name = value.Name;
            Value = value;
        }

        [MethodImpl(Inline)]
        public OpData(OpNameKind name, object value)
        {
            Name = name;
            Value = value;
        }

        public string Format()
            => Value?.ToString() ?? EmptyString;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static explicit operator Disp(OpData src)
            => src.Value is Operand v ? (Disp)v : Disp.Empty;

        public static OpData Empty => new (OpNameKind.None, z8);
    }
}
