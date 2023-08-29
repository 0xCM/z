//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct CheckSVF<T> : ICheckSVF<T>
        where T : unmanaged
    {
        public ITestContext Context {get;}

        public CheckSVF(ITestContext context)
            => Context = context;
    }
}
