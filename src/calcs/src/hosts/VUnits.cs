//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial struct CalcHosts
{
    public readonly struct VUnits128<T> : IEmitter128<T>
        where T : unmanaged
    {
        [MethodImpl(Inline)]
        public Vector128<T> Invoke()
            => vcpu.vunits<T>(w128);
    }

    public readonly struct VUnits256<T> : IEmitter256<T>
        where T : unmanaged
    {
        [MethodImpl(Inline)]
        public Vector256<T> Invoke()
            => vcpu.vunits<T>(w256);
    }
}
