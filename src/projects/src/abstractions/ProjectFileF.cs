//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    partial class ProjectModels
    {
        public abstract record class ProjectFile<F> : IProjectFile<F>
            where F : ProjectFile<F>, new()
        {

        }
    }
}