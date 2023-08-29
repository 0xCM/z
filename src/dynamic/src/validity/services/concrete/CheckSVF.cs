//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct CheckSVF : ICheckSVF
    {
        public ITestContext Context {get;}

        [MethodImpl(Inline)]
        public CheckSVF(ITestContext context)
            => Context = context;

        [MethodImpl(Inline)]
        void ISink<TestCaseRecord>.Deposit(TestCaseRecord src)
            => Context.Deposit(src);
    }
}