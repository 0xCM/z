//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Windows;

    public interface ISymLink : IFsEntry
    {
        SymLinkKind Kind {get;}

        FsEntry Source {get;}

        FsEntry Target {get;}

    }

    public interface ISymLink<S> : ISymLink, IFsEntry<S>
        where S : struct, ISymLink<S>
    {

    }
}
 