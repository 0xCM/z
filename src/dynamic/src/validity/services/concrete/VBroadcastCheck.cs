//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public static class VBroadcastChecks
    {
       [MethodImpl(Inline)]
       public static VBroadcastCheck128<S,T> vbroadcast<S,T>(N128 w, S s = default, T t = default)
            where S : unmanaged
            where T : unmanaged
                => VBroadcastCheck128<S,T>.Op;

       [MethodImpl(Inline)]
       public static VBroadcastCheck256<S,T> vbroadcast<S,T>(N256 w, S s = default, T t = default)
            where S : unmanaged
            where T : unmanaged
                => VBroadcastCheck256<S,T>.Op;
    }
}