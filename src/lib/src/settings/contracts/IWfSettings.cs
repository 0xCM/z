//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IWfSettings : ISettings
    {

    }

    public interface IWfSettings<T> : IWfSettings, ISettings<T>
        where T : IWfSettings<T>, new()
    {

    }
}