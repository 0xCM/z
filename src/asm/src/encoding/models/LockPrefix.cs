//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;


/// <summary>
/// Defines the lock prefix code
/// </summary>
public enum LockPrefixCode : byte
{
    None = 0,

    [Symbol("F0", "Lock Prefix")]
    LOCK = 0xF0,
}

public readonly record struct LockPrefix : IAsmPrefix<LockPrefixCode>, IAsmByte<LockPrefix>
{
    public readonly LockPrefixCode _Code;

    [MethodImpl(Inline)]
    public LockPrefix(LockPrefixCode src)
    {
        _Code = src;
    }

    [MethodImpl(Inline)]
    public byte Value()
        => (byte)_Code;

    public byte Encoded
    {
        [MethodImpl(Inline)]
        get => (byte)_Code;
    }

    [MethodImpl(Inline)]
    public LockPrefixCode Code()
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
        => AsmBytes.format(this);

    [MethodImpl(Inline)]
    public static implicit operator LockPrefix(LockPrefixCode src)
        => new (src);

    [MethodImpl(Inline)]
    public static implicit operator byte(LockPrefix src)
        => (byte)src._Code;
}
