//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct CmdVarExpr
    {
        public readonly ScriptPattern Pattern;

        public readonly CmdVars Variables;

        [MethodImpl(Inline)]
        public CmdVarExpr(string pattern)
        {
            Pattern = pattern;
            Variables = CmdVars.create();
        }

        [MethodImpl(Inline)]
        public CmdVarExpr(ScriptPattern pattern)
        {
            Pattern = pattern;
            Variables = CmdVars.create();
        }

        [MethodImpl(Inline)]
        public CmdVarExpr(ScriptPattern pattern, CmdVars vars)
        {
            Pattern = pattern;
            Variables = vars;
        }

        public Hash32 Hash
            => sys.nhash(Pattern.Format().GetHashCode(),  Variables.Format().GetHashCode());

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

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public static implicit operator CmdVarExpr(string src)
            => new CmdVarExpr(src);

        [MethodImpl(Inline)]
        public static implicit operator CmdVarExpr(ScriptPattern src)
            => new CmdVarExpr(src);

        public static CmdVarExpr Empty => new CmdVarExpr(EmptyString);
    }
}