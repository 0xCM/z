//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface INumericFormatter<T> : ITextFormatter<T>
        where T : unmanaged
    {
        string Format(T src, NumericBaseKind @base);

        string ITextFormatter<T>.Format(T src)
            => Format(src, NumericBaseKind.Base10);
    }

    public interface INumericFormatter<F,T> : INumericFormatter<T>
        where F : struct, INumericFormatter<F,T>
        where T : unmanaged
    {

    }
}