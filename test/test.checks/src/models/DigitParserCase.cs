//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct DigitParserCase : ITextual
    {
        public NumericBaseKind Base {get;}

        public char Input {get;}

        public byte Expect {get;}

        [MethodImpl(Inline)]
        public DigitParserCase(NumericBaseKind @base, char input, byte expect)
        {
            Base = @base;
            Input = input;
            Expect = expect;
        }

        public string Format()
            => string.Format("{1} => {2} ({0})", Base, Input, Expect);

        public override string ToString()
            => Format();
    }
}