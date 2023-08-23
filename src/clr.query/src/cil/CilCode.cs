//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[StructLayout(StructLayout,Pack=1)]
public readonly record struct CilCode
{
    [MethodImpl(Inline), Op]
    public static CilCode define(EcmaToken token, EcmaSig sig, BinaryCode encoded, MethodImplAttributes attribs)
        => new (token, sig, encoded, attribs);

    /// <summary>
    /// The source method token
    /// </summary>
    public readonly EcmaToken Token;

    /// <summary>
    /// The source method signature
    /// </summary>
    public readonly EcmaSig Sig;

    /// <summary>
    /// The encoded cil
    /// </summary>
    public readonly BinaryCode Encoded;

    /// <summary>
    /// Applied attributes
    /// </summary>
    public readonly MethodImplAttributes Attributes;

    [MethodImpl(Inline)]
    public CilCode(EcmaToken id, EcmaSig sig, BinaryCode encoded, MethodImplAttributes attributes)
    {
        Token = id;
        Sig = sig;
        Encoded = encoded;
        Attributes = attributes;
    }

    public ByteSize Size
    {
        [MethodImpl(Inline)]
        get => Encoded.Size;
    }

    public bool IsEmpty
    {
        [MethodImpl(Inline)]
        get => Token.IsEmpty && Sig.IsEmpty && Encoded.IsEmpty;
    }

    public bool IsNonEmpty
    {
        [MethodImpl(Inline)]
        get => Token.IsNonEmpty || Sig.IsNonEmpty || Encoded.IsNonEmpty;
    }

    public bool Complete
    {
        [MethodImpl(Inline)]
        get => Token.IsNonEmpty && Sig.IsNonEmpty && Encoded.IsNonEmpty;
    }

    public ReadOnlySpan<byte> View
    {
        [MethodImpl(Inline)]
        get => Encoded.View;
    }

    public static CilCode Empty
    {
        [MethodImpl(Inline)]
        get => new CilCode(EcmaToken.Empty, EcmaSig.Empty, BinaryCode.Empty, MethodImplAttributes.Managed);
    }
}
