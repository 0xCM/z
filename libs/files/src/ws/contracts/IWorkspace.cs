//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IWorkspace : IDbArchive
    {
        ReadOnlySeq<IWorkspace> Deps
            => sys.empty<IWorkspace>();
    }

    public interface IWorkspace<W> : IWorkspace
        where W : IWorkspace<W>, new()
    {
        
    }
}