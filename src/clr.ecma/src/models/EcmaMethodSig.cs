//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public readonly record struct EcmaMethodSig
{
    readonly MethodSignature<string> _Source;

    readonly @string Formatted;

    public EcmaMethodSig(MethodSignature<string> src)
    {
        _Source = src;
        Formatted = MetadataVisualizer.format(_Source);
    }

    public MethodSignature<string> Source
        => _Source;
    
    public Hash32 Hash
    {
        get => Formatted.Hash;
    }
    
    public string Format()
        => Formatted;

    public bool Equals(EcmaMethodSig src)
        => Formatted == src.Formatted;

    public override int GetHashCode()
        => Hash;

    public override string ToString()
        => Format();

    public static implicit operator EcmaMethodSig(MethodSignature<string> src)
        => new(src);
}
