//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public readonly struct BitRecordDef
{
    /// <summary>
    /// Specifies record type name
    /// </summary>
    public readonly asci16 BitfieldName;

    readonly Index<BitRecordField> _Fields;

    [MethodImpl(Inline)]
    public BitRecordDef(asci16 name, BitRecordField[] fields)
    {
        BitfieldName = name;
        _Fields = fields;
    }

    public Span<BitRecordField> Edit
    {
        [MethodImpl(Inline)]
        get => _Fields.Edit;
    }

    public uint FieldCount
    {
        [MethodImpl(Inline)]
        get => _Fields.Count;
    }

    public ref BitRecordField this[uint i]
    {
        [MethodImpl(Inline)]
        get => ref _Fields[i];
    }

    public ref BitRecordField this[int i]
    {
        [MethodImpl(Inline)]
        get => ref _Fields[i];
    }
}
