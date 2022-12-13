//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ICmdResult
    {
        ICmd Spec {get;}

        ExecToken Token {get;}

        bool Succeeded {get;}

        dynamic Payload {get;}
    }

    [Free]
    public interface ICmdResult<C,P> : ICmdResult
        where C : ICmd, new()
        where P : INullity, new()
    {
        new C Spec {get;}

        new P Payload {get;}

        ICmd ICmdResult.Spec
            => Spec;

        dynamic ICmdResult.Payload
            => Payload;
    }
}