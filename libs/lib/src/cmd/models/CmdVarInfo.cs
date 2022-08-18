//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct CmdVarInfo
    {
        public readonly Name VarName;

        public readonly TextBlock Purpose;

        [MethodImpl(Inline)]
        public CmdVarInfo(Name name, TextBlock purpose)
        {
            VarName = name;
            Purpose = purpose;
        }
    }
}