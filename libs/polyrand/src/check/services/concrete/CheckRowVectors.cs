//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct CheckRowVectors : ICheckRowVectors<CheckRowVectors>
    {
        [MethodImpl(Inline)]
        public static int length<T>(RowVector256<T> a, RowVector256<T> b)
            where T : unmanaged
                => a.Length == b.Length ? a.Length  : AppErrors.ThrowNotEqualNoCaller(a.Length, b.Length);
    }
}