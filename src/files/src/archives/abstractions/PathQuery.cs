//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract record class PathQuery
    {
        public readonly FolderPath Root;

        protected PathQuery(FolderPath root)
        {
            Root = root;
        }
    }
}