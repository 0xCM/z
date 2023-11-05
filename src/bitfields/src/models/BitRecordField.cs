//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[StructLayout(LayoutKind.Sequential, Pack=1)]
public readonly struct BitRecordField
{
    /// <summary>
    /// The field name
    /// </summary>
    public readonly asci16 Name;

    /// <summary>
    /// The symbolic field representation
    /// </summary>
    public readonly asci16 Expr;

    /// <summary>
    /// The 0-based, record-relative field position/index
    /// </summary>
    public readonly byte FieldIndex;

    /// <summary>
    /// The position of the first bit in the field
    /// </summary>
    public readonly uint FieldOffset;

    /// <summary>
    /// The number of semantic bits required by the field
    /// </summary>
    public readonly byte PackedWidth;

    [MethodImpl(Inline)]
    public BitRecordField(asci16 name, asci16 expr, byte index, uint offset, byte width)
    {
        Name = name;
        Expr = expr;
        FieldIndex = index;
        FieldOffset = offset;
        PackedWidth = width;
    }

    public BfInterval Interval
    {
        [MethodImpl(Inline)]
        get => new(FieldOffset,PackedWidth);
    }

    /// <summary>
    /// The position of the last bit in the field
    /// </summary>
    public uint LastBit
    {
        [MethodImpl(Inline)]
        get => FieldOffset + PackedWidth;
    }
}
