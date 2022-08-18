//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a shared execution environment
    /// </summary>
    public interface IContextual
    {
        object Context {get;}
    }

    /// <summary>
    /// Characterizes a shared execution environment
    /// </summary>
    public interface IContextual<C> : IContextual
    {
        new C Context {get;}

        object IContextual.Context
            => Context;
    }
}