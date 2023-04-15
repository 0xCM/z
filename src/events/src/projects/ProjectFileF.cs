//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract record class ProjectFile<F> : IProjectFile<F>
        where F : ProjectFile<F>, new()
    {

    }    
}