//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IProjectFlow<S,T> : IFlow<S,T>
        where S : IProjectFile
        where T : IProjectTarget
    {

    }
}