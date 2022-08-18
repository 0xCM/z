//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IErrorEvent : ILevelEvent
    {
        bool IAppEvent.IsError
            => true;
    }
}