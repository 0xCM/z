//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class Project<K> : Project, IProject<K>
        where K : unmanaged
    {
        protected Project()
        {
            
        }

        protected Project(string name, IDbArchive root)
            : base(name,root)
        {
            
        }

        public abstract K Kind {get;}
    } 
}