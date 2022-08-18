//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICmdResultHandler
    {
        Actor Actor {get;}

        bool CanHandle(TextLine src);

        bool Handle(TextLine src);
    }
}