//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct CheckUnaryOpSF<T> : ICheckSF<T,T>
        where T : unmanaged, IEquatable<T>
    {
        public ITestContext Context {get;}

        public bool ExcludeZero {get;}

        [MethodImpl(Inline)]
        public CheckUnaryOpSF(ITestContext context, bool xz = false)
        {
            Context = context;
            ExcludeZero = xz;
        }
    }
}