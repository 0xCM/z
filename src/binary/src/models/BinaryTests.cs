//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static BinaryTypes;

    public partial class BinaryTests
    {
        public static ReadOnlySeq<IChanneledTest> discover(params Assembly[] src)
        {
            var types = src.Types().Tagged<ChanneledTestAttribute>().Concrete();
            return types.Map(t => (IChanneledTest)Activator.CreateInstance(t));
            
        }

        sealed class IntegerTypeTest : ChanneledTest<IntegerTypeTest>
        {
            record class ParserCase
            {
                public readonly string Input;

                public readonly IntegerType Expect;

                public ParserCase(string input, IntegerType expect)
                {
                    Input = input;
                    Expect = expect;
                }                
            }

            record class SizingCase
            {
                public readonly IntegerType Input;

                public readonly ByteSize Expect;

                public SizingCase(IntegerType input, ByteSize expect)
                {
                    Input = input;
                    Expect = expect;
                }                
            }

            protected override ExecToken Run(ExecFlow flow)
            {
                CheckParsers();
                return Channel.Ran(flow);
            }

            void CheckParsers()
            {
                var cases = new ParserCase[]{
                    new("i14", signed(14)),
                    new("i234", signed(234)),
                    new("u17", unsigned(17)),
                    new("u64", unsigned(64)),
                };
                iter(cases, c => {
                    Require.invariant(parse(c.Input, out IntegerType dst));
                    Require.equal(c.Expect, dst);
                });
            }
        }
    }
}