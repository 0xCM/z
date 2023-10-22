//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

/// <summary>
/// Implements a parallel 32-way lookup
/// </summary>
[ApiComplete]
public readonly struct VLut64
{
    readonly Vector512<byte> Mask;

    public byte this[byte i]
    {
        [MethodImpl(Inline)]
        get => vcpu.vcell(Mask, i);
    }

    [MethodImpl(Inline)]
    public VLut64(Vector512<byte> mask)
        => Mask = mask;

    [MethodImpl(Inline)]
    public VLut64(ReadOnlySpan<byte> mask)
        => Mask = vgcpu.vload(w512,mask);

    [MethodImpl(Inline)]
    public Vector512<byte> Select(Vector512<byte> items)
        => vcpu.vshuffle(items, Mask);
}
