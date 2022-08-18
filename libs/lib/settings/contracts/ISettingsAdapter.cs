//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ISettingsAdapter<T>
        where T : ISettingsAdapter<T>, new()
    {
        T Adapt(IJsonSettings source);
    }
}