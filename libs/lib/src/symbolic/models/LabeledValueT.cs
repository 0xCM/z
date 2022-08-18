//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct LabeledValue<T> : IExpr
    {
        public readonly Label Label;

        public readonly Value<T> Value;

        [MethodImpl(Inline)]
        public LabeledValue(Label label, T value)
        {
            Label = label;
            Value = value;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Label.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Label.IsNonEmpty;
        }
        public string Format()
            => string.Format("{0}:{1}", Label, Value);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator LabeledValue<T>((Label l, T v) src)
            => new LabeledValue<T>(src.l, src.v);

        [MethodImpl(Inline)]
        public static implicit operator LabeledValue<T>((string l, T v) src)
            => new LabeledValue<T>(src.l, src.v);
    }
}