//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class Project<P,K> : Project<K>, IProject<P,K>
        where P : Project<P,K>,new()
        where K : unmanaged
    {
        protected Project()
        {
            
        }

        protected Project(string name, IDbArchive root)
            : base(name,root)
        {
            
        }

    } 
}