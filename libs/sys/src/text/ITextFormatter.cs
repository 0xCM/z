//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    [Free]
    public interface ITextFormatter
    {
        string Format(dynamic src);

        Type SourceType {get;}

        FormatterDelegate Delegate => Format;
    }

    [Free]
    public interface ITextFormatter<T> : ITextFormatter
    {
        string Format(T src);

        new RenderDelegate<T> Delegate => Format;

        FormatterDelegate ITextFormatter.Delegate
            => x => Format((T)x);

        string ITextFormatter.Format(dynamic src)
            => Format((T)src);

        Type ITextFormatter.SourceType
            => typeof(T);
    }
}