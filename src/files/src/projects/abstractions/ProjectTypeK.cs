//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract record class ProjectType<K> : IProjectType<K>
        where K : IProjectType<K>, new()
    {
        public @string Name {get;}

        protected ProjectType(string name)
        {
            Name = name;
        }
    }
}