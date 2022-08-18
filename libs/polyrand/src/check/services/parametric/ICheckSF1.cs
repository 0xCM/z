//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Matches;

    public interface ICheckSF<T,R> : ICheckSF
        where T : unmanaged, IEquatable<T>
        where R : unmanaged
    {
        void CheckMatch<F,G>(F f, G g)
            where F : IFunc<T,R>
            where G : IFunc<T,R>
                => api.points<F,G,T,R>(Context, f, g, ExcludeZero);

        void CheckSpanMatch<F,G>(F f, G g)
            where F : IFunc<T,R>
            where G : IFunc<T,R>
                => api.spans<F,G,T,R>(Context, f ,g, ExcludeZero);
    }
}