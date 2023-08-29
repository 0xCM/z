//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct CheckBinaryPredSF<T> : ICheckSF<T,T,bit>
        where T : unmanaged, IEquatable<T>
    {
        public ITestContext Context {get;}

        public bool ExcludeZero {get;}

        [MethodImpl(Inline)]
        public CheckBinaryPredSF(ITestContext context, bool xz = false)
        {
            Context = context;
            ExcludeZero = xz;
        }
    }
}