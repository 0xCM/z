//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct CheckTernaryPredSF<T> : ICheckSF<T,T,T,bit>
        where T : unmanaged, IEquatable<T>
    {
        public ITestContext Context {get;}

        public bool ExcludeZero {get;}

        [MethodImpl(Inline)]
        public CheckTernaryPredSF(ITestContext context, bool xzero = false)
        {
            Context = context;
            ExcludeZero = xzero;
        }
    }
}