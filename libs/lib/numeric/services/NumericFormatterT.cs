//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct NumericFormatter<T> : INumericFormatter<T>
        where T : unmanaged
    {
        readonly INumericFormatter<T> Formatter;

        [MethodImpl(Inline)]
        public NumericFormatter(INumericFormatter<T> formatter)
            => Formatter = formatter;

        [MethodImpl(Inline)]
        public string Format(T src, NumericBaseKind @base)
            => Formatter.Format(src, @base);

        [MethodImpl(Inline)]
        public NumericFormatter<F> As<F>()
            where F : unmanaged
                => new NumericFormatter<F>(this as INumericFormatter<F>);
    }
}