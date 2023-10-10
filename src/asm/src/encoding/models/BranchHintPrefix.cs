//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static AsmPrefixTokens;

public readonly record struct BranchHintPrefix : IAsmPrefix<BranchHintPrefix>
{
    readonly byte _Code;

    [MethodImpl(Inline)]
    public BranchHintPrefix(BranchHintCode src)
    {
        _Code = (byte)src;
    }

    public byte Encoded
    {
        [MethodImpl(Inline)]
        get => (byte)_Code;
    }

    [MethodImpl(Inline)]
    public BranchHintCode Code()
        => (BranchHintCode)_Code;

    public bool IsEmpty
    {
        [MethodImpl(Inline)]
        get => _Code == 0;
    }

    public bool IsNonEmpty
    {
        [MethodImpl(Inline)]
        get => _Code != 0;
    }

    public override string ToString()
        => Format();

    public string Format()
        => Encoded.FormatHex();

    [MethodImpl(Inline)]
    public static implicit operator BranchHintPrefix(BranchHintCode src)
        => new (src);

    [MethodImpl(Inline)]
    public static implicit operator BranchHintCode(BranchHintPrefix src)
        => src.Code();

    [MethodImpl(Inline)]
    public static implicit operator byte(BranchHintPrefix src)
        => (byte)src._Code;
}
