//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public enum CmdMethodType : byte
    {
        None,

        Pure,

        Emitter,

        Receiver,

        Func,

        DiscriminatedReceiver,

        DiscriminatedFunc,
    }
}