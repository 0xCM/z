//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public enum ApiActorKind : byte
    {
        None,

        Pure,

        Emitter,

        Receiver,

        Func,

        ContextReceiver,

        ContextFunc,
    }
}