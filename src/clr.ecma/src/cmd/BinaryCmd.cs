//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    class BinaryCmd : WfAppCmd<BinaryCmd>
    {
        [CmdOp("binary/test")]
        void RunTests()
        {
            var tests = BinaryTests.discover(typeof(BinaryTests).Assembly);
            iter(tests, test => test.Run(Channel));
        }

        [CmdOp("binary/align")]
        void Align()
        {
            var expressions = new Binary.IExpr[]{
                Binary.align(25, 24),
                Binary.align(29, 24),
                Binary.align(43, 24),
                Binary.align(48, 24),
                Binary.align(49, 24),
                Binary.align(3, 8),
                };

            iter(expressions, e => Channel.Row($"{e.Format()} = {e.Evaluate()}"));
            
            
        }
    }
}