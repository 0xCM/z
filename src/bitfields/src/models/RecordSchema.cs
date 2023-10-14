//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public readonly struct BitRecordSchema
{
    public readonly asci16 Scope;

    /// <summary>
    /// Specifies record type name
    /// </summary>
    public readonly asci16 EntityName;

    readonly Index<BitRecordField> _Fields;

    [MethodImpl(Inline)]
    public BitRecordSchema(asci16 scope, asci16 name, BitRecordField[] fields)
    {
        Scope = scope;
        EntityName = name;
        _Fields = fields;
    }

    public Span<BitRecordField> Fields
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
