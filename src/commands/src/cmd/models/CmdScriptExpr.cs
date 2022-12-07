//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct CmdScriptExpr
    {
        public readonly PScript Pattern;

        public readonly CmdVars Variables;

        [MethodImpl(Inline)]
        public CmdScriptExpr(string pattern)
        {
            Pattern = pattern;
            Variables = CmdVars.create();
        }

        [MethodImpl(Inline)]
        public CmdScriptExpr(PScript pattern)
        {
            Pattern = pattern;
            Variables = CmdVars.create();
        }

        [MethodImpl(Inline)]
        public CmdScriptExpr(PScript pattern, CmdVars vars)
        {
            Pattern = pattern;
            Variables = vars;
        }

        public string Format()
            => Pattern.Format();

        public string Id
        {
            [MethodImpl(Inline)]
            get => Pattern.Name;
        }

        public ref CmdVar this[byte index]
        {
            [MethodImpl(Inline)]
            get => ref Variables[index];
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Pattern.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Pattern.IsNonEmpty;
        }

        [MethodImpl(Inline)]
        public static implicit operator CmdScriptExpr(string src)
            => new CmdScriptExpr(src);

        [MethodImpl(Inline)]
        public static implicit operator CmdScriptExpr(PScript src)
            => new CmdScriptExpr(src);

        public static CmdScriptExpr Empty => new CmdScriptExpr(EmptyString);
    }
}