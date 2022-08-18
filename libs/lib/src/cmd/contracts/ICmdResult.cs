//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ICmdResult : ITextual
    {
        CmdId Id {get;}

        bool Succeeded {get;}

        dynamic Payload {get;}

        TextBlock Message {get;}

        string ITextual.Format()
            => Message;
    }

    [Free]
    public interface ICmdResult<C> : ICmdResult
        where C : struct, ICmd
    {
        C Cmd {get;}
    }

    [Free]
    public interface ICmdResult<C,P> : ICmdResult<C>
        where C : struct, ICmd
    {
        new P Payload {get;}

        dynamic ICmdResult.Payload
            => Payload;
    }
}