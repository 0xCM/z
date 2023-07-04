//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct AsmToken
    {
        public readonly uint Key;

        public readonly Label Name;

        public readonly Label Expression;

        [MethodImpl(Inline)]
        public AsmToken(uint key, Label name, Label expression)
        {
            Key = key;
            Name = name;
            Expression = expression;
        }

    }
}