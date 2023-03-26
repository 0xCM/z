//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectTargets
    {
        public abstract class ProjectTarget<T,R,C> : IProjectTarget<T>
            where T : ProjectTarget<T,R,C>, new()
            where R : IProjectRule, new()
        {
    
            public abstract C Build(R rule);

            public static T Empty => new();
        }
    }
}