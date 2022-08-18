//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct CmdScript
    {
        public readonly Name Name;

        readonly CmdScriptExpr Data;

        [MethodImpl(Inline)]
        public CmdScript(CmdScriptExpr src)
        {
            Name = EmptyString;
            Data = src;
        }

        [MethodImpl(Inline)]
        public CmdScript(Name name, CmdScriptExpr src)
        {
            Name = name;
            Data = src;
        }

        public string Format()
            => Data.Format();

        public override string ToString()
            => Format();

        public CmdLine ToCmdLine()
            => new CmdLine(Format());

        public static CmdScript Empty
        {
            [MethodImpl(Inline)]
            get => new CmdScript(CmdScriptExpr.Empty);
        }
    }
}