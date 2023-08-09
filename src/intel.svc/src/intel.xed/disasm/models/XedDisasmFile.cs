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
    public readonly FilePath Source;

    public readonly Index<XedDisasmBlock> Blocks;

    [MethodImpl(Inline)]
    public XedDisasmFile(FilePath src, XedDisasmBlock[] blocks)
    {
        Source = src;
        Blocks = blocks;
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
        => Source.CompareTo(src.Source);

    public static XedDisasmFile Empty => new (FilePath.Empty, sys.empty<XedDisasmBlock>());
}

