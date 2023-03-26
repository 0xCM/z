//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IProjectFile
    {

    }    
    public interface IProjectFile<F> : IProjectFile
        where F : IProjectFile<F>, new()
    {

    }
}