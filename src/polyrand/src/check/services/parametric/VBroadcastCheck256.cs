//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct VBroadcastCheck256<S,T> : ICheckSF256<S,T>
        where S : unmanaged
        where T : unmanaged
    {
        public static VBroadcastCheck256<S,T> Op => default;

        public Vec256Kind<T> VKind => default;

        public const string Name = "vbroadcast_check";

        public OpIdentity Id
            => SFxIdentity.identity(Name,VKind);

        public bit Invoke(S a, Vector256<T> x)
        {
            var count = cpu.vcount<T>(w256);
            var result = bit.On;
            var y = x.As<T,S>();
            for(var i=0; i< count; i++)
                result &= gmath.eq(a, y.Cell(i));
            return result;
        }
    }
}