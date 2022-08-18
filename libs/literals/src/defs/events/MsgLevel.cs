//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [SymSource(events)]
    public enum MsgLevel : byte
    {
        None = 0,

        Babble = 1,

        Status = 4,

        Warning = 8,

        Error = 16,
    }
}