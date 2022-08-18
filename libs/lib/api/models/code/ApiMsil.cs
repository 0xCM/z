//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ApiMsil
    {
        /// <summary>
        /// The encoded msil
        /// </summary>
        public readonly MsilCode Source;

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
        public ApiMsil(CliToken token, MemoryAddress @base, MethodDisplaySig dispSig, OpUri uri, CliSig cliSig, BinaryCode data, MethodImplAttributes impl)
        {
            Source = MsilCode.define(token,cliSig, data, impl);
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
            get => ref Source.Attributes;
        }

        /// <summary>
        /// The encoded cil
        /// </summary>
        public ref readonly BinaryCode CliCode
        {
            [MethodImpl(Inline)]
            get => ref Source.Encoded;
        }

        /// <summary>
        /// The Cli signature
        /// </summary>
        public ref readonly CliSig CliSig
        {
            [MethodImpl(Inline)]
            get => ref Source.Sig;
        }

        /// <summary>
        /// The assembly-relative method identifier
        /// </summary>
        public ref readonly CliToken Token
        {
            [MethodImpl(Inline)]
            get => ref Source.Token;
        }

        public static ApiMsil Empty
            => new ApiMsil(CliToken.Empty, MemoryAddress.Zero, MethodDisplaySig.Empty, OpUri.Empty, CliSig.Empty, BinaryCode.Empty, 0);
    }
}