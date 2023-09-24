//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static AsmPrefixTokens;

public readonly record struct BndPrefix : IAsmPrefix<BndPrefixCode>
{
    readonly BndPrefixCode _Code;

    [MethodImpl(Inline)]
    public BndPrefix(BndPrefixCode src)
    {
        _Code = src;
    }

    public byte Encoded
    {
        [MethodImpl(Inline)]
        get => (byte)_Code;
    }

    [MethodImpl(Inline)]
    public BndPrefixCode Code()
        => _Code;

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
    public static implicit operator BndPrefix(BndPrefixCode src)
        => new (src);

    [MethodImpl(Inline)]
    public static implicit operator byte(BndPrefix src)
        => (byte)src._Code;
}
