//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public class CilMember
{
    /// <summary>
    /// The encoded msil
    /// </summary>
    public readonly CilCode Block;

    /// <summary>
    /// The method display signature
    /// </summary>
    public MethodDisplaySig DisplaySig;

    /// <summary>
    /// The operation identity
    /// </summary>
    public readonly OpUri Uri;

    /// <summary>
    /// The code's base address
    /// </summary>
    public readonly MemoryAddress BaseAddress;

    [MethodImpl(Inline)]
    public CilMember(EcmaToken token, MemoryAddress @base, MethodDisplaySig dispSig, OpUri uri, EcmaSig cliSig, BinaryCode data, MethodImplAttributes impl)
    {
        Block = CilCode.define(token,cliSig, data, impl);
        BaseAddress = @base;
        Uri = Require.notnull(uri);
        DisplaySig = dispSig;
    }

    /// <summary>
    /// The method implementation attributes
    /// </summary>
    public ref readonly MethodImplAttributes Attributes
    {
        [MethodImpl(Inline)]
        get => ref Block.Attributes;
    }

    /// <summary>
    /// The encoded cil
    /// </summary>
    public ref readonly BinaryCode CliCode
    {
        [MethodImpl(Inline)]
        get => ref Block.Encoded;
    }

    /// <summary>
    /// The Cli signature
    /// </summary>
    public ref readonly EcmaSig CliSig
    {
        [MethodImpl(Inline)]
        get => ref Block.Sig;
    }

    /// <summary>
    /// The assembly-relative method identifier
    /// </summary>
    public ref readonly EcmaToken Token
    {
        [MethodImpl(Inline)]
        get => ref Block.Token;
    }

    public static CilMember Empty
        => new CilMember(EcmaToken.Empty, MemoryAddress.Zero, MethodDisplaySig.Empty, OpUri.Empty, EcmaSig.Empty, BinaryCode.Empty, 0);
}
