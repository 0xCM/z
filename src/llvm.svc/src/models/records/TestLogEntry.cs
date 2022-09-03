//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct TestLogEntry
    {
        public string TestName;

        public string ResultCode;

        public double Elapsed;

        public TextBlock Output;
    }
}