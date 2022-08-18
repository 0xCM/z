//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct CmdFlag
    {
        public readonly string Name;

        public readonly bit State;

        [MethodImpl(Inline)]
        public CmdFlag(string name, bit state)
        {
            Name = name;
            State = state;
        }

        [MethodImpl(Inline)]
        public static implicit operator CmdArg(CmdFlag src)
            => src.State ? new CmdArg(src.Name) : CmdArg.Empty;
    }
}