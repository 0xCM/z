//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class ProjectArchive : IProjectArchive
    {
        public abstract IProjectType ProjectType {get;}

        public abstract IDbArchive Root {get;}       
    }
}