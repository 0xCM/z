//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Caller = System.Runtime.CompilerServices.CallerMemberNameAttribute;
    using File = System.Runtime.CompilerServices.CallerFilePathAttribute;
    using Line = System.Runtime.CompilerServices.CallerLineNumberAttribute;

    using Claims = BvClaims;

    public interface ICheckBitVectors : ICheckPrimal, ICheckInvariant
    {
        ICheckPrimal Primal => this;

        void eq(BitVector4 x, BitVector4 y, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Claims.eq(x, y, caller, file, line);

        void eq(BitVector8 x, BitVector8 y, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Claims.eq(x, y, caller, file, line);

        void eq(BitVector16 x, BitVector16 y, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Claims.eq(x, y, caller, file, line);

        void eq(BitVector32 x, BitVector32 y, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Claims.eq(x, y, caller, file, line);

        void eq(BitVector64 x, BitVector64 y, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Primal.eq(x.State, y.State, caller, file, line);

        void eq<T>(ScalarBits<T> x, ScalarBits<T> y, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            where T : unmanaged
                => Claims.eq(x, y, caller, file, line);

        void eq<T>(BitVector128<T> x, BitVector128<T> y, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            where T : unmanaged
                => Claims.eq(x, y, caller, file, line);

        void eq<N,T>(ScalarBits<N,T> x, ScalarBits<N,T> y, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => Claims.eq(x, y, caller, file, line);
    }
}