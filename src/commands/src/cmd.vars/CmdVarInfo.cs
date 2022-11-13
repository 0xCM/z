//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct CmdVarInfo
    {
        public readonly @string VarName;

        public readonly TextBlock Purpose;

        [MethodImpl(Inline)]
        public CmdVarInfo(@string name, TextBlock purpose)
        {
            VarName = name;
            Purpose = purpose;
        }
    }
}