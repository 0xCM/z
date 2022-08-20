//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public delegate string RenderDelegate<T>(T src);

    [Free]
    public delegate string FormatterDelegate(dynamic src);

    public readonly struct FormatFunction<T> : ITextFormatter<T>
    {
        readonly RenderDelegate<T> F;

        [MethodImpl(Inline),Op]
        public FormatFunction(RenderDelegate<T> f)
        {
            F = f;
        }

        [MethodImpl(Inline),Op]
        public string Format(T src)
            => F(src);

        [MethodImpl(Inline)]
        public static implicit operator FormatFunction<T>(RenderDelegate<T> src)
            => new FormatFunction<T>(src);
    }
}