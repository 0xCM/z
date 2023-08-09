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

    public ref readonly FilePath Source
    {
        [MethodImpl(Inline)]
        get => ref DataFile.Source;
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
        get => DataFile.Source;
    }

    public uint Count
    {
        [MethodImpl(Inline)]
        get => Blocks.Count;
    }

    public int CompareTo(XedDisasmDetail src)
        => Path.CompareTo(src.Path);

    public static XedDisasmDetail Empty => new (XedDisasmFile.Empty, sys.empty<XedDisasmDetailBlock>());
}

