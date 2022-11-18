//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct CmdModifier
    {
        public readonly @string Value;

        [MethodImpl(Inline)]
        public CmdModifier(@string value)
        {
            Value = value;
        }

        [MethodImpl(Inline)]
        public string Format()
            => Value.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator CmdModifier(string src)
            => new CmdModifier(src);
    }
}