//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IDocument
    {
        IFsEntry Location {get;}
    }

    public interface IDocument<D> : IDocument
        where D :  IDocument, new()
    {
        D Load();
    }

    public interface IDocument<D,C> : IDocument<D>
        where D : IDocument, new()
    {
        C Content {get;}
    }

    public interface IDocument<D,C,L> : IDocument<D,C>
        where D : IDocument, new()
        where L : IFsEntry
    {
        new L Location {get;}

        IFsEntry IDocument.Location
            => Location;

        D IDocument<D>.Load()
            => Load();
    }
}