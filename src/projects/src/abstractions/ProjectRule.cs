//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectModels
    {
        public abstract record class ProjectRule<R> : ProjectMember<R>, IProjectRule<R>
            where R : ProjectRule<R>, new()
        {

        }
    }
}