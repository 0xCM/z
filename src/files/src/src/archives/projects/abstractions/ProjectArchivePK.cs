//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    public abstract class ProjectArchive<P,K> : ProjectArchive<K>
        where P : ProjectArchive<P,K>, new()
        where K : unmanaged, IProjectType
    {

    }

}