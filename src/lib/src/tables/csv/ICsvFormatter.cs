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

        string Format<T>(in T src)
            where T : struct;

        void RenderLine<T>(in T src, ITextEmitter dst)
            where T : struct
                => dst.AppendLine(Format(src));
    }

    public interface ICsvFormatter<T> : ICsvFormatter
        where T : struct
    {
        string Format(in T src);

        string ICsvFormatter.Format<X>(in X src)
            => Format(sys.@as<X,T>(src));

        TableId ICsvFormatter.TableId
            => TableId.identify(typeof(T));
    }
}