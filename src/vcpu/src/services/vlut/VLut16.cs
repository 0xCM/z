//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

/// <summary>
/// Implements a parallel 16-way lookup
/// </summary>
[ApiComplete]
public readonly struct VLut16
{
    readonly Vector128<byte> Mask;

    public byte this[byte i]
    {
        [MethodImpl(Inline)]
        get => vcpu.vcell(Mask,i);
    }

    [MethodImpl(Inline)]
    public VLut16(Vector128<byte> src)
        => Mask = src;

    [MethodImpl(Inline)]
    public VLut16(ReadOnlySpan<byte> src)
        => Mask = vgcpu.vload(w128, src);

    [MethodImpl(Inline)]
    public Vector128<byte> Select(Vector128<byte> items)
        => vcpu.vshuffle(items, Mask);
}
