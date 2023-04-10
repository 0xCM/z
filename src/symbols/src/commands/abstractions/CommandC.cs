//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Cmd]
    public abstract record class Command : ICmd
    {
        public abstract CmdId CmdId {get;}

        public abstract string Format();

        public sealed override string ToString()
            => Format();
    }
}