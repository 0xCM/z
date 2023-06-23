//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public class XedDisasmDetail : IComparable<XedDisasmDetail>
{
    public readonly XedDisasmFile DataFile;

    public readonly Index<XedDisasmDetailBlock> Blocks;

    [MethodImpl(Inline)]
    public XedDisasmDetail(in XedDisasmFile file, XedDisasmDetailBlock[] data)
    {
        DataFile = file;
        Blocks = data;
    }

    public ref readonly FileRef Origin
    {
        [MethodImpl(Inline)]
        get => ref DataFile.Origin;
    }

    public ref readonly FileRef Source
    {
        [MethodImpl(Inline)]
        get => ref DataFile.Source;
    }

    public uint Seq
    {
        [MethodImpl(Inline)]
        get => DataFile.Source.Seq;
    }

    public ref XedDisasmDetailBlock this[int i]
    {
        [MethodImpl(Inline)]
        get => ref Blocks[i];
    }

    public ref XedDisasmDetailBlock this[uint i]
    {
        [MethodImpl(Inline)]
        get => ref Blocks[i];
    }

    public FilePath Path
    {
        [MethodImpl(Inline)]
        get => DataFile.Source.Path;
    }

    public uint Count
    {
        [MethodImpl(Inline)]
        get => Blocks.Count;
    }

    public int CompareTo(XedDisasmDetail src)
        => Seq.CompareTo(src.Seq);

    public static XedDisasmDetail Empty => new XedDisasmDetail(XedDisasmFile.Empty, sys.empty<XedDisasmDetailBlock>());
}

