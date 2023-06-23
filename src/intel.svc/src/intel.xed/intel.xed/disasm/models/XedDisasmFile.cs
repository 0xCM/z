//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedRules;
using static XedDisasm;

public readonly record struct XedDisasmFile : IComparable<XedDisasmFile>
{
    public readonly FileRef Origin;

    public readonly FileRef Source;

    public readonly Index<XedDisasmBlock> Blocks;

    [MethodImpl(Inline)]
    public XedDisasmFile(in FileRef origin, in FileRef src, XedDisasmBlock[] blocks)
    {
        Origin = origin;
        Source = src;
        Blocks = blocks;
    }

    public uint Seq
    {
        [MethodImpl(Inline)]
        get => Source.Seq;
    }

    public Hex32 DocId
    {
        [MethodImpl(Inline)]
        get => Source.DocId;
    }

    public uint LineCount
    {
        [MethodImpl(Inline)]
        get => Blocks.Count;
    }

    public ref readonly XedDisasmBlock this[int i]
    {
        [MethodImpl(Inline)]
        get => ref Blocks[i];
    }

    public ref readonly XedDisasmBlock this[uint i]
    {
        [MethodImpl(Inline)]
        get => ref Blocks[i];
    }

    public OperandStates ParseStates()
        => states(this);

    public int CompareTo(XedDisasmFile src)
        => Seq.CompareTo(src.Seq);

    public static XedDisasmFile Empty => new XedDisasmFile(FileRef.Empty, FileRef.Empty, sys.empty<XedDisasmBlock>());
}

