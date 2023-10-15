//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    [MethodImpl(Inline), TestZ]
    public static bit testc(ulong a, ulong b)
        => TestC(vbroadcast(w128, a), vbroadcast(w128, b));

    [MethodImpl(Inline), TestZ]
    public static bit testc(ulong a)
        => TestC(vbroadcast(w128, a), vones<ulong>(w128));
}
