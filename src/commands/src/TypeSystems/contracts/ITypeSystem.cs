//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    public interface ITypeSystem
    {
        @string Name {get;}
    }

    public interface ITypeSystem<T> : ITypeSystem
        where T : ITypeSystem<T>, new()
    {
        ref readonly T Instance {get;}
    }
}
