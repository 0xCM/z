//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct CmdScript
    {
        public readonly @string Name;

        readonly CmdVarExpr Data;

        [MethodImpl(Inline)]
        public CmdScript(CmdVarExpr src)
        {
            Name = EmptyString;
            Data = src;
        }

        [MethodImpl(Inline)]
        public CmdScript(string name, CmdVarExpr src)
        {
            Name = name;
            Data = src;
        }

        public string Format()
            => Data.Format();

        public override string ToString()
            => Format();


        public static CmdScript Empty
        {
            [MethodImpl(Inline)]
            get => new CmdScript(CmdVarExpr.Empty);
        }
    }
}