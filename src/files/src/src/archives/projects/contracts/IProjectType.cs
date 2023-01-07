//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IProjectType
    {
        @string Name {get;}        
    }

    public interface IProjectType<K> : IProjectType
        where K : IProjectType<K>, new()
    {
        
    }
}