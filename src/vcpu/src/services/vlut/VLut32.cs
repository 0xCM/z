//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

/// <summary>
/// Implements a parallel 32-way lookup
/// </summary>
[ApiComplete]
public readonly struct VLut32
{
    readonly Vector256<byte> Mask;

    public byte this[byte i]
    {
        [MethodImpl(Inline)]
        get => vcpu.vcell(Mask, i);
    }

    [MethodImpl(Inline)]
    public VLut32(Vector256<byte> mask)
        => Mask = mask;

    [MethodImpl(Inline)]
    public VLut32(ReadOnlySpan<byte> mask)
        => Mask = vgcpu.vload(w256,mask);

    [MethodImpl(Inline)]
    public Vector256<byte> Select(Vector256<byte> items)
        => vcpu.vshuffle(items, Mask);
}
