//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct CheckBinaryPredSF8<T> : ICheckSF<T,T,bool>
        where T : unmanaged, IEquatable<T>
    {
        public ITestContext Context {get;}

        public bool ExcludeZero {get;}

        [MethodImpl(Inline)]
        public CheckBinaryPredSF8(ITestContext context, bool xz = false)
        {
            Context = context;
            ExcludeZero = xz;
        }
    }
}