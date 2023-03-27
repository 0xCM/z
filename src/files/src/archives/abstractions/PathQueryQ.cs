//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract record class PathQuery<Q> : PathQuery
        where Q : PathQuery<Q>
    {
        protected PathQuery(FolderPath root)    
            : base(root)
        {

        }     
    }
}