//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class ProjectArchive<K> : ProjectArchive, IProjectArchive<K>
        where K : IProjectType, new()
    {
        protected ProjectArchive()
        {
            ProjectType = new K();
        }
        
        public override IProjectType ProjectType {get;}
    }
}