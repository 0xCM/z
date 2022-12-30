//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct CmdPattern
    {
        public readonly ScriptPattern Body;

        public readonly CmdVars Variables;

        [MethodImpl(Inline)]
        public CmdPattern(string pattern)
        {
            Body = pattern;
            Variables = CmdVars.create();
        }

        [MethodImpl(Inline)]
        public CmdPattern(ScriptPattern pattern)
        {
            Body = pattern;
            Variables = CmdVars.create();
        }

        [MethodImpl(Inline)]
        public CmdPattern(ScriptPattern pattern, CmdVars vars)
        {
            Body = pattern;
            Variables = vars;
        }

        public Hash32 Hash
            => sys.nhash(Body.Format().GetHashCode(),  Variables.Format().GetHashCode());

        public string Format()
            => Body.Format();

        public string Id
        {
            [MethodImpl(Inline)]
            get => Body.Name;
        }

        public ref CmdVar this[byte index]
        {
            [MethodImpl(Inline)]
            get => ref Variables[index];
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Body.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Body.IsNonEmpty;
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public static implicit operator CmdPattern(string src)
            => new CmdPattern(src);

        [MethodImpl(Inline)]
        public static implicit operator CmdPattern(ScriptPattern src)
            => new CmdPattern(src);

        public static CmdPattern Empty => new CmdPattern(EmptyString);
    }
}