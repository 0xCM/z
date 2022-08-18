//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Roslyn
{
    using Microsoft.CodeAnalysis;

    public interface IDocXmlSource
    {
        @string DocXml();
    }

    public interface ICaSymbol : IExpr, IDocXmlSource
    {
        ISymbol Source {get;}

        SymbolKind Kind {get;}

        bool INullity.IsEmpty
            => Source == null;

        bool INullity.IsNonEmpty
            => Source != null;

        string IExpr.Format()
            => Source?.ToDisplayString() ?? "<null>";
    }

    public interface ICaSymbol<T> : ICaSymbol
        where T : ISymbol
    {
        new T Source {get;}

        ISymbol ICaSymbol.Source
            => Source;
    }

    public interface ICaSymbol<H,T> : ICaSymbol<T>
        where H : new()
        where T : ISymbol
    {

    }
}