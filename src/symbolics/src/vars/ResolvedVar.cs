//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ResolvedVar : IValued<object>, ITerm
    {
        public readonly dynamic Value;

        [MethodImpl(Inline)]
        public ResolvedVar(dynamic value)
        {
            Value = value;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Value == null;
        }
        object IValued<object>.Value
            => Value;

        public string Format()
            => Value != null ? Value.ToString() : EmptyString;

        public override string ToString()
            => Format();

    }
}