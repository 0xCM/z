//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(StructLayout,Pack=1)]
    public readonly struct MsilCode
    {
        [MethodImpl(Inline), Op]
        public static MsilCode define(CliToken token, CliSig sig, BinaryCode encoded, MethodImplAttributes attribs)
            => new MsilCode(token, sig, encoded, attribs);

        /// <summary>
        /// The source method token
        /// </summary>
        public readonly CliToken Token;

        /// <summary>
        /// The source method signature
        /// </summary>
        public readonly CliSig Sig;

        /// <summary>
        /// The encoded cil
        /// </summary>
        public readonly BinaryCode Encoded;

        /// <summary>
        /// Applied attributes
        /// </summary>
        public readonly MethodImplAttributes Attributes;

        [MethodImpl(Inline)]
        public MsilCode(CliToken id, CliSig sig, BinaryCode encoded, MethodImplAttributes attributes)
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

        public static MsilCode Empty
        {
            [MethodImpl(Inline)]
            get => new MsilCode(CliToken.Empty, CliSig.Empty, BinaryCode.Empty, MethodImplAttributes.Managed);
        }
    }
}