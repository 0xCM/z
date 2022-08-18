//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct VBroadcastCheck128<S,T> : ICheckSF128<S,T>
        where S : unmanaged
        where T : unmanaged
    {
        public static VBroadcastCheck128<S,T> Op => default;

        public const string Name = "vbroadcast_check";

        public Vec128Kind<T> VKind => default;

        public OpIdentity Id
            => SFxIdentity.identity(Name,VKind);

        public bit Invoke(S a, Vector128<T> x)
        {
            var count = cpu.vcount<T>(w128);
            var result = bit.On;
            var y = x.As<T,S>();
            for(var i=0; i< count; i++)
                result &= gmath.eq(a, y.Cell(i));
            return result;
        }
    }
}