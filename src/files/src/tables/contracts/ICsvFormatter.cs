//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICsvFormatter
    {
        TableId TableId {get;}

        RowFormatSpec FormatSpec {get;}

        string FormatHeader();

        string Format<T>(in T src);

        void RenderLine<T>(in T src, ITextEmitter dst)
                => dst.AppendLine(Format(src));
    }

    public interface ICsvFormatter<T> : ICsvFormatter
    {
        string Format(in T src);

        string ICsvFormatter.Format<X>(in X src)
            => Format(sys.@as<X,T>(src));

        TableId ICsvFormatter.TableId
            => TableId.identify(typeof(T));
    }
}