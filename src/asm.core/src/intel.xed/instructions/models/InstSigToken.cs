//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct InstSigToken
        {
            readonly asci8 Value;

            [MethodImpl(Inline)]
            public InstSigToken(asci8 src)
            {
                Value = src;
            }

            public string Format()
                => Value.Format();

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator InstSigToken(string src)
                => new InstSigToken(src);
        }
    }
}