//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IControl : IDisposable
    {

    }

    public interface IControl<T> : IControl
        where T : IControl<T>
    {

    }
}